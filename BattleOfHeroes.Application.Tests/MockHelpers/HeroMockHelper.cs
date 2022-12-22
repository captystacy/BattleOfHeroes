using BattleOfHeroes.Entities.Interfaces;
using BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;
using BattleOfHeroes.Entities.Skills.DebuffSkills.Interfaces;
using Moq;

namespace BattleOfHeroes.Application.Tests.MockHelpers
{
    public static class HeroMockHelper
    {
        public static Mock<IHero> GetHeroMock(bool isAlive = true)
        {
            var heroMock = new Mock<IHero>();

            heroMock
                .Setup(x => x.IsAlive())
                .Returns(isAlive);

            return heroMock;
        }

        public static Mock<IHero> GetPrivilegedHeroMock()
        {
            var heroMock = new Mock<IHero>();

            IMakePrivilegedSkill? makePrivilegedSkill = null;
            heroMock.Setup(makePrivilegedSkill);

            return heroMock;
        }

        public static void Setup(this Mock<IHero> heroMock, IMakePrivilegedSkill? makePrivilegedSkill)
        {
            heroMock
                .Setup(x => x.TryGetActiveSkill(out makePrivilegedSkill))
                .Returns(true);
        }

        public static void Setup(this Mock<IHero> heroMock, IReduceHitSkill? reduceHitSkill)
        {
            heroMock
                .Setup(x => x.TryGetActiveSkill(out reduceHitSkill))
                .Returns(true);
        }
    }
}
