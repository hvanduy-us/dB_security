
namespace LAP4_CaNhan
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.LBAccount = new System.Windows.Forms.Label();
            this.LBPassword = new System.Windows.Forms.Label();
            this.TBAccount = new System.Windows.Forms.TextBox();
            this.TBPassWord = new System.Windows.Forms.TextBox();
            this.TBCaptCha = new System.Windows.Forms.TextBox();
            this.LBCaptCha = new System.Windows.Forms.Label();
            this.BTLogIn = new System.Windows.Forms.Button();
            this.BTExit = new System.Windows.Forms.Button();
            this.CBPassword = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(126, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LBAccount
            // 
            this.LBAccount.AutoSize = true;
            this.LBAccount.Location = new System.Drawing.Point(49, 77);
            this.LBAccount.Name = "LBAccount";
            this.LBAccount.Size = new System.Drawing.Size(52, 15);
            this.LBAccount.TabIndex = 1;
            this.LBAccount.Text = "Account";
            this.LBAccount.Click += new System.EventHandler(this.LBAccount_Click);
            // 
            // LBPassword
            // 
            this.LBPassword.AutoSize = true;
            this.LBPassword.Location = new System.Drawing.Point(49, 106);
            this.LBPassword.Name = "LBPassword";
            this.LBPassword.Size = new System.Drawing.Size(59, 15);
            this.LBPassword.TabIndex = 2;
            this.LBPassword.Text = "PassWord";
            this.LBPassword.Click += new System.EventHandler(this.label3_Click);
            // 
            // TBAccount
            // 
            this.TBAccount.Location = new System.Drawing.Point(111, 74);
            this.TBAccount.Name = "TBAccount";
            this.TBAccount.Size = new System.Drawing.Size(185, 23);
            this.TBAccount.TabIndex = 1;
            // 
            // TBPassWord
            // 
            this.TBPassWord.Location = new System.Drawing.Point(111, 103);
            this.TBPassWord.Name = "TBPassWord";
            this.TBPassWord.Size = new System.Drawing.Size(185, 23);
            this.TBPassWord.TabIndex = 2;
            this.TBPassWord.UseSystemPasswordChar = true;
            this.TBPassWord.TextChanged += new System.EventHandler(this.TBPassWord_TextChanged);
            // 
            // TBCaptCha
            // 
            this.TBCaptCha.Location = new System.Drawing.Point(148, 185);
            this.TBCaptCha.Name = "TBCaptCha";
            this.TBCaptCha.Size = new System.Drawing.Size(61, 23);
            this.TBCaptCha.TabIndex = 4;
            // 
            // LBCaptCha
            // 
            this.LBCaptCha.AutoSize = true;
            this.LBCaptCha.BackColor = System.Drawing.SystemColors.Highlight;
            this.LBCaptCha.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LBCaptCha.Location = new System.Drawing.Point(135, 154);
            this.LBCaptCha.Name = "LBCaptCha";
            this.LBCaptCha.Size = new System.Drawing.Size(99, 25);
            this.LBCaptCha.TabIndex = 5;
            this.LBCaptCha.Text = "CAPTCHA";
            // 
            // BTLogIn
            // 
            this.BTLogIn.Location = new System.Drawing.Point(68, 214);
            this.BTLogIn.Name = "BTLogIn";
            this.BTLogIn.Size = new System.Drawing.Size(78, 25);
            this.BTLogIn.TabIndex = 5;
            this.BTLogIn.Text = "LOG IN";
            this.BTLogIn.UseVisualStyleBackColor = true;
            this.BTLogIn.Click += new System.EventHandler(this.BTLogIn_Click);
            // 
            // BTExit
            // 
            this.BTExit.Location = new System.Drawing.Point(204, 214);
            this.BTExit.Name = "BTExit";
            this.BTExit.Size = new System.Drawing.Size(78, 25);
            this.BTExit.TabIndex = 6;
            this.BTExit.Text = "EXIT";
            this.BTExit.UseVisualStyleBackColor = true;
            this.BTExit.Click += new System.EventHandler(this.BTExit_Click);
            // 
            // CBPassword
            // 
            this.CBPassword.AutoSize = true;
            this.CBPassword.Location = new System.Drawing.Point(111, 132);
            this.CBPassword.Name = "CBPassword";
            this.CBPassword.Size = new System.Drawing.Size(110, 19);
            this.CBPassword.TabIndex = 3;
            this.CBPassword.Text = "Show PassWord";
            this.CBPassword.UseVisualStyleBackColor = true;
            this.CBPassword.CheckedChanged += new System.EventHandler(this.CBPassword_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(385, 273);
            this.Controls.Add(this.CBPassword);
            this.Controls.Add(this.BTExit);
            this.Controls.Add(this.BTLogIn);
            this.Controls.Add(this.TBCaptCha);
            this.Controls.Add(this.LBCaptCha);
            this.Controls.Add(this.TBPassWord);
            this.Controls.Add(this.TBAccount);
            this.Controls.Add(this.LBPassword);
            this.Controls.Add(this.LBAccount);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "MANAGEMENT OF STUDENT";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBAccount;
        private System.Windows.Forms.Label LBPassword;
        private System.Windows.Forms.TextBox TBAccount;
        private System.Windows.Forms.TextBox TBPassWord;
        private System.Windows.Forms.TextBox TBCaptCha;
        private System.Windows.Forms.Label LBCaptCha;
        private System.Windows.Forms.Button BTLogIn;
        private System.Windows.Forms.Button BTExit;
        private System.Windows.Forms.CheckBox CBPassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}

