namespace Mission_8_11.Models
{
    public interface IStatsRepository
    {
        IQueryable<Stat> Stats { get; }
        IQueryable<Category> Categories { get; }

        public IQueryable<Stat> GetStatsWithCategory();
        public void AddStat(Stat stat);

        public void EditStat(Stat stat);
        public void DeleteStat(Stat stat);
    }
}
