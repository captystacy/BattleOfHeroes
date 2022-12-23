using BattleOfHeroes.Entities.Skills.Base;

namespace BattleOfHeroes.Entities.Interfaces
{
    public interface IHero
    {
        int Hp { get; }
        string Name { get; }
        ITeam Team { get; }

        bool AnyActiveSkill();
        void AddTemporarySkill(ISkill skill, int strokeCount);
        void RemoveTemporarySkill(ISkill skill);
        bool TryGetActiveSkill<T>(out T? skill) where T : class, ISkill;
        bool CanBuff();
        bool IsAlive();
        void Damage(int hit);
        bool IsActionToMyTeam();
        ISkill Buff(IHero comrade);
        ISkill Debuff(IHero enemy);
    }
}