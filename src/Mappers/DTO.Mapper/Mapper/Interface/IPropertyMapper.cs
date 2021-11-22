using Weelo.Domain.Property;
using Weelo.Dto.Property;

namespace Weelo.Mapper.Interface
{
    public interface IPropertyMapper
    {
        Property MapearProperty(PropertyDto req);
        PropertyImage MapearPropertyImageDto(PropertyImageDto req);
        Property MapearNewProperty(NewPropertyDto req);
    }
}
