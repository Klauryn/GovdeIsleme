namespace Csharp.Pages.Production.usercontrols.DelikUserController
{
    partial class uc_IlaveBosaltmaUst
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
            this.anaParcaSag = new CustomControls.RJControls.RectangleShape();
            this.anaParcaMerkez = new CustomControls.RJControls.RectangleShape();
            this.anaParcaSol = new CustomControls.RJControls.RectangleShape();
            this.anaParcaSag.SuspendLayout();
            this.SuspendLayout();
            // 
            // anaParcaSag
            // 
            this.anaParcaSag.BackColor = System.Drawing.Color.White;
            this.anaParcaSag.BackgroundColor = System.Drawing.Color.White;
            this.anaParcaSag.BorderColor = System.Drawing.Color.Fuchsia;
            this.anaParcaSag.BorderRadius = 3;
            this.anaParcaSag.BorderSize = 1;
            this.anaParcaSag.Controls.Add(this.anaParcaMerkez);
            this.anaParcaSag.ForeColor = System.Drawing.Color.White;
            this.anaParcaSag.Location = new System.Drawing.Point(0, 0);
            this.anaParcaSag.Margin = new System.Windows.Forms.Padding(0);
            this.anaParcaSag.Name = "anaParcaSag";
            this.anaParcaSag.Size = new System.Drawing.Size(58, 11);
            this.anaParcaSag.TabIndex = 1;
            this.anaParcaSag.TextColor = System.Drawing.Color.White;
            // 
            // anaParcaMerkez
            // 
            this.anaParcaMerkez.BackColor = System.Drawing.Color.White;
            this.anaParcaMerkez.BackgroundColor = System.Drawing.Color.White;
            this.anaParcaMerkez.BorderColor = System.Drawing.Color.Transparent;
            this.anaParcaMerkez.BorderRadius = 2;
            this.anaParcaMerkez.BorderSize = 0;
            this.anaParcaMerkez.ForeColor = System.Drawing.Color.Transparent;
            this.anaParcaMerkez.Location = new System.Drawing.Point(52, 5);
            this.anaParcaMerkez.Margin = new System.Windows.Forms.Padding(0);
            this.anaParcaMerkez.Name = "anaParcaMerkez";
            this.anaParcaMerkez.Size = new System.Drawing.Size(12, 5);
            this.anaParcaMerkez.TabIndex = 1;
            this.anaParcaMerkez.TextColor = System.Drawing.Color.Transparent;
            // 
            // anaParcaSol
            // 
            this.anaParcaSol.BackColor = System.Drawing.Color.White;
            this.anaParcaSol.BackgroundColor = System.Drawing.Color.White;
            this.anaParcaSol.BorderColor = System.Drawing.Color.Fuchsia;
            this.anaParcaSol.BorderRadius = 3;
            this.anaParcaSol.BorderSize = 1;
            this.anaParcaSol.ForeColor = System.Drawing.Color.White;
            this.anaParcaSol.Location = new System.Drawing.Point(49, 4);
            this.anaParcaSol.Margin = new System.Windows.Forms.Padding(0);
            this.anaParcaSol.Name = "anaParcaSol";
            this.anaParcaSol.Size = new System.Drawing.Size(15, 7);
            this.anaParcaSol.TabIndex = 1;
            this.anaParcaSol.TextColor = System.Drawing.Color.White;
            // 
            // uc_IlaveBosaltmaUst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.anaParcaSag);
            this.Controls.Add(this.anaParcaSol);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "uc_IlaveBosaltmaUst";
            this.Size = new System.Drawing.Size(111, 27);
            this.anaParcaSag.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.RJControls.RectangleShape anaParcaSol;
        private CustomControls.RJControls.RectangleShape anaParcaSag;
        private CustomControls.RJControls.RectangleShape anaParcaMerkez;
    }
}
