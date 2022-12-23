using BattleOfHeroes.Entities.Interfaces;
using BattleOfHeroes.Entities.Skills.Base;
using BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;
using BattleOfHeroes.Entities.Skills.DebuffSkills.Interfaces;

namespace BattleOfHeroes.Entities.Skills.DebuffSkills
{
    public class DamageSkill : BaseSkill
    {
        private readonly int _hit;

        public int LastHit;

        public DamageSkill(string name, int hit) : base(name)
        {
            _hit = hit;
        }

        public override void Apply(IHero hero)
        {
            LastHit = _hit;

            if (Hero.TryGetActiveSkill<IReduceHitSkill>(out var reduceHitSkill))
            {
                LastHit = reduceHitSkill!.Affect(LastHit);
            }

            if (Hero.TryGetActiveSkill<IMakePrivilegedSkill>(out var makePrivilegedSkill))
            {
                LastHit = makePrivilegedSkill!.Affect(LastHit);
            }

            hero.Damage(LastHit);
        }
    }
}