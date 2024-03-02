namespace Mission_8_11.Models
{
    // Create the interface for our repository
    public interface IStatsRepository
    {
        // Grab the tables using IQueryable
        IQueryable<Stat> Stats { get; }
        IQueryable<Category> Categories { get; }

        // Some methods that will be made in the class for our repository
        public IQueryable<Stat> GetStatsWithCategory();
        public void AddStat(Stat stat);

        public void EditStat(Stat stat);
        public void DeleteStat(Stat stat);
    }
}
