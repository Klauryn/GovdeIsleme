namespace Csharp.Pages.MachinePars
{
    partial class uc_machinepar_numerik
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rectangleShape1 = new CustomControls.RJControls.RectangleShape();
            this.tb_Text = new System.Windows.Forms.TextBox();
            this.rectangleShape2 = new CustomControls.RJControls.RectangleShape();
            this.tb_value = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.rectangleShape1.SuspendLayout();
            this.rectangleShape2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Controls.Add(this.rectangleShape1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rectangleShape2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(480, 39);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.AliceBlue;
            this.rectangleShape1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.rectangleShape1.BorderColor = System.Drawing.Color.LightBlue;
            this.rectangleShape1.BorderRadius = 15;
            this.rectangleShape1.BorderSize = 3;
            this.rectangleShape1.Controls.Add(this.tb_Text);
            this.rectangleShape1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleShape1.ForeColor = System.Drawing.Color.White;
            this.rectangleShape1.Location = new System.Drawing.Point(3, 3);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(397, 33);
            this.rectangleShape1.TabIndex = 2;
            this.rectangleShape1.TextColor = System.Drawing.Color.White;
            // 
            // tb_Text
            // 
            this.tb_Text.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tb_Text.BackColor = System.Drawing.Color.AliceBlue;
            this.tb_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Text.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tb_Text.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_Text.ForeColor = System.Drawing.Color.Black;
            this.tb_Text.Location = new System.Drawing.Point(15, 8);
            this.tb_Text.Name = "tb_Text";
            this.tb_Text.ReadOnly = true;
            this.tb_Text.Size = new System.Drawing.Size(400, 18);
            this.tb_Text.TabIndex = 1;
            this.tb_Text.Text = " Text";
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.Silver;
            this.rectangleShape2.BackgroundColor = System.Drawing.Color.Silver;
            this.rectangleShape2.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.rectangleShape2.BorderRadius = 10;
            this.rectangleShape2.BorderSize = 2;
            this.rectangleShape2.Controls.Add(this.tb_value);
            this.rectangleShape2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleShape2.ForeColor = System.Drawing.Color.White;
            this.rectangleShape2.Location = new System.Drawing.Point(406, 3);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(71, 33);
            this.rectangleShape2.TabIndex = 3;
            this.rectangleShape2.TextColor = System.Drawing.Color.White;
            // 
            // tb_value
            // 
            this.tb_value.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_value.BackColor = System.Drawing.Color.Silver;
            this.tb_value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_value.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_value.Location = new System.Drawing.Point(7, 8);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(59, 18);
            this.tb_value.TabIndex = 3;
            this.tb_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_value.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tb_value_MouseDown);
            // 
            // uc_machinepar_numerik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uc_machinepar_numerik";
            this.Size = new System.Drawing.Size(480, 39);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.rectangleShape1.ResumeLayout(false);
            this.rectangleShape1.PerformLayout();
            this.rectangleShape2.ResumeLayout(false);
            this.rectangleShape2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.RJControls.RectangleShape rectangleShape1;
        public System.Windows.Forms.TextBox tb_Text;
        private CustomControls.RJControls.RectangleShape rectangleShape2;
        public System.Windows.Forms.TextBox tb_value;
    }
}
