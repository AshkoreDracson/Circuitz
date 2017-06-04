using Elementary;
using System;
using System.Windows.Forms;

namespace Circuitz
{
    public partial class MainForm : Form
    {
        private readonly Timer timer = new Timer();

        public MainForm()
        {
            InitializeComponent();

            gateProperties.PropertyValueChanged += GateProperties_PropertyValueChanged;
            timer.Tick += Timer_Tick;

            UpdateStatusLabel();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            boardControl.Invalidate();
        }

        private void GateProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            boardControl.Board.UpdateWires();
            boardControl.Invalidate();
        }

        private void stepBTN_Click(object sender, EventArgs e)
        {
            Step();
        }

        private void autoStepBTN_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
        }

        private void timeField_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = (int)timeField.Value.Clamp(1, 10000);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Step();
        }

        private void Step()
        {
            boardControl.Board.Step();
            boardControl.Refresh();
        }

        private void OnBoardMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            deleteNodeToolStripMenuItem.Enabled = boardControl.SelectedNode != null;
        }

        private void deleteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (boardControl.SelectedNode != null)
                boardControl.RemoveNode(boardControl.SelectedNode);
        }

        private void UpdateStatusLabel()
        {
            statusLabel.Text = $"{(timer.Enabled ? "Playing" : "Stopped")} | Step count: {boardControl.Board.StepCount}, Update count: {boardControl.Board.UpdateCount}";
        }

        private void OnBoardControlRepainting(object sender, PaintEventArgs e)
        {
            UpdateStatusLabel();
        }
    }
}
