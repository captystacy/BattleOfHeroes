using Captystacy.BattleOfHeroes.Entities.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Skills.Base;
using Captystacy.BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;

namespace Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills
{
    public class MakeUnprivilegedSkill : BaseSkill
    {
        public MakeUnprivilegedSkill() : base("наложение проклятия") { }

        public override void Apply(IHero hero)
        {
            if (hero.TryGetActiveSkill<IMakePrivilegedSkill>(out var makePrivilegedSkill))
            {
                hero.RemoveTemporarySkill(makePrivilegedSkill!);
            }
        }
    }
}
