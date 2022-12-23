using BattleOfHeroes.Entities.Interfaces;

namespace BattleOfHeroes.Entities.Skills.Base;

public interface ISkill
{
    string Name { get; }
    IHero Hero { get; set; }

    void Apply(IHero hero);
}