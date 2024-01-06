namespace Cmms.Models
{
    public class RestaurantQuery
    {
        public string SearchPhrases { get; set; }   
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } = 10;
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; } = SortDirection.Asc;
    }
}
