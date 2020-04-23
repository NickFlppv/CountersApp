using System.Collections.Generic;
using System.Linq;

namespace CountersApp.Model
{
    public class CountersRepository : ICountersRepository
    {
        private readonly DomainContext _context;

        public CountersRepository(DomainContext context)
        {
            _context = context;
        }

        public IQueryable<Counter> GetCounters() => _context.Counters;

        public int AddCounter(Counter counter)
        {
            _context.Counters.Add(counter);
            return _context.SaveChanges();
        }

        public IQueryable<(int, int)> GetCounts()
        {
            throw new System.NotImplementedException();
        }

        public (int, int) GetCounts(int key) =>
            (_context.Counters.Count(c => c.Key == key),
                _context.Counters.Count(c => c.Value > 1));
    }
}