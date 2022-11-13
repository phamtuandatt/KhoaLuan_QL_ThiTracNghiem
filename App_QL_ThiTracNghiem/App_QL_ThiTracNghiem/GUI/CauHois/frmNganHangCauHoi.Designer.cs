namespace App_QL_ThiTracNghiem.GUI
{
    partial class frmNganHangCauHoi
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
            this.btnThemMonHoc = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnImport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCapNhat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTroVe = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTaoCauHoi = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnContent = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnContent)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnThemMonHoc);
            this.kryptonPanel1.Controls.Add(this.btnImport);
            this.kryptonPanel1.Controls.Add(this.btnCapNhat);
            this.kryptonPanel1.Controls.Add(this.btnTroVe);
            this.kryptonPanel1.Controls.Add(this.btnTaoCauHoi);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonPanel1.Size = new System.Drawing.Size(1160, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnThemMonHoc
            // 
            this.btnThemMonHoc.Location = new System.Drawing.Point(307, 5);
            this.btnThemMonHoc.Name = "btnThemMonHoc";
            this.btnThemMonHoc.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnThemMonHoc.Size = new System.Drawing.Size(132, 40);
            this.btnThemMonHoc.TabIndex = 1;
            this.btnThemMonHoc.Values.Text = "Thêm môn học";
            this.btnThemMonHoc.Click += new System.EventHandler(this.btnThemMonHoc_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(209, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnImport.Size = new System.Drawing.Size(90, 40);
            this.btnImport.TabIndex = 1;
            this.btnImport.Values.Text = "Import ";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(111, 5);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnCapNhat.Size = new System.Drawing.Size(90, 40);
            this.btnCapNhat.TabIndex = 1;
            this.btnCapNhat.Values.Text = "Cập nhật";
            // 
            // btnTroVe
            // 
            this.btnTroVe.Location = new System.Drawing.Point(13, 5);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnTroVe.Size = new System.Drawing.Size(90, 40);
            this.btnTroVe.TabIndex = 1;
            this.btnTroVe.Values.Text = "Trờ về";
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnTaoCauHoi
            // 
            this.btnTaoCauHoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoCauHoi.Location = new System.Drawing.Point(960, 5);
            this.btnTaoCauHoi.Name = "btnTaoCauHoi";
            this.btnTaoCauHoi.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnTaoCauHoi.Size = new System.Drawing.Size(194, 40);
            this.btnTaoCauHoi.TabIndex = 0;
            this.btnTaoCauHoi.Values.Text = "Tạo câu hỏi";
            this.btnTaoCauHoi.Click += new System.EventHandler(this.btnTaoCauHoi_Click);
            // 
            // pnContent
            // 
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 50);
            this.pnContent.Name = "pnContent";
            this.pnContent.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.pnContent.Size = new System.Drawing.Size(1160, 694);
            this.pnContent.TabIndex = 1;
            // 
            // frmNganHangCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "frmNganHangCauHoi";
            this.Size = new System.Drawing.Size(1160, 744);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTaoCauHoi;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnContent;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTroVe;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImport;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThemMonHoc;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCapNhat;
    }
}
