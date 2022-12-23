using Calabonga.OperationResults;
using Captystacy.BattleOfHeroes.Entities;
using Captystacy.BattleOfHeroes.Entities.Skills.BuffSkills;
using Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills;

namespace Captystacy.BattleOfHeroes.Application.DefaultTeams
{
    public class DarkDefaultTeam : Team
    {
        public DarkDefaultTeam() : base("Dark")
        {
            var teamBHeroesBuildOperations = new List<OperationResult<Hero>>
            {
                new HeroBuilder("Орк-шаман", 100)
                    .AddBuffSkill(new MakePrivilegedSkill(1))
                    .AddDebuffSkill(new MakeUnprivilegedSkill())
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Орк-лучник", 100)
                    .AddDebuffSkill(new DamageSkill("стрелять из лука", 3))
                    .AddDebuffSkill(new DamageSkill("удар клинком", 2))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Нежить-охотник 1", 100)
                    .AddDebuffSkill(new DamageSkill("стрелять из лука", 4))
                    .AddDebuffSkill(new DamageSkill("удар клинком", 2))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Нежить-охотник 2", 100)
                    .AddDebuffSkill(new DamageSkill("стрелять из лука", 4))
                    .AddDebuffSkill(new DamageSkill("удар клинком", 2))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Орк-гоблин 1", 100)
                    .AddDebuffSkill(new DamageSkill("атака дубиной", 20))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Орк-гоблин 2", 100)
                    .AddDebuffSkill(new DamageSkill("атака дубиной", 20))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Нежить-зомби 1", 100)
                    .AddDebuffSkill(new DamageSkill("удар копьем", 18))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Нежить-зомби 2", 100)
                    .AddDebuffSkill(new DamageSkill("удар копьем", 18))
                    .SetTeam(this)
                    .Build(),
            };

            if (teamBHeroesBuildOperations.Any(x => !x.Ok))
            {
                var badOperations = teamBHeroesBuildOperations.Where(x => !x.Ok);
                throw new Exception(string.Join("\n", badOperations.Select(x => x.GetMetadataMessages())));
            }

        }
    }
}
