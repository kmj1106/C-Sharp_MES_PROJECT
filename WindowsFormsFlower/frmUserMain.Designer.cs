
namespace WindowsFormsFlower
{
    partial class frmUserMain
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
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회원가입ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.마이페이지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.쇼핑몰ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnShoppingMall = new System.Windows.Forms.Button();
            this.btnMyPage = new System.Windows.Forms.Button();
            this.checkBoxHide = new System.Windows.Forms.CheckBox();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelSideMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 로그인ToolStripMenuItem
            // 
            this.로그인ToolStripMenuItem.Name = "로그인ToolStripMenuItem";
            this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 회원가입ToolStripMenuItem
            // 
            this.회원가입ToolStripMenuItem.Name = "회원가입ToolStripMenuItem";
            this.회원가입ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 마이페이지ToolStripMenuItem
            // 
            this.마이페이지ToolStripMenuItem.Name = "마이페이지ToolStripMenuItem";
            this.마이페이지ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 쇼핑몰ToolStripMenuItem
            // 
            this.쇼핑몰ToolStripMenuItem.Name = "쇼핑몰ToolStripMenuItem";
            this.쇼핑몰ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelSideMenu.Controls.Add(this.btnShoppingMall);
            this.panelSideMenu.Controls.Add(this.btnMyPage);
            this.panelSideMenu.Controls.Add(this.checkBoxHide);
            this.panelSideMenu.Controls.Add(this.btnUser);
            this.panelSideMenu.Controls.Add(this.btnLogin);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(100, 560);
            this.panelSideMenu.TabIndex = 3;
            // 
            // btnShoppingMall
            // 
            this.btnShoppingMall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShoppingMall.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShoppingMall.FlatAppearance.BorderSize = 0;
            this.btnShoppingMall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnShoppingMall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnShoppingMall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShoppingMall.ForeColor = System.Drawing.Color.White;
            this.btnShoppingMall.Location = new System.Drawing.Point(0, 135);
            this.btnShoppingMall.Name = "btnShoppingMall";
            this.btnShoppingMall.Size = new System.Drawing.Size(100, 45);
            this.btnShoppingMall.TabIndex = 4;
            this.btnShoppingMall.Tag = "frmShoppingMall";
            this.btnShoppingMall.Text = "쇼핑몰";
            this.btnShoppingMall.UseVisualStyleBackColor = true;
            this.btnShoppingMall.Click += new System.EventHandler(this.btnShoppingMall_Click);
            // 
            // btnMyPage
            // 
            this.btnMyPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMyPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyPage.FlatAppearance.BorderSize = 0;
            this.btnMyPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnMyPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnMyPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyPage.ForeColor = System.Drawing.Color.White;
            this.btnMyPage.Location = new System.Drawing.Point(0, 90);
            this.btnMyPage.Name = "btnMyPage";
            this.btnMyPage.Size = new System.Drawing.Size(100, 45);
            this.btnMyPage.TabIndex = 3;
            this.btnMyPage.Tag = "frmMyPage";
            this.btnMyPage.Text = "마이페이지";
            this.btnMyPage.UseVisualStyleBackColor = true;
            this.btnMyPage.Click += new System.EventHandler(this.btnMyPage_Click);
            // 
            // checkBoxHide
            // 
            this.checkBoxHide.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxHide.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkBoxHide.FlatAppearance.BorderSize = 0;
            this.checkBoxHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.checkBoxHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.checkBoxHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxHide.ForeColor = System.Drawing.Color.White;
            this.checkBoxHide.Location = new System.Drawing.Point(0, 510);
            this.checkBoxHide.Name = "checkBoxHide";
            this.checkBoxHide.Size = new System.Drawing.Size(100, 50);
            this.checkBoxHide.TabIndex = 2;
            this.checkBoxHide.Text = "<";
            this.checkBoxHide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxHide.UseVisualStyleBackColor = true;
            // 
            // btnUser
            // 
            this.btnUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Location = new System.Drawing.Point(0, 45);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(100, 45);
            this.btnUser.TabIndex = 1;
            this.btnUser.Tag = "frmUser";
            this.btnUser.Text = "회원가입";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(0, 0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 45);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Tag = "frmLogin";
            this.btnLogin.Text = "로그인";
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmUserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 560);
            this.Controls.Add(this.panelSideMenu);
            this.IsMdiContainer = true;
            this.Name = "frmUserMain";
            this.Text = "User 메인화면";
            this.Load += new System.EventHandler(this.frmUserMain_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem 마이페이지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 쇼핑몰ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 회원가입ToolStripMenuItem;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnShoppingMall;
        private System.Windows.Forms.Button btnMyPage;
        private System.Windows.Forms.CheckBox checkBoxHide;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnLogin;
    }
}