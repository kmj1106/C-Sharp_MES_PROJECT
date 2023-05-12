
namespace WindowsFormsFlower
{
    partial class frmFowardReverse
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvFR = new System.Windows.Forms.DataGridView();
            this.lblFRSel = new System.Windows.Forms.Label();
            this.cboFR = new System.Windows.Forms.ComboBox();
            this.btnFRSearch = new System.Windows.Forms.Button();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProdNamemain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProdCodeMain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ptbProd = new System.Windows.Forms.PictureBox();
            this.dgvFRInfo = new System.Windows.Forms.DataGridView();
            this.dgvRVInfo = new System.Windows.Forms.DataGridView();
            this.dgvRV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFRInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRVInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRV)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Size = new System.Drawing.Size(1183, 619);
            this.splitContainer1.SplitterDistance = 79;
            // 
            // splitContainer3
            // 
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnFRSearch);
            this.splitContainer3.Panel2.Controls.Add(this.cboFR);
            this.splitContainer3.Panel2.Controls.Add(this.lblFRSel);
            this.splitContainer3.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer3.Size = new System.Drawing.Size(1183, 79);
            this.splitContainer3.SplitterDistance = 38;
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvRV);
            this.splitContainer2.Panel1.Controls.Add(this.dgvFR);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(1183, 536);
            this.splitContainer2.SplitterDistance = 335;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1105, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvFR
            // 
            this.dgvFR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFR.Location = new System.Drawing.Point(0, 0);
            this.dgvFR.MaximumSize = new System.Drawing.Size(296, 472);
            this.dgvFR.Name = "dgvFR";
            this.dgvFR.RowTemplate.Height = 23;
            this.dgvFR.Size = new System.Drawing.Size(296, 472);
            this.dgvFR.TabIndex = 0;
            this.dgvFR.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFR_CellDoubleClick);
            // 
            // lblFRSel
            // 
            this.lblFRSel.AutoSize = true;
            this.lblFRSel.Location = new System.Drawing.Point(12, 7);
            this.lblFRSel.Name = "lblFRSel";
            this.lblFRSel.Size = new System.Drawing.Size(59, 12);
            this.lblFRSel.TabIndex = 16;
            this.lblFRSel.Text = "정/역전개";
            // 
            // cboFR
            // 
            this.cboFR.FormattingEnabled = true;
            this.cboFR.Items.AddRange(new object[] {
            "정전개",
            "역전개"});
            this.cboFR.Location = new System.Drawing.Point(77, 3);
            this.cboFR.Name = "cboFR";
            this.cboFR.Size = new System.Drawing.Size(114, 20);
            this.cboFR.TabIndex = 17;
            this.cboFR.SelectedIndexChanged += new System.EventHandler(this.cboFR_SelectedIndexChanged);
            // 
            // btnFRSearch
            // 
            this.btnFRSearch.Location = new System.Drawing.Point(197, 3);
            this.btnFRSearch.Name = "btnFRSearch";
            this.btnFRSearch.Size = new System.Drawing.Size(75, 23);
            this.btnFRSearch.TabIndex = 18;
            this.btnFRSearch.Text = "찾기";
            this.btnFRSearch.UseVisualStyleBackColor = true;
            this.btnFRSearch.Click += new System.EventHandler(this.btnFRSearch_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.txtType);
            this.splitContainer4.Panel1.Controls.Add(this.label4);
            this.splitContainer4.Panel1.Controls.Add(this.txtProdNamemain);
            this.splitContainer4.Panel1.Controls.Add(this.label3);
            this.splitContainer4.Panel1.Controls.Add(this.txtProdCodeMain);
            this.splitContainer4.Panel1.Controls.Add(this.label2);
            this.splitContainer4.Panel1.Controls.Add(this.ptbProd);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvFRInfo);
            this.splitContainer4.Panel2.Controls.Add(this.dgvRVInfo);
            this.splitContainer4.Size = new System.Drawing.Size(844, 536);
            this.splitContainer4.SplitterDistance = 277;
            this.splitContainer4.TabIndex = 28;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(92, 350);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(107, 21);
            this.txtType.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "유형";
            // 
            // txtProdNamemain
            // 
            this.txtProdNamemain.Location = new System.Drawing.Point(92, 298);
            this.txtProdNamemain.Name = "txtProdNamemain";
            this.txtProdNamemain.Size = new System.Drawing.Size(150, 21);
            this.txtProdNamemain.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "제품명";
            // 
            // txtProdCodeMain
            // 
            this.txtProdCodeMain.Location = new System.Drawing.Point(92, 246);
            this.txtProdCodeMain.Name = "txtProdCodeMain";
            this.txtProdCodeMain.Size = new System.Drawing.Size(163, 21);
            this.txtProdCodeMain.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "제품 코드";
            // 
            // ptbProd
            // 
            this.ptbProd.Location = new System.Drawing.Point(3, 3);
            this.ptbProd.Name = "ptbProd";
            this.ptbProd.Size = new System.Drawing.Size(289, 222);
            this.ptbProd.TabIndex = 27;
            this.ptbProd.TabStop = false;
            // 
            // dgvFRInfo
            // 
            this.dgvFRInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFRInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvFRInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFRInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvFRInfo.Name = "dgvFRInfo";
            this.dgvFRInfo.RowTemplate.Height = 23;
            this.dgvFRInfo.Size = new System.Drawing.Size(563, 536);
            this.dgvFRInfo.TabIndex = 1;
            // 
            // dgvRVInfo
            // 
            this.dgvRVInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRVInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRVInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvRVInfo.Name = "dgvRVInfo";
            this.dgvRVInfo.RowTemplate.Height = 23;
            this.dgvRVInfo.Size = new System.Drawing.Size(563, 536);
            this.dgvRVInfo.TabIndex = 0;
            // 
            // dgvRV
            // 
            this.dgvRV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRV.Location = new System.Drawing.Point(0, 0);
            this.dgvRV.MaximumSize = new System.Drawing.Size(296, 472);
            this.dgvRV.Name = "dgvRV";
            this.dgvRV.RowTemplate.Height = 23;
            this.dgvRV.Size = new System.Drawing.Size(296, 472);
            this.dgvRV.TabIndex = 1;
            this.dgvRV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRV_CellDoubleClick);
            // 
            // frmFowardReverse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1183, 619);
            this.Name = "frmFowardReverse";
            this.Text = "BOM 정/역전개";
            this.Load += new System.EventHandler(this.frmFowardReverse_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFR)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFRInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRVInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvFR;
        private System.Windows.Forms.ComboBox cboFR;
        private System.Windows.Forms.Label lblFRSel;
        private System.Windows.Forms.Button btnFRSearch;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProdNamemain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProdCodeMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ptbProd;
        private System.Windows.Forms.DataGridView dgvRVInfo;
        private System.Windows.Forms.DataGridView dgvRV;
        private System.Windows.Forms.DataGridView dgvFRInfo;
    }
}
