using BattleOfHeroes.Entities.Helpers;
using BattleOfHeroes.Entities.Interfaces;
using BattleOfHeroes.Entities.Skills.Base;

namespace BattleOfHeroes.Entities
{
    public class Hero : IHero
    {
        public int Hp { get; private set; }
        public string Name { get; }
        public ITeam Team { get; }

        private readonly IDictionary<ISkill, int> _activeSkills;
        private readonly IList<ISkill> _buffSkills;
        private readonly IList<ISkill> _debuffSkills;

        public Hero(string name, int hp, ITeam team, IList<ISkill> buffSkills, IList<ISkill> debuffSkills)
        {
            Name = name;
            Team = team;
            Hp = hp;
            _activeSkills = new Dictionary<ISkill, int>();
            _buffSkills = buffSkills;
            _debuffSkills = debuffSkills;
        }

        public bool AnyActiveSkill()
        {
            return _activeSkills.Any();
        }

        public void AddTemporarySkill(ISkill skill, int strokeCount)
        {
            if (!_activeSkills.ContainsKey(skill))
            {
                _activeSkills.Add(skill, strokeCount);
            }
        }

        public void RemoveTemporarySkill(ISkill skill)
        {
            _activeSkills.Remove(skill);
        }

        public bool TryGetActiveSkill<T>(out T? skill) where T : class, ISkill
        {
            skill = _activeSkills.FirstOrDefault(x =>
                x.Key.GetType().IsAssignableTo(typeof(T))).Key as T;

            return skill is not null;
        }

        public bool CanBuff()
        {
            return _buffSkills.Any();
        }

        public bool IsAlive()
        {
            return Hp > 0;
        }

        public void Damage(int hit)
        {
            Hp -= hit;
        }

        public bool IsActionToMyTeam()
        {
            return RandomHelper.NextBool();
        }

        public ISkill Buff(IHero comrade)
        {
            UpdateActiveSkillsExpirationTurns();

            return ApplySkill(_buffSkills, comrade);
        }

        public ISkill  Debuff(IHero enemy)
        {
            UpdateActiveSkillsExpirationTurns();

            return ApplySkill(_debuffSkills, enemy);
        }

        private void UpdateActiveSkillsExpirationTurns()
        {
            foreach (var key in _activeSkills.Keys)
            {
                _activeSkills[key]--;

                if (_activeSkills[key] == 0)
                {
                    _activeSkills.Remove(key);
                }
            }
        }

        private ISkill ApplySkill(IList<ISkill> actions, IHero hero)
        {
            var skill = actions.GetRandomItem();

            skill.Apply(hero);

            return skill;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Hp)}: {Hp}";
        }
    }
}
