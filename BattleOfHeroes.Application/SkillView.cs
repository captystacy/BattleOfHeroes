using BattleOfHeroes.Entities.Interfaces;
using BattleOfHeroes.Entities.Skills.Base;
using System.Text;
using BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;
using BattleOfHeroes.Entities.Skills.DebuffSkills;
using BattleOfHeroes.Entities.Skills.DebuffSkills.Interfaces;

namespace BattleOfHeroes.Application
{
    public class SkillView : ISkillView
    {
        public string GetView(IHero sender, IHero receiver, ISkill skill)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{GetHeroView(sender)}(Команда \"{sender.Team.Name}\") vs {GetHeroView(receiver)}(Команда \"{receiver.Team.Name}\")");

            stringBuilder.Append($"\t*** использовал умение - \"{skill.Name}\"");

            if (skill is DamageSkill damageSkill)
            {
                stringBuilder.Append($"(нанесение урона {damageSkill.LastHit} HP)");
            }

            stringBuilder.Append(" ***");

            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }

        private string GetHeroView(IHero hero)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"\"{hero.Name}\"");

            if (hero.Hp > 0)
            {
                stringBuilder.Append($"({hero.Hp} HP)");
            }
            else
            {
                stringBuilder.Append("(убит)");
            }

            if (hero.TryGetActiveSkill<IMakePrivilegedSkill>(out var makePrivilegedSkill))
            {
                stringBuilder.Append($"(улучшение ({makePrivilegedSkill!.Multiplier}x урон))");
            }

            if (hero.TryGetActiveSkill<IReduceHitSkill>(out var reduceHitSkill))
            {
                stringBuilder.Append($"(недуг ({reduceHitSkill!.Multiplier}x урон))");
            }

            return stringBuilder.ToString();
        }
    }
}
