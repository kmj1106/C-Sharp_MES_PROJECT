
namespace WindowsFormsFlower
{
    partial class frmUser
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
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUserPhone = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserEmail1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserPwdDetail = new System.Windows.Forms.TextBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserEmail2 = new System.Windows.Forms.TextBox();
            this.zipControl1 = new WindowsFormsFlower.ZipControl();
            this.dtpUserBirth = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(104, 288);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 16);
            this.label17.TabIndex = 65;
            this.label17.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(104, 148);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 16);
            this.label15.TabIndex = 63;
            this.label15.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(104, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 16);
            this.label14.TabIndex = 62;
            this.label14.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(104, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 16);
            this.label13.TabIndex = 61;
            this.label13.Text = "*";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(275, 443);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(150, 52);
            this.btnInsert.TabIndex = 48;
            this.btnInsert.Text = "회원가입";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(104, 422);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 16);
            this.label11.TabIndex = 60;
            this.label11.Text = "*";
            // 
            // txtUserPhone
            // 
            this.txtUserPhone.BackColor = System.Drawing.Color.White;
            this.txtUserPhone.Location = new System.Drawing.Point(130, 421);
            this.txtUserPhone.Mask = "000-9000-0000";
            this.txtUserPhone.Name = "txtUserPhone";
            this.txtUserPhone.Size = new System.Drawing.Size(100, 21);
            this.txtUserPhone.TabIndex = 47;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 426);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 59;
            this.label12.Text = "핸드폰번호";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(130, 33);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(144, 21);
            this.txtUserID.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(61, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 12);
            this.label10.TabIndex = 58;
            this.label10.Text = "회원 ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 54;
            this.label8.Text = "생년월일";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 53;
            this.label6.Text = "이메일";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "성별";
            // 
            // txtUserEmail1
            // 
            this.txtUserEmail1.Location = new System.Drawing.Point(130, 285);
            this.txtUserEmail1.Name = "txtUserEmail1";
            this.txtUserEmail1.Size = new System.Drawing.Size(100, 21);
            this.txtUserEmail1.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 51;
            this.label2.Text = "회원 주소";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(130, 145);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 50;
            this.label1.Text = "이름";
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(130, 69);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(144, 21);
            this.txtUserPwd.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 49;
            this.label7.Text = "비밀번호";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(285, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 21);
            this.button2.TabIndex = 70;
            this.button2.Text = "중복확인\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(104, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 73;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 12);
            this.label4.TabIndex = 72;
            this.label4.Text = "비밀번호 확인";
            // 
            // txtUserPwdDetail
            // 
            this.txtUserPwdDetail.Location = new System.Drawing.Point(130, 103);
            this.txtUserPwdDetail.Name = "txtUserPwdDetail";
            this.txtUserPwdDetail.PasswordChar = '*';
            this.txtUserPwdDetail.Size = new System.Drawing.Size(144, 21);
            this.txtUserPwdDetail.TabIndex = 74;
            // 
            // cboGender
            // 
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "남",
            "여"});
            this.cboGender.Location = new System.Drawing.Point(130, 374);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(57, 20);
            this.cboGender.TabIndex = 75;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(104, 189);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 16);
            this.label16.TabIndex = 64;
            this.label16.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 77;
            this.label9.Text = "@";
            // 
            // txtUserEmail2
            // 
            this.txtUserEmail2.Location = new System.Drawing.Point(254, 285);
            this.txtUserEmail2.Name = "txtUserEmail2";
            this.txtUserEmail2.Size = new System.Drawing.Size(114, 21);
            this.txtUserEmail2.TabIndex = 79;
            // 
            // zipControl1
            // 
            this.zipControl1.Address1 = "";
            this.zipControl1.Address2 = "";
            this.zipControl1.Location = new System.Drawing.Point(126, 186);
            this.zipControl1.Name = "zipControl1";
            this.zipControl1.Size = new System.Drawing.Size(257, 84);
            this.zipControl1.TabIndex = 76;
            this.zipControl1.ZipCode = "";
            // 
            // dtpUserBirth
            // 
            this.dtpUserBirth.Location = new System.Drawing.Point(128, 329);
            this.dtpUserBirth.Name = "dtpUserBirth";
            this.dtpUserBirth.Size = new System.Drawing.Size(115, 21);
            this.dtpUserBirth.TabIndex = 80;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 524);
            this.Controls.Add(this.dtpUserBirth);
            this.Controls.Add(this.txtUserEmail2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.zipControl1);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.txtUserPwdDetail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtUserPhone);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserEmail1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.label7);
            this.Name = "frmUser";
            this.Text = "회원가입";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtUserPhone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserEmail1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserPwdDetail;
        private System.Windows.Forms.ComboBox cboGender;
        private ZipControl zipControl1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserEmail2;
        private System.Windows.Forms.DateTimePicker dtpUserBirth;
    }
}