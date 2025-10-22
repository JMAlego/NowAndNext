namespace NowAndNext
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            PicClock = new PictureBox();
            TimerTick = new System.Windows.Forms.Timer(components);
            LabelCurrentTime = new Label();
            LabelNowAndNextInfo = new Label();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)PicClock).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // PicClock
            // 
            PicClock.Location = new Point(14, 16);
            PicClock.Margin = new Padding(3, 4, 3, 4);
            PicClock.Name = "PicClock";
            PicClock.Size = new Size(158, 184);
            PicClock.TabIndex = 0;
            PicClock.TabStop = false;
            PicClock.Paint += PicClock_Paint;
            PicClock.DoubleClick += PicClock_DoubleClick;
            // 
            // TimerTick
            // 
            TimerTick.Enabled = true;
            TimerTick.Tick += TimerTick_Tick;
            // 
            // LabelCurrentTime
            // 
            LabelCurrentTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelCurrentTime.Font = new Font("Segoe UI", 9.75F);
            LabelCurrentTime.Location = new Point(185, 20);
            LabelCurrentTime.Margin = new Padding(3, 8, 3, 8);
            LabelCurrentTime.Name = "LabelCurrentTime";
            LabelCurrentTime.Size = new Size(355, 25);
            LabelCurrentTime.TabIndex = 1;
            LabelCurrentTime.Text = "LabelCurrentTime";
            LabelCurrentTime.DoubleClick += LabelCurrentTime_DoubleClick;
            // 
            // LabelNowAndNextInfo
            // 
            LabelNowAndNextInfo.AutoSize = true;
            LabelNowAndNextInfo.BackColor = SystemColors.ControlLightLight;
            LabelNowAndNextInfo.Font = new Font("Segoe UI", 9.75F);
            LabelNowAndNextInfo.Location = new Point(5, 5);
            LabelNowAndNextInfo.Margin = new Padding(10, 0, 3, 0);
            LabelNowAndNextInfo.Name = "LabelNowAndNextInfo";
            LabelNowAndNextInfo.Size = new Size(45, 23);
            LabelNowAndNextInfo.TabIndex = 2;
            LabelNowAndNextInfo.Text = "Now";
            LabelNowAndNextInfo.UseMnemonic = false;
            LabelNowAndNextInfo.DoubleClick += LabelNowAndNextInfo_DoubleClick;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(LabelNowAndNextInfo);
            panel1.Location = new Point(185, 53);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5, 5, 5, 5);
            panel1.Size = new Size(355, 146);
            panel1.TabIndex = 3;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(461, 20);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(79, 24);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "On Top";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 215);
            Controls.Add(panel1);
            Controls.Add(checkBox1);
            Controls.Add(LabelCurrentTime);
            Controls.Add(PicClock);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(570, 251);
            Name = "FrmMain";
            Text = "Now & Next";
            TopMost = true;
            Load += FrmMain_Load;
            DoubleClick += FrmMain_DoubleClick;
            ((System.ComponentModel.ISupportInitialize)PicClock).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private PictureBox PicClock;
        private System.Windows.Forms.Timer TimerTick;
        private Label LabelCurrentTime;
        private Label LabelNowAndNextInfo;
        private Panel panel1;
        private CheckBox checkBox1;
    }
}