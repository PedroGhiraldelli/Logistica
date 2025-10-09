namespace WinFormsApp1
{
    partial class cadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cadastro));
            label1 = new Label();
            label2 = new Label();
            label = new Label();
            label4 = new Label();
            textBox_user = new TextBox();
            textBox_pwd = new TextBox();
            textBox_cpwd = new TextBox();
            button_cadastrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(111, 71);
            label1.Name = "label1";
            label1.Size = new Size(117, 27);
            label1.TabIndex = 0;
            label1.Text = "Cadastrar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(96, 140);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Usuário";
            // 
            // label
            // 
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Location = new Point(96, 198);
            label.Name = "label";
            label.Size = new Size(39, 15);
            label.TabIndex = 2;
            label.Text = "Senha";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(96, 265);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 3;
            label4.Text = "Confirme Senha";
            // 
            // textBox_user
            // 
            textBox_user.Location = new Point(96, 158);
            textBox_user.Name = "textBox_user";
            textBox_user.Size = new Size(152, 23);
            textBox_user.TabIndex = 4;
            // 
            // textBox_pwd
            // 
            textBox_pwd.Location = new Point(96, 216);
            textBox_pwd.Name = "textBox_pwd";
            textBox_pwd.Size = new Size(152, 23);
            textBox_pwd.TabIndex = 5;
            // 
            // textBox_cpwd
            // 
            textBox_cpwd.Location = new Point(96, 283);
            textBox_cpwd.Name = "textBox_cpwd";
            textBox_cpwd.Size = new Size(152, 23);
            textBox_cpwd.TabIndex = 6;
            // 
            // button_cadastrar
            // 
            button_cadastrar.Location = new Point(129, 339);
            button_cadastrar.Name = "button_cadastrar";
            button_cadastrar.Size = new Size(75, 23);
            button_cadastrar.TabIndex = 7;
            button_cadastrar.Text = "Cadastrar";
            button_cadastrar.UseVisualStyleBackColor = true;
            button_cadastrar.Click += button_cadastrar_Click;
            // 
            // cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(339, 450);
            Controls.Add(button_cadastrar);
            Controls.Add(textBox_cpwd);
            Controls.Add(textBox_pwd);
            Controls.Add(textBox_user);
            Controls.Add(label4);
            Controls.Add(label);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "cadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "cadastro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label;
        private Label label4;
        private TextBox textBox_user;
        private TextBox textBox_pwd;
        private TextBox textBox_cpwd;
        private Button button_cadastrar;
    }
}