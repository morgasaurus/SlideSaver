namespace SlideSaver
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.Label_Order = new System.Windows.Forms.Label();
            this.TextBox_Folder = new System.Windows.Forms.TextBox();
            this.CheckBox_IncludeSubfolders = new System.Windows.Forms.CheckBox();
            this.Label_Folder = new System.Windows.Forms.Label();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Button_Browse = new System.Windows.Forms.Button();
            this.RadioButton_Name = new System.Windows.Forms.RadioButton();
            this.RadioButton_Date = new System.Windows.Forms.RadioButton();
            this.RadioButton_Random = new System.Windows.Forms.RadioButton();
            this.RadioButton_Shuffle = new System.Windows.Forms.RadioButton();
            this.Panel_Order = new System.Windows.Forms.Panel();
            this.FolderBrowserDialog_Folder = new System.Windows.Forms.FolderBrowserDialog();
            this.Panel_Order.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_Order
            // 
            this.Label_Order.AutoSize = true;
            this.Label_Order.Location = new System.Drawing.Point(15, 15);
            this.Label_Order.Name = "Label_Order";
            this.Label_Order.Size = new System.Drawing.Size(67, 13);
            this.Label_Order.TabIndex = 0;
            this.Label_Order.Text = "Photo Order:";
            // 
            // TextBox_Folder
            // 
            this.TextBox_Folder.Location = new System.Drawing.Point(88, 39);
            this.TextBox_Folder.Name = "TextBox_Folder";
            this.TextBox_Folder.ReadOnly = true;
            this.TextBox_Folder.Size = new System.Drawing.Size(441, 20);
            this.TextBox_Folder.TabIndex = 3;
            // 
            // CheckBox_IncludeSubfolders
            // 
            this.CheckBox_IncludeSubfolders.AutoSize = true;
            this.CheckBox_IncludeSubfolders.Location = new System.Drawing.Point(176, 69);
            this.CheckBox_IncludeSubfolders.Name = "CheckBox_IncludeSubfolders";
            this.CheckBox_IncludeSubfolders.Size = new System.Drawing.Size(114, 17);
            this.CheckBox_IncludeSubfolders.TabIndex = 4;
            this.CheckBox_IncludeSubfolders.Text = "Include Subfolders";
            this.CheckBox_IncludeSubfolders.UseVisualStyleBackColor = true;
            // 
            // Label_Folder
            // 
            this.Label_Folder.AutoSize = true;
            this.Label_Folder.Location = new System.Drawing.Point(12, 42);
            this.Label_Folder.Name = "Label_Folder";
            this.Label_Folder.Size = new System.Drawing.Size(70, 13);
            this.Label_Folder.TabIndex = 2;
            this.Label_Folder.Text = "Photo Folder:";
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(192, 104);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 23);
            this.Button_OK.TabIndex = 5;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(273, 104);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 6;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Button_Browse
            // 
            this.Button_Browse.Location = new System.Drawing.Point(88, 65);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(75, 23);
            this.Button_Browse.TabIndex = 7;
            this.Button_Browse.Text = "Browse";
            this.Button_Browse.UseVisualStyleBackColor = true;
            this.Button_Browse.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // RadioButton_Name
            // 
            this.RadioButton_Name.AutoSize = true;
            this.RadioButton_Name.Location = new System.Drawing.Point(3, 1);
            this.RadioButton_Name.Name = "RadioButton_Name";
            this.RadioButton_Name.Size = new System.Drawing.Size(53, 17);
            this.RadioButton_Name.TabIndex = 8;
            this.RadioButton_Name.TabStop = true;
            this.RadioButton_Name.Text = "Name";
            this.RadioButton_Name.UseVisualStyleBackColor = true;
            // 
            // RadioButton_Date
            // 
            this.RadioButton_Date.AutoSize = true;
            this.RadioButton_Date.Location = new System.Drawing.Point(62, 1);
            this.RadioButton_Date.Name = "RadioButton_Date";
            this.RadioButton_Date.Size = new System.Drawing.Size(48, 17);
            this.RadioButton_Date.TabIndex = 9;
            this.RadioButton_Date.TabStop = true;
            this.RadioButton_Date.Text = "Date";
            this.RadioButton_Date.UseVisualStyleBackColor = true;
            // 
            // RadioButton_Random
            // 
            this.RadioButton_Random.AutoSize = true;
            this.RadioButton_Random.Location = new System.Drawing.Point(116, 1);
            this.RadioButton_Random.Name = "RadioButton_Random";
            this.RadioButton_Random.Size = new System.Drawing.Size(65, 17);
            this.RadioButton_Random.TabIndex = 10;
            this.RadioButton_Random.TabStop = true;
            this.RadioButton_Random.Text = "Random";
            this.RadioButton_Random.UseVisualStyleBackColor = true;
            // 
            // RadioButton_Shuffle
            // 
            this.RadioButton_Shuffle.AutoSize = true;
            this.RadioButton_Shuffle.Location = new System.Drawing.Point(187, 1);
            this.RadioButton_Shuffle.Name = "RadioButton_Shuffle";
            this.RadioButton_Shuffle.Size = new System.Drawing.Size(58, 17);
            this.RadioButton_Shuffle.TabIndex = 11;
            this.RadioButton_Shuffle.TabStop = true;
            this.RadioButton_Shuffle.Text = "Shuffle";
            this.RadioButton_Shuffle.UseVisualStyleBackColor = true;
            // 
            // Panel_Order
            // 
            this.Panel_Order.Controls.Add(this.RadioButton_Name);
            this.Panel_Order.Controls.Add(this.RadioButton_Shuffle);
            this.Panel_Order.Controls.Add(this.RadioButton_Date);
            this.Panel_Order.Controls.Add(this.RadioButton_Random);
            this.Panel_Order.Location = new System.Drawing.Point(88, 12);
            this.Panel_Order.Name = "Panel_Order";
            this.Panel_Order.Size = new System.Drawing.Size(441, 21);
            this.Panel_Order.TabIndex = 12;
            // 
            // FolderBrowserDialog_Folder
            // 
            this.FolderBrowserDialog_Folder.ShowNewFolderButton = false;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 136);
            this.Controls.Add(this.Panel_Order);
            this.Controls.Add(this.Button_Browse);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Label_Folder);
            this.Controls.Add(this.CheckBox_IncludeSubfolders);
            this.Controls.Add(this.TextBox_Folder);
            this.Controls.Add(this.Label_Order);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "Slide Show Settings";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.Panel_Order.ResumeLayout(false);
            this.Panel_Order.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Order;
        private System.Windows.Forms.TextBox TextBox_Folder;
        private System.Windows.Forms.CheckBox CheckBox_IncludeSubfolders;
        private System.Windows.Forms.Label Label_Folder;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button Button_Browse;
        private System.Windows.Forms.RadioButton RadioButton_Name;
        private System.Windows.Forms.RadioButton RadioButton_Date;
        private System.Windows.Forms.RadioButton RadioButton_Random;
        private System.Windows.Forms.RadioButton RadioButton_Shuffle;
        private System.Windows.Forms.Panel Panel_Order;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog_Folder;
    }
}