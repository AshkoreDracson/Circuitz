using Circuitz.Properties;
using System.Drawing;

namespace Circuitz.Nodes
{
    public class Constant : Node
    {
        public override string Name => "Constant";

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

        public override Image Icon => Resources.Node_Constant;

        public Constant() : base(0, 1) { }
    }
}