namespace App_QL_ThiTracNghiem.GUI.TaoDeThi
{
    partial class frmChon_SL_CauHoi
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
            this.pnContent = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblbTieuDe = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSL = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnHuy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnContent)).BeginInit();
            this.pnContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.btnHuy);
            this.pnContent.Controls.Add(this.btnOK);
            this.pnContent.Controls.Add(this.lblbTieuDe);
            this.pnContent.Controls.Add(this.txtSL);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(20, 60);
            this.pnContent.Name = "pnContent";
            this.pnContent.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.pnContent.Size = new System.Drawing.Size(564, 115);
            this.pnContent.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(380, 60);
            this.btnOK.Name = "btnOK";
            this.btnOK.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnOK.Size = new System.Drawing.Size(159, 40);
            this.btnOK.TabIndex = 2;
            this.btnOK.Values.Text = "XÁC NHẬN";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblbTieuDe
            // 
            this.lblbTieuDe.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblbTieuDe.Location = new System.Drawing.Point(16, 18);
            this.lblbTieuDe.Name = "lblbTieuDe";
            this.lblbTieuDe.Size = new System.Drawing.Size(138, 24);
            this.lblbTieuDe.TabIndex = 1;
            this.lblbTieuDe.Values.Text = "Số lượng câu hỏi:";
            // 
            // txtSL
            // 
            this.txtSL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSL.Location = new System.Drawing.Point(244, 17);
            this.txtSL.Name = "txtSL";
            this.txtSL.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.txtSL.Size = new System.Drawing.Size(295, 27);
            this.txtSL.TabIndex = 0;
            this.txtSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSL_KeyPress);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.Location = new System.Drawing.Point(215, 60);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnHuy.Size = new System.Drawing.Size(159, 40);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Values.Text = "HỦY";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmChon_SL_CauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 195);
            this.Controls.Add(this.pnContent);
            this.Name = "frmChon_SL_CauHoi";
            this.Text = "Tùy chỉnh";
            ((System.ComponentModel.ISupportInitialize)(this.pnContent)).EndInit();
            this.pnContent.ResumeLayout(false);
            this.pnContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnContent;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblbTieuDe;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSL;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnHuy;
    }
}