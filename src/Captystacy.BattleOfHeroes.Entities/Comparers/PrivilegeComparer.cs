using Captystacy.BattleOfHeroes.Entities.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;

namespace Captystacy.BattleOfHeroes.Entities.Comparers
{
    public class PrivilegeComparer : IComparer<IHero>
    {
        public int Compare(IHero? heroX, IHero? heroY)
        {
            if (heroX is null)
            {
                throw new ArgumentNullException(nameof(heroX));
            }

            if (heroY is null)
            {
                throw new ArgumentNullException(nameof(heroY));
            }

            var heroXIsPrivileged = 
                heroX.TryGetActiveSkill<IMakePrivilegedSkill>(out var heroAMakePrivilegedSkill);

            var heroYIsPrivileged = 
                heroY.TryGetActiveSkill<IMakePrivilegedSkill>(out var heroBMakePrivilegedSkill);

            if (heroXIsPrivileged && heroYIsPrivileged)
            {
                return 0;
            }

            if (heroXIsPrivileged)
            {
                return -1;
            }

            return 1;
        }
    }
}
