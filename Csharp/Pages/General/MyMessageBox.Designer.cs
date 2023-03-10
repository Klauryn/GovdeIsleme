namespace Csharp.Pages.General
{
    partial class MyMessageBox
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rectangleShape1 = new CustomControls.RJControls.RectangleShape();
            this.label_tittle = new System.Windows.Forms.Label();
            this.rectangleShape2 = new CustomControls.RJControls.RectangleShape();
            this.label_msg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Accept = new CustomControls.RJControls.RoundedButton();
            this.btn_Cancel = new CustomControls.RJControls.RoundedButton();
            this.btn_Ok = new CustomControls.RJControls.RoundedButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.rectangleShape1.SuspendLayout();
            this.rectangleShape2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rectangleShape1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rectangleShape2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(431, 194);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.Goldenrod;
            this.rectangleShape1.BackgroundColor = System.Drawing.Color.Goldenrod;
            this.rectangleShape1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rectangleShape1.BorderRadius = 5;
            this.rectangleShape1.BorderSize = 0;
            this.rectangleShape1.Controls.Add(this.label_tittle);
            this.rectangleShape1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleShape1.ForeColor = System.Drawing.Color.White;
            this.rectangleShape1.Location = new System.Drawing.Point(3, 3);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(425, 33);
            this.rectangleShape1.TabIndex = 1;
            this.rectangleShape1.TextColor = System.Drawing.Color.White;
            // 
            // label_tittle
            // 
            this.label_tittle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_tittle.AutoSize = true;
            this.label_tittle.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_tittle.Location = new System.Drawing.Point(173, 6);
            this.label_tittle.Name = "label_tittle";
            this.label_tittle.Size = new System.Drawing.Size(130, 22);
            this.label_tittle.TabIndex = 0;
            this.label_tittle.Text = "label_tittle";
            this.label_tittle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.White;
            this.rectangleShape2.BackgroundColor = System.Drawing.Color.White;
            this.rectangleShape2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rectangleShape2.BorderRadius = 10;
            this.rectangleShape2.BorderSize = 0;
            this.rectangleShape2.Controls.Add(this.label_msg);
            this.rectangleShape2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleShape2.ForeColor = System.Drawing.Color.White;
            this.rectangleShape2.Location = new System.Drawing.Point(3, 42);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(425, 100);
            this.rectangleShape2.TabIndex = 0;
            this.rectangleShape2.TextColor = System.Drawing.Color.White;
            // 
            // label_msg
            // 
            this.label_msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_msg.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_msg.ForeColor = System.Drawing.Color.Black;
            this.label_msg.Location = new System.Drawing.Point(6, 6);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(416, 89);
            this.label_msg.TabIndex = 1;
            this.label_msg.Text = "label_msg";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Accept);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 43);
            this.panel1.TabIndex = 2;
            // 
            // btn_Accept
            // 
            this.btn_Accept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Accept.BackColor = System.Drawing.Color.Green;
            this.btn_Accept.BackgroundColor = System.Drawing.Color.Green;
            this.btn_Accept.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_Accept.BorderRadius = 10;
            this.btn_Accept.BorderSize = 0;
            this.btn_Accept.FlatAppearance.BorderSize = 0;
            this.btn_Accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Accept.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Accept.ForeColor = System.Drawing.Color.White;
            this.btn_Accept.Location = new System.Drawing.Point(266, 5);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(72, 33);
            this.btn_Accept.TabIndex = 5;
            this.btn_Accept.Text = "KABUL";
            this.btn_Accept.TextColor = System.Drawing.Color.White;
            this.btn_Accept.UseVisualStyleBackColor = false;
            this.btn_Accept.Visible = false;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Cancel.BackColor = System.Drawing.Color.Red;
            this.btn_Cancel.BackgroundColor = System.Drawing.Color.Red;
            this.btn_Cancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_Cancel.BorderRadius = 10;
            this.btn_Cancel.BorderSize = 0;
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(344, 5);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(72, 33);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "REDDET";
            this.btn_Cancel.TextColor = System.Drawing.Color.White;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Ok.BackColor = System.Drawing.Color.Gray;
            this.btn_Ok.BackgroundColor = System.Drawing.Color.Gray;
            this.btn_Ok.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_Ok.BorderRadius = 10;
            this.btn_Ok.BorderSize = 0;
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Ok.ForeColor = System.Drawing.Color.White;
            this.btn_Ok.Location = new System.Drawing.Point(163, 5);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(99, 33);
            this.btn_Ok.TabIndex = 3;
            this.btn_Ok.Text = "TAMAM";
            this.btn_Ok.TextColor = System.Drawing.Color.White;
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // MyMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 194);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.rectangleShape1.ResumeLayout(false);
            this.rectangleShape1.PerformLayout();
            this.rectangleShape2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.RJControls.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label_tittle;
        private CustomControls.RJControls.RectangleShape rectangleShape2;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.RJControls.RoundedButton btn_Accept;
        private CustomControls.RJControls.RoundedButton btn_Cancel;
        private CustomControls.RJControls.RoundedButton btn_Ok;
        private System.Windows.Forms.Label label_msg;
    }
}