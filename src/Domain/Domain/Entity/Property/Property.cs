using System.Collections.Generic;

namespace Weelo.Domain.Property
{
    public class Property
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternational { get; set; }
        public int Year { get; set; }
        public Owner Owner { get; set; }
        public List<PropertyImage> PropertyImage { get; set; }
        public List<PropertyTrace> PropertyTrace { get; set; }

    }
}
