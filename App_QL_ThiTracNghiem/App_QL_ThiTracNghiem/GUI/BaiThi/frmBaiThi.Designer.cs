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
            ((System.ComponentModel.ISupportInitialize)(this.krpContent)).BeginInit();
            this.SuspendLayout();
            // 
            // krpContent
            // 
            this.krpContent.AutoScroll = true;
            this.krpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krpContent.Location = new System.Drawing.Point(0, 0);
            this.krpContent.Name = "krpContent";
            this.krpContent.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.krpContent.Size = new System.Drawing.Size(800, 450);
            this.krpContent.TabIndex = 0;
            // 
            // frmBaiThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.krpContent);
            this.Name = "frmBaiThi";
            this.Text = "Bài thi";
            ((System.ComponentModel.ISupportInitialize)(this.krpContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel krpContent;
    }
}