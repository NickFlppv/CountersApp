using System.Collections.Generic;
using System.Linq;

namespace CountersApp.Model
{
    public interface ICountersRepository
    {
        IQueryable<Counter> GetCounters();
        int AddCounter(Counter counter);
        (int, int) GetCounts(int key);
        IQueryable<(int, int)> GetCounts();
    }
}