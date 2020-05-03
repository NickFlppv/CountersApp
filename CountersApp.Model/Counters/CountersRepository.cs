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

        public IEnumerable<(int, int, int)> GetCounts()
        {
            var filteredCounts = _context.Counters
                .Where(c => c.Value > 1)
                .GroupBy(c => c.Key, c => c.Value)
                .Select(group => new {Key = group.Key, CountMoreThanOne = group.Count()}).ToList();
            var counts = _context.Counters
                .GroupBy(c => c.Key, c => c.Value)
                .Select(group => new {Key = group.Key, Count = group.Count()}).ToList();
            return counts
                .Join(
                filteredCounts, 
                first => first.Key, 
                second => second.Key,
                (first,second) => new {first.Key, first.Count, second.CountMoreThanOne})
                .Select(j => (j.Key, j.Count, j.CountMoreThanOne));
        }

        public (int, int) GetCountsByKey(int key) =>
            (_context.Counters.Count(c => c.Key == key),
                _context.Counters.Count(c => c.Value > 1));
    }
}