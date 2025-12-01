namespace QuanLyCuaHangDongHo
{
    partial class frmDangKy
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtNhapLaiMK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtTaikhoan = new System.Windows.Forms.TextBox();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDangKy = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 435);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnDangNhap);
            this.panel8.Controls.Add(this.btnDangKy);
            this.panel8.Location = new System.Drawing.Point(275, 321);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(532, 111);
            this.panel8.TabIndex = 3;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(31, 45);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(160, 48);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.Snow;
            this.btnDangKy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.Location = new System.Drawing.Point(354, 45);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(156, 48);
            this.btnDangKy.TabIndex = 3;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtNhapLaiMK);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Location = new System.Drawing.Point(275, 246);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(532, 69);
            this.panel7.TabIndex = 2;
            // 
            // txtNhapLaiMK
            // 
            this.txtNhapLaiMK.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhapLaiMK.Location = new System.Drawing.Point(197, 9);
            this.txtNhapLaiMK.Name = "txtNhapLaiMK";
            this.txtNhapLaiMK.Size = new System.Drawing.Size(292, 27);
            this.txtNhapLaiMK.TabIndex = 2;
            this.txtNhapLaiMK.UseSystemPasswordChar = true;
            this.txtNhapLaiMK.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nhập lại mật khẩu:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtMatKhau);
            this.panel6.Controls.Add(this.lblMatKhau);
            this.panel6.Location = new System.Drawing.Point(275, 171);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(532, 69);
            this.panel6.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(197, 9);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(292, 27);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.Location = new System.Drawing.Point(10, 9);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(90, 20);
            this.lblMatKhau.TabIndex = 0;
            this.lblMatKhau.Text = "Mật khẩu:";
            this.lblMatKhau.Click += new System.EventHandler(this.lblMatKhau_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtTaikhoan);
            this.panel4.Controls.Add(this.lblTaiKhoan);
            this.panel4.Location = new System.Drawing.Point(275, 96);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(532, 69);
            this.panel4.TabIndex = 0;
            // 
            // txtTaikhoan
            // 
            this.txtTaikhoan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaikhoan.Location = new System.Drawing.Point(197, 9);
            this.txtTaikhoan.Name = "txtTaikhoan";
            this.txtTaikhoan.Size = new System.Drawing.Size(292, 27);
            this.txtTaikhoan.TabIndex = 0;
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaiKhoan.Location = new System.Drawing.Point(10, 9);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(102, 20);
            this.lblTaiKhoan.TabIndex = 0;
            this.lblTaiKhoan.Text = "Tài Khoản: ";
            this.lblTaiKhoan.Click += new System.EventHandler(this.lblTaiKhoan_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblDangKy);
            this.panel3.Location = new System.Drawing.Point(275, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(532, 87);
            this.panel3.TabIndex = 0;
            // 
            // lblDangKy
            // 
            this.lblDangKy.AutoSize = true;
            this.lblDangKy.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangKy.Location = new System.Drawing.Point(51, 25);
            this.lblDangKy.Name = "lblDangKy";
            this.lblDangKy.Size = new System.Drawing.Size(140, 38);
            this.lblDangKy.TabIndex = 0;
            this.lblDangKy.Text = "Đăng ký";
            this.lblDangKy.Click += new System.EventHandler(this.lblDangKy_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 429);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::QuanLyCuaHangDongHo.Properties.Resources.logo2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 429);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(272, 168);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(532, 69);
            this.panel5.TabIndex = 3;
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(834, 447);
            this.Controls.Add(this.panel1);
            this.Name = "frmDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDangKy_FormClosing);
            this.Load += new System.EventHandler(this.frmDangKy_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.TextBox txtNhapLaiMK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtTaikhoan;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Label lblDangKy;
    }
}