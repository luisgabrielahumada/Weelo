using Common.Infrastructure;
using Core.Component.Library.PagerRecord;
using Infrastructure.Helper;
using System;
using System.Linq;
using Weelo.Dto.Property;
using Weelo.Mapper.Interface;
using Weelo.Repository.Interface;
using Weelo.Services.Interface;

namespace Weelo.Services
{
    public class PropertyService : IProperty
    {
        public PropertyRepository db;
        public readonly Settings _settings;
        public readonly IPropertyMapper _map;
        public IPropertyRepository _db;
        public PropertyService(IPropertyMapper map, IPropertyRepository db, Settings settings)
        {
            _map = map;
            _db = db;
            _settings = settings;
        }

        public WebPagerRecord<PropertyAllDto> List(FilterDto req)
        {
            // Access to the database.
            var data = _db.PropertyList(req);
            var totalRecords = data.Count == 0 ? 0 : (int)data.FirstOrDefault().TotalRecords;
            return new WebPagerRecord<PropertyAllDto>(list: data, page: req.Pagination.PageIndex, pageSize: req.Pagination.PageSize, allItemsCount: totalRecords);
        }

        public int Create(NewPropertyDto req)
        {
            if (string.IsNullOrEmpty(req.Name))
                throw new Exception("The name of the property is required");

            if (string.IsNullOrEmpty(req.Name))
                throw new Exception("The price of the property is required");

            var property = _map.MapearNewProperty(req);
            // Access to the database.
            return _db.Create(property);
        }

        public void Update(int id, PropertyDto req)
        {

            if (string.IsNullOrEmpty(req.Name))
                throw new Exception("The name of the property is required");

            if (string.IsNullOrEmpty(req.Name))
                throw new Exception("The price of the property is required");

            if (id == 0)
                throw new Exception("The property ID required");


            var property = _map.MapearProperty(req);
            // Access to the database.
            _db.Update(id, property);
        }

        public void AddImage(int id, PropertyImageDto req)
        {
            if (id == 0)
                throw new Exception("The property ID required");

            if (req.File ==null || string.IsNullOrEmpty(req.File.Content))
                throw new Exception("The content of the file is required");

            if (req.File == null || string.IsNullOrEmpty(req.File.Name))
                throw new Exception("The name of the file is required");

            string referenceFile = Guid.NewGuid().ToString();
            var propertyImage = _map.MapearPropertyImageDto(req);
            // Upload file
            propertyImage.file = UploadFile.Upload($"{referenceFile}-{req.File.Name}", req.File.Content, _settings.Storage);
            // Access to the database.
            _db.AddImage(id, propertyImage);
        }

        public void UpdatePrice(int id, PropertyPriceDto req)
        {
            if (id == 0)
                throw new Exception("The property ID required");
            // Access to the database.
            _db.UpdatePrice(id, req);
        }
    }
}
