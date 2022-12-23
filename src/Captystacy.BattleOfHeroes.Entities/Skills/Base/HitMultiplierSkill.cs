namespace Captystacy.BattleOfHeroes.Entities.Skills.Base
{
    public class HitMultiplierSkill : TemporarySkill, IHitMultiplierSkill
    {
        public double Multiplier { get; }

        public HitMultiplierSkill(string name, double multiplier, int strokeCount) : base(name, strokeCount)
        {
            Multiplier = multiplier;
        }

        public int Affect(int hit)
        {
            return (int)double.Ceiling(Multiplier * hit);
        }
    }
}
