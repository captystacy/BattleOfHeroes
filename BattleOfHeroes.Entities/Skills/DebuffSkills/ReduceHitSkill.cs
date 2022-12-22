using BattleOfHeroes.Entities.Skills.Base;
using BattleOfHeroes.Entities.Skills.DebuffSkills.Interfaces;

namespace BattleOfHeroes.Entities.Skills.DebuffSkills
{
    public class ReduceHitSkill : HitMultiplierSkill, IReduceHitSkill
    {
        public ReduceHitSkill(int strokeCount)
            : base("наслать недуг", 0.5, strokeCount) { }
    }
}
