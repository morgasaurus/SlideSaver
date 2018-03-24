namespace SlideSaver
{
    partial class SlideShowForm
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
            this.SuspendLayout();
            // 
            // SlideShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SlideShowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SlideShowForm";
            this.Load += new System.EventHandler(this.SlideShowForm_Load);
            this.Click += new System.EventHandler(this.SlideShowForm_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SlideShowForm_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SlideShowForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SlideShowForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SlideShowForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}