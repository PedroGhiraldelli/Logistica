namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Inicializa configuração da aplicação (fontes, DPI, etc)
            ApplicationConfiguration.Initialize();

            // Cria a instância do formulário login
            using (var loginForm = new login())
            {
                // Exibe login modal e captura resultado
                var resultado = loginForm.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    // Se login OK, abre formulário principal
                    Application.Run(new Form1());
                }
                else
                {
                    // Encerra aplicação caso login não tenha ocorrido
                    Application.Exit();
                }
            }
        }
    }
}
