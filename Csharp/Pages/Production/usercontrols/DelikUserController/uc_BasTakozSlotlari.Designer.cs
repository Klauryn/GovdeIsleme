namespace Csharp.Pages.Production.usercontrols.DelikUserController
{
    partial class uc_BasTakozSlotlari
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
            this.sagPim = new CustomControls.RJControls.RectangleShape();
            this.solPim = new CustomControls.RJControls.RectangleShape();
            this.anaPim = new CustomControls.RJControls.RectangleShape();
            this.SuspendLayout();
            // 
            // sagPim
            // 
            this.sagPim.BackColor = System.Drawing.Color.White;
            this.sagPim.BackgroundColor = System.Drawing.Color.White;
            this.sagPim.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sagPim.BorderRadius = 3;
            this.sagPim.BorderSize = 1;
            this.sagPim.ForeColor = System.Drawing.Color.White;
            this.sagPim.Location = new System.Drawing.Point(5, 0);
            this.sagPim.Margin = new System.Windows.Forms.Padding(0);
            this.sagPim.Name = "sagPim";
            this.sagPim.Size = new System.Drawing.Size(3, 3);
            this.sagPim.TabIndex = 2;
            this.sagPim.TextColor = System.Drawing.Color.White;
            // 
            // solPim
            // 
            this.solPim.BackColor = System.Drawing.Color.White;
            this.solPim.BackgroundColor = System.Drawing.Color.White;
            this.solPim.BorderColor = System.Drawing.Color.DodgerBlue;
            this.solPim.BorderRadius = 3;
            this.solPim.BorderSize = 1;
            this.solPim.ForeColor = System.Drawing.Color.White;
            this.solPim.Location = new System.Drawing.Point(0, 0);
            this.solPim.Margin = new System.Windows.Forms.Padding(0);
            this.solPim.Name = "solPim";
            this.solPim.Size = new System.Drawing.Size(3, 3);
            this.solPim.TabIndex = 1;
            this.solPim.TextColor = System.Drawing.Color.White;
            // 
            // anaPim
            // 
            this.anaPim.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.anaPim.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.anaPim.BackColor = System.Drawing.Color.White;
            this.anaPim.BackgroundColor = System.Drawing.Color.White;
            this.anaPim.BorderColor = System.Drawing.Color.DodgerBlue;
            this.anaPim.BorderRadius = 3;
            this.anaPim.BorderSize = 1;
            this.anaPim.ForeColor = System.Drawing.Color.White;
            this.anaPim.Location = new System.Drawing.Point(-2, 3);
            this.anaPim.Margin = new System.Windows.Forms.Padding(0);
            this.anaPim.Name = "anaPim";
            this.anaPim.Size = new System.Drawing.Size(11, 6);
            this.anaPim.TabIndex = 0;
            this.anaPim.TextColor = System.Drawing.Color.White;
            // 
            // uc_BasTakozSlotlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.sagPim);
            this.Controls.Add(this.solPim);
            this.Controls.Add(this.anaPim);
            this.Name = "uc_BasTakozSlotlari";
            this.Size = new System.Drawing.Size(11, 10);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.RJControls.RectangleShape anaPim;
        private CustomControls.RJControls.RectangleShape solPim;
        private CustomControls.RJControls.RectangleShape sagPim;
    }
}
