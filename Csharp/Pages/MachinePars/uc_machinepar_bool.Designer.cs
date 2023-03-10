namespace Csharp.Pages.MachinePars
{
    partial class uc_machinepar_bool
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
            this.rectangleShape1 = new CustomControls.RJControls.RectangleShape();
            this.cb_State = new System.Windows.Forms.CheckBox();
            this.tb_Text = new System.Windows.Forms.TextBox();
            this.btn_toggle = new CustomControls.RJControls.RoundedButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.rectangleShape1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Controls.Add(this.rectangleShape1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_toggle, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
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
            this.rectangleShape1.Controls.Add(this.cb_State);
            this.rectangleShape1.Controls.Add(this.tb_Text);
            this.rectangleShape1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleShape1.ForeColor = System.Drawing.Color.White;
            this.rectangleShape1.Location = new System.Drawing.Point(3, 3);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(397, 33);
            this.rectangleShape1.TabIndex = 3;
            this.rectangleShape1.TextColor = System.Drawing.Color.White;
            // 
            // cb_State
            // 
            this.cb_State.AutoSize = true;
            this.cb_State.Enabled = false;
            this.cb_State.Location = new System.Drawing.Point(71, 11);
            this.cb_State.Name = "cb_State";
            this.cb_State.Size = new System.Drawing.Size(15, 14);
            this.cb_State.TabIndex = 2;
            this.cb_State.UseVisualStyleBackColor = true;
            this.cb_State.Visible = false;
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
            this.tb_Text.Size = new System.Drawing.Size(364, 18);
            this.tb_Text.TabIndex = 1;
            this.tb_Text.Text = " Text";
            // 
            // btn_toggle
            // 
            this.btn_toggle.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_toggle.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_toggle.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_toggle.BorderRadius = 10;
            this.btn_toggle.BorderSize = 0;
            this.btn_toggle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_toggle.FlatAppearance.BorderSize = 0;
            this.btn_toggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_toggle.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_toggle.ForeColor = System.Drawing.Color.White;
            this.btn_toggle.Location = new System.Drawing.Point(406, 3);
            this.btn_toggle.Name = "btn_toggle";
            this.btn_toggle.Size = new System.Drawing.Size(71, 33);
            this.btn_toggle.TabIndex = 4;
            this.btn_toggle.Text = "roundedButton1";
            this.btn_toggle.TextColor = System.Drawing.Color.White;
            this.btn_toggle.UseVisualStyleBackColor = false;
            this.btn_toggle.Click += new System.EventHandler(this.btn_toggle_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uc_machinepar_bool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uc_machinepar_bool";
            this.Size = new System.Drawing.Size(480, 39);
            this.Load += new System.EventHandler(this.uc_machinepar_bool_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.rectangleShape1.ResumeLayout(false);
            this.rectangleShape1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.RJControls.RectangleShape rectangleShape1;
        public System.Windows.Forms.TextBox tb_Text;
        public CustomControls.RJControls.RoundedButton btn_toggle;
        public System.Windows.Forms.CheckBox cb_State;
        private System.Windows.Forms.Timer timer1;
    }
}
