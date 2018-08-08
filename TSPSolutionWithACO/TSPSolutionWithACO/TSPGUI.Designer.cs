namespace TSPSolutionWithACO
{
    partial class TSPGUI
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tSPSolverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greedyApproachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCOImplementationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.openDataFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelfileName = new System.Windows.Forms.Label();
            this.lblNameLabel = new System.Windows.Forms.Label();
            this.lblTourLenLabel = new System.Windows.Forms.Label();
            this.lblDimensionLabel = new System.Windows.Forms.Label();
            this.lblTimeTakenLabel = new System.Windows.Forms.Label();
            this.lblAlgoNameLabel = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelDimension = new System.Windows.Forms.Label();
            this.labelTourLen = new System.Windows.Forms.Label();
            this.progressBarAlgo = new System.Windows.Forms.ProgressBar();
            this.saveImageFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tSPSolverToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(873, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadDataToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // LoadDataToolStripMenuItem
            // 
            this.LoadDataToolStripMenuItem.Name = "LoadDataToolStripMenuItem";
            this.LoadDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.LoadDataToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.LoadDataToolStripMenuItem.Text = "&Load Data";
            this.LoadDataToolStripMenuItem.Click += new System.EventHandler(this.LoadDataToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "&Save As Image";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tSPSolverToolStripMenuItem
            // 
            this.tSPSolverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.greedyApproachToolStripMenuItem,
            this.aCOImplementationToolStripMenuItem});
            this.tSPSolverToolStripMenuItem.Name = "tSPSolverToolStripMenuItem";
            this.tSPSolverToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.tSPSolverToolStripMenuItem.Text = "TSP Solver";
            // 
            // greedyApproachToolStripMenuItem
            // 
            this.greedyApproachToolStripMenuItem.Name = "greedyApproachToolStripMenuItem";
            this.greedyApproachToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.greedyApproachToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.greedyApproachToolStripMenuItem.Text = "Greedy Approach";
            this.greedyApproachToolStripMenuItem.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // aCOImplementationToolStripMenuItem
            // 
            this.aCOImplementationToolStripMenuItem.Name = "aCOImplementationToolStripMenuItem";
            this.aCOImplementationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.aCOImplementationToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.aCOImplementationToolStripMenuItem.Text = "ACO Implementation";
            this.aCOImplementationToolStripMenuItem.Click += new System.EventHandler(this.aCOImplementationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Location = new System.Drawing.Point(19, 39);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(584, 434);
            this.Canvas.TabIndex = 1;
            this.Canvas.TabStop = false;
            // 
            // openDataFileDialog
            // 
            this.openDataFileDialog.DefaultExt = "*.txt";
            this.openDataFileDialog.Filter = "Text Files (.txt)|*.txt";
            this.openDataFileDialog.Title = "Select a data file to load City Data";
            // 
            // labelfileName
            // 
            this.labelfileName.AutoSize = true;
            this.labelfileName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelfileName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfileName.ForeColor = System.Drawing.Color.GreenYellow;
            this.labelfileName.Location = new System.Drawing.Point(16, 487);
            this.labelfileName.Name = "labelfileName";
            this.labelfileName.Size = new System.Drawing.Size(159, 16);
            this.labelfileName.TabIndex = 2;
            this.labelfileName.Text = "Label To Load File Name";
            // 
            // lblNameLabel
            // 
            this.lblNameLabel.AutoSize = true;
            this.lblNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameLabel.Location = new System.Drawing.Point(618, 85);
            this.lblNameLabel.Name = "lblNameLabel";
            this.lblNameLabel.Size = new System.Drawing.Size(59, 16);
            this.lblNameLabel.TabIndex = 3;
            this.lblNameLabel.Text = "NAME :";
            // 
            // lblTourLenLabel
            // 
            this.lblTourLenLabel.AutoSize = true;
            this.lblTourLenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTourLenLabel.Location = new System.Drawing.Point(618, 166);
            this.lblTourLenLabel.Name = "lblTourLenLabel";
            this.lblTourLenLabel.Size = new System.Drawing.Size(162, 16);
            this.lblTourLenLabel.TabIndex = 4;
            this.lblTourLenLabel.Text = "Optimum Tour Length :";
            // 
            // lblDimensionLabel
            // 
            this.lblDimensionLabel.AutoSize = true;
            this.lblDimensionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDimensionLabel.Location = new System.Drawing.Point(618, 123);
            this.lblDimensionLabel.Name = "lblDimensionLabel";
            this.lblDimensionLabel.Size = new System.Drawing.Size(104, 16);
            this.lblDimensionLabel.TabIndex = 5;
            this.lblDimensionLabel.Text = "DIMENSION : ";
            // 
            // lblTimeTakenLabel
            // 
            this.lblTimeTakenLabel.AutoSize = true;
            this.lblTimeTakenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeTakenLabel.Location = new System.Drawing.Point(618, 211);
            this.lblTimeTakenLabel.Name = "lblTimeTakenLabel";
            this.lblTimeTakenLabel.Size = new System.Drawing.Size(133, 16);
            this.lblTimeTakenLabel.TabIndex = 6;
            this.lblTimeTakenLabel.Text = "Time Taken (ms) :";
            // 
            // lblAlgoNameLabel
            // 
            this.lblAlgoNameLabel.AutoSize = true;
            this.lblAlgoNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlgoNameLabel.Location = new System.Drawing.Point(618, 395);
            this.lblAlgoNameLabel.Name = "lblAlgoNameLabel";
            this.lblAlgoNameLabel.Size = new System.Drawing.Size(0, 16);
            this.lblAlgoNameLabel.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelName.Location = new System.Drawing.Point(692, 85);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(75, 16);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "TSP User";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTime.Location = new System.Drawing.Point(757, 211);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 16);
            this.labelTime.TabIndex = 11;
            // 
            // labelDimension
            // 
            this.labelDimension.AutoSize = true;
            this.labelDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDimension.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelDimension.Location = new System.Drawing.Point(718, 123);
            this.labelDimension.Name = "labelDimension";
            this.labelDimension.Size = new System.Drawing.Size(0, 16);
            this.labelDimension.TabIndex = 10;
            // 
            // labelTourLen
            // 
            this.labelTourLen.AutoSize = true;
            this.labelTourLen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTourLen.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelTourLen.Location = new System.Drawing.Point(786, 166);
            this.labelTourLen.Name = "labelTourLen";
            this.labelTourLen.Size = new System.Drawing.Size(0, 16);
            this.labelTourLen.TabIndex = 9;
            // 
            // progressBarAlgo
            // 
            this.progressBarAlgo.Location = new System.Drawing.Point(621, 432);
            this.progressBarAlgo.Name = "progressBarAlgo";
            this.progressBarAlgo.Size = new System.Drawing.Size(226, 23);
            this.progressBarAlgo.TabIndex = 12;
            // 
            // saveImageFileDialog
            // 
            this.saveImageFileDialog.AddExtension = false;
            this.saveImageFileDialog.FileName = "TSPSolnImage";
            this.saveImageFileDialog.Filter = "Text Files (.png)|*.png";
            // 
            // TSPGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 518);
            this.Controls.Add(this.progressBarAlgo);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelDimension);
            this.Controls.Add(this.labelTourLen);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.lblAlgoNameLabel);
            this.Controls.Add(this.lblTimeTakenLabel);
            this.Controls.Add(this.lblDimensionLabel);
            this.Controls.Add(this.lblTourLenLabel);
            this.Controls.Add(this.lblNameLabel);
            this.Controls.Add(this.labelfileName);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "TSPGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Travelling Salesman Problem GUI";
            this.Load += new System.EventHandler(this.TSPGUI_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tSPSolverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greedyApproachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCOImplementationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.OpenFileDialog openDataFileDialog;
        private System.Windows.Forms.Label labelfileName;
        private System.Windows.Forms.Label lblNameLabel;
        private System.Windows.Forms.Label lblTourLenLabel;
        private System.Windows.Forms.Label lblDimensionLabel;
        private System.Windows.Forms.Label lblTimeTakenLabel;
        private System.Windows.Forms.Label lblAlgoNameLabel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelDimension;
        private System.Windows.Forms.Label labelTourLen;
        private System.Windows.Forms.ProgressBar progressBarAlgo;
        private System.Windows.Forms.SaveFileDialog saveImageFileDialog;
    }
}

