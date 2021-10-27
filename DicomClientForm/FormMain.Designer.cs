
namespace DicomClientForm
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnLoad = new System.Windows.Forms.Button();
            this.BtnCreateDicom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnLoad
            // 
            this.BtnLoad.AutoSize = true;
            this.BtnLoad.Location = new System.Drawing.Point(25, 22);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(75, 23);
            this.BtnLoad.TabIndex = 0;
            this.BtnLoad.Text = "加载影像";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // BtnCreateDicom
            // 
            this.BtnCreateDicom.AutoSize = true;
            this.BtnCreateDicom.Location = new System.Drawing.Point(124, 22);
            this.BtnCreateDicom.Name = "BtnCreateDicom";
            this.BtnCreateDicom.Size = new System.Drawing.Size(111, 22);
            this.BtnCreateDicom.TabIndex = 1;
            this.BtnCreateDicom.Text = "使用图片生成影像";
            this.BtnCreateDicom.UseVisualStyleBackColor = true;
            this.BtnCreateDicom.Click += new System.EventHandler(this.BtnCreateDicom_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCreateDicom);
            this.Controls.Add(this.BtnLoad);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Button BtnCreateDicom;
    }
}

