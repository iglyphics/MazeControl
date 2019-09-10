using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maze3D
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Maze3DControl : UserControl
    {
        //private const string MODEL_PATH = @"C:\Users\rhughes\Downloads\Mouse Maze.stl";
        //private const string MODEL_PATH = @".\Mouse Maze.stl";
        //private const string PinkyModel = @"Pinky.stl";

        public static readonly RoutedEvent DoorChangedEvent = EventManager.RegisterRoutedEvent(
        "DoorChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Maze3DControl));

        public static readonly RoutedEvent SensorChangedEvent = EventManager.RegisterRoutedEvent(
        "SensorChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Maze3DControl));

        public static readonly RoutedEvent DialChangedEvent = EventManager.RegisterRoutedEvent(
        "DialChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Maze3DControl));

        public Maze3DControl()
        {
            InitializeComponent();
            //ModelVisual3D device3D = new ModelVisual3D();
            //device3D.Content = Display3d(MODEL_PATH);

            //device3D.SetName("maze");

            //viewPort3d.Children.Add(device3D);
            MazeDoor Door2 = new MazeDoor("DP1", -20, -37, 12);
            MazeDoor Door1 = new MazeDoor("DP2", 20, -37, 12);
            MazeDoor Door3 = new MazeDoor("DS1", -20, 39, 12);
            MazeDoor Door4 = new MazeDoor("DS2", 20, 39, 12);
            MazeDoor Door5 = new MazeDoor("DS0", 0, -15, 12, true);
            MazeDoor Door6 = new MazeDoor("DA1", -88, 20, 12, true);
            MazeDoor Door7 = new MazeDoor("DA2", 88, 20, 12, true);

            MazeSensor Sensor6 = new MazePathSensor("MA1", -88, 5, 5, true);
            MazeSensor Sensor7 = new MazePathSensor("MA2", 88, 5, 5, true);

            MazeSensor Sensor3 = new MazePathSensor("MS1", -40, 39, 5);
            MazeSensor Sensor4 = new MazePathSensor("MS2", 40, 39, 5);
            MazeSensor Sensor5 = new MazePathSensor("MS0", 0, 5, 5, true);

            MazeSensor Sensor2 = new MazePathSensor("MP1", -15, -37, 5);
            MazeSensor Sensor1 = new MazePathSensor("MP2", 15, -37, 5);

            MazeSensor Sensor8 = new MazeLickSensor("MF1", -98, 39, 5, true);
            MazeSensor Sensor9 = new MazeLickSensor("MF2", 98, 39, 5, true);

            MazePumpDial Dial1 = new MazePumpDial("FT1", -108, 36, 0);
            MazePumpDial Dial2 = new MazePumpDial("FT2", 108, 36, 0);

            viewPort3d.Children.Add(Door1);
            viewPort3d.Children.Add(Door2);
            viewPort3d.Children.Add(Door3);
            viewPort3d.Children.Add(Door4);
            viewPort3d.Children.Add(Door5);
            viewPort3d.Children.Add(Door6);
            viewPort3d.Children.Add(Door7);

            viewPort3d.Children.Add(Sensor1);
            viewPort3d.Children.Add(Sensor2);
            viewPort3d.Children.Add(Sensor3);
            viewPort3d.Children.Add(Sensor4);
            viewPort3d.Children.Add(Sensor5);
            viewPort3d.Children.Add(Sensor6);
            viewPort3d.Children.Add(Sensor7);
            viewPort3d.Children.Add(Sensor8);
            viewPort3d.Children.Add(Sensor9);

            viewPort3d.Children.Add(Dial1);
            viewPort3d.Children.Add(Dial2);

            //var Pinky = new MazeMouse(0, -45, 5, 180);
            //viewPort3d.Children.Add(Pinky);

            //Door.IsClosed = false;

            foreach (MazeDoor Door in MazeDoor.Doors.Values)
            {
                Door.DoorChanged += new RoutedEventHandler(Door_DoorChanged);
            }

            foreach (MazeSensor Sensor in MazeSensor.Sensors.Values)
            {
                Sensor.SensorChanged += new RoutedEventHandler(Sensor_SensorChanged);
            }

            foreach (MazePumpDial Dial in MazePumpDial.Dials.Values)
            {
                Dial.DialChanged += new RoutedEventHandler(Dial_DialChanged);
            }
        }

        public void AddModel(string Filename)
        {
            if (File.Exists(Filename))
            {
                ModelVisual3D device3D = new ModelVisual3D();
                device3D.Content = Display3d(Filename);
                viewPort3d.Children.Add(device3D);
            }
        }

        public event RoutedEventHandler DoorChanged
        {
            add { AddHandler(DoorChangedEvent, value); }
            remove { RemoveHandler(DoorChangedEvent, value); }
        }

        public event RoutedEventHandler SensorChanged
        {
            add { AddHandler(SensorChangedEvent, value); }
            remove { RemoveHandler(SensorChangedEvent, value); }
        }

        public event RoutedEventHandler DialChanged
        {
            add { AddHandler(DialChangedEvent, value); }
            remove { RemoveHandler(DialChangedEvent, value); }
        }

        void RaiseDoorChangedEvent(MazeDoor Door)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Maze3DControl.DoorChangedEvent);
            newEventArgs.Source = Door;
            RaiseEvent(newEventArgs);
        }

        void RaiseSensorChangedEvent(MazeSensor Sensor)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Maze3DControl.SensorChangedEvent);
            newEventArgs.Source = Sensor;
            RaiseEvent(newEventArgs);
        }

        void RaiseDialChangedEvent(MazePumpDial Dial)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Maze3DControl.DialChangedEvent);
            newEventArgs.Source = Dial;
            RaiseEvent(newEventArgs);
        }

        private void Door_DoorChanged(object sender, RoutedEventArgs e)
        {
            MazeDoor Door = (MazeDoor)sender;
            RaiseDoorChangedEvent(Door);
        }

        private void Sensor_SensorChanged(object sender, RoutedEventArgs e)
        {
            MazeSensor Sensor = (MazeSensor)sender;
            RaiseSensorChangedEvent(Sensor);
        }

        private void Dial_DialChanged(object sender, RoutedEventArgs e)
        {
            MazePumpDial Dial = (MazePumpDial)sender;
            RaiseDialChangedEvent(Dial);
        }

        private Model3D Display3d(string model)
        {
            Model3D device = null;
            try
            {
                //Adding a gesture here
                viewPort3d.RotateGesture = new MouseGesture(MouseAction.RightClick);

                //Import 3D model file
                ModelImporter import = new ModelImporter();
                System.Windows.Media.Media3D.Material mat = MaterialHelper.CreateMaterial(
            new SolidColorBrush(Color.FromRgb(255, 255, 255)));
                import.DefaultMaterial = mat;
                //Load the 3D model file
                device = import.Load(model);

                ////Stream stream = new MemoryStream(Properties.Resources.Mouse_Maze);
                //Stream stream = new FileStream(model, FileMode.Open);
                //var reader = new HelixToolkit.Wpf.StLReader();
                //reader.DefaultMaterial = mat;
                //Model3DGroup MazeModel = reader.Read(stream);
                ////Properties.Resources.

            }
            catch (Exception e)
            {
                // Handle exception in case can not file 3D model
                MessageBox.Show("Exception Error : " + e.StackTrace);
            }
            return device;
        }

        public void TriggerSensor(string SensorName, bool IsTriggered)
        {
            MazeSensor Sensor;
            if (MazeSensor.Sensors.TryGetValue(SensorName, out Sensor))
            {
                Sensor.IsTriggered = IsTriggered;
            }
        }

        public bool IsSensorTriggered(string SensorName)
        {
            bool RetVal = false;
            MazeSensor Sensor;
            if (MazeSensor.Sensors.TryGetValue(SensorName, out Sensor))
            {
                RetVal = Sensor.IsTriggered;
            }
            return RetVal;
        }

        public void Reset()
        {
            foreach(MazeDoor Door in MazeDoor.Doors.Values)
            {
                Door.Close();
            }

            foreach(MazeSensor Sensor in MazeSensor.Sensors.Values)
            {
                Sensor.IsTriggered = false;
            }

            foreach(MazePumpDial Dial in MazePumpDial.Dials.Values)
            {
                Dial.Angle = 0;
            }
        }

        public void OpenDoor(string Name)
        {
            MazeDoor Door;
            if (MazeDoor.Doors.TryGetValue(Name, out Door))
            {
                Door.Open();
            }
        }

        public void CloseDoor(string Name)
        {
            MazeDoor Door;
            if (MazeDoor.Doors.TryGetValue(Name, out Door))
            {
                Door.Close();
            }
        }

        public void DispenseReward(string Name)
        {
            MazePumpDial Dial;
            if (MazePumpDial.Dials.TryGetValue(Name, out Dial))
            {
                Dial.Dispense();
            }
        }
    }
}
