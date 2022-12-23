using Captystacy.BattleOfHeroes.Entities.Skills.Base;
using Captystacy.BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;

namespace Captystacy.BattleOfHeroes.Entities.Skills.BuffSkills
{
    public class MakePrivilegedSkill : HitMultiplierSkill, IMakePrivilegedSkill
    {
        public MakePrivilegedSkill(int strokeCount)
            : base("наложение улучшения на персонажа своего отряда", 1.5, strokeCount)
        {
        }
    }
}
