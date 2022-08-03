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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.PicClock = new System.Windows.Forms.PictureBox();
            this.TimerTick = new System.Windows.Forms.Timer(this.components);
            this.LabelCurrentTime = new System.Windows.Forms.Label();
            this.LabelNowAndNextInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicClock)).BeginInit();
            this.SuspendLayout();
            // 
            // PicClock
            // 
            this.PicClock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicClock.Location = new System.Drawing.Point(12, 12);
            this.PicClock.Name = "PicClock";
            this.PicClock.Size = new System.Drawing.Size(138, 138);
            this.PicClock.TabIndex = 0;
            this.PicClock.TabStop = false;
            this.PicClock.Paint += new System.Windows.Forms.PaintEventHandler(this.PicClock_Paint);
            this.PicClock.DoubleClick += new System.EventHandler(this.PicClock_DoubleClick);
            // 
            // TimerTick
            // 
            this.TimerTick.Enabled = true;
            this.TimerTick.Tick += new System.EventHandler(this.TimerTick_Tick);
            // 
            // LabelCurrentTime
            // 
            this.LabelCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelCurrentTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelCurrentTime.Location = new System.Drawing.Point(162, 15);
            this.LabelCurrentTime.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.LabelCurrentTime.Name = "LabelCurrentTime";
            this.LabelCurrentTime.Size = new System.Drawing.Size(311, 19);
            this.LabelCurrentTime.TabIndex = 1;
            this.LabelCurrentTime.Text = "LabelCurrentTime";
            this.LabelCurrentTime.DoubleClick += new System.EventHandler(this.LabelCurrentTime_DoubleClick);
            // 
            // LabelNowAndNextInfo
            // 
            this.LabelNowAndNextInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelNowAndNextInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelNowAndNextInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelNowAndNextInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelNowAndNextInfo.Location = new System.Drawing.Point(162, 40);
            this.LabelNowAndNextInfo.Margin = new System.Windows.Forms.Padding(9, 0, 3, 0);
            this.LabelNowAndNextInfo.Name = "LabelNowAndNextInfo";
            this.LabelNowAndNextInfo.Padding = new System.Windows.Forms.Padding(4);
            this.LabelNowAndNextInfo.Size = new System.Drawing.Size(311, 110);
            this.LabelNowAndNextInfo.TabIndex = 2;
            this.LabelNowAndNextInfo.Text = "Now";
            this.LabelNowAndNextInfo.DoubleClick += new System.EventHandler(this.LabelNowAndNextInfo_DoubleClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 161);
            this.Controls.Add(this.LabelNowAndNextInfo);
            this.Controls.Add(this.LabelCurrentTime);
            this.Controls.Add(this.PicClock);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Now & Next";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.DoubleClick += new System.EventHandler(this.FrmMain_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.PicClock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PicClock;
        private System.Windows.Forms.Timer TimerTick;
        private Label LabelCurrentTime;
        private Label LabelNowAndNextInfo;
    }
}