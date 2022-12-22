namespace BattleOfHeroes.Entities.Interfaces
{
    public interface ITeam
    {
        string Name { get; }
        void AddHero(IHero hero);
        IHero Turn();
        bool IsAlive();
        void ClearCorpses();
    }
}
