namespace App_QL_ThiTracNghiem.GUI.CauHoi
{
    partial class frmDS_MonHoc_CauHoi
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
            this.pnDSMonHoc = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.gridDSMonHoc = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnDSMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnDSMonHoc.Panel)).BeginInit();
            this.pnDSMonHoc.Panel.SuspendLayout();
            this.pnDSMonHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSMonHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // pnDSMonHoc
            // 
            this.pnDSMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDSMonHoc.Location = new System.Drawing.Point(0, 0);
            this.pnDSMonHoc.Name = "pnDSMonHoc";
            this.pnDSMonHoc.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            // 
            // pnDSMonHoc.Panel
            // 
            this.pnDSMonHoc.Panel.Controls.Add(this.gridDSMonHoc);
            this.pnDSMonHoc.Size = new System.Drawing.Size(1141, 753);
            this.pnDSMonHoc.TabIndex = 3;
            this.pnDSMonHoc.Values.Heading = "Danh sách môn học";
            // 
            // gridDSMonHoc
            // 
            this.gridDSMonHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDSMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDSMonHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.gridDSMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDSMonHoc.Location = new System.Drawing.Point(0, 0);
            this.gridDSMonHoc.Name = "gridDSMonHoc";
            this.gridDSMonHoc.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.gridDSMonHoc.RowHeadersWidth = 51;
            this.gridDSMonHoc.RowTemplate.Height = 24;
            this.gridDSMonHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDSMonHoc.Size = new System.Drawing.Size(1137, 725);
            this.gridDSMonHoc.TabIndex = 0;
            this.gridDSMonHoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDSMonHoc_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tên môn học";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Số lượng câu hỏi";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ngày tạo";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ngày cập nhật";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // frmDS_MonHoc_CauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnDSMonHoc);
            this.Name = "frmDS_MonHoc_CauHoi";
            this.Size = new System.Drawing.Size(1141, 753);
            ((System.ComponentModel.ISupportInitialize)(this.pnDSMonHoc.Panel)).EndInit();
            this.pnDSMonHoc.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnDSMonHoc)).EndInit();
            this.pnDSMonHoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDSMonHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox pnDSMonHoc;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridDSMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
