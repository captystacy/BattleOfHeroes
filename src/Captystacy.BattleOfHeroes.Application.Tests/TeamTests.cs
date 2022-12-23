using Captystacy.BattleOfHeroes.Application.Tests.MockHelpers;
using Captystacy.BattleOfHeroes.Entities;
using Captystacy.BattleOfHeroes.Entities.Interfaces;

namespace Captystacy.BattleOfHeroes.Application.Tests
{
    public class TeamTests
    {
        [Fact]
        public void ItShould_pull_out_the_privileged_hero_first()
        {
            // arrange 

            var privilegedHero = HeroMockHelper.GetPrivilegedHeroMock().Object;

            var heroes = new List<IHero>
            {
                HeroMockHelper.GetHeroMock().Object,
                HeroMockHelper.GetHeroMock().Object,
                privilegedHero,
                HeroMockHelper.GetHeroMock().Object,
            };

            var sut = new Team(string.Empty);

            heroes.ForEach(x => sut.AddHero(x));

            // act

            var result = sut.Turn();

            // assert

            Assert.Same(privilegedHero, result);
        }

        [Fact]
        public void ItShould_enqueue_fresh_dequeued_hero()
        {
            // arrange

            var heroMock = HeroMockHelper.GetHeroMock();

            var heroes = new List<IHero>
            {
                heroMock.Object,
                HeroMockHelper.GetHeroMock().Object,
                HeroMockHelper.GetHeroMock().Object,
            };

            var sut = new Team(string.Empty);

            foreach (var hero in heroes)
            {
                sut.AddHero(hero);
            }

            // act

            var resultA = sut.Turn();
            sut.Turn();
            sut.Turn();
            var resultB = sut.Turn();

            // assert

            Assert.Same(heroMock.Object, resultA);
            Assert.Same(heroMock.Object, resultB);
        }

        [Fact]
        public void ItShould_do_not_enqueue_dead_hero()
        {
            // arrange

            var heroMock = HeroMockHelper.GetHeroMock(false);

            var heroes = new List<IHero>
            {
                heroMock.Object,
                HeroMockHelper.GetHeroMock().Object,
                HeroMockHelper.GetHeroMock().Object,
            };

            var sut = new Team(string.Empty);

            foreach (var hero in heroes)
            {
                sut.AddHero(hero);
            }

            // act

            sut.Turn();

            var results = new List<IHero>
            {
                sut.Turn(),
                sut.Turn(),
                sut.Turn(),
                sut.Turn(),
                sut.Turn(),
                sut.Turn(),
            };

            // assert

            Assert.DoesNotContain(heroMock.Object, results);
        }
    }
}