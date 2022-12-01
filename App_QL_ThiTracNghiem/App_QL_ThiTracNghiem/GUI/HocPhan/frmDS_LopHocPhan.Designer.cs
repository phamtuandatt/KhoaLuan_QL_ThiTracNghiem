namespace App_QL_ThiTracNghiem.GUI.HocPhan
{
    partial class frmDS_LopHocPhan
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
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.gridDSLOPHP = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextXoa = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xÓALỚPHỌCPHẦNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSLOPHP)).BeginInit();
            this.contextXoa.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonPanel1.Size = new System.Drawing.Size(1348, 596);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            this.kryptonGroupBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.gridDSLOPHP);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(1348, 596);
            this.kryptonGroupBox1.TabIndex = 1;
            this.kryptonGroupBox1.Values.Heading = "Danh sách lớp học phần";
            // 
            // gridDSLOPHP
            // 
            this.gridDSLOPHP.AllowUserToAddRows = false;
            this.gridDSLOPHP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDSLOPHP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDSLOPHP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.gridDSLOPHP.ContextMenuStrip = this.contextXoa;
            this.gridDSLOPHP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDSLOPHP.Location = new System.Drawing.Point(0, 0);
            this.gridDSLOPHP.Name = "gridDSLOPHP";
            this.gridDSLOPHP.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.gridDSLOPHP.ReadOnly = true;
            this.gridDSLOPHP.RowHeadersWidth = 51;
            this.gridDSLOPHP.RowTemplate.Height = 24;
            this.gridDSLOPHP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDSLOPHP.Size = new System.Drawing.Size(1344, 568);
            this.gridDSLOPHP.TabIndex = 1;
            this.gridDSLOPHP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDSLOPHP_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MALOPHOCPHAN";
            this.Column1.HeaderText = "Mã lớp học phần";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "MAHOCPHAN";
            this.Column3.HeaderText = "Mã học phần";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MAGV";
            this.Column4.HeaderText = "Mã giảng viên";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "THU";
            this.Column5.HeaderText = "Thứ";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TIET";
            this.Column6.HeaderText = "Tiết";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "PHONG";
            this.Column7.HeaderText = "Phòng";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "NGAYBD";
            this.Column8.HeaderText = "Ngày bắt đầu";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "NGAYKT";
            this.Column9.HeaderText = "Ngày kết thúc";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // contextXoa
            // 
            this.contextXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextXoa.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextXoa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xÓALỚPHỌCPHẦNToolStripMenuItem});
            this.contextXoa.Name = "contextXoa";
            this.contextXoa.Size = new System.Drawing.Size(218, 28);
            // 
            // xÓALỚPHỌCPHẦNToolStripMenuItem
            // 
            this.xÓALỚPHỌCPHẦNToolStripMenuItem.Name = "xÓALỚPHỌCPHẦNToolStripMenuItem";
            this.xÓALỚPHỌCPHẦNToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.xÓALỚPHỌCPHẦNToolStripMenuItem.Text = "XÓA LỚP HỌC PHẦN";
            this.xÓALỚPHỌCPHẦNToolStripMenuItem.Click += new System.EventHandler(this.xÓALỚPHỌCPHẦNToolStripMenuItem_Click);
            // 
            // frmDS_LopHocPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "frmDS_LopHocPhan";
            this.Size = new System.Drawing.Size(1348, 596);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDSLOPHP)).EndInit();
            this.contextXoa.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridDSLOPHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.ContextMenuStrip contextXoa;
        private System.Windows.Forms.ToolStripMenuItem xÓALỚPHỌCPHẦNToolStripMenuItem;
    }
}
