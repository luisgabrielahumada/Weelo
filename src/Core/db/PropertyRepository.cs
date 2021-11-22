using Common.Infrastructure;
using Core.Component.Library.SQL;
using System.Collections.Generic;
using System.Linq;
using Weelo.Domain.Property;
using Weelo.Dto.Property;
using Weelo.Repository;
using Weelo.Repository.Interface;

namespace Weelo.Services
{
    public class PropertyRepository : IPropertyRepository
    {
        readonly AppDatabase db;
        Settings _settings;
        public PropertyRepository(Settings settings)
        {
            _settings = settings;
            db = new AppDatabase(settings.ConnectionStrings.ConnectionString);
        }
        public List<PropertyAllDto> PropertyList(FilterDto req)
        {
            var data = new Execute(db, "DB_Property_List",
                                   new
                                   {
                                       pageIndex = req.Pagination.PageIndex,
                                       pageSize = req.Pagination.PageSize,
                                       year = req.Year,
                                       price = req.Price,
                                       descripcion = req.Desciption
                                   })
                                   .Procedure<PropertyAllDto>()
                                   .ToList();
            return data;
        }
        public int Create(Property req)
        {
            return new Execute(db, "DB_Property_Save",
                                      new
                                      {
                                          IdProperty = 0,
                                          Address=req.Address,
                                          CodeInternational = req.CodeInternational,
                                          Name = req.Name,
                                          Price = req.Price,
                                          Year = req.Year,
                                          IdOwner = req.Owner.IdOwner,
                                          PropertyTrace = req.PropertyTrace
                                      })
                                      .Procedure<int>()
                                      .FirstOrDefault();
        }
        public void Update(int id, Property req)
        {
            _ = new Execute(db, "DB_Property_Save",
                                      new
                                      {
                                          IdProperty = id,
                                          Address = req.Address,
                                          CodeInternational = req.CodeInternational,
                                          Name = req.Name,
                                          Price = req.Price,
                                          Year = req.Year,
                                          IdOwner = req.Owner.IdOwner,
                                          PropertyTrace = new List<PropertyTrace>()
                                      })
                                      .Procedure<int>();
        }
        public void AddImage(int id, PropertyImage req)
        {
            _= new Execute(db, "DB_Property_Image_Save",
                                     new
                                     {
                                         idProperty = id,
                                         file = req.file,
                                         enabled = req.Enabled
                                     })
                                     .Procedure<int>();
        }
        public void UpdatePrice(int id, PropertyPriceDto req)
        {
          _ =  new Execute(db, "DB_Property_UpdatePrice",
                              new
                              {
                                  idProperty = id,
                                  price = req.Price
                              })
                              .Procedure<int>();
        }
    }
}