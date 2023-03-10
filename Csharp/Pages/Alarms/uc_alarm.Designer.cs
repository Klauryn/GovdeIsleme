namespace Csharp.Pages.Alarms
{
    partial class uc_alarm
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
            this.rectangleShape1 = new CustomControls.RJControls.RectangleShape();
            this.variable_bit = new CustomControls.RJControls.RectangleShape();
            this.tb_Text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rectangleShape1.SuspendLayout();
            this.variable_bit.SuspendLayout();
            this.SuspendLayout();
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.AliceBlue;
            this.rectangleShape1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.rectangleShape1.BorderColor = System.Drawing.Color.LightBlue;
            this.rectangleShape1.BorderRadius = 15;
            this.rectangleShape1.BorderSize = 3;
            this.rectangleShape1.Controls.Add(this.variable_bit);
            this.rectangleShape1.Controls.Add(this.tb_Text);
            this.rectangleShape1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleShape1.ForeColor = System.Drawing.Color.White;
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(1615, 39);
            this.rectangleShape1.TabIndex = 0;
            this.rectangleShape1.TextColor = System.Drawing.Color.White;
            this.rectangleShape1.Paint += new System.Windows.Forms.PaintEventHandler(this.rectangleShape1_Paint);
            // 
            // variable_bit
            // 
            this.variable_bit.BackColor = System.Drawing.Color.Crimson;
            this.variable_bit.BackgroundColor = System.Drawing.Color.Crimson;
            this.variable_bit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.variable_bit.BorderRadius = 0;
            this.variable_bit.BorderSize = 0;
            this.variable_bit.Controls.Add(this.label2);
            this.variable_bit.Controls.Add(this.label1);
            this.variable_bit.ForeColor = System.Drawing.Color.White;
            this.variable_bit.Location = new System.Drawing.Point(18, 11);
            this.variable_bit.Name = "variable_bit";
            this.variable_bit.Size = new System.Drawing.Size(18, 18);
            this.variable_bit.TabIndex = 2;
            this.variable_bit.TextColor = System.Drawing.Color.White;
            // 
            // tb_Text
            // 
            this.tb_Text.BackColor = System.Drawing.Color.AliceBlue;
            this.tb_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Text.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_Text.ForeColor = System.Drawing.Color.Black;
            this.tb_Text.Location = new System.Drawing.Point(42, 11);
            this.tb_Text.Name = "tb_Text";
            this.tb_Text.Size = new System.Drawing.Size(1544, 18);
            this.tb_Text.TabIndex = 1;
            this.tb_Text.Text = " Text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-20, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(1, -4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "!";
            // 
            // uc_alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rectangleShape1);
            this.Name = "uc_alarm";
            this.Size = new System.Drawing.Size(1615, 39);
            this.rectangleShape1.ResumeLayout(false);
            this.rectangleShape1.PerformLayout();
            this.variable_bit.ResumeLayout(false);
            this.variable_bit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.RJControls.RectangleShape rectangleShape1;
        private System.Windows.Forms.TextBox tb_Text;
        public CustomControls.RJControls.RectangleShape variable_bit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
