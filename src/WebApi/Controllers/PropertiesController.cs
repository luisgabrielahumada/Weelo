using Weelo.Services.Interface;
using Core.Component.Library.PagerRecord;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Helper;
using Weelo.Dto.Property;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/Properties")]
    public class PropertiesController : ControllerBase
    {
        private readonly IProperty _process;
        public PropertiesController(IProperty process)
        {
            _process = process;
        }

        [HttpPost]
        [Route("List")]
        public HttpMessage<WebPagerRecord<PropertyAllDto>> List(FilterDto req)
        {

            var resp = _process.List(req);

            return new HttpMessage<WebPagerRecord<PropertyAllDto>>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Data = resp
            };
        }

        [HttpPost]
        [Route("Properties")]
        public HttpMessage<int> Create(NewPropertyDto req)
        {
            var resp = _process.Create(req);

            return new HttpMessage<int>
            {
                StatusCode = HttpStatusCode.Created,
                IsSuccess = true,
                Data = resp
            };
        }

        [HttpPut]
        [Route("{id}")]
        public HttpMessage<int> Update(int id, PropertyDto req)
        {
            _process.Update(id, req);

            return new HttpMessage<int>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true
            };
        }

        [HttpPost]
        [Route("{id}/image")]
        public HttpMessage<int> AddImage(int id, PropertyImageDto req)
        {

            _process.AddImage(id, req);

            return new HttpMessage<int>
            {
                StatusCode = HttpStatusCode.Created,
                IsSuccess = true
            };
        }

        [HttpPatch]
        [Route("{id}/price")]
        public HttpMessage<int> Price(int id, PropertyPriceDto req)
        {
            _process.UpdatePrice(id, req);

            return new HttpMessage<int>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true
            };
        }
    }
}
