using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Application.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class BaseController<T> : ControllerBase
        where T : BaseEntity
    {
        private readonly IBaseService<T> _service;
        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] T item)
        {
            _service.Post(item);
            return new ObjectResult(item);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromBody] T item, Guid id)
        {
            item.Id = id;
            return new ObjectResult(_service.Put(item));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {

            return new ObjectResult(_service.Get(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new ObjectResult(_service.Get());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return new ObjectResult(
                new
                {
                    status = 200,
                    message = "Removido com succeso"
                }
                );
        }
    }
}
