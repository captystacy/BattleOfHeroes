using BattleOfHeroes.Entities;
using BattleOfHeroes.Entities.Interfaces;
using BattleOfHeroes.Entities.Skills.Base;
using Calabonga.OperationResults;

namespace BattleOfHeroes.Application
{
    public class HeroBuilder
    {
        private readonly string _name;
        private readonly int _hp;

        private readonly List<ISkill> _buffSkills = new();
        private readonly List<ISkill> _debuffSkills = new();
        private ITeam? _team;

        public HeroBuilder(string name, int hp)
        {
            _name = name;
            _hp = hp;
        }

        public HeroBuilder AddBuffSkill(ISkill skill)
        {
            _buffSkills.Add(skill);

            return this;
        }

        public HeroBuilder AddDebuffSkill(ISkill skill)
        {
            _debuffSkills.Add(skill);

            return this;
        }

        public HeroBuilder SetTeam(ITeam team)
        {
            _team = team;

            return this;
        }

        public OperationResult<Hero> Build()
        {
            var operation = OperationResult.CreateResult<Hero>();

            if (string.IsNullOrEmpty(_name))
            {
                operation.AddError("Name was not set");
                return operation;
            }

            if (_hp < 0)
            {
                operation.AddError("Hp can't be less than zero");
                return operation;
            }

            if (_team is null)
            {
                operation.AddError("Team was not set");
                return operation;
            }

            if (!_buffSkills.Any() && !_debuffSkills.Any())
            {
                operation.AddError("Hero must have at least one skill");
                return operation;
            }

            var hero = new Hero(_name, _hp, _team, _buffSkills, _debuffSkills);

            _buffSkills.ForEach(x => x.Hero = hero);
            _debuffSkills.ForEach(x => x.Hero = hero);
            _team.AddHero(hero);

            operation.Result = hero;

            return operation;
        }
    }
}
