using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MazeControl
{
    public static class Helper
    {
        public static bool GetBoolValue(string Value)
        {
            bool RetVal = false;
            switch (Value.ToLower())
            {
                case "true":
                case "yes":
                case "1":
                    RetVal = true;
                    break;
            }

            return RetVal;
        }

        public static int GetIntValue(string Value, int DefaultValue = 0)
        {
            int RetVal = DefaultValue;
            int.TryParse(Value, out RetVal);
            return RetVal;
        }

        public static string Label(this ScriptMachine.StatusType Type)
        {
            string RetVal = System.Text.RegularExpressions.Regex.Replace(Type.ToString(), "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
            return RetVal;
        }
        

        public static T AttributeValue<T>(this XElement Node, string Name, T DefaultValue = default(T))
        {
            T RetVal = DefaultValue;
            string StrValue = Node.Attribute(Name)?.Value;
            if (StrValue == null)
            {
                StrValue = "";
            }
            switch (DefaultValue)
            {
                case bool val when StrValue != null:
                    if (StrValue.ToLower().StartsWith("y"))
                    {
                        StrValue = "true";
                    }
                    else if (StrValue.ToLower().StartsWith("n"))
                    {
                        StrValue = "false";
                    }
                    RetVal = (T)Convert.ChangeType(GetBoolValue(StrValue), typeof(T));
                    break;

                case int val when StrValue != null:
                    int IntVal = Convert.ToInt32(DefaultValue);
                    int.TryParse(StrValue, out IntVal);
                    RetVal = (T)Convert.ChangeType(IntVal, typeof(T));
                    break;

                case float val when StrValue != null:
                    float Val = Convert.ToInt32(DefaultValue);
                    float.TryParse(StrValue, out Val);
                    RetVal = (T)Convert.ChangeType(Val, typeof(T));
                    break;

                default:
                    RetVal = (T)Convert.ChangeType(StrValue, typeof(T));
                    break;
            }

            return RetVal;
        }

        public static bool Like(this string Str, string Pattern)
        {
            bool RetVal = false;
            string RegStr = "^" + Regex.Escape(Pattern).Replace("\\?", ".").Replace("\\*", ".*") + "$";
            RetVal = Regex.IsMatch(Str, RegStr);
            return RetVal;
        }
    }
}
