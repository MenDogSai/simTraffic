namespace simTraffic
{
    partial class mainForm
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
            settingButton = new Button();
            startButton = new Button();
            SuspendLayout();
            // 
            // settingButton
            // 
            settingButton.Location = new Point(12, 12);
            settingButton.Name = "settingButton";
            settingButton.Size = new Size(75, 23);
            settingButton.TabIndex = 0;
            settingButton.Text = "설정";
            settingButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            startButton.Location = new Point(93, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 1;
            startButton.Text = "시작";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButtonClick;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(173, 43);
            Controls.Add(startButton);
            Controls.Add(settingButton);
            Name = "mainForm";
            Text = "simTraffic";
            ResumeLayout(false);
        }

        #endregion

        private Button settingButton;
        private Button startButton;
    }
}