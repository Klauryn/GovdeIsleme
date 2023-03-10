namespace Csharp.Pages.Alarms
{
    partial class uc_Alarms
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel_1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rectangleShape1 = new CustomControls.RJControls.RectangleShape();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.rectangleShape1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel_1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rectangleShape1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1472, 834);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel_1
            // 
            this.flowLayoutPanel_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_1.Location = new System.Drawing.Point(3, 58);
            this.flowLayoutPanel_1.Name = "flowLayoutPanel_1";
            this.flowLayoutPanel_1.Size = new System.Drawing.Size(1466, 773);
            this.flowLayoutPanel_1.TabIndex = 1;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.LightSlateGray;
            this.rectangleShape1.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.rectangleShape1.BorderColor = System.Drawing.Color.Lavender;
            this.rectangleShape1.BorderRadius = 20;
            this.rectangleShape1.BorderSize = 2;
            this.rectangleShape1.Controls.Add(this.pictureBox1);
            this.rectangleShape1.Controls.Add(this.label1);
            this.rectangleShape1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleShape1.ForeColor = System.Drawing.Color.Snow;
            this.rectangleShape1.Location = new System.Drawing.Point(3, 3);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(1466, 49);
            this.rectangleShape1.TabIndex = 0;
            this.rectangleShape1.TextColor = System.Drawing.Color.Snow;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(66, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ALARMLAR";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Csharp.Properties.Resources.alarm;
            this.pictureBox1.Location = new System.Drawing.Point(25, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // uc_Alarms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uc_Alarms";
            this.Size = new System.Drawing.Size(1472, 834);
            this.Load += new System.EventHandler(this.uc_StartCondPage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.rectangleShape1.ResumeLayout(false);
            this.rectangleShape1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.RJControls.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
