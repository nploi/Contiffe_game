namespace GameShowMC
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblName = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.rtbQuestion = new System.Windows.Forms.RichTextBox();
            this.tbA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbD = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbNotifications = new System.Windows.Forms.ListBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.btnLiveStreaming = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.lblQuestionNumber = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbChat = new System.Windows.Forms.TextBox();
            this.btnChat = new System.Windows.Forms.Button();
            this.lblCountDowrn = new System.Windows.Forms.Label();
            this.btnLive = new System.Windows.Forms.Button();
            this.lbAward = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(1111, 50);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "MC";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(7, 14);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(87, 27);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // rtbQuestion
            // 
            this.rtbQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbQuestion.Location = new System.Drawing.Point(33, 214);
            this.rtbQuestion.Name = "rtbQuestion";
            this.rtbQuestion.Size = new System.Drawing.Size(206, 80);
            this.rtbQuestion.TabIndex = 4;
            this.rtbQuestion.Text = "";
            // 
            // tbA
            // 
            this.tbA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbA.Location = new System.Drawing.Point(33, 308);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(206, 21);
            this.tbA.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "B";
            // 
            // tbB
            // 
            this.tbB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbB.Location = new System.Drawing.Point(33, 338);
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(206, 21);
            this.tbB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "C";
            // 
            // tbC
            // 
            this.tbC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbC.Location = new System.Drawing.Point(33, 364);
            this.tbC.Name = "tbC";
            this.tbC.Size = new System.Drawing.Size(206, 21);
            this.tbC.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "D";
            // 
            // tbD
            // 
            this.tbD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbD.Location = new System.Drawing.Point(33, 396);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(206, 21);
            this.tbD.TabIndex = 11;
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(85, 423);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(87, 27);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Send";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbNotifications
            // 
            this.lbNotifications.BackColor = System.Drawing.SystemColors.Control;
            this.lbNotifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotifications.ForeColor = System.Drawing.Color.Black;
            this.lbNotifications.FormattingEnabled = true;
            this.lbNotifications.Location = new System.Drawing.Point(854, 77);
            this.lbNotifications.Name = "lbNotifications";
            this.lbNotifications.Size = new System.Drawing.Size(252, 301);
            this.lbNotifications.TabIndex = 17;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.Color.White;
            this.lblNumber.Location = new System.Drawing.Point(346, 65);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(66, 17);
            this.lblNumber.TabIndex = 18;
            this.lblNumber.Text = "0 players";
            // 
            // btnLiveStreaming
            // 
            this.btnLiveStreaming.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLiveStreaming.Enabled = false;
            this.btnLiveStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiveStreaming.Location = new System.Drawing.Point(257, 14);
            this.btnLiveStreaming.Name = "btnLiveStreaming";
            this.btnLiveStreaming.Size = new System.Drawing.Size(99, 27);
            this.btnLiveStreaming.TabIndex = 20;
            this.btnLiveStreaming.Text = "Streaming";
            this.btnLiveStreaming.UseVisualStyleBackColor = true;
            this.btnLiveStreaming.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(264, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(584, 407);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Enabled = false;
            this.btnLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadFile.Location = new System.Drawing.Point(124, 14);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(106, 27);
            this.btnLoadFile.TabIndex = 22;
            this.btnLoadFile.Text = "Load question";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.AutoSize = true;
            this.lblQuestionNumber.Location = new System.Drawing.Point(100, 196);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(56, 15);
            this.lblQuestionNumber.TabIndex = 23;
            this.lblQuestionNumber.Text = "Question";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(932, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Notifications";
            // 
            // tbChat
            // 
            this.tbChat.Location = new System.Drawing.Point(854, 388);
            this.tbChat.Name = "tbChat";
            this.tbChat.Size = new System.Drawing.Size(251, 21);
            this.tbChat.TabIndex = 25;
            // 
            // btnChat
            // 
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.Location = new System.Drawing.Point(936, 418);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(87, 27);
            this.btnChat.TabIndex = 26;
            this.btnChat.Text = "Send";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // lblCountDowrn
            // 
            this.lblCountDowrn.AutoSize = true;
            this.lblCountDowrn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDowrn.Location = new System.Drawing.Point(115, 159);
            this.lblCountDowrn.Name = "lblCountDowrn";
            this.lblCountDowrn.Size = new System.Drawing.Size(0, 20);
            this.lblCountDowrn.TabIndex = 27;
            // 
            // btnLive
            // 
            this.btnLive.BackColor = System.Drawing.Color.Gray;
            this.btnLive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLive.ForeColor = System.Drawing.Color.White;
            this.btnLive.Location = new System.Drawing.Point(273, 59);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(65, 30);
            this.btnLive.TabIndex = 28;
            this.btnLive.Text = "LIVE";
            this.btnLive.UseVisualStyleBackColor = false;
            // 
            // lbAward
            // 
            this.lbAward.AutoSize = true;
            this.lbAward.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAward.Location = new System.Drawing.Point(36, 59);
            this.lbAward.Name = "lbAward";
            this.lbAward.Size = new System.Drawing.Size(0, 22);
            this.lbAward.TabIndex = 29;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 469);
            this.Controls.Add(this.lbAward);
            this.Controls.Add(this.btnLive);
            this.Controls.Add(this.lblCountDowrn);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.tbChat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblQuestionNumber);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnLiveStreaming);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lbNotifications);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbA);
            this.Controls.Add(this.rtbQuestion);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "CONFETTI GAMESHOW";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox rtbQuestion;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ListBox lbNotifications;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Button btnLiveStreaming;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Label lblQuestionNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbChat;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Label lblCountDowrn;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.Label lbAward;
    }
}

