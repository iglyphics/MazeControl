using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;

namespace MazeControl
{
    public class Script
    {
        public List<ScriptRule> Rules = new List<ScriptRule>();
        public int CurrentRuleIndex = -1;
        public event EventHandler<ScriptRule> ScriptRuleTimeout;
        public event EventHandler ScriptComplete;
        private Timer RuleTimer = null;

        public Script(string Text)
        {
            LoadXml(Text);
        }

        public ScriptRule CurrentRule
        {
            get
            {
                ScriptRule RetVal = null;
                if (CurrentRuleIndex >= 0 && CurrentRuleIndex < Rules.Count)
                {
                    RetVal = Rules[CurrentRuleIndex];
                }
                return RetVal;
            }
        }
        public void Load(string Script)
        {
            Rules.Clear();
            List<string> Lines = Script.Split('\n').ToList();
            List<string> Parts = new List<string>();
            foreach (string Item in Lines)
            {
                string Line = Item.Trim();
                if (Line != "")
                {
                    Parts = Line.Split(',').ToList();
                    ScriptRule s = new ScriptRule();
                    s.Sensor = Parts[0];
                    for (int i = 1; i < Parts.Count; i++)
                    {
                        var CmdParts = Parts[i].Split(':');
                        var DoorCmd = new ScriptDoorCommand();

                        DoorCmd.Door = CmdParts[0];
                        if (CmdParts[1].ToLower() == "o")
                        {
                            DoorCmd.Action = ScriptDoorCommand.DoorAction.Open;
                        }
                        else
                        {
                            DoorCmd.Action = ScriptDoorCommand.DoorAction.Close;

                        }
                        if (CmdParts.Length > 2)
                        {
                            int.TryParse(CmdParts[2], out DoorCmd.Delay);
                        }
                        s.DoorCommands.Add(DoorCmd);
                    }
                    Rules.Add(s);
                }
            }
        }

        public void LoadXml(string Xml)
        {
            Rules.Clear();
            XDocument Doc = XDocument.Parse(Xml);
            var RuleDefs = Doc.Elements("script").Elements<XElement>("rules").Elements<XElement>();
            foreach (XElement RuleDef in RuleDefs)
            {
                var Rule = new ScriptRule(RuleDef);
                Rules.Add(Rule);
            }


        }

        public ScriptRule StartNextRule()
        {
            ScriptRule RetVal = null;
            if (++CurrentRuleIndex < Rules.Count)
            {
                
                RetVal = Rules[CurrentRuleIndex];
                if (RetVal.Timeout > 0)
                {
                    RuleTimer = new Timer(RetVal.Timeout);
                    RuleTimer.Elapsed += RuleTimer_Elapsed;
                    RuleTimer.Start();
                }
            }
            else
            {
                ScriptComplete?.Invoke(this, new EventArgs());
            }
            return RetVal;
        }

        private void RuleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StopRuleTimer();
            ScriptRuleTimeout?.Invoke(this, CurrentRule);
        }

        private void StopRuleTimer()
        {
            if (RuleTimer != null)
            {
                RuleTimer.Stop();
            }
            RuleTimer = null;
        }

        public void Start()
        {
            StopRuleTimer();
            CurrentRuleIndex = -1;
            StartNextRule();
        }

        public void RuleComplete(ScriptRule Rule)
        {
            StopRuleTimer();
        }
    }
}
