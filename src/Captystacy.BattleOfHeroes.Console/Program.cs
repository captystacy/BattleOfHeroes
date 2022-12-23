using Captystacy.BattleOfHeroes.Application;
using Captystacy.BattleOfHeroes.Application.DefaultTeams;
using Captystacy.BattleOfHeroes.Console;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var teamA = new LightDefaultTeam();

var teamB = new DarkDefaultTeam();

var loggerService = new LoggerService();

var skillView = new SkillView();

var battle = new Battle(teamA, teamB, skillView, loggerService);

battle.Init();