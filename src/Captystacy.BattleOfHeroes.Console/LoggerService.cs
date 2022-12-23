using Captystacy.BattleOfHeroes.Application.Services.Interfaces;

namespace Captystacy.BattleOfHeroes.Console
{
    public class LoggerService : ILoggerService
    {
        public void Log(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
