using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using g9events.Models;
using g9events.Api.Brokers;
using ValidacoesLibrary;

namespace g9events.Controllers
{
    [Route("v1/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        //Get api/institutions
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Client>>> Get([FromServices] DataBroker Context)
        {
            try
            {
                var Clients = await Context.Clients.ToListAsync();

                if (Clients.Count == 0)
                    return Ok("Clients not Found!");

                return Clients;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Client>> GetById([FromServices] DataBroker Context, int id)
        {
            try
            {
                var client = await Context.Clients.FirstOrDefaultAsync(x => x.id == id);

                if (client == null)
                    return Ok("Client not found!");

                return client;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
            
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Client>> Post( [FromServices] DataBroker Context, [FromBody] Client model)
        {
            var valid = Validacoes.ValidaCPF(model.cpf);

            if(!valid)
                return Ok("CPF is Invalid!");

            if (ModelState.IsValid)
            {
                Context.Clients.Add(model);
                await Context.SaveChangesAsync();
                return model;
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        [Route("")]
        public async Task<ActionResult<Client>> Delete([FromServices] DataBroker Context, int id)
        {
            try
            {
                var client = await Context.Clients.FirstOrDefaultAsync(x => x.id == id);

                if (client == null)
                    return Ok("Client not found!");

                var delete_client = Context.Remove(client);

                await Context.SaveChangesAsync();

                return client;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }

        }

        [HttpPut("{id}")]
        [Route("")]
        public async Task<ActionResult<Client>> Put([FromServices] DataBroker Context, int id, Client model)
        {
            try
            {
                var cliente = await Context.Clients.FirstOrDefaultAsync(x => x.id == id);

                if (cliente == null)
                    return Ok("Client not found!");

                var valid = Validacoes.ValidaCPF(model.cpf);

                if(!valid)
                    return Ok("CPF is Invalid!");

                cliente.name = model.name;
                cliente.cpf = model.cpf;
                cliente.categories = model.categories;
                cliente.cellphone = model.cellphone;

                await Context.SaveChangesAsync();

                return cliente;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }

        }
    }
}