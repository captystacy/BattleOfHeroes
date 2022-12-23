using System.Text;
using Captystacy.BattleOfHeroes.Entities.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Skills.Base;
using Captystacy.BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills;
using Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills.Interfaces;

namespace Captystacy.BattleOfHeroes.Application
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
