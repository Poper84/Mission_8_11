namespace Mission_8_11.Models
{
    public interface IStatsRepository
    {
        List<Stat> Stats { get; }

        public void AddStat(Stat stat);
    }
}
