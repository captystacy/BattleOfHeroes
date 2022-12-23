using Captystacy.BattleOfHeroes.Application.Tests.MockHelpers;
using Captystacy.BattleOfHeroes.Entities.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Skills.BuffSkills.Interfaces;
using Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills;
using Captystacy.BattleOfHeroes.Entities.Skills.DebuffSkills.Interfaces;
using Moq;

namespace Captystacy.BattleOfHeroes.Application.Tests.Skills.DebuffSkills
{
    public class DamageSkillTests
    {
        [Fact]
        public void ItShould_reduce_hit_when_reduce_hit_skill_is_active()
        {
            // arrange

            var heroMock = new Mock<IHero>();

            var reduceHitSkillMock = new Mock<IReduceHitSkill>();

            heroMock.Setup(reduceHitSkillMock.Object);

            var enemy = new Mock<IHero>();

            var sut = new DamageSkill(string.Empty, 10)
            {
                Hero = heroMock.Object
            };

            // act

            sut.Apply(enemy.Object);

            // assert

            reduceHitSkillMock.Verify(x => x.Affect(10));
        }

        [Fact]
        public void ItShould_increase_hit_when_privilege_skill_is_active()
        {
            // arrange

            var heroMock = new Mock<IHero>();

            var makePrivilegedSkillMock = new Mock<IMakePrivilegedSkill>();

            heroMock.Setup(makePrivilegedSkillMock.Object);

            var enemy = new Mock<IHero>();

            var sut = new DamageSkill(string.Empty, 10)
            {
                Hero = heroMock.Object
            };

            // act

            sut.Apply(enemy.Object);

            // assert

            makePrivilegedSkillMock.Verify(x => x.Affect(10));
        }

        [Fact]
        public void ItShould_deal_damage_when_no_skills_are_active()
        {
            // arrange

            var heroMock = new Mock<IHero>();

            var enemy = new Mock<IHero>();

            var sut = new DamageSkill(string.Empty, 10)
            {
                Hero = heroMock.Object
            };

            // act

            sut.Apply(enemy.Object);

            // assert

            enemy.Verify(x => x.Damage(10));
        }
    }
}
