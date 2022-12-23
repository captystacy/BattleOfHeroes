using BattleOfHeroes.Entities.Skills.Base;
using BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;

namespace BattleOfHeroes.Entities.Skills.BuffSkills
{
    public class MakePrivilegedSkill : HitMultiplierSkill, IMakePrivilegedSkill
    {
        public MakePrivilegedSkill(int strokeCount)
            : base("наложение улучшения на персонажа своего отряда", 1.5, strokeCount)
        {
        }
    }
}
