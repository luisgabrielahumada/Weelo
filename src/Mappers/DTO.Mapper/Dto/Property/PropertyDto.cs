using System.Collections.Generic;

namespace Weelo.Dto.Property
{
    public class PropertyDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternational { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }

    }
}
