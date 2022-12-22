using BattleOfHeroes.Entities.Interfaces;
using BattleOfHeroes.Entities.Skills.Base;
using BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;

namespace BattleOfHeroes.Entities.Skills.DebuffSkills
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
