namespace WinFormsApp1
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            label1 = new Label();
            textBox_usuario = new TextBox();
            textBox_senha = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button_entrar = new Button();
            button_cadastro = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(130, 70);
            label1.Name = "label1";
            label1.Size = new Size(78, 27);
            label1.TabIndex = 0;
            label1.Text = "Entrar";
            // 
            // textBox_usuario
            // 
            textBox_usuario.Location = new Point(99, 169);
            textBox_usuario.Name = "textBox_usuario";
            textBox_usuario.Size = new Size(137, 23);
            textBox_usuario.TabIndex = 1;
            // 
            // textBox_senha
            // 
            textBox_senha.Location = new Point(99, 234);
            textBox_senha.Name = "textBox_senha";
            textBox_senha.Size = new Size(137, 23);
            textBox_senha.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(99, 151);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 3;
            label2.Text = "Usuário";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(99, 216);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Senha";
            // 
            // button_entrar
            // 
            button_entrar.Location = new Point(130, 301);
            button_entrar.Name = "button_entrar";
            button_entrar.Size = new Size(75, 23);
            button_entrar.TabIndex = 5;
            button_entrar.Text = "Entrar";
            button_entrar.UseVisualStyleBackColor = true;
            button_entrar.Click += button_entrar_Click_1;
            // 
            // button_cadastro
            // 
            button_cadastro.Location = new Point(130, 344);
            button_cadastro.Name = "button_cadastro";
            button_cadastro.Size = new Size(75, 23);
            button_cadastro.TabIndex = 6;
            button_cadastro.Text = "Cadastrar";
            button_cadastro.UseVisualStyleBackColor = true;
            button_cadastro.Click += button_cadastro_Click_1;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(339, 450);
            Controls.Add(button_cadastro);
            Controls.Add(button_entrar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox_senha);
            Controls.Add(textBox_usuario);
            Controls.Add(label1);
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_usuario;
        private TextBox textBox_senha;
        private Label label2;
        private Label label3;
        private Button button_entrar;
        private Button button_cadastro;
    }
}