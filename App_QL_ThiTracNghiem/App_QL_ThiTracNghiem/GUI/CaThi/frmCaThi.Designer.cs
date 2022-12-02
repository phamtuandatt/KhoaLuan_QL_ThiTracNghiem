namespace App_QL_ThiTracNghiem.GUI.CaThi
{
    partial class frmCaThi
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
            this.btnReload = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTroVe = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTaoCaThi = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnContent = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboKhoa = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cboHocPhan = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKhoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHocPhan)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.cboHocPhan);
            this.kryptonPanel1.Controls.Add(this.cboKhoa);
            this.kryptonPanel1.Controls.Add(this.btnReload);
            this.kryptonPanel1.Controls.Add(this.btnTroVe);
            this.kryptonPanel1.Controls.Add(this.btnTaoCaThi);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonPanel1.Size = new System.Drawing.Size(1594, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReload.Location = new System.Drawing.Point(151, 5);
            this.btnReload.Name = "btnReload";
            this.btnReload.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnReload.Size = new System.Drawing.Size(138, 40);
            this.btnReload.TabIndex = 0;
            this.btnReload.Values.Text = "Cập nhật";
            this.btnReload.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnTroVe
            // 
            this.btnTroVe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTroVe.Location = new System.Drawing.Point(7, 5);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnTroVe.Size = new System.Drawing.Size(138, 40);
            this.btnTroVe.TabIndex = 0;
            this.btnTroVe.Values.Text = "Trờ về";
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnTaoCaThi
            // 
            this.btnTaoCaThi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoCaThi.Location = new System.Drawing.Point(1451, 5);
            this.btnTaoCaThi.Name = "btnTaoCaThi";
            this.btnTaoCaThi.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnTaoCaThi.Size = new System.Drawing.Size(138, 40);
            this.btnTaoCaThi.TabIndex = 0;
            this.btnTaoCaThi.Values.Text = "Tạo ca thi";
            this.btnTaoCaThi.Click += new System.EventHandler(this.btnTaoCaThi_Click);
            // 
            // pnContent
            // 
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 50);
            this.pnContent.Name = "pnContent";
            this.pnContent.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.pnContent.Size = new System.Drawing.Size(1594, 645);
            this.pnContent.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(319, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonLabel1.Size = new System.Drawing.Size(53, 26);
            this.kryptonLabel1.TabIndex = 11;
            this.kryptonLabel1.Values.Text = "Khoa:";
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.DropDownWidth = 450;
            this.cboKhoa.Location = new System.Drawing.Point(395, 13);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.cboKhoa.Size = new System.Drawing.Size(446, 25);
            this.cboKhoa.TabIndex = 10;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
            // 
            // cboHocPhan
            // 
            this.cboHocPhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocPhan.DropDownWidth = 450;
            this.cboHocPhan.Location = new System.Drawing.Point(976, 13);
            this.cboHocPhan.Name = "cboHocPhan";
            this.cboHocPhan.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.cboHocPhan.Size = new System.Drawing.Size(366, 25);
            this.cboHocPhan.TabIndex = 10;
            this.cboHocPhan.SelectedIndexChanged += new System.EventHandler(this.cboHocPhan_SelectedIndexChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(877, 12);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonLabel2.Size = new System.Drawing.Size(85, 26);
            this.kryptonLabel2.TabIndex = 11;
            this.kryptonLabel2.Values.Text = "Học phần:";
            // 
            // frmCaThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "frmCaThi";
            this.Size = new System.Drawing.Size(1594, 695);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKhoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHocPhan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTaoCaThi;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnContent;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTroVe;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReload;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboKhoa;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboHocPhan;
    }
}
