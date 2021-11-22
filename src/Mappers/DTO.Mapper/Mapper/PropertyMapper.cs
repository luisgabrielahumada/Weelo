using System.Collections.Generic;
using System.Linq;
using Weelo.Domain.Property;
using Weelo.Dto.Property;
using Weelo.Mapper.Interface;

namespace Weelo.Mapper
{
    public class PropertyMapper : IPropertyMapper
    {
        public PropertyImage MapearPropertyImageDto(PropertyImageDto req)
        {
            var propertyImage = new PropertyImage
            {
                Enabled = req.Enabled,
            };

            return propertyImage;
        }

        public Property MapearProperty(PropertyDto req)
        {
            var property = new Property
            {
                Name = req.Name,
                Address = req.Address,
                Price = req.Price,
                CodeInternational = req.CodeInternational,
                Year = req.Year,
                Owner = new Owner
                {
                    IdOwner = req.IdOwner
                }
            };
            return property;
        }

        public Property MapearNewProperty(NewPropertyDto req)
        {
            var property = new Property
            {
                Name = req.Name,
                Address = req.Address,
                Price = req.Price,
                CodeInternational = req.CodeInternational,
                Year = req.Year,
                Owner = new Owner
                {
                    IdOwner = req.IdOwner
                },
                PropertyTrace = (req.PropertyTrace == null || req.PropertyTrace.Count() ==0) ? new List<PropertyTrace>()  : req.PropertyTrace.Select(m => new PropertyTrace
                {
                    DateSale = m.DateSale,
                    Name = m.Name,
                    Tax = m.Tax,
                    Value = m.Value
                }).ToList()
            };
            return property;
        }
    }
}
