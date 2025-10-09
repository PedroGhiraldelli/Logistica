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
            // Inicializa configura��o da aplica��o (fontes, DPI, etc)
            ApplicationConfiguration.Initialize();

            // Cria a inst�ncia do formul�rio login
            using (var loginForm = new login())
            {
                // Exibe login modal e captura resultado
                var resultado = loginForm.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    // Se login OK, abre formul�rio principal
                    Application.Run(new Form1());
                }
                else
                {
                    // Encerra aplica��o caso login n�o tenha ocorrido
                    Application.Exit();
                }
            }
        }
    }
}
