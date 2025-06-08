using System;

namespace LojaVirtual.Services.Logs
{
    public class LogConsole : ILogger
    {
        public void Registrar(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[LOG - {DateTime.Now}] {mensagem}");
            Console.ResetColor();
        }
    }
}
