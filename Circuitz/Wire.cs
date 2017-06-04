namespace Circuitz
{
    using Nodes;
    public class Wire
    {
        public Board Board { get; set; }

        public Node Input { get; }
        public Node Output { get; }

        public int InputIndex { get; }
        public int OutputIndex { get; }

        public bool Value => Input.Outputs[InputIndex];

        public bool ConnectionValid => Input != null && Output != null && Input.HasOutput(InputIndex) &&
                                       Output.HasInput(OutputIndex) && Input.Board != null && Output.Board != null;

        public bool RequiresUpdate => Output.Inputs[OutputIndex] != Value;

        public Wire(Node input, Node output, int inputIndex, int outputIndex)
        {
            Input = input;
            Output = output;
            InputIndex = inputIndex;
            OutputIndex = outputIndex;
        }

        public void Update()
        {
            if (ConnectionValid)
            {
                Output.Inputs[OutputIndex] = Value;
                Output.RequiresUpdate = true;
                Output.Update();
            }
        }
    }
}
