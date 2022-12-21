namespace App_QL_ThiTracNghiem.GUI.BaiThi
{
    partial class frmBaiThi
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
            this.krpContent = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtCauSai = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCauDUng = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDiem = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pnContent = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.krpContent)).BeginInit();
            this.krpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnContent)).BeginInit();
            this.SuspendLayout();
            // 
            // krpContent
            // 
            this.krpContent.AutoScroll = true;
            this.krpContent.Controls.Add(this.pnContent);
            this.krpContent.Controls.Add(this.kryptonPanel1);
            this.krpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krpContent.Location = new System.Drawing.Point(20, 60);
            this.krpContent.Name = "krpContent";
            this.krpContent.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.krpContent.Size = new System.Drawing.Size(1353, 641);
            this.krpContent.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.txtCauSai);
            this.kryptonPanel1.Controls.Add(this.txtCauDUng);
            this.kryptonPanel1.Controls.Add(this.txtDiem);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonPanel1.Size = new System.Drawing.Size(1353, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // txtCauSai
            // 
            this.txtCauSai.Location = new System.Drawing.Point(877, 13);
            this.txtCauSai.Name = "txtCauSai";
            this.txtCauSai.Size = new System.Drawing.Size(92, 24);
            this.txtCauSai.TabIndex = 7;
            this.txtCauSai.Values.Text = "........................";
            // 
            // txtCauDUng
            // 
            this.txtCauDUng.Location = new System.Drawing.Point(676, 13);
            this.txtCauDUng.Name = "txtCauDUng";
            this.txtCauDUng.Size = new System.Drawing.Size(92, 24);
            this.txtCauDUng.TabIndex = 8;
            this.txtCauDUng.Values.Text = "........................";
            // 
            // txtDiem
            // 
            this.txtDiem.Location = new System.Drawing.Point(443, 13);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(92, 24);
            this.txtDiem.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.txtDiem.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.txtDiem.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.txtDiem.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.txtDiem.StateDisabled.LongText.Color1 = System.Drawing.Color.Red;
            this.txtDiem.StateDisabled.LongText.Color2 = System.Drawing.Color.Red;
            this.txtDiem.StateDisabled.ShortText.Color1 = System.Drawing.Color.Red;
            this.txtDiem.StateDisabled.ShortText.Color2 = System.Drawing.Color.Red;
            this.txtDiem.TabIndex = 9;
            this.txtDiem.Values.Text = "........................";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(784, 13);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(87, 24);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Số câu sai:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(565, 13);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(105, 24);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Số câu đúng:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(383, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(54, 24);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Điểm:";
            // 
            // pnContent
            // 
            this.pnContent.AutoScroll = true;
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 50);
            this.pnContent.Name = "pnContent";
            this.pnContent.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.pnContent.Size = new System.Drawing.Size(1353, 591);
            this.pnContent.TabIndex = 1;
            // 
            // frmBaiThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 721);
            this.Controls.Add(this.krpContent);
            this.Name = "frmBaiThi";
            this.Text = "Bài thi";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.krpContent)).EndInit();
            this.krpContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel krpContent;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtCauSai;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtCauDUng;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel txtDiem;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnContent;
    }
}