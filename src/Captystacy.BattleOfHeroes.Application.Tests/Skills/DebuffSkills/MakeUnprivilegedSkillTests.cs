using Captystacy.BattleOfHeroes.Entities.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Skills.BuffSkills;
using Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills;
using Moq;

namespace Captystacy.BattleOfHeroes.Application.Tests.Skills.DebuffSkills
{
    public class MakeUnprivilegedSkillTests
    {
        [Fact]
        public void ItShould_remove_make_privileged_skill()
        {
            // arrange

            var heroMock = new Mock<IHero>();

            var makePrivilegedSkill = new MakePrivilegedSkill(1)
            {
                Hero = heroMock.Object
            };

            heroMock.Object.AddTemporarySkill(makePrivilegedSkill, 1);

            var sut = new MakeUnprivilegedSkill();

            // act

            sut.Apply(heroMock.Object);

            // assert

            Assert.False(heroMock.Object.AnyActiveSkill());
        }
    }
}
