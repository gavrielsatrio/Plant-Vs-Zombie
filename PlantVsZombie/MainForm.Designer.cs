namespace PlantVsZombie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerRandomSun = new System.Windows.Forms.Timer(this.components);
            this.panelGameArea = new System.Windows.Forms.Panel();
            this.picBoxGameArea = new System.Windows.Forms.PictureBox();
            this.panelTopBoard = new System.Windows.Forms.Panel();
            this.panelPlantListBorder = new System.Windows.Forms.Panel();
            this.panelPlantList = new System.Windows.Forms.Panel();
            this.panelSunCountBorder = new System.Windows.Forms.Panel();
            this.panelSunCount = new System.Windows.Forms.Panel();
            this.picBoxSunCount = new System.Windows.Forms.PictureBox();
            this.lblSunCount = new System.Windows.Forms.Label();
            this.panelShovelBorder = new System.Windows.Forms.Panel();
            this.panelShovel = new System.Windows.Forms.Panel();
            this.picBoxShovel = new System.Windows.Forms.PictureBox();
            this.timerRandomZombie = new System.Windows.Forms.Timer(this.components);
            this.panelGameArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGameArea)).BeginInit();
            this.panelTopBoard.SuspendLayout();
            this.panelPlantListBorder.SuspendLayout();
            this.panelSunCountBorder.SuspendLayout();
            this.panelSunCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSunCount)).BeginInit();
            this.panelShovelBorder.SuspendLayout();
            this.panelShovel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxShovel)).BeginInit();
            this.SuspendLayout();
            // 
            // timerRandomSun
            // 
            this.timerRandomSun.Interval = 5000;
            this.timerRandomSun.Tick += new System.EventHandler(this.timerRandomSun_Tick);
            // 
            // panelGameArea
            // 
            this.panelGameArea.Controls.Add(this.picBoxGameArea);
            this.panelGameArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGameArea.Location = new System.Drawing.Point(0, 100);
            this.panelGameArea.Name = "panelGameArea";
            this.panelGameArea.Size = new System.Drawing.Size(944, 561);
            this.panelGameArea.TabIndex = 2;
            // 
            // picBoxGameArea
            // 
            this.picBoxGameArea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picBoxGameArea.Location = new System.Drawing.Point(0, 0);
            this.picBoxGameArea.Name = "picBoxGameArea";
            this.picBoxGameArea.Size = new System.Drawing.Size(944, 561);
            this.picBoxGameArea.TabIndex = 0;
            this.picBoxGameArea.TabStop = false;
            this.picBoxGameArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBoxGameArea_MouseClick);
            this.picBoxGameArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxGameArea_MouseMove);
            // 
            // panelTopBoard
            // 
            this.panelTopBoard.BackColor = global::PlantVsZombie.Properties.Settings.Default.ColorLightBrown;
            this.panelTopBoard.Controls.Add(this.panelPlantListBorder);
            this.panelTopBoard.Controls.Add(this.panelSunCountBorder);
            this.panelTopBoard.Controls.Add(this.panelShovelBorder);
            this.panelTopBoard.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::PlantVsZombie.Properties.Settings.Default, "ColorLightBrown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panelTopBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBoard.Location = new System.Drawing.Point(0, 0);
            this.panelTopBoard.Name = "panelTopBoard";
            this.panelTopBoard.Size = new System.Drawing.Size(944, 100);
            this.panelTopBoard.TabIndex = 1;
            // 
            // panelPlantListBorder
            // 
            this.panelPlantListBorder.Controls.Add(this.panelPlantList);
            this.panelPlantListBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlantListBorder.Location = new System.Drawing.Point(90, 0);
            this.panelPlantListBorder.Name = "panelPlantListBorder";
            this.panelPlantListBorder.Padding = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.panelPlantListBorder.Size = new System.Drawing.Size(754, 100);
            this.panelPlantListBorder.TabIndex = 5;
            // 
            // panelPlantList
            // 
            this.panelPlantList.BackColor = global::PlantVsZombie.Properties.Settings.Default.ColorDarkBrown;
            this.panelPlantList.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::PlantVsZombie.Properties.Settings.Default, "ColorDarkBrown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panelPlantList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlantList.Location = new System.Drawing.Point(4, 8);
            this.panelPlantList.Name = "panelPlantList";
            this.panelPlantList.Size = new System.Drawing.Size(746, 84);
            this.panelPlantList.TabIndex = 6;
            // 
            // panelSunCountBorder
            // 
            this.panelSunCountBorder.Controls.Add(this.panelSunCount);
            this.panelSunCountBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSunCountBorder.Location = new System.Drawing.Point(0, 0);
            this.panelSunCountBorder.Name = "panelSunCountBorder";
            this.panelSunCountBorder.Padding = new System.Windows.Forms.Padding(8, 8, 4, 8);
            this.panelSunCountBorder.Size = new System.Drawing.Size(90, 100);
            this.panelSunCountBorder.TabIndex = 4;
            // 
            // panelSunCount
            // 
            this.panelSunCount.BackColor = global::PlantVsZombie.Properties.Settings.Default.ColorDarkBrown;
            this.panelSunCount.Controls.Add(this.picBoxSunCount);
            this.panelSunCount.Controls.Add(this.lblSunCount);
            this.panelSunCount.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::PlantVsZombie.Properties.Settings.Default, "ColorDarkBrown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panelSunCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSunCount.Location = new System.Drawing.Point(8, 8);
            this.panelSunCount.Name = "panelSunCount";
            this.panelSunCount.Size = new System.Drawing.Size(78, 84);
            this.panelSunCount.TabIndex = 3;
            // 
            // picBoxSunCount
            // 
            this.picBoxSunCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBoxSunCount.Image = global::PlantVsZombie.Properties.Resources.Sun;
            this.picBoxSunCount.Location = new System.Drawing.Point(15, 4);
            this.picBoxSunCount.Name = "picBoxSunCount";
            this.picBoxSunCount.Size = new System.Drawing.Size(48, 48);
            this.picBoxSunCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxSunCount.TabIndex = 11;
            this.picBoxSunCount.TabStop = false;
            // 
            // lblSunCount
            // 
            this.lblSunCount.BackColor = global::PlantVsZombie.Properties.Settings.Default.ColorPaper;
            this.lblSunCount.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::PlantVsZombie.Properties.Settings.Default, "ColorPaper", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblSunCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSunCount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSunCount.Location = new System.Drawing.Point(0, 55);
            this.lblSunCount.Name = "lblSunCount";
            this.lblSunCount.Size = new System.Drawing.Size(78, 29);
            this.lblSunCount.TabIndex = 4;
            this.lblSunCount.Text = "25";
            this.lblSunCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelShovelBorder
            // 
            this.panelShovelBorder.Controls.Add(this.panelShovel);
            this.panelShovelBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelShovelBorder.Location = new System.Drawing.Point(844, 0);
            this.panelShovelBorder.Name = "panelShovelBorder";
            this.panelShovelBorder.Padding = new System.Windows.Forms.Padding(4, 8, 8, 8);
            this.panelShovelBorder.Size = new System.Drawing.Size(100, 100);
            this.panelShovelBorder.TabIndex = 3;
            // 
            // panelShovel
            // 
            this.panelShovel.BackColor = global::PlantVsZombie.Properties.Settings.Default.ColorDarkBrown;
            this.panelShovel.Controls.Add(this.picBoxShovel);
            this.panelShovel.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::PlantVsZombie.Properties.Settings.Default, "ColorDarkBrown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panelShovel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShovel.Location = new System.Drawing.Point(4, 8);
            this.panelShovel.Name = "panelShovel";
            this.panelShovel.Padding = new System.Windows.Forms.Padding(8);
            this.panelShovel.Size = new System.Drawing.Size(88, 84);
            this.panelShovel.TabIndex = 6;
            // 
            // picBoxShovel
            // 
            this.picBoxShovel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxShovel.Image = ((System.Drawing.Image)(resources.GetObject("picBoxShovel.Image")));
            this.picBoxShovel.Location = new System.Drawing.Point(8, 8);
            this.picBoxShovel.Name = "picBoxShovel";
            this.picBoxShovel.Size = new System.Drawing.Size(72, 68);
            this.picBoxShovel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxShovel.TabIndex = 0;
            this.picBoxShovel.TabStop = false;
            // 
            // timerRandomZombie
            // 
            this.timerRandomZombie.Interval = 7000;
            this.timerRandomZombie.Tick += new System.EventHandler(this.timerRandomZombie_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 661);
            this.Controls.Add(this.panelGameArea);
            this.Controls.Add(this.panelTopBoard);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plant Vs Zombie";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelGameArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxGameArea)).EndInit();
            this.panelTopBoard.ResumeLayout(false);
            this.panelPlantListBorder.ResumeLayout(false);
            this.panelSunCountBorder.ResumeLayout(false);
            this.panelSunCount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSunCount)).EndInit();
            this.panelShovelBorder.ResumeLayout(false);
            this.panelShovel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxShovel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerRandomSun;
        private System.Windows.Forms.Panel panelTopBoard;
        private System.Windows.Forms.Panel panelShovelBorder;
        private System.Windows.Forms.Panel panelSunCountBorder;
        private System.Windows.Forms.Panel panelSunCount;
        private System.Windows.Forms.Label lblSunCount;
        private System.Windows.Forms.PictureBox picBoxSunCount;
        private System.Windows.Forms.Panel panelShovel;
        private System.Windows.Forms.PictureBox picBoxShovel;
        private System.Windows.Forms.Panel panelPlantListBorder;
        private System.Windows.Forms.Panel panelPlantList;
        private System.Windows.Forms.Panel panelGameArea;
        private System.Windows.Forms.PictureBox picBoxGameArea;
        private System.Windows.Forms.Timer timerRandomZombie;
    }
}

