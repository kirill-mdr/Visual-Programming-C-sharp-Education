
namespace VP_6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nuPogodi1 = new VP_6.NuPogodi();
            this.SuspendLayout();
            // 
            // nuPogodi1
            // 
            this.nuPogodi1.Am = true;
            this.nuPogodi1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nuPogodi1.BackgroundImage")));
            this.nuPogodi1.BasketPosition = -1;
            this.nuPogodi1.CrashLeft = false;
            this.nuPogodi1.CrashRight = false;
            this.nuPogodi1.EggGeneratorCounter = 6;
            this.nuPogodi1.EggGeneratorMax = 6;
            this.nuPogodi1.Faults = 0;
            this.nuPogodi1.GameA = true;
            this.nuPogodi1.GameB = false;
            this.nuPogodi1.IsStart = false;
            this.nuPogodi1.Location = new System.Drawing.Point(1, 1);
            this.nuPogodi1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.nuPogodi1.Name = "nuPogodi1";
            this.nuPogodi1.Pm = false;
            this.nuPogodi1.Score = 0;
            this.nuPogodi1.Size = new System.Drawing.Size(1012, 615);
            this.nuPogodi1.TabIndex = 0;
            this.nuPogodi1.Time = false;
            this.nuPogodi1.RedButtonClick += new VP_6.NuPogodi.RedButtonHandler(this.nuPogodi1_RedButtonClick);
            this.nuPogodi1.Load += new System.EventHandler(this.nuPogodi1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 617);
            this.Controls.Add(this.nuPogodi1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private NuPogodi nuPogodi1;
    }
}

