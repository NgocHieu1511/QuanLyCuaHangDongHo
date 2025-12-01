namespace QuanLyCuaHangDongHo
{
    partial class frmQLNhaCungCap
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
            this.LBLNhaCungCap = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblTENNCC = new System.Windows.Forms.Label();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.dtgvNCC = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNCC)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LBLNhaCungCap);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Location = new System.Drawing.Point(6, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 51);
            this.panel1.TabIndex = 0;
            // 
            // LBLNhaCungCap
            // 
            this.LBLNhaCungCap.AutoSize = true;
            this.LBLNhaCungCap.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLNhaCungCap.Location = new System.Drawing.Point(383, 3);
            this.LBLNhaCungCap.Name = "LBLNhaCungCap";
            this.LBLNhaCungCap.Size = new System.Drawing.Size(357, 37);
            this.LBLNhaCungCap.TabIndex = 1;
            this.LBLNhaCungCap.Text = "Quản Lý Nhà Cung Cấp";
            this.LBLNhaCungCap.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(21, 9);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(87, 36);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBoQua);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.lblDiaChi);
            this.panel2.Controls.Add(this.lblSDT);
            this.panel2.Controls.Add(this.lblTENNCC);
            this.panel2.Controls.Add(this.lblMaNCC);
            this.panel2.Controls.Add(this.dtgvNCC);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.txtDiaChi);
            this.panel2.Controls.Add(this.txtSDT);
            this.panel2.Controls.Add(this.txtTenNCC);
            this.panel2.Controls.Add(this.txtMaNCC);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Controls.Add(this.lblTimKiem);
            this.panel2.Location = new System.Drawing.Point(6, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1131, 603);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoQua.Location = new System.Drawing.Point(905, 362);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(123, 43);
            this.btnBoQua.TabIndex = 21;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(703, 361);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(123, 43);
            this.btnLuu.TabIndex = 20;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Location = new System.Drawing.Point(17, 247);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(72, 19);
            this.lblDiaChi.TabIndex = 19;
            this.lblDiaChi.Text = "Địa Chỉ:";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(17, 184);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(45, 19);
            this.lblSDT.TabIndex = 18;
            this.lblSDT.Text = "SĐT:";
            // 
            // lblTENNCC
            // 
            this.lblTENNCC.AutoSize = true;
            this.lblTENNCC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTENNCC.Location = new System.Drawing.Point(17, 124);
            this.lblTENNCC.Name = "lblTENNCC";
            this.lblTENNCC.Size = new System.Drawing.Size(82, 19);
            this.lblTENNCC.TabIndex = 17;
            this.lblTENNCC.Text = "Tên NCC:";
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.AutoSize = true;
            this.lblMaNCC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNCC.Location = new System.Drawing.Point(17, 60);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(79, 19);
            this.lblMaNCC.TabIndex = 16;
            this.lblMaNCC.Text = "Mã NCC:";
            // 
            // dtgvNCC
            // 
            this.dtgvNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvNCC.Location = new System.Drawing.Point(569, 60);
            this.dtgvNCC.Name = "dtgvNCC";
            this.dtgvNCC.RowHeadersWidth = 51;
            this.dtgvNCC.RowTemplate.Height = 24;
            this.dtgvNCC.Size = new System.Drawing.Size(485, 284);
            this.dtgvNCC.TabIndex = 15;
            this.dtgvNCC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvNCC_CellContentClick);
            this.dtgvNCC.Click += new System.EventHandler(this.dtgvNCC_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(514, 361);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(123, 43);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(323, 361);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(123, 43);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(137, 361);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(123, 43);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(175, 242);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(303, 27);
            this.txtDiaChi.TabIndex = 11;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(175, 184);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(303, 27);
            this.txtSDT.TabIndex = 10;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNCC.Location = new System.Drawing.Point(175, 124);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(303, 27);
            this.txtTenNCC.TabIndex = 9;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNCC.Location = new System.Drawing.Point(175, 60);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(303, 27);
            this.txtMaNCC.TabIndex = 8;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(440, 7);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(153, 36);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(124, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(287, 27);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.Location = new System.Drawing.Point(17, 15);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(86, 19);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm:";
            this.lblTimKiem.Click += new System.EventHandler(this.label2_Click);
            // 
            // frmQLNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 685);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmQLNhaCungCap";
            this.Text = "frmQLNhaCungCap";
            this.Load += new System.EventHandler(this.frmQLNhaCungCap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNCC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBLNhaCungCap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.DataGridView dtgvNCC;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblTENNCC;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnLuu;
    }
}