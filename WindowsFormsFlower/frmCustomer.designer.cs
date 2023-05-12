
namespace WindowsFormsFlower
{
    partial class frmCustomer
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
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.txtCusManager = new System.Windows.Forms.TextBox();
            this.txtCuslicense = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCusID = new System.Windows.Forms.TextBox();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.dgvCusMat = new System.Windows.Forms.DataGridView();
            this.txtCusSearch = new System.Windows.Forms.TextBox();
            this.btnPrSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCusCharge = new System.Windows.Forms.TextBox();
            this.txtCusPhone = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCusEmail1 = new System.Windows.Forms.TextBox();
            this.txtCusEmail2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboCusID = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboMaterialID = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnMatDelete = new System.Windows.Forms.Button();
            this.btnMatInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusMat)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.txtCusEmail2);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.txtCusEmail1);
            this.splitContainer1.Panel2.Controls.Add(this.txtCusPhone);
            this.splitContainer1.Panel2.Controls.Add(this.txtCusCharge);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnUpdate);
            this.splitContainer1.Panel2.Controls.Add(this.btnInsert);
            this.splitContainer1.Panel2.Controls.Add(this.txtCusID);
            this.splitContainer1.Panel2.Controls.Add(this.txtCusName);
            this.splitContainer1.Panel2.Controls.Add(this.txtCusManager);
            this.splitContainer1.Panel2.Controls.Add(this.txtCuslicense);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCusSearch);
            this.panel1.Controls.Add(this.btnPrSearch);
            this.panel1.Controls.SetChildIndex(this.btnPrSearch, 0);
            this.panel1.Controls.SetChildIndex(this.txtCusSearch, 0);
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvCustomer);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvCusMat);
            this.splitContainer2.Size = new System.Drawing.Size(752, 555);
            this.splitContainer2.SplitterDistance = 384;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 555);
            this.panel2.Size = new System.Drawing.Size(752, 28);
            // 
            // txtCusName
            // 
            this.txtCusName.Location = new System.Drawing.Point(97, 71);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(83, 21);
            this.txtCusName.TabIndex = 55;
            this.txtCusName.Tag = "거래처명";
            // 
            // txtCusManager
            // 
            this.txtCusManager.Location = new System.Drawing.Point(92, 158);
            this.txtCusManager.Name = "txtCusManager";
            this.txtCusManager.Size = new System.Drawing.Size(88, 21);
            this.txtCusManager.TabIndex = 56;
            this.txtCusManager.Tag = "사업자명";
            // 
            // txtCuslicense
            // 
            this.txtCuslicense.Location = new System.Drawing.Point(100, 112);
            this.txtCuslicense.Name = "txtCuslicense";
            this.txtCuslicense.Size = new System.Drawing.Size(94, 21);
            this.txtCuslicense.TabIndex = 57;
            this.txtCuslicense.Tag = "사업자 등록번호";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 12);
            this.label11.TabIndex = 48;
            this.label11.Text = "거래처 이메일";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 12);
            this.label5.TabIndex = 49;
            this.label5.Text = "거래처 연락처";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 50;
            this.label4.Text = "사업자명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 51;
            this.label3.Text = "사업자번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "거래처명";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(15, 549);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 59;
            this.btnInsert.Text = "등록";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(105, 549);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 60;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(196, 549);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 60;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 52;
            this.label2.Text = "거래처ID";
            // 
            // txtCusID
            // 
            this.txtCusID.Location = new System.Drawing.Point(97, 30);
            this.txtCusID.Name = "txtCusID";
            this.txtCusID.Size = new System.Drawing.Size(83, 21);
            this.txtCusID.TabIndex = 55;
            this.txtCusID.Tag = "거래처ID";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomer.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowTemplate.Height = 23;
            this.dgvCustomer.Size = new System.Drawing.Size(752, 384);
            this.dgvCustomer.TabIndex = 0;
            this.dgvCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellDoubleClick);
            // 
            // dgvCusMat
            // 
            this.dgvCusMat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCusMat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCusMat.Location = new System.Drawing.Point(0, 0);
            this.dgvCusMat.Name = "dgvCusMat";
            this.dgvCusMat.RowTemplate.Height = 23;
            this.dgvCusMat.Size = new System.Drawing.Size(752, 167);
            this.dgvCusMat.TabIndex = 0;
            // 
            // txtCusSearch
            // 
            this.txtCusSearch.Location = new System.Drawing.Point(12, 37);
            this.txtCusSearch.Name = "txtCusSearch";
            this.txtCusSearch.Size = new System.Drawing.Size(177, 21);
            this.txtCusSearch.TabIndex = 38;
            // 
            // btnPrSearch
            // 
            this.btnPrSearch.Location = new System.Drawing.Point(196, 36);
            this.btnPrSearch.Name = "btnPrSearch";
            this.btnPrSearch.Size = new System.Drawing.Size(95, 23);
            this.btnPrSearch.TabIndex = 37;
            this.btnPrSearch.Text = "검색";
            this.btnPrSearch.UseVisualStyleBackColor = true;
            this.btnPrSearch.Click += new System.EventHandler(this.btnPrSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 61;
            this.label6.Text = "담당자명";
            // 
            // txtCusCharge
            // 
            this.txtCusCharge.Location = new System.Drawing.Point(92, 198);
            this.txtCusCharge.Name = "txtCusCharge";
            this.txtCusCharge.Size = new System.Drawing.Size(88, 21);
            this.txtCusCharge.TabIndex = 62;
            this.txtCusCharge.Tag = "담당자명";
            // 
            // txtCusPhone
            // 
            this.txtCusPhone.BackColor = System.Drawing.Color.White;
            this.txtCusPhone.Location = new System.Drawing.Point(118, 240);
            this.txtCusPhone.Mask = "000-9000-0000";
            this.txtCusPhone.Name = "txtCusPhone";
            this.txtCusPhone.Size = new System.Drawing.Size(100, 21);
            this.txtCusPhone.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(136, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 80;
            this.label9.Text = "@";
            // 
            // txtCusEmail1
            // 
            this.txtCusEmail1.Location = new System.Drawing.Point(33, 314);
            this.txtCusEmail1.Name = "txtCusEmail1";
            this.txtCusEmail1.Size = new System.Drawing.Size(100, 21);
            this.txtCusEmail1.TabIndex = 78;
            this.txtCusEmail1.Tag = "이메일1";
            // 
            // txtCusEmail2
            // 
            this.txtCusEmail2.Location = new System.Drawing.Point(155, 314);
            this.txtCusEmail2.Name = "txtCusEmail2";
            this.txtCusEmail2.Size = new System.Drawing.Size(100, 21);
            this.txtCusEmail2.TabIndex = 81;
            this.txtCusEmail2.Tag = "이메일1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 82;
            this.label10.Text = "자재분류";
            // 
            // cboCusID
            // 
            this.cboCusID.FormattingEnabled = true;
            this.cboCusID.Location = new System.Drawing.Point(118, 22);
            this.cboCusID.Name = "cboCusID";
            this.cboCusID.Size = new System.Drawing.Size(92, 20);
            this.cboCusID.TabIndex = 87;
            this.cboCusID.SelectedIndexChanged += new System.EventHandler(this.cboCusID_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboMaterialID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnMatDelete);
            this.groupBox1.Controls.Add(this.btnMatInsert);
            this.groupBox1.Controls.Add(this.cboCusID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(11, 380);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 145);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "취급자재";
            // 
            // cboMaterialID
            // 
            this.cboMaterialID.FormattingEnabled = true;
            this.cboMaterialID.Location = new System.Drawing.Point(118, 64);
            this.cboMaterialID.Name = "cboMaterialID";
            this.cboMaterialID.Size = new System.Drawing.Size(92, 20);
            this.cboMaterialID.TabIndex = 92;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 91;
            this.label8.Text = "자재";
            // 
            // btnMatDelete
            // 
            this.btnMatDelete.Location = new System.Drawing.Point(146, 105);
            this.btnMatDelete.Name = "btnMatDelete";
            this.btnMatDelete.Size = new System.Drawing.Size(97, 23);
            this.btnMatDelete.TabIndex = 89;
            this.btnMatDelete.Text = "취급자재삭제";
            this.btnMatDelete.UseVisualStyleBackColor = true;
            this.btnMatDelete.Click += new System.EventHandler(this.btnMatDelete_Click);
            // 
            // btnMatInsert
            // 
            this.btnMatInsert.Location = new System.Drawing.Point(24, 105);
            this.btnMatInsert.Name = "btnMatInsert";
            this.btnMatInsert.Size = new System.Drawing.Size(100, 23);
            this.btnMatInsert.TabIndex = 88;
            this.btnMatInsert.Text = "취급자재추가";
            this.btnMatInsert.UseVisualStyleBackColor = true;
            this.btnMatInsert.Click += new System.EventHandler(this.btnMatInsert_Click);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1038, 649);
            this.Name = "frmCustomer";
            this.Text = "거래처 등록";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusMat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.TextBox txtCusManager;
        private System.Windows.Forms.TextBox txtCuslicense;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtCusID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.DataGridView dgvCusMat;
        private System.Windows.Forms.TextBox txtCusSearch;
        private System.Windows.Forms.Button btnPrSearch;
        private System.Windows.Forms.TextBox txtCusCharge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtCusPhone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCusEmail1;
        private System.Windows.Forms.TextBox txtCusEmail2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboCusID;
        private System.Windows.Forms.ComboBox cboMaterialID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnMatDelete;
        private System.Windows.Forms.Button btnMatInsert;
    }
}
