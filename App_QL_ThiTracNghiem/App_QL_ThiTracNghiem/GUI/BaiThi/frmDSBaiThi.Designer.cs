namespace App_QL_ThiTracNghiem.GUI.BaiThi
{
    partial class frmDSBaiThi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.gridDSSinhVienLamBai = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtNgayThi = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMocHOc = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCN = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDaNop = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDangThi = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSSinhVienLamBai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonPanel1.Size = new System.Drawing.Size(1496, 713);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 50);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            this.kryptonGroupBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.gridDSSinhVienLamBai);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(1496, 663);
            this.kryptonGroupBox1.TabIndex = 1;
            this.kryptonGroupBox1.Values.Heading = "Danh sách sinh viên đã nộp bài";
            // 
            // gridDSSinhVienLamBai
            // 
            this.gridDSSinhVienLamBai.AllowUserToAddRows = false;
            this.gridDSSinhVienLamBai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDSSinhVienLamBai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDSSinhVienLamBai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column4,
            this.Column7,
            this.Column8});
            this.gridDSSinhVienLamBai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDSSinhVienLamBai.Location = new System.Drawing.Point(0, 0);
            this.gridDSSinhVienLamBai.Name = "gridDSSinhVienLamBai";
            this.gridDSSinhVienLamBai.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.gridDSSinhVienLamBai.ReadOnly = true;
            this.gridDSSinhVienLamBai.RowHeadersWidth = 51;
            this.gridDSSinhVienLamBai.RowTemplate.Height = 24;
            this.gridDSSinhVienLamBai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDSSinhVienLamBai.Size = new System.Drawing.Size(1492, 635);
            this.gridDSSinhVienLamBai.TabIndex = 0;
            this.gridDSSinhVienLamBai.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDSSinhVienLamBai_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MASV";
            this.Column1.HeaderText = "Mã sinh viên";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TENSV";
            this.Column2.HeaderText = "Tên sinh viên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NGAYSINH";
            this.Column3.HeaderText = "Ngày sinh";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "GIOITINH";
            this.Column5.HeaderText = "Giới tính";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "MALOP";
            this.Column6.HeaderText = "Lớp";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "GIONOPBAI";
            this.Column4.HeaderText = "Giờ nộp bài";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "TINHTRANG";
            this.Column7.HeaderText = "Tình trạng";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "MABAITHI";
            this.Column8.HeaderText = "Mã bài thi";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.txtDangThi);
            this.kryptonPanel2.Controls.Add(this.txtDaNop);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.txtNgayThi);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.txtMocHOc);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.btnCN);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonPanel2.Size = new System.Drawing.Size(1496, 50);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // txtNgayThi
            // 
            this.txtNgayThi.Location = new System.Drawing.Point(399, 13);
            this.txtNgayThi.Name = "txtNgayThi";
            this.txtNgayThi.Size = new System.Drawing.Size(119, 24);
            this.txtNgayThi.TabIndex = 2;
            this.txtNgayThi.Values.Text = "................................";
            // 
            // txtMocHOc
            // 
            this.txtMocHOc.Location = new System.Drawing.Point(155, 13);
            this.txtMocHOc.Name = "txtMocHOc";
            this.txtMocHOc.Size = new System.Drawing.Size(119, 24);
            this.txtMocHOc.TabIndex = 2;
            this.txtMocHOc.Values.Text = "................................";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(315, 13);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(78, 24);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Ngày thi:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(74, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(80, 24);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Môn học:";
            // 
            // btnCN
            // 
            this.btnCN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCN.Location = new System.Drawing.Point(1341, 5);
            this.btnCN.Name = "btnCN";
            this.btnCN.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnCN.Size = new System.Drawing.Size(150, 40);
            this.btnCN.TabIndex = 0;
            this.btnCN.Values.Text = "CẬP NHẬT";
            this.btnCN.Click += new System.EventHandler(this.btnCN_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(563, 13);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(137, 24);
            this.kryptonLabel3.TabIndex = 1;
            this.kryptonLabel3.Values.Text = "Sinh viên đã nộp:";
            // 
            // txtDaNop
            // 
            this.txtDaNop.Location = new System.Drawing.Point(701, 13);
            this.txtDaNop.Name = "txtDaNop";
            this.txtDaNop.Size = new System.Drawing.Size(119, 24);
            this.txtDaNop.TabIndex = 2;
            this.txtDaNop.Values.Text = "................................";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(819, 13);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(147, 24);
            this.kryptonLabel5.TabIndex = 1;
            this.kryptonLabel5.Values.Text = "Sinh viên đang thi:";
            // 
            // txtDangThi
            // 
            this.txtDangThi.Location = new System.Drawing.Point(968, 13);
            this.txtDangThi.Name = "txtDangThi";
            this.txtDangThi.Size = new System.Drawing.Size(119, 24);
            this.txtDangThi.TabIndex = 2;
            this.txtDangThi.Values.Text = "................................";
            // 
            // frmDSBaiThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "frmDSBaiThi";
            this.Size = new System.Drawing.Size(1496, 713);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDSSinhVienLamBai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCN;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridDSSinhVienLamBai;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtNgayThi;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtMocHOc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtDangThi;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtDaNop;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
    }
}
