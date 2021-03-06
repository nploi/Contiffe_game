﻿namespace GameShow
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.lbCountDown = new System.Windows.Forms.Label();
            this.lbNotifications = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.pLive = new System.Windows.Forms.PictureBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnChat = new System.Windows.Forms.Button();
            this.tbChat = new System.Windows.Forms.TextBox();
            this.lblCorrect = new System.Windows.Forms.Label();
            this.lblAward = new System.Windows.Forms.Label();
            this.btnLive = new System.Windows.Forms.Button();
            this.lblNumberQuestion = new System.Windows.Forms.Label();
            this.lbNumberCorrectWrong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pLive)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(6, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(771, 43);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Player";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.Color.White;
            this.btnA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA.Location = new System.Drawing.Point(74, 332);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(193, 25);
            this.btnA.TabIndex = 3;
            this.btnA.Text = "A";
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // btnB
            // 
            this.btnB.BackColor = System.Drawing.Color.White;
            this.btnB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnB.Location = new System.Drawing.Point(287, 332);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(188, 25);
            this.btnB.TabIndex = 4;
            this.btnB.Text = "B";
            this.btnB.UseVisualStyleBackColor = false;
            this.btnB.Click += new System.EventHandler(this.btnB_Click);
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.Color.White;
            this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC.Location = new System.Drawing.Point(74, 367);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(193, 25);
            this.btnC.TabIndex = 5;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = false;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnD
            // 
            this.btnD.BackColor = System.Drawing.Color.White;
            this.btnD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnD.Location = new System.Drawing.Point(287, 367);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(188, 25);
            this.btnD.TabIndex = 6;
            this.btnD.Text = "D";
            this.btnD.UseVisualStyleBackColor = false;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // lbCountDown
            // 
            this.lbCountDown.AutoSize = true;
            this.lbCountDown.BackColor = System.Drawing.Color.Transparent;
            this.lbCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountDown.ForeColor = System.Drawing.Color.White;
            this.lbCountDown.Location = new System.Drawing.Point(243, 54);
            this.lbCountDown.Name = "lbCountDown";
            this.lbCountDown.Size = new System.Drawing.Size(0, 37);
            this.lbCountDown.TabIndex = 10;
            // 
            // lbNotifications
            // 
            this.lbNotifications.FormattingEnabled = true;
            this.lbNotifications.Location = new System.Drawing.Point(549, 65);
            this.lbNotifications.Name = "lbNotifications";
            this.lbNotifications.Size = new System.Drawing.Size(209, 264);
            this.lbNotifications.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Notifications";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.Color.White;
            this.lblNumber.Location = new System.Drawing.Point(74, 59);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(66, 17);
            this.lblNumber.TabIndex = 13;
            this.lblNumber.Text = "0 players";
            // 
            // pLive
            // 
            this.pLive.BackColor = System.Drawing.Color.Transparent;
            this.pLive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pLive.BackgroundImage")));
            this.pLive.Location = new System.Drawing.Point(5, 49);
            this.pLive.Name = "pLive";
            this.pLive.Size = new System.Drawing.Size(537, 348);
            this.pLive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pLive.TabIndex = 15;
            this.pLive.TabStop = false;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.BackColor = System.Drawing.Color.White;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.ForeColor = System.Drawing.Color.Black;
            this.lblQuestion.Location = new System.Drawing.Point(86, 272);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(0, 18);
            this.lblQuestion.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // btnChat
            // 
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.Location = new System.Drawing.Point(618, 371);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(75, 23);
            this.btnChat.TabIndex = 17;
            this.btnChat.Text = "Send";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // tbChat
            // 
            this.tbChat.Location = new System.Drawing.Point(549, 337);
            this.tbChat.Name = "tbChat";
            this.tbChat.Size = new System.Drawing.Size(209, 20);
            this.tbChat.TabIndex = 18;
            // 
            // lblCorrect
            // 
            this.lblCorrect.AutoSize = true;
            this.lblCorrect.BackColor = System.Drawing.Color.Transparent;
            this.lblCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrect.ForeColor = System.Drawing.Color.White;
            this.lblCorrect.Location = new System.Drawing.Point(422, 88);
            this.lblCorrect.Name = "lblCorrect";
            this.lblCorrect.Size = new System.Drawing.Size(0, 18);
            this.lblCorrect.TabIndex = 19;
            // 
            // lblAward
            // 
            this.lblAward.AutoSize = true;
            this.lblAward.BackColor = System.Drawing.Color.Transparent;
            this.lblAward.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAward.ForeColor = System.Drawing.Color.White;
            this.lblAward.Location = new System.Drawing.Point(422, 54);
            this.lblAward.Name = "lblAward";
            this.lblAward.Size = new System.Drawing.Size(0, 18);
            this.lblAward.TabIndex = 20;
            // 
            // btnLive
            // 
            this.btnLive.BackColor = System.Drawing.Color.Gray;
            this.btnLive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLive.ForeColor = System.Drawing.Color.White;
            this.btnLive.Location = new System.Drawing.Point(12, 54);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(56, 26);
            this.btnLive.TabIndex = 29;
            this.btnLive.Text = "LIVE";
            this.btnLive.UseVisualStyleBackColor = false;
            // 
            // lblNumberQuestion
            // 
            this.lblNumberQuestion.AutoSize = true;
            this.lblNumberQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberQuestion.ForeColor = System.Drawing.Color.White;
            this.lblNumberQuestion.Location = new System.Drawing.Point(9, 272);
            this.lblNumberQuestion.Name = "lblNumberQuestion";
            this.lblNumberQuestion.Size = new System.Drawing.Size(0, 18);
            this.lblNumberQuestion.TabIndex = 30;
            // 
            // lbNumberCorrectWrong
            // 
            this.lbNumberCorrectWrong.AutoSize = true;
            this.lbNumberCorrectWrong.BackColor = System.Drawing.Color.Transparent;
            this.lbNumberCorrectWrong.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumberCorrectWrong.ForeColor = System.Drawing.Color.White;
            this.lbNumberCorrectWrong.Location = new System.Drawing.Point(10, 101);
            this.lbNumberCorrectWrong.Name = "lbNumberCorrectWrong";
            this.lbNumberCorrectWrong.Size = new System.Drawing.Size(0, 19);
            this.lbNumberCorrectWrong.TabIndex = 31;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 404);
            this.Controls.Add(this.lbNumberCorrectWrong);
            this.Controls.Add(this.lblNumberQuestion);
            this.Controls.Add(this.btnLive);
            this.Controls.Add(this.lblAward);
            this.Controls.Add(this.lblCorrect);
            this.Controls.Add(this.tbChat);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.lbNotifications);
            this.Controls.Add(this.lbCountDown);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pLive);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "CONFETTI GAMESHOW";
            ((System.ComponentModel.ISupportInitialize)(this.pLive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Label lbCountDown;
        private System.Windows.Forms.ListBox lbNotifications;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.PictureBox pLive;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.TextBox tbChat;
        private System.Windows.Forms.Label lblCorrect;
        private System.Windows.Forms.Label lblAward;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.Label lblNumberQuestion;
        private System.Windows.Forms.Label lbNumberCorrectWrong;
    }
}

