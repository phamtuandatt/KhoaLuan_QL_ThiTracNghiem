namespace App_QL_ThiTracNghiem.GUI.CaThi
{
    partial class frmDSCaThi
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
            this.groupDSCaThi = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.gridDSCaThi = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            this.Column7 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDSCaThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDSCaThi.Panel)).BeginInit();
            this.groupDSCaThi.Panel.SuspendLayout();
            this.groupDSCaThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSCaThi)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1093, 641);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // groupDSCaThi
            // 
            this.groupDSCaThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDSCaThi.Location = new System.Drawing.Point(0, 0);
            this.groupDSCaThi.Name = "groupDSCaThi";
            this.groupDSCaThi.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            // 
            // groupDSCaThi.Panel
            // 
            this.groupDSCaThi.Panel.Controls.Add(this.gridDSCaThi);
            this.groupDSCaThi.Size = new System.Drawing.Size(1093, 641);
            this.groupDSCaThi.TabIndex = 1;
            this.groupDSCaThi.Values.Heading = "Danh sách ca thi";
            // 
            // gridDSCaThi
            // 
            this.gridDSCaThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDSCaThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDSCaThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.gridDSCaThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDSCaThi.Location = new System.Drawing.Point(0, 0);
            this.gridDSCaThi.Name = "gridDSCaThi";
            this.gridDSCaThi.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.gridDSCaThi.RowHeadersWidth = 51;
            this.gridDSCaThi.RowTemplate.Height = 24;
            this.gridDSCaThi.Size = new System.Drawing.Size(1089, 613);
            this.gridDSCaThi.TabIndex = 0;
            this.gridDSCaThi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDSCaThi_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã ca thi";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên môn học";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mã đề thi";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ngày thi";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tình trạng";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Sửa";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Xóa";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // frmDSCaThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupDSCaThi);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "frmDSCaThi";
            this.Size = new System.Drawing.Size(1093, 641);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDSCaThi.Panel)).EndInit();
            this.groupDSCaThi.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupDSCaThi)).EndInit();
            this.groupDSCaThi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDSCaThi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupDSCaThi;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridDSCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn Column6;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn Column7;
    }
}
