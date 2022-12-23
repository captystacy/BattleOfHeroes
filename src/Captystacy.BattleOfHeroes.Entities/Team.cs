using Captystacy.BattleOfHeroes.Entities.Comparers;
using Captystacy.BattleOfHeroes.Entities.Interfaces;

namespace Captystacy.BattleOfHeroes.Entities
{
    public class Team : ITeam
    {
        public string Name { get; }

        private readonly PriorityQueue<IHero, IHero> _heroes;

        public Team(string name)
        {
            Name = name;
            _heroes = new PriorityQueue<IHero, IHero>(new PrivilegeComparer());
        }

        public void AddHero(IHero hero)
        {
            _heroes.Enqueue(hero, hero);
        }

        public IHero Turn()
        {
            IHero? result = null;

            if (_heroes.TryDequeue(out var hero, out var priority))
            {
                result = hero;
            }

            if (result is null)
            {
                throw new NullReferenceException("The queue is empty or you dequeued null");
            }

            if (result.IsAlive())
            {
                AddHero(result);
            }

            return result;
        }

        public bool IsAlive()
        {
            return _heroes.UnorderedItems.Any(x => x.Element.IsAlive());
        }

        public void ClearCorpses()
        {
            if (_heroes.UnorderedItems.Any(x => !x.Element.IsAlive()))
            {
                var aliveHeroes = _heroes.UnorderedItems
                    .Where(x => x.Element.IsAlive())
                    .Select(x => x.Element)
                    .ToList();

                _heroes.Clear();

                aliveHeroes.ForEach(AddHero);
            }
        }
    }
}
