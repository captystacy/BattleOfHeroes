using Captystacy.BattleOfHeroes.Application.Services.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Helpers;
using Captystacy.BattleOfHeroes.Entities.Interfaces;

namespace Captystacy.BattleOfHeroes.Application
{
    public class Battle
    {
        private readonly ITeam _teamA;
        private readonly ITeam _teamB;
        private readonly ISkillView _skillView;
        private readonly ILoggerService _loggerService;

        public Battle(ITeam teamA, ITeam teamB, ISkillView skillView, ILoggerService loggerService)
        {
            _teamA = teamA;
            _teamB = teamB;
            _skillView = skillView;
            _loggerService = loggerService;
        }

        public void Init()
        {
            var turn = RandomHelper.NextBool();

            _loggerService.Log("Да начнется битва!\n");

            do
            {
                var team = turn ? _teamA : _teamB;

                var hero = team.Turn();

                if (hero.IsActionToMyTeam() && hero.CanBuff())
                {
                    var comrade = turn ? _teamA.Turn() : _teamB.Turn();

                    var skill = hero.Buff(comrade);

                    var view = _skillView.GetView(hero, comrade, skill);

                    _loggerService.Log(view);
                }
                else
                {
                    var enemy = !turn ? _teamA.Turn() : _teamB.Turn();

                    var skill = hero.Debuff(enemy);

                    var view = _skillView.GetView(hero, enemy, skill);

                    _loggerService.Log(view);
                }

                team.ClearCorpses();

                turn = !turn;
            } while (_teamA.IsAlive() && _teamB.IsAlive());

            var winnerTeamName = _teamA.IsAlive() ? _teamA.Name : _teamB.Name;

            _loggerService.Log($"Команда \"{winnerTeamName}\" победила!");
        }
    }
}
