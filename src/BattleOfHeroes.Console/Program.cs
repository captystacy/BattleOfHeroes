using BattleOfHeroes.Application;
using BattleOfHeroes.Application.DefaultTeams;
using BattleOfHeroes.Console;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var teamA = new LightDefaultTeam();

var teamB = new DarkDefaultTeam();

var loggerService = new LoggerService();

var skillView = new SkillView();

var battle = new Battle(teamA, teamB, skillView, loggerService);

battle.Init();