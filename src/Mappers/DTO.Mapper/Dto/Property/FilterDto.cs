using Weelo.Dto.Common;

namespace Weelo.Dto.Property
{
    public class FilterDto
    {
        public PaginationDto Pagination { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Desciption { get; set; }
    }
}
