using Core.Component.Library.PagerRecord;
using Weelo.Dto.Property;

namespace Weelo.Services.Interface
{
    public interface IProperty
    {
        WebPagerRecord<PropertyAllDto> List(FilterDto req);
        int Create(NewPropertyDto req);
        void Update(int id, PropertyDto req);
        void AddImage(int id, PropertyImageDto req);
        void UpdatePrice(int id, PropertyPriceDto req);
    }
}
