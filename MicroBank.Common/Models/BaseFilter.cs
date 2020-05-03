namespace MicroBank.Common.Models
{
    public class BaseFilter
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string Order { get; set; } = "CreatedAt";
        public string Direction { get; set; } = "asc"; //asc desc

        /// <summary>
        /// Search through all fields
        /// </summary>
        public string SearchTerm { get; set; }
    }
}

