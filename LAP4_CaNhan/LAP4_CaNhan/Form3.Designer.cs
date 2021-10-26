
namespace LAP4_CaNhan
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.BTXoa = new System.Windows.Forms.Button();
            this.BTHuy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTXoa
            // 
            this.BTXoa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BTXoa.Location = new System.Drawing.Point(105, 111);
            this.BTXoa.Name = "BTXoa";
            this.BTXoa.Size = new System.Drawing.Size(103, 52);
            this.BTXoa.TabIndex = 0;
            this.BTXoa.Text = "Xóa";
            this.BTXoa.UseVisualStyleBackColor = true;
            this.BTXoa.Click += new System.EventHandler(this.BTXoa_Click);
            // 
            // BTHuy
            // 
            this.BTHuy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BTHuy.Location = new System.Drawing.Point(283, 111);
            this.BTHuy.Name = "BTHuy";
            this.BTHuy.Size = new System.Drawing.Size(103, 52);
            this.BTHuy.TabIndex = 1;
            this.BTHuy.Text = "Hủy";
            this.BTHuy.UseVisualStyleBackColor = true;
            this.BTHuy.Click += new System.EventHandler(this.BTHuy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(82, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bạn chắc chắn muốn xóa nhân viên này không ?";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(480, 222);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTHuy);
            this.Controls.Add(this.BTXoa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Text = "Xóa nhân viên";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTXoa;
        private System.Windows.Forms.Button BTHuy;
        private System.Windows.Forms.Label label1;
    }
}