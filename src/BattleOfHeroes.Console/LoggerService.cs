using BattleOfHeroes.Application.Services.Interfaces;

namespace BattleOfHeroes.Console
{
    public class LoggerService : ILoggerService
    {
        public void Log(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
