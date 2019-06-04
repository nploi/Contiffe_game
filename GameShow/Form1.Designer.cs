namespace GameShow
{
    partial class Form1
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbCountDown = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(537, 369);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(758, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(33, 333);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(193, 23);
            this.btnA.TabIndex = 3;
            this.btnA.Text = "A";
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // btnB
            // 
            this.btnB.Location = new System.Drawing.Point(272, 333);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(188, 23);
            this.btnB.TabIndex = 4;
            this.btnB.Text = "B";
            this.btnB.UseVisualStyleBackColor = true;
            this.btnB.Click += new System.EventHandler(this.btnB_Click);
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(33, 362);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(193, 23);
            this.btnC.TabIndex = 5;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnD
            // 
            this.btnD.Location = new System.Drawing.Point(272, 362);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(188, 23);
            this.btnD.TabIndex = 6;
            this.btnD.Text = "D";
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(636, 369);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(339, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 106);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // lbCountDown
            // 
            this.lbCountDown.AutoSize = true;
            this.lbCountDown.BackColor = System.Drawing.SystemColors.Control;
            this.lbCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountDown.ForeColor = System.Drawing.Color.White;
            this.lbCountDown.Location = new System.Drawing.Point(265, 54);
            this.lbCountDown.Name = "lbCountDown";
            this.lbCountDown.Size = new System.Drawing.Size(53, 37);
            this.lbCountDown.TabIndex = 10;
            this.lbCountDown.Text = "10";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(535, 104);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(209, 212);
            this.listBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(672, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Notification";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(571, 51);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(100, 26);
            this.lblNumber.TabIndex = 13;
            this.lblNumber.Text = "0 players";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(-23, -46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox3.Location = new System.Drawing.Point(6, 46);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(513, 346);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.ForeColor = System.Drawing.Color.White;
            this.lblQuestion.Location = new System.Drawing.Point(29, 296);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(51, 20);
            this.lblQuestion.TabIndex = 16;
            this.lblQuestion.Text = "label3";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 404);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbCountDown);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.pictureBox3);
            this.Name = "Form1";
            this.Text = "Game Show";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbCountDown;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Timer timer1;
    }
}

