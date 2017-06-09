using Circuitz.Properties;
using System.Drawing;

namespace Circuitz.Nodes
{
    public class Not : Node
    {
        public override string Name => "NOT";
        public override NodeIdentifier Type => NodeIdentifier.Not;

        public override Image Icon => Resources.Node_NOT;

        public Not() : base(1, 1)
        {
            Update();
        }

        public override void Update()
        {
            base.Update();
            Outputs[0] = !Inputs[0];
        }
    }
}
