namespace Mission_8_11.Models
{
    public interface IStatsRepository
    {
        IQueryable<Stat> Stats { get; }
        IQueryable<Category> Categories { get; }

        public IQueryable<Stat> GetStatsWithCategory();
        public void AddStat(Stat stat);
    }
}
