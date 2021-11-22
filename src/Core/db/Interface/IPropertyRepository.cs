using System.Collections.Generic;
using Weelo.Domain.Property;
using Weelo.Dto.Property;

namespace Weelo.Repository.Interface
{
    public interface IPropertyRepository
    {
        List<PropertyAllDto> PropertyList(FilterDto req);
        int Create(Property req);
        void Update(int id, Property req);
        void AddImage(int id, PropertyImage req);
        void UpdatePrice(int id, PropertyPriceDto req);
    }
}
