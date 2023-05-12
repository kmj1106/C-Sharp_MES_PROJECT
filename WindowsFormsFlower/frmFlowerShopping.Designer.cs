
namespace WindowsFormsFlower
{
    partial class frmFlowerShopping
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox35 = new System.Windows.Forms.PictureBox();
            this.label146 = new System.Windows.Forms.Label();
            this.button35 = new System.Windows.Forms.Button();
            this.label137 = new System.Windows.Forms.Label();
            this.textBox103 = new System.Windows.Forms.TextBox();
            this.label138 = new System.Windows.Forms.Label();
            this.textBox104 = new System.Windows.Forms.TextBox();
            this.label139 = new System.Windows.Forms.Label();
            this.textBox105 = new System.Windows.Forms.TextBox();
            this.label140 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox35)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.pictureBox35);
            this.panel2.Controls.Add(this.label146);
            this.panel2.Controls.Add(this.button35);
            this.panel2.Controls.Add(this.label137);
            this.panel2.Controls.Add(this.textBox103);
            this.panel2.Controls.Add(this.label138);
            this.panel2.Controls.Add(this.textBox104);
            this.panel2.Controls.Add(this.label139);
            this.panel2.Controls.Add(this.textBox105);
            this.panel2.Controls.Add(this.label140);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(305, 110);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(167, 21);
            this.numericUpDown1.TabIndex = 36;
            // 
            // pictureBox35
            // 
            this.pictureBox35.Location = new System.Drawing.Point(6, 9);
            this.pictureBox35.Name = "pictureBox35";
            this.pictureBox35.Size = new System.Drawing.Size(238, 194);
            this.pictureBox35.TabIndex = 35;
            this.pictureBox35.TabStop = false;
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Location = new System.Drawing.Point(270, 112);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(29, 12);
            this.label146.TabIndex = 34;
            this.label146.Text = "수량";
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(352, 359);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(120, 26);
            this.button35.TabIndex = 33;
            this.button35.Text = "장바구니";
            this.button35.UseVisualStyleBackColor = true;
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(4, 212);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(29, 12);
            this.label137.TabIndex = 32;
            this.label137.Text = "정보";
            // 
            // textBox103
            // 
            this.textBox103.Location = new System.Drawing.Point(39, 209);
            this.textBox103.Multiline = true;
            this.textBox103.Name = "textBox103";
            this.textBox103.Size = new System.Drawing.Size(433, 142);
            this.textBox103.TabIndex = 31;
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(-1, 110);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(0, 12);
            this.label138.TabIndex = 30;
            // 
            // textBox104
            // 
            this.textBox104.Location = new System.Drawing.Point(305, 66);
            this.textBox104.Name = "textBox104";
            this.textBox104.Size = new System.Drawing.Size(167, 21);
            this.textBox104.TabIndex = 29;
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(270, 69);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(29, 12);
            this.label139.TabIndex = 28;
            this.label139.Text = "가격";
            // 
            // textBox105
            // 
            this.textBox105.Location = new System.Drawing.Point(305, 21);
            this.textBox105.Name = "textBox105";
            this.textBox105.Size = new System.Drawing.Size(167, 21);
            this.textBox105.TabIndex = 27;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(258, 24);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(41, 12);
            this.label140.TabIndex = 26;
            this.label140.Text = "품목명";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 21);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 21);
            this.button1.TabIndex = 5;
            this.button1.Text = "검색";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmFlowerShopping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(804, 443);
            this.Name = "frmFlowerShopping";
            this.Text = "쇼핑창";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox35)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox pictureBox35;
        private System.Windows.Forms.Label label146;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Label label137;
        private System.Windows.Forms.TextBox textBox103;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.TextBox textBox104;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.TextBox textBox105;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
