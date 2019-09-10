using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeControl.Messages
{
    
    public class StateEvent
    {
        public enum EventType
        {
            Begin,
            End
        }
        ScriptState State { get; set; }
        EventType Type = EventType.Begin;
        public StateEvent(ScriptState State, EventType Type)
        {
            this.State = State;
            this.Type = Type;
        }
    }
}
