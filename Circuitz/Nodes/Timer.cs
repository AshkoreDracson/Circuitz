using Circuitz.Properties;
using System.Drawing;

namespace Circuitz.Nodes
{
    public class Timer : Node
    {
        public override string Name => "Timer";

        private uint _interval = 1;
        public uint Interval
        {
            get => _interval;
            set
            {
                _interval = value;
                intervalLeft = _interval;
            }
        }

        private bool _value;
        public bool Value
        {
            get => _value;
            set
            {
                _value = value;
                Outputs[0] = _value;
            }
        }

        public override Image Icon => Resources.Node_Timer;

        private uint intervalLeft;

        public Timer() : base(0, 1)
        {
            intervalLeft = Interval + 1;
        }

        public override void Update()
        {
            base.Update();
            intervalLeft--;

            if (intervalLeft <= 0)
            {
                Value = true;
                intervalLeft = Interval + 1;
            }
            else
            {
                Value = false;
            }
        }
    }
}