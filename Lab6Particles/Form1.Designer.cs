namespace Lab6Particles
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.DirectionTrackBar = new System.Windows.Forms.TrackBar();
            this.ForceTrackBar = new System.Windows.Forms.TrackBar();
            this.AutoPlayCheck = new System.Windows.Forms.CheckBox();
            this.ShowPointsCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DirectionTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForceTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(2, 3);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(1534, 556);
            this.picDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            // 
            // DirectionTrackBar
            // 
            this.DirectionTrackBar.Location = new System.Drawing.Point(2, 574);
            this.DirectionTrackBar.Maximum = 200;
            this.DirectionTrackBar.Minimum = -200;
            this.DirectionTrackBar.Name = "DirectionTrackBar";
            this.DirectionTrackBar.Size = new System.Drawing.Size(170, 56);
            this.DirectionTrackBar.TabIndex = 10;
            this.DirectionTrackBar.TickFrequency = 50;
            this.DirectionTrackBar.Scroll += new System.EventHandler(this.DirectionTrackBar_Scroll);
            // 
            // ForceTrackBar
            // 
            this.ForceTrackBar.Location = new System.Drawing.Point(225, 574);
            this.ForceTrackBar.Maximum = 350;
            this.ForceTrackBar.Minimum = -350;
            this.ForceTrackBar.Name = "ForceTrackBar";
            this.ForceTrackBar.Size = new System.Drawing.Size(170, 56);
            this.ForceTrackBar.TabIndex = 12;
            this.ForceTrackBar.TickFrequency = 10;
            this.ForceTrackBar.Scroll += new System.EventHandler(this.ForceTrackBar_Scroll);
            // 
            // AutoPlayCheck
            // 
            this.AutoPlayCheck.AutoSize = true;
            this.AutoPlayCheck.Location = new System.Drawing.Point(685, 590);
            this.AutoPlayCheck.Name = "AutoPlayCheck";
            this.AutoPlayCheck.Size = new System.Drawing.Size(105, 20);
            this.AutoPlayCheck.TabIndex = 13;
            this.AutoPlayCheck.Text = "Автоиграть";
            this.AutoPlayCheck.UseVisualStyleBackColor = true;
            this.AutoPlayCheck.CheckedChanged += new System.EventHandler(this.AutoPlayCheck_CheckedChanged);
            // 
            // ShowPointsCheck
            // 
            this.ShowPointsCheck.AutoSize = true;
            this.ShowPointsCheck.Location = new System.Drawing.Point(685, 622);
            this.ShowPointsCheck.Name = "ShowPointsCheck";
            this.ShowPointsCheck.Size = new System.Drawing.Size(150, 20);
            this.ShowPointsCheck.TabIndex = 14;
            this.ShowPointsCheck.Text = "Показывать точки";
            this.ShowPointsCheck.UseVisualStyleBackColor = true;
            this.ShowPointsCheck.CheckedChanged += new System.EventHandler(this.ShowPointsCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 654);
            this.Controls.Add(this.ShowPointsCheck);
            this.Controls.Add(this.AutoPlayCheck);
            this.Controls.Add(this.ForceTrackBar);
            this.Controls.Add(this.DirectionTrackBar);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DirectionTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForceTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar DirectionTrackBar;
        private System.Windows.Forms.TrackBar ForceTrackBar;
        private System.Windows.Forms.CheckBox AutoPlayCheck;
        private System.Windows.Forms.CheckBox ShowPointsCheck;
    }
}

