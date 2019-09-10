using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace MazeControl
{
    public class MazeController
    {
        private enum ByteState
        {
            Start,
            Sensor,
            Door
        }
        private ByteState ProcessingState = ByteState.Start;
        private SerialPort _Port = null;
        private string _ComPort = "";
        Queue<string> InputQueue = new Queue<string>();
        public event EventHandler<string> LogMessage;
        public event EventHandler<string> DataReceived;
        public event EventHandler<string> SensorTriggered;
        private StringBuilder SensorMessage = new StringBuilder();
        private StringBuilder ByteBuffer = new StringBuilder();
        CancellationToken CancelToken;
        private bool PumpRunning = false;

        public List<string> Sensors = new List<string>()
        {
            "MS0",
            "MS1",
            "MS2",
            "MA1",
            "MA2",
            "MP1",
            "MP2",
            "MF1",
            "MF2"
        };

        public List<string> Doors = new List<string>()
        {
            "DS0",
            "DS1",
            "DS2",
            "DA1",
            "DA2",
            "DP1",
            "DP2"
        };

        // 0x01, 0x06, 0x00, 0x02, 0x02, 0x76, 0xA8, 0x8C
        // 0x01, 0x06, 0x00, 0x00, 0x00, 0x01, 0x48, 0x0A
        private byte[] PumpSpeedCommand = { 0x01, 0x06, 0x00, 0x02, 0x02, 0x76, 0xA8, 0x8C };
        private byte[] PumpStartCommand = { 0x01, 0x06, 0x00, 0x00, 0x00, 0x01, 0x48, 0x0A };
        private byte[] PumpStopCommand = { 0x01, 0x06, 0x00, 0x00, 0x00, 0x00, 0x89, 0xCA };        private PumpCommand[,] PumpCommands =            {            {
                new PumpCommand() { Data = new byte[] {0x01, 0x06, 0x00, 0x02, 0x02, 0x76, 0xA8, 0x8C } },
                new PumpCommand() { Data = new byte[]{ 0x01, 0x06, 0x00, 0x00, 0x00, 0x01, 0x48, 0x0A } },
                new PumpCommand() { Data = new byte[] { 0x01, 0x06, 0x00, 0x00, 0x00, 0x00, 0x89, 0xCA } }
            },            {
                new PumpCommand() { Data = new byte[]{ 0x02, 0x06, 0x00, 0x02, 0x02, 0x76, 0xA8, 0xbf } },
                new PumpCommand() { Data = new byte[]{ 0x02, 0x06, 0x00, 0x00, 0x00, 0x01, 0x48, 0x39 } },
                new PumpCommand() { Data = new byte[]{ 0x02, 0x06, 0x00, 0x00, 0x00, 0x00, 0x89, 0xf9 } }
            }            };
        private Dictionary<string, byte> PumpId = new Dictionary<string, byte>(StringComparer.CurrentCultureIgnoreCase)
        {
            {"ft1", 0x00 },
            {"ft2", 0x01 }
        };

        public MazeController(string ComPort, CancellationToken Token)
        {
            _ComPort = ComPort;
            _Port = new SerialPort(ComPort, 9600);
            CancelToken = Token;
        }

        public string ComPort
        {
            get
            {
                return _ComPort;
            }
            set
            {
                if (_Port != null && _Port.IsOpen)
                {
                    _Port.Close();
                }
                _ComPort = value;
                _Port = new SerialPort(ComPort, 9600);
            }
        }

        public void OpenDoor(string Door)
        {
            SendCommand($"{Door}0");
        }

        public void CloseDoor(string Door)
        {
            SendCommand($"{Door}1");
        }

        public async void DispenseReward(string Tray, int Count)
        {
            while (Count-- > 0)
            {
                await RunPump(Tray);
                //SendCommand(Tray);
                //if (Count > 0)
                //{
                //    try
                //    {
                //        await Task.Delay(1000, CancelToken);
                //    }
                //    catch(Exception ex)
                //    {
                //        Count = 0;
                //    }
                //}
            }
        }

        public void Open()
        {
            if (!_Port.IsOpen)
            {
                _Port.Open();
            }
            _Port.DataReceived += _Port_DataReceived;
        }

        private void _Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string Data = _Port.ReadExisting();
            ProcessData(Data);
            //InputQueue.Enqueue(Data);
            //DataReceived?.Invoke(this, Data);
            //if (InputQueue.Count > 1000)
            //{
            //    InputQueue.Clear();
            //}
        }

        private void ProcessData(string Data)
        {
            Data = Data.ToLower();
            char Ch;
            int Index = 0;
            int IndexInc = 1;
            while (Index < Data.Length)
            {
                Ch = Data[Index];
                IndexInc = 1;
                switch (ProcessingState)
                {
                    case ByteState.Start:
                        ByteBuffer.Clear();
                        if (Ch == 'm')
                        {
                            ProcessingState = ByteState.Sensor;
                            ByteBuffer.Append(Ch);
                        }
                        break;

                    case ByteState.Sensor:
                        if (Ch == 'm')
                        {
                            ProcessingState = ByteState.Start;
                            IndexInc = 0;
                        }
                        else
                        {
                            ByteBuffer.Append(Ch);
                            string Msg = ByteBuffer.ToString().ToUpper();
                            if (Sensors.Contains(Msg))
                            {
                                SensorTriggered?.Invoke(this, Msg);
                                LogMessage?.Invoke(this, $"Recvd: {Msg}");
                                ProcessingState = ByteState.Start;
                            }
                        }
                        break;
                }
                Index += IndexInc;
            }
        }

        private void SendCommand(string Command)
        {
            try
            {
                if (_Port != null && _Port.IsOpen)
                {
                    _Port.Write(Command);
                }
                LogMessage?.Invoke(this, $"Sent: {Command}");
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public void Close()
        {
            _Port.Close();
        }
        
        public void Reset()
        {
            foreach(string Door in Doors)
            {
                CloseDoor(Door);
            }
        }

        public void RunRule(ScriptRule Rule)
        {

        }

        public async Task RunPump(string Pump)
        {
            if (!PumpRunning)
            {
                PumpRunning = true;
                try
                {
                    int i = PumpId[Pump];

                    await Task.Delay(500);

                    await SendPumpCommand(PumpCommands[i,0].Data);
                    await Task.Delay(1000);
                    await SendPumpCommand(PumpCommands[i, 1].Data);
                    await Task.Delay(1500);
                    await SendPumpCommand(PumpCommands[i, 2].Data);
                }
                catch(Exception ex)
                {

                }
                PumpRunning = false;
            }
        }

        public Task SendPumpCommand(byte[] Data)
        {
            if (_Port != null && _Port.IsOpen)
            {
                _Port.Write(Data, 0, Data.Length);
            }
            Log(Data);
            return Task.CompletedTask;
        }
        public Task SendPumpCommand(string Pump, byte[] Data)
        {
            int i = PumpId[Pump];

            Data[0] = PumpId[Pump];
            if (_Port != null && _Port.IsOpen)
            {
                _Port.Write(Data, 0, Data.Length);
            }
            Log(Data);
            return Task.CompletedTask;
        }

        private void Log(byte[] Data)
        {
            List<string> Items = new List<string>();
            foreach(byte b in Data)
            {
                Items.Add(b.ToString("X2"));
            }
            LogMessage?.Invoke(this, $"Sent: {string.Join(", ", Items)}");
        }
    }
}
