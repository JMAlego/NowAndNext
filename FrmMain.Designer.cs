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
            TextBoxUpcomingMeetings = new TextBox();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)PicClock).BeginInit();
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
            LabelCurrentTime.Font = new Font("Segoe UI", 9.75F);
            LabelCurrentTime.Location = new Point(175, 15);
            LabelCurrentTime.Margin = new Padding(3, 6, 3, 6);
            LabelCurrentTime.Name = "LabelCurrentTime";
            LabelCurrentTime.Size = new Size(298, 19);
            LabelCurrentTime.TabIndex = 1;
            LabelCurrentTime.Text = "LabelCurrentTime";
            LabelCurrentTime.DoubleClick += LabelCurrentTime_DoubleClick;
            // 
            // TextBoxUpcomingMeetings
            // 
            TextBoxUpcomingMeetings.AcceptsReturn = true;
            TextBoxUpcomingMeetings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxUpcomingMeetings.BorderStyle = BorderStyle.FixedSingle;
            TextBoxUpcomingMeetings.Location = new Point(175, 42);
            TextBoxUpcomingMeetings.Multiline = true;
            TextBoxUpcomingMeetings.Name = "TextBoxUpcomingMeetings";
            TextBoxUpcomingMeetings.ReadOnly = true;
            TextBoxUpcomingMeetings.ScrollBars = ScrollBars.Both;
            TextBoxUpcomingMeetings.ShortcutsEnabled = false;
            TextBoxUpcomingMeetings.Size = new Size(297, 108);
            TextBoxUpcomingMeetings.TabIndex = 2;
            TextBoxUpcomingMeetings.WordWrap = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(435, 20);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(79, 24);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "On Top";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 161);
            Controls.Add(checkBox1);
            Controls.Add(TextBoxUpcomingMeetings);
            Controls.Add(LabelCurrentTime);
            Controls.Add(PicClock);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(178, 200);
            Name = "FrmMain";
            Text = "Now & Next";
            TopMost = true;
            Load += FrmMain_Load;
            DoubleClick += FrmMain_DoubleClick;
            ((System.ComponentModel.ISupportInitialize)PicClock).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private PictureBox PicClock;
        private System.Windows.Forms.Timer TimerTick;
        private Label LabelCurrentTime;
        private TextBox TextBoxUpcomingMeetings;
        private CheckBox checkBox1;
    }
}