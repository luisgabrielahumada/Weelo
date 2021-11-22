using System.Collections.Generic;

namespace Weelo.Dto.Property
{
    public class PropertyAllDto
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternational { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
        public string NameOwner { get; set; }
        public string AddressOwner { get; set; }
        public string Birthday { get; set; }
        public string Photo { get; set; }
        public int TotalRecords { get; set; }

    }
}
