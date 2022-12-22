using BattleOfHeroes.Entities.Interfaces;
using BattleOfHeroes.Entities.Skills.Base;

namespace BattleOfHeroes.Application;

public interface ISkillView
{
    string GetView(IHero sender, IHero receiver, ISkill skill);
}