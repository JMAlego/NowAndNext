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
            ((System.ComponentModel.ISupportInitialize)PicClock).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // PicClock
            // 
            PicClock.Location = new Point(12, 12);
            PicClock.Name = "PicClock";
            PicClock.Size = new Size(138, 138);
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
            LabelCurrentTime.Location = new Point(162, 15);
            LabelCurrentTime.Margin = new Padding(3, 6, 3, 6);
            LabelCurrentTime.Name = "LabelCurrentTime";
            LabelCurrentTime.Size = new Size(311, 19);
            LabelCurrentTime.TabIndex = 1;
            LabelCurrentTime.Text = "LabelCurrentTime";
            LabelCurrentTime.DoubleClick += LabelCurrentTime_DoubleClick;
            // 
            // LabelNowAndNextInfo
            // 
            LabelNowAndNextInfo.AutoSize = true;
            LabelNowAndNextInfo.BackColor = SystemColors.ControlLightLight;
            LabelNowAndNextInfo.Font = new Font("Segoe UI", 9.75F);
            LabelNowAndNextInfo.Location = new Point(4, 4);
            LabelNowAndNextInfo.Margin = new Padding(9, 0, 3, 0);
            LabelNowAndNextInfo.Name = "LabelNowAndNextInfo";
            LabelNowAndNextInfo.Size = new Size(35, 17);
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
            panel1.Location = new Point(162, 40);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(4);
            panel1.Size = new Size(311, 110);
            panel1.TabIndex = 3;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 161);
            Controls.Add(panel1);
            Controls.Add(LabelCurrentTime);
            Controls.Add(PicClock);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(501, 200);
            Name = "FrmMain";
            Text = "Now & Next";
            TopMost = true;
            Load += FrmMain_Load;
            DoubleClick += FrmMain_DoubleClick;
            ((System.ComponentModel.ISupportInitialize)PicClock).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private PictureBox PicClock;
        private System.Windows.Forms.Timer TimerTick;
        private Label LabelCurrentTime;
        private Label LabelNowAndNextInfo;
        private Panel panel1;
    }
}