
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Mission_8_11.Models
{
    // Make the class inherit from the interface
    public class EFStatsRepository : IStatsRepository
    {
        // create an instance of the database using the context file
        private CoolDataContext _context;

        // here's a constructor to make the repo
        public EFStatsRepository(CoolDataContext temp) 
        {
            _context = temp;
        }

        // Grab the stats table
        public IQueryable<Stat> Stats => _context.Stats;

        // Grab the Categories table
        public IQueryable<Category> Categories => _context.Categories;

        // Method to add a stat to the database and save changes
        public void AddStat(Stat stat)
        {
            _context.Add(stat);
            _context.SaveChanges();
        }

        // Method to update a task and save changes to the db
        public void EditStat(Stat stat)
        {
            _context.Update(stat);
            _context.SaveChanges();
        }

        // Method to delete a task and save changes to the db
        public void DeleteStat(Stat stat)
        {
            _context.Stats.Remove(stat);
            _context.SaveChanges();
        }

        // Method to get the stats and include Category
        public IQueryable<Stat> GetStatsWithCategory()
        {
            return _context.Stats.Include(s => s.Category);
        }
    }
}
