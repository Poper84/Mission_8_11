namespace Mission_8_11.Models
{
    public interface IStatsRepository
    {
        List<Stat> Stats { get; }
        List<Category> Categories { get; }

        public void AddStat(Stat stat);
    }
}
