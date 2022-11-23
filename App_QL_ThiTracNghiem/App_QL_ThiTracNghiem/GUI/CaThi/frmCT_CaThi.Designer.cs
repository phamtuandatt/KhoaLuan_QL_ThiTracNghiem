namespace App_QL_ThiTracNghiem.GUI.CaThi
{
    partial class frmCT_CaThi
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
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNgayThi = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnHuy = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtMaDe = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtGioThi = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtMonHoc = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGioThi)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 31);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(80, 24);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Môn học:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 75);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(85, 24);
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.Values.Text = "Mã đề thi:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(408, 31);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(78, 24);
            this.kryptonLabel3.TabIndex = 0;
            this.kryptonLabel3.Values.Text = "Ngày thi:";
            // 
            // txtNgayThi
            // 
            this.txtNgayThi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNgayThi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgayThi.Location = new System.Drawing.Point(499, 30);
            this.txtNgayThi.Name = "txtNgayThi";
            this.txtNgayThi.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.txtNgayThi.Size = new System.Drawing.Size(232, 25);
            this.txtNgayThi.TabIndex = 3;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(408, 75);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(65, 24);
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.Text = "Giờ thi:";
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.Location = new System.Drawing.Point(399, 137);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnHuy.Size = new System.Drawing.Size(163, 40);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Values.Text = "HỦY";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(568, 137);
            this.btnOK.Name = "btnOK";
            this.btnOK.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.btnOK.Size = new System.Drawing.Size(163, 40);
            this.btnOK.TabIndex = 4;
            this.btnOK.Values.Text = "HOÀN THÀNH";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtMaDe
            // 
            this.txtMaDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtMaDe.DropDownWidth = 170;
            this.txtMaDe.Location = new System.Drawing.Point(123, 74);
            this.txtMaDe.Name = "txtMaDe";
            this.txtMaDe.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.txtMaDe.Size = new System.Drawing.Size(232, 25);
            this.txtMaDe.TabIndex = 1;
            // 
            // txtGioThi
            // 
            this.txtGioThi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGioThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtGioThi.DropDownWidth = 170;
            this.txtGioThi.Items.AddRange(new object[] {
            "Tiết 1",
            "Tiết 2",
            "Tiết 3",
            "Tiết 4",
            "Tiết 5",
            "Tiết 6",
            "Tiết 7",
            "Tiết 8",
            "Tiết 9",
            "Tiết 10",
            "Tiết 11",
            "Tiết 12",
            "Tiết 13",
            "Tiết 14",
            "Tiết 15",
            "Tiết 16"});
            this.txtGioThi.Location = new System.Drawing.Point(499, 75);
            this.txtGioThi.Name = "txtGioThi";
            this.txtGioThi.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.txtGioThi.Size = new System.Drawing.Size(232, 25);
            this.txtGioThi.TabIndex = 1;
            this.txtGioThi.Text = "Tiết 1";
            // 
            // txtMonHoc
            // 
            this.txtMonHoc.Location = new System.Drawing.Point(123, 30);
            this.txtMonHoc.Name = "txtMonHoc";
            this.txtMonHoc.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.txtMonHoc.ReadOnly = true;
            this.txtMonHoc.Size = new System.Drawing.Size(232, 27);
            this.txtMonHoc.TabIndex = 5;
            // 
            // frmCT_CaThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 189);
            this.Controls.Add(this.txtMonHoc);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.txtNgayThi);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.txtGioThi);
            this.Controls.Add(this.txtMaDe);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Name = "frmCT_CaThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCT_CaThi";
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGioThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtNgayThi;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnHuy;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtMaDe;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox txtGioThi;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMonHoc;
    }
}