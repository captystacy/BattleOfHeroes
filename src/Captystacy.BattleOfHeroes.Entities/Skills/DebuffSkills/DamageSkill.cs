using Captystacy.BattleOfHeroes.Entities.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Skills.Base;
using Captystacy.BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills.Interfaces;

namespace Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills
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