
using Microsoft.EntityFrameworkCore;
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
        public IQueryable<Stat> Stats => _context.Stats;
        public IQueryable<Category> Categories => _context.Categories;

        public void AddStat(Stat stat)
        {
            _context.Add(stat);
            _context.SaveChanges();
        }

        public IQueryable<Stat> GetStatsWithCategory()
        {
            return _context.Stats.Include(s => s.Category);
        }
    }
}
