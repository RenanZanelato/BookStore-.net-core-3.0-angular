using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Post([FromBody] T item)
        {
            await _service.Post(item);
            return new ObjectResult(
                new
                {
                    status = 200,
                    message = "Inserido com Sucesso"
                }
                );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromBody] T item, Guid id)
        {
            item.Id = id;
            await _service.Put(item);
            return new ObjectResult(
               new
               {
                   status = 200,
                   message = "Atualizado com Sucesso"
               }
               );
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {

            return Ok(await _service.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.Get());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
           await  _service.Delete(id);
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
