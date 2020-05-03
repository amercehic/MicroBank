using System.Collections.Generic;

namespace MicroBank.Common.Models
{
    /// <summary>
    /// Wrapper for return value from list endpoints
    /// </summary>
    /// <typeparam name="T1">Type of items</typeparam>
    /// <typeparam name="T2">Type of id</typeparam>
    public class QueryResultDto<T1, T2>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T1> Items { get; set; }
    }
}
