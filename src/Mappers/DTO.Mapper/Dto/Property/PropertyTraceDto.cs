using System;

namespace Weelo.Dto.Property
{
    public class PropertyTraceDto
    {
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
    }
}
