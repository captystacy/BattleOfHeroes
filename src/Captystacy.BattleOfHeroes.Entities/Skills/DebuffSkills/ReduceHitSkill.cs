using Captystacy.BattleOfHeroes.Entities.Skills.Base;
using Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills.Interfaces;

namespace Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills
{
    public class ReduceHitSkill : HitMultiplierSkill, IReduceHitSkill
    {
        public ReduceHitSkill(int strokeCount)
            : base("наслать недуг", 0.5, strokeCount) { }
    }
}
