using Common.Infrastructure;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProjectWeelo.Helper;
using Weelo.Domain.Property;
using Weelo.Dto.Common;
using Weelo.Dto.Property;
using Weelo.Mapper.Interface;
using Weelo.Repository.Interface;
using Weelo.Services;

namespace TestProjectWeelo
{
    public class Property_Test
    {
        private Mock<IPropertyMapper> iPropertyMapper;
        private Mock<IPropertyRepository> iPropertyRepository;
        private PropertyService propertyService;
        FilterDto filter;
        [SetUp]
        public void Setup()
        {
            iPropertyRepository = new Mock<IPropertyRepository>();
            iPropertyMapper = new Mock<IPropertyMapper>();
            Settings settings = new Settings
            {
                Storage = new Storage
                {
                    ConnectionString = "DefaultEndpointsProtocol=https;AccountName=weelo;AccountKey=Q7PG9A7+/LgEcp3Wh0xl5Mz0+ZJH1/Uj0vaAQ43iYzmYKj6gDAZ94VsXvfm6iA5ABs7GcvRonBkTrfwLOADpJQ==;EndpointSuffix=core.windows.net",
                    ContaninerName = "attachments"
                }
            };
            propertyService = new PropertyService(iPropertyMapper.Object, iPropertyRepository.Object, settings);
            filter = new FilterDto
            {
                Pagination = new PaginationDto
                {
                    PageIndex = 1,
                    PageSize = 20
                },
                Desciption = string.Empty,
                Price = 0,
                Year = 0
            };
        }

        [Test]
        public void Property_List_Success()
        {
            iPropertyRepository.Setup(p => p.PropertyList(It.IsAny<FilterDto>())).Returns(PropertyDtoTest.Properties());
            var resp = propertyService.List(filter);
            Assert.IsTrue(resp.items.Count() > 0);
        }

        [Test]
        public void Property_List_Fail()
        {
            iPropertyRepository.Setup(p => p.PropertyList(It.IsAny<FilterDto>())).Returns(new List<PropertyAllDto>());
            var resp = propertyService.List(filter);
            Assert.IsFalse(resp.items.Count() > 0);
        }


        [Test]
        public void Property_Create_Success()
        {
            iPropertyRepository.Setup(p => p.Create(It.IsAny<Property>())).Returns(7);
            var resp = propertyService.Create(PropertyDtoTest.NewProperty());
            Assert.IsTrue(resp > 0);
        }

        [Test]
        public void Property_Create_Fail()
        {
            iPropertyRepository.Setup(p => p.Create(It.IsAny<Property>())).Returns(0);
            var resp = propertyService.Create(PropertyDtoTest.NewProperty());
            Assert.IsFalse(resp > 0);
        }


        [Test]
        public void Property_Update_Success()
        {
            iPropertyRepository.Setup(p => p.Update(It.IsAny<int>(), It.IsAny<Property>()));
            propertyService.Update(7, PropertyDtoTest.Property());
            Assert.IsTrue(true);
        }

        [Test]
        public void Property_Update_Exception_Fail()
        {
            iPropertyRepository.Setup(p => p.Update(It.IsAny<int>(), It.IsAny<Property>()));
            var ex = Assert.Throws<Exception>(() => propertyService.Update(0, PropertyDtoTest.Property()));
            Assert.AreEqual("The property ID required", ex.Message);
        }

        [Test]
        public void Property_Update_Fail()
        {
            iPropertyRepository.Setup(p => p.Update(It.IsAny<int>(), It.IsAny<Property>()));
            propertyService.Update(7, PropertyDtoTest.Property());
            Assert.IsTrue(true);
        }


        [Test]
        public void Property_UpdatePrice_Success()
        {
            iPropertyRepository.Setup(p => p.UpdatePrice(It.IsAny<int>(), It.IsAny<PropertyPriceDto>()));
            propertyService.UpdatePrice(7, PropertyDtoTest.PropertyPrice());
            Assert.IsTrue(true);
        }

        [Test]
        public void Property_UpdatePrice_Fail()
        {
            iPropertyRepository.Setup(p => p.UpdatePrice(It.IsAny<int>(), It.IsAny<PropertyPriceDto>()));
            propertyService.UpdatePrice(7, PropertyDtoTest.PropertyPrice());
            Assert.IsTrue(true);
        }

        [Test]
        public void Property_UpdatePrice_Exception_Fail()
        {
            iPropertyRepository.Setup(p => p.UpdatePrice(It.IsAny<int>(), It.IsAny<PropertyPriceDto>()));
            var ex = Assert.Throws<Exception>(() => propertyService.Update(0, PropertyDtoTest.Property()));
            Assert.AreEqual("The property ID required", ex.Message);
        }



        [Test]
        public void Property_AddImage_Success()
        {

            iPropertyMapper.Setup(m => m.MapearPropertyImageDto(It.IsAny<PropertyImageDto>())).Returns(new PropertyImage());
            iPropertyRepository.Setup(p => p.AddImage(It.IsAny<int>(), It.IsAny<PropertyImage>()));
            propertyService.AddImage(7, PropertyDtoTest.NewImage());
            Assert.IsTrue(true);
        }

        [Test]
        public void Property_AddImage_Fail()
        {
            iPropertyMapper.Setup(m => m.MapearPropertyImageDto(It.IsAny<PropertyImageDto>())).Returns(new PropertyImage());
            iPropertyRepository.Setup(p => p.AddImage(It.IsAny<int>(), It.IsAny<PropertyImage>()));
            propertyService.AddImage(8, PropertyDtoTest.NewImage());
            Assert.IsTrue(true);
        }

        [Test]
        public void Property_AddImage_NotContent_Fail()
        {
            iPropertyMapper.Setup(m => m.MapearPropertyImageDto(It.IsAny<PropertyImageDto>())).Returns(new PropertyImage());
            iPropertyRepository.Setup(p => p.AddImage(It.IsAny<int>(), It.IsAny<PropertyImage>()));
            var ex = Assert.Throws<Exception>(() => propertyService.AddImage(7, PropertyDtoTest.NewNotContentImage()));
            Assert.AreEqual("The content of the file is required", ex.Message);
        }
    }
}