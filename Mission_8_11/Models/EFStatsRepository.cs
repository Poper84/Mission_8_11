
using SQLitePCL;

namespace Mission_8_11.Models
{
    public class EFStatsRepository : IStatsRepository
    {
        private CoolDataContext _context;
        public EFStatsRepository(CoolDataContext temp) 
        {
        _context = temp;
        }
        public List<Stat> Stats => _context.Stats.ToList();

        public void AddStat(Stat stat)
        {
            _context.Add(stat);
            _context.SaveChanges();
        }
    }
}
