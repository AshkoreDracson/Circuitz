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
            this.boardControl = new Circuitz.BoardControl();
            this.boardMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridsnapCB = new System.Windows.Forms.CheckBox();
            this.gateList = new System.Windows.Forms.ListBox();
            this.gateProperties = new System.Windows.Forms.PropertyGrid();
            this.stepBTN = new System.Windows.Forms.Button();
            this.autoStepBTN = new System.Windows.Forms.Button();
            this.timeField = new System.Windows.Forms.NumericUpDown();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeField)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
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
            this.boardControl.LinkedListBox = this.gateList;
            this.boardControl.LinkedPropertyGrid = this.gateProperties;
            this.boardControl.Location = new System.Drawing.Point(263, 27);
            this.boardControl.Margin = new System.Windows.Forms.Padding(0);
            this.boardControl.Name = "boardControl";
            this.boardControl.OffColor = System.Drawing.Color.IndianRed;
            this.boardControl.OnColor = System.Drawing.Color.ForestGreen;
            this.boardControl.SelectedNodeColor = System.Drawing.Color.LightBlue;
            this.boardControl.Size = new System.Drawing.Size(512, 487);
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
            this.gridsnapCB.Location = new System.Drawing.Point(12, 84);
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
            this.gateList.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gateList.FormattingEnabled = true;
            this.gateList.IntegralHeight = false;
            this.gateList.ItemHeight = 18;
            this.gateList.Items.AddRange(new object[] {
            "Constant",
            "AND Gate",
            "OR Gate",
            "XOR Gate",
            "Buffer Gate",
            "NOT Gate",
            "NAND Gate",
            "NOR Gate",
            "XNOR Gate",
            "Adder",
            "SR Latch",
            "Timer"});
            this.gateList.Location = new System.Drawing.Point(12, 107);
            this.gateList.Name = "gateList";
            this.gateList.Size = new System.Drawing.Size(243, 202);
            this.gateList.TabIndex = 8;
            // 
            // gateProperties
            // 
            this.gateProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gateProperties.Location = new System.Drawing.Point(12, 315);
            this.gateProperties.Name = "gateProperties";
            this.gateProperties.Size = new System.Drawing.Size(243, 199);
            this.gateProperties.TabIndex = 5;
            this.gateProperties.ToolbarVisible = false;
            // 
            // stepBTN
            // 
            this.stepBTN.Location = new System.Drawing.Point(12, 27);
            this.stepBTN.Name = "stepBTN";
            this.stepBTN.Size = new System.Drawing.Size(243, 23);
            this.stepBTN.TabIndex = 1;
            this.stepBTN.Text = "Step";
            this.stepBTN.UseVisualStyleBackColor = true;
            this.stepBTN.Click += new System.EventHandler(this.stepBTN_Click);
            // 
            // autoStepBTN
            // 
            this.autoStepBTN.Location = new System.Drawing.Point(12, 56);
            this.autoStepBTN.Name = "autoStepBTN";
            this.autoStepBTN.Size = new System.Drawing.Size(158, 22);
            this.autoStepBTN.TabIndex = 2;
            this.autoStepBTN.Text = "Auto-step";
            this.autoStepBTN.UseVisualStyleBackColor = true;
            this.autoStepBTN.Click += new System.EventHandler(this.autoStepBTN_Click);
            // 
            // timeField
            // 
            this.timeField.Location = new System.Drawing.Point(176, 57);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 517);
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
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 9;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 539);
            this.Controls.Add(this.gateList);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.gridsnapCB);
            this.Controls.Add(this.gateProperties);
            this.Controls.Add(this.timeField);
            this.Controls.Add(this.autoStepBTN);
            this.Controls.Add(this.stepBTN);
            this.Controls.Add(this.boardControl);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Circuitz";
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.boardMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeField)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BoardControl boardControl;
        private System.Windows.Forms.Button stepBTN;
        private System.Windows.Forms.Button autoStepBTN;
        private System.Windows.Forms.NumericUpDown timeField;
        private System.Windows.Forms.PropertyGrid gateProperties;
        private System.Windows.Forms.ContextMenuStrip boardMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteNodeToolStripMenuItem;
        private System.Windows.Forms.CheckBox gridsnapCB;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ListBox gateList;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

