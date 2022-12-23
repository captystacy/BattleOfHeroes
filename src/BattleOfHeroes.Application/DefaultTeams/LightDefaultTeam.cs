using BattleOfHeroes.Entities;
using BattleOfHeroes.Entities.Skills.BuffSkills;
using BattleOfHeroes.Entities.Skills.DebuffSkills;
using Calabonga.OperationResults;

namespace BattleOfHeroes.Application.DefaultTeams
{
    public class LightDefaultTeam : Team
    {
        public LightDefaultTeam() : base("Light")
        {
            var teamAHeroesBuildOperations = new List<OperationResult<Hero>>
            {
                new HeroBuilder("Эльф-маг", 100)
                    .AddBuffSkill(new MakePrivilegedSkill(1))
                    .AddDebuffSkill(new DamageSkill("атаковать магией", 10))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Эльф-лучник", 100)
                    .AddDebuffSkill(new DamageSkill("стрелять из лука", 7))
                    .AddDebuffSkill(new DamageSkill("атаковать", 3))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Человек-арбалетчик 1", 100)
                    .AddDebuffSkill(new DamageSkill("стрелять из арбалета", 7))
                    .AddDebuffSkill(new DamageSkill("атаковать", 3))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Человек-арбалетчик 2", 100)
                    .AddDebuffSkill(new DamageSkill("стрелять из арбалета", 7))
                    .AddDebuffSkill(new DamageSkill("атаковать", 3))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Эльф-воин 1", 100)
                    .AddDebuffSkill(new DamageSkill("атаковать мечом", 15))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Эльф-воин 2", 100)
                    .AddDebuffSkill(new DamageSkill("атаковать мечом", 15))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Человек-воин 1", 100)
                    .AddDebuffSkill(new DamageSkill("атаковать мечом", 18))
                    .SetTeam(this)
                    .Build(),
                new HeroBuilder("Человек-воин 2", 100)
                    .AddDebuffSkill(new DamageSkill("атаковать мечом", 18))
                    .SetTeam(this)
                    .Build(),
            };

            if (teamAHeroesBuildOperations.Any(x => !x.Ok))
            {
                var badOperations = teamAHeroesBuildOperations.Where(x => !x.Ok);
                throw new Exception(string.Join("\n", badOperations.Select(x => x.GetMetadataMessages())));
            }
        }
    }
}
