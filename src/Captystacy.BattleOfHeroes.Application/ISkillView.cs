using Captystacy.BattleOfHeroes.Entities.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Skills.Base;

namespace Captystacy.BattleOfHeroes.Application;

public interface ISkillView
{
    string GetView(IHero sender, IHero receiver, ISkill skill);
}