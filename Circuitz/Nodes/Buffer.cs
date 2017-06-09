using Circuitz.Properties;
using System.Drawing;

namespace Circuitz.Nodes
{
    public class Buffer : Node
    {
        public override string Name => "Buffer";
        public override NodeIdentifier Type => NodeIdentifier.Buffer;

        public override Image Icon => Resources.Node_Buffer;

        public Buffer() : base(1, 1) { }

        public override void Update()
        {
            base.Update();
            Outputs[0] = Inputs[0];
        }
    }
}
