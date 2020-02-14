namespace Cooking
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.panelRegistrationDoctors = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IdCard = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.registerDoctorOrSister = new System.Windows.Forms.Button();
            this.panelRegistrationDoctors.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRegistrationDoctors
            // 
            this.panelRegistrationDoctors.BackColor = System.Drawing.Color.Transparent;
            this.panelRegistrationDoctors.Controls.Add(this.label7);
            this.panelRegistrationDoctors.Controls.Add(this.password);
            this.panelRegistrationDoctors.Controls.Add(this.label3);
            this.panelRegistrationDoctors.Controls.Add(this.label2);
            this.panelRegistrationDoctors.Controls.Add(this.label1);
            this.panelRegistrationDoctors.Controls.Add(this.IdCard);
            this.panelRegistrationDoctors.Controls.Add(this.surname);
            this.panelRegistrationDoctors.Controls.Add(this.name);
            this.panelRegistrationDoctors.Controls.Add(this.registerDoctorOrSister);
            this.panelRegistrationDoctors.Location = new System.Drawing.Point(36, 22);
            this.panelRegistrationDoctors.Name = "panelRegistrationDoctors";
            this.panelRegistrationDoctors.Size = new System.Drawing.Size(280, 233);
            this.panelRegistrationDoctors.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(16, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Sifra:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(164, 97);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "ID kartice:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Prezime:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ime:";
            // 
            // IdCard
            // 
            this.IdCard.Location = new System.Drawing.Point(164, 66);
            this.IdCard.Name = "IdCard";
            this.IdCard.Size = new System.Drawing.Size(100, 20);
            this.IdCard.TabIndex = 3;
            // 
            // surname
            // 
            this.surname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.surname.Location = new System.Drawing.Point(164, 40);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(100, 20);
            this.surname.TabIndex = 2;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(164, 14);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(100, 20);
            this.name.TabIndex = 1;
            // 
            // registerDoctorOrSister
            // 
            this.registerDoctorOrSister.Location = new System.Drawing.Point(67, 207);
            this.registerDoctorOrSister.Name = "registerDoctorOrSister";
            this.registerDoctorOrSister.Size = new System.Drawing.Size(143, 23);
            this.registerDoctorOrSister.TabIndex = 0;
            this.registerDoctorOrSister.Text = "Registruj se";
            this.registerDoctorOrSister.UseVisualStyleBackColor = true;
            this.registerDoctorOrSister.Click += new System.EventHandler(this.registerDoctorOrSister_Click);
            // 
            // Register
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(327, 313);
            this.Controls.Add(this.panelRegistrationDoctors);
            this.Name = "Register";
            this.panelRegistrationDoctors.ResumeLayout(false);
            this.panelRegistrationDoctors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRegistrationDoctors;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IdCard;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button registerDoctorOrSister;
    }
}
