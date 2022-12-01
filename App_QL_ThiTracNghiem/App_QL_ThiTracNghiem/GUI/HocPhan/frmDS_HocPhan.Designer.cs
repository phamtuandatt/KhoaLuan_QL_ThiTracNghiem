namespace App_QL_ThiTracNghiem.GUI.HocPhan
{
    partial class frmDS_HocPhan
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
            this.pnNoiDung = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboKhoa = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnThem = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTroVe = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnND = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnNoiDung)).BeginInit();
            this.pnNoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnND)).BeginInit();
            this.SuspendLayout();
            // 
            // pnNoiDung
            // 
            this.pnNoiDung.Controls.Add(this.pnND);
            this.pnNoiDung.Controls.Add(this.kryptonPanel2);
            this.pnNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnNoiDung.Location = new System.Drawing.Point(0, 0);
            this.pnNoiDung.Name = "pnNoiDung";
            this.pnNoiDung.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.pnNoiDung.Size = new System.Drawing.Size(1139, 716);
            this.pnNoiDung.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.cboKhoa);
            this.kryptonPanel2.Controls.Add(this.btnTroVe);
            this.kryptonPanel2.Controls.Add(this.btnThem);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonPanel2.Size = new System.Drawing.Size(1139, 50);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(246, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonLabel1.Size = new System.Drawing.Size(53, 26);
            this.kryptonLabel1.TabIndex = 9;
            this.kryptonLabel1.Values.Text = "Khoa:";
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.DropDownWidth = 450;
            this.cboKhoa.Location = new System.Drawing.Point(322, 13);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.cboKhoa.Size = new System.Drawing.Size(446, 25);
            this.cboKhoa.TabIndex = 8;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(115, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnThem.Size = new System.Drawing.Size(102, 40);
            this.btnThem.TabIndex = 3;
            this.btnThem.Values.Text = "THÊM";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTroVe
            // 
            this.btnTroVe.Location = new System.Drawing.Point(8, 5);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnTroVe.Size = new System.Drawing.Size(102, 40);
            this.btnTroVe.TabIndex = 3;
            this.btnTroVe.Values.Text = "TRỞ VỀ";
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // pnND
            // 
            this.pnND.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnND.Location = new System.Drawing.Point(0, 50);
            this.pnND.Name = "pnND";
            this.pnND.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.pnND.Size = new System.Drawing.Size(1139, 666);
            this.pnND.TabIndex = 2;
            // 
            // frmDS_HocPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnNoiDung);
            this.Name = "frmDS_HocPhan";
            this.Size = new System.Drawing.Size(1139, 716);
            ((System.ComponentModel.ISupportInitialize)(this.pnNoiDung)).EndInit();
            this.pnNoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnND)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnNoiDung;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThem;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboKhoa;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTroVe;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnND;
    }
}
