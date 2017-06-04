namespace Circuitz
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Basic Gates", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Constant");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("AND Gate");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("OR Gate");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("XOR Gate");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("NOT Gate");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Buffer");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Timer");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Adder");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("NAND Gate");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("NOR Gate");
            this.boardControl = new Circuitz.BoardControl();
            this.boardMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridsnapCB = new System.Windows.Forms.CheckBox();
            this.gateList = new System.Windows.Forms.ListView();
            this.gateProperties = new System.Windows.Forms.PropertyGrid();
            this.stepBTN = new System.Windows.Forms.Button();
            this.autoStepBTN = new System.Windows.Forms.Button();
            this.timeField = new System.Windows.Forms.NumericUpDown();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.boardMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeField)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardControl
            // 
            this.boardControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boardControl.BackColor = System.Drawing.Color.White;
            this.boardControl.BigGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.boardControl.ContextMenuStrip = this.boardMenu;
            this.boardControl.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.boardControl.GridSize = 16;
            this.boardControl.LinkedGridSnapCheckBox = this.gridsnapCB;
            this.boardControl.LinkedListView = this.gateList;
            this.boardControl.LinkedPropertyGrid = this.gateProperties;
            this.boardControl.Location = new System.Drawing.Point(263, 12);
            this.boardControl.Margin = new System.Windows.Forms.Padding(0);
            this.boardControl.Name = "boardControl";
            this.boardControl.OffColor = System.Drawing.Color.IndianRed;
            this.boardControl.OnColor = System.Drawing.Color.ForestGreen;
            this.boardControl.SelectedNodeColor = System.Drawing.Color.LightBlue;
            this.boardControl.Size = new System.Drawing.Size(512, 468);
            this.boardControl.TabIndex = 0;
            this.boardControl.ViewPoint = new System.Drawing.Point(0, 0);
            this.boardControl.Paint += new System.Windows.Forms.PaintEventHandler(this.OnBoardControlRepainting);
            // 
            // boardMenu
            // 
            this.boardMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteNodeToolStripMenuItem});
            this.boardMenu.Name = "boardMenu";
            this.boardMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.boardMenu.Size = new System.Drawing.Size(140, 26);
            this.boardMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnBoardMenuOpening);
            // 
            // deleteNodeToolStripMenuItem
            // 
            this.deleteNodeToolStripMenuItem.Name = "deleteNodeToolStripMenuItem";
            this.deleteNodeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.deleteNodeToolStripMenuItem.Text = "Delete Node";
            this.deleteNodeToolStripMenuItem.Click += new System.EventHandler(this.deleteNodeToolStripMenuItem_Click);
            // 
            // gridsnapCB
            // 
            this.gridsnapCB.AutoSize = true;
            this.gridsnapCB.Checked = true;
            this.gridsnapCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridsnapCB.Location = new System.Drawing.Point(12, 67);
            this.gridsnapCB.Name = "gridsnapCB";
            this.gridsnapCB.Size = new System.Drawing.Size(89, 17);
            this.gridsnapCB.TabIndex = 6;
            this.gridsnapCB.Text = "Snap to grid?";
            this.gridsnapCB.UseVisualStyleBackColor = true;
            // 
            // gateList
            // 
            this.gateList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            listViewGroup1.Header = "Basic Gates";
            listViewGroup1.Name = "basicGroup";
            this.gateList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.gateList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewItem9.Group = listViewGroup1;
            listViewItem10.Group = listViewGroup1;
            this.gateList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.gateList.Location = new System.Drawing.Point(12, 90);
            this.gateList.Name = "gateList";
            this.gateList.Size = new System.Drawing.Size(243, 185);
            this.gateList.TabIndex = 4;
            this.gateList.UseCompatibleStateImageBehavior = false;
            this.gateList.View = System.Windows.Forms.View.SmallIcon;
            // 
            // gateProperties
            // 
            this.gateProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gateProperties.Location = new System.Drawing.Point(12, 281);
            this.gateProperties.Name = "gateProperties";
            this.gateProperties.Size = new System.Drawing.Size(243, 199);
            this.gateProperties.TabIndex = 5;
            this.gateProperties.ToolbarVisible = false;
            // 
            // stepBTN
            // 
            this.stepBTN.Location = new System.Drawing.Point(12, 12);
            this.stepBTN.Name = "stepBTN";
            this.stepBTN.Size = new System.Drawing.Size(243, 23);
            this.stepBTN.TabIndex = 1;
            this.stepBTN.Text = "Step";
            this.stepBTN.UseVisualStyleBackColor = true;
            this.stepBTN.Click += new System.EventHandler(this.stepBTN_Click);
            // 
            // autoStepBTN
            // 
            this.autoStepBTN.Location = new System.Drawing.Point(12, 39);
            this.autoStepBTN.Name = "autoStepBTN";
            this.autoStepBTN.Size = new System.Drawing.Size(158, 22);
            this.autoStepBTN.TabIndex = 2;
            this.autoStepBTN.Text = "Auto-step";
            this.autoStepBTN.UseVisualStyleBackColor = true;
            this.autoStepBTN.Click += new System.EventHandler(this.autoStepBTN_Click);
            // 
            // timeField
            // 
            this.timeField.Location = new System.Drawing.Point(176, 40);
            this.timeField.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.timeField.Name = "timeField";
            this.timeField.Size = new System.Drawing.Size(79, 20);
            this.timeField.TabIndex = 3;
            this.timeField.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.timeField.ValueChanged += new System.EventHandler(this.timeField_ValueChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 483);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(16, 17);
            this.statusLabel.Text = "...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 505);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gridsnapCB);
            this.Controls.Add(this.gateProperties);
            this.Controls.Add(this.gateList);
            this.Controls.Add(this.timeField);
            this.Controls.Add(this.autoStepBTN);
            this.Controls.Add(this.stepBTN);
            this.Controls.Add(this.boardControl);
            this.Name = "MainForm";
            this.Text = "Circuitz";
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.boardMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeField)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BoardControl boardControl;
        private System.Windows.Forms.Button stepBTN;
        private System.Windows.Forms.Button autoStepBTN;
        private System.Windows.Forms.NumericUpDown timeField;
        private System.Windows.Forms.ListView gateList;
        private System.Windows.Forms.PropertyGrid gateProperties;
        private System.Windows.Forms.ContextMenuStrip boardMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteNodeToolStripMenuItem;
        private System.Windows.Forms.CheckBox gridsnapCB;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

