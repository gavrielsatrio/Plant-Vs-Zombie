namespace PlantVsZombie.Layouts
{
    partial class PlantCardLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlantCardLayout));
            this.panelMargin = new System.Windows.Forms.Panel();
            this.panelPlantCost = new System.Windows.Forms.Panel();
            this.picBoxSun = new System.Windows.Forms.PictureBox();
            this.lblPlantCost = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelPicBoxPlant = new System.Windows.Forms.Panel();
            this.picBoxPlant = new System.Windows.Forms.PictureBox();
            this.panelMargin.SuspendLayout();
            this.panelPlantCost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSun)).BeginInit();
            this.panelPicBoxPlant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlant)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMargin
            // 
            this.panelMargin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(253)))), ((int)(((byte)(232)))));
            this.panelMargin.Controls.Add(this.panelPicBoxPlant);
            this.panelMargin.Controls.Add(this.panelPlantCost);
            this.panelMargin.Controls.Add(this.lblHeader);
            this.panelMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMargin.Location = new System.Drawing.Point(4, 4);
            this.panelMargin.Name = "panelMargin";
            this.panelMargin.Size = new System.Drawing.Size(76, 76);
            this.panelMargin.TabIndex = 0;
            // 
            // panelPlantCost
            // 
            this.panelPlantCost.BackColor = System.Drawing.Color.White;
            this.panelPlantCost.Controls.Add(this.picBoxSun);
            this.panelPlantCost.Controls.Add(this.lblPlantCost);
            this.panelPlantCost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPlantCost.Location = new System.Drawing.Point(0, 56);
            this.panelPlantCost.Name = "panelPlantCost";
            this.panelPlantCost.Size = new System.Drawing.Size(76, 20);
            this.panelPlantCost.TabIndex = 4;
            // 
            // picBoxSun
            // 
            this.picBoxSun.Dock = System.Windows.Forms.DockStyle.Right;
            this.picBoxSun.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSun.Image")));
            this.picBoxSun.Location = new System.Drawing.Point(51, 0);
            this.picBoxSun.Name = "picBoxSun";
            this.picBoxSun.Size = new System.Drawing.Size(25, 20);
            this.picBoxSun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxSun.TabIndex = 3;
            this.picBoxSun.TabStop = false;
            // 
            // lblPlantCost
            // 
            this.lblPlantCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlantCost.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlantCost.Location = new System.Drawing.Point(0, 0);
            this.lblPlantCost.Name = "lblPlantCost";
            this.lblPlantCost.Size = new System.Drawing.Size(76, 20);
            this.lblPlantCost.TabIndex = 2;
            this.lblPlantCost.Text = "75";
            this.lblPlantCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(76, 16);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Plant Vs Zombie";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPicBoxPlant
            // 
            this.panelPicBoxPlant.Controls.Add(this.picBoxPlant);
            this.panelPicBoxPlant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicBoxPlant.Location = new System.Drawing.Point(0, 16);
            this.panelPicBoxPlant.Name = "panelPicBoxPlant";
            this.panelPicBoxPlant.Padding = new System.Windows.Forms.Padding(6);
            this.panelPicBoxPlant.Size = new System.Drawing.Size(76, 40);
            this.panelPicBoxPlant.TabIndex = 5;
            // 
            // picBoxPlant
            // 
            this.picBoxPlant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxPlant.Location = new System.Drawing.Point(6, 6);
            this.picBoxPlant.Name = "picBoxPlant";
            this.picBoxPlant.Size = new System.Drawing.Size(64, 28);
            this.picBoxPlant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxPlant.TabIndex = 6;
            this.picBoxPlant.TabStop = false;
            this.picBoxPlant.Click += new System.EventHandler(this.picBoxPlant_Click);
            // 
            // PlantListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::PlantVsZombie.Properties.Settings.Default.ColorDarkBrown;
            this.Controls.Add(this.panelMargin);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::PlantVsZombie.Properties.Settings.Default, "ColorDarkBrown", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PlantListItem";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(84, 84);
            this.Load += new System.EventHandler(this.PlantListItem_Load);
            this.panelMargin.ResumeLayout(false);
            this.panelPlantCost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSun)).EndInit();
            this.panelPicBoxPlant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelPlantCost;
        private System.Windows.Forms.PictureBox picBoxSun;
        private System.Windows.Forms.Label lblPlantCost;
        private System.Windows.Forms.Panel panelMargin;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panelPicBoxPlant;
        private System.Windows.Forms.PictureBox picBoxPlant;
    }
}
