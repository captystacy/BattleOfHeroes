namespace BattleOfHeroes.Entities.Skills.Base;

public interface IHitMultiplierSkill : ISkill
{
    double Multiplier { get; }
    int Affect(int hit);
}