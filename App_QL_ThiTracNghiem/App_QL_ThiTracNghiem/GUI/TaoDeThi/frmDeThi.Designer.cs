namespace App_QL_ThiTracNghiem.GUI.TaoDeThi
{
    partial class frmDeThi
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
            this.cboDSMonHoc = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnTroVe = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTaoDeThi = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnContent = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDSMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnContent)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.cboDSMonHoc);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.btnTroVe);
            this.kryptonPanel1.Controls.Add(this.btnTaoDeThi);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonPanel1.Size = new System.Drawing.Size(1093, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // cboDSMonHoc
            // 
            this.cboDSMonHoc.DropDownWidth = 198;
            this.cboDSMonHoc.Location = new System.Drawing.Point(260, 12);
            this.cboDSMonHoc.Name = "cboDSMonHoc";
            this.cboDSMonHoc.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.cboDSMonHoc.Size = new System.Drawing.Size(198, 25);
            this.cboDSMonHoc.TabIndex = 2;
            this.cboDSMonHoc.SelectedIndexChanged += new System.EventHandler(this.cboDSMonHoc_SelectedIndexChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(174, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(80, 24);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Môn học:";
            // 
            // btnTroVe
            // 
            this.btnTroVe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTroVe.Location = new System.Drawing.Point(7, 5);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnTroVe.Size = new System.Drawing.Size(140, 40);
            this.btnTroVe.TabIndex = 0;
            this.btnTroVe.Values.Text = "Trờ về";
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnTaoDeThi
            // 
            this.btnTaoDeThi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoDeThi.Location = new System.Drawing.Point(947, 5);
            this.btnTaoDeThi.Name = "btnTaoDeThi";
            this.btnTaoDeThi.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnTaoDeThi.Size = new System.Drawing.Size(140, 40);
            this.btnTaoDeThi.TabIndex = 0;
            this.btnTaoDeThi.Values.Text = "Tạo đề thì";
            this.btnTaoDeThi.Click += new System.EventHandler(this.btnTaoDeThi_Click);
            // 
            // pnContent
            // 
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 50);
            this.pnContent.Name = "pnContent";
            this.pnContent.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.pnContent.Size = new System.Drawing.Size(1093, 673);
            this.pnContent.TabIndex = 1;
            // 
            // frmDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "frmDeThi";
            this.Size = new System.Drawing.Size(1093, 723);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDSMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTroVe;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTaoDeThi;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnContent;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboDSMonHoc;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
