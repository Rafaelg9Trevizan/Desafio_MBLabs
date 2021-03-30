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
    [Route("v1/institutions")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Institution>>> Get([FromServices] DataBroker Context)
        {
            try
            {
                var Institutions = await Context.Institutions.ToListAsync();

                if (Institutions.Count == 0)
                    return Ok("Institutions not Found!");

                return Institutions;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Institution>> GetById([FromServices] DataBroker Context, int id)
        {
        try
            {
                var institution = await Context.Institutions.FirstOrDefaultAsync(x => x.id == id);

                if (institution == null)
                    return Ok("Institution not found!");

                return institution;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Institution>> Post([FromServices] DataBroker Context, [FromBody] Institution model)
        {
             var valid = Validacoes.ValidaCNPJ(model.cnpj);

            if(!valid)
                return Ok("CNPJ is Invalid!");

            if (ModelState.IsValid)
            {
                Context.Institutions.Add(model);
                await Context.SaveChangesAsync();
                return model;
            }
            else
               return BadRequest(ModelState);
        }
        
        [HttpDelete("{id:int}")]
        [Route("")]
        public async Task<ActionResult<Institution>> Delete([FromServices] DataBroker Context, int id)
        {
            try
            {
                var institution = await Context.Institutions.FirstOrDefaultAsync(x => x.id == id);

                if (institution == null)
                    return Ok("Client not found!");

                var delete_institution = Context.Remove(institution);

                await Context.SaveChangesAsync();

                return institution;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpPut("{id}")]
        [Route("")]
        public async Task<ActionResult<Institution>> Put([FromServices] DataBroker Context, int id, Institution model)
        {
            try
            {
                var institution = await Context.Institutions.FirstOrDefaultAsync(x => x.id == id);

                if (institution == null)
                    return Ok("Client not found!");

                var valid = Validacoes.ValidaCPF(model.cnpj);

                if(!valid)
                    return Ok("CNPJ is Invalid!");

                institution.name = model.name;
                institution.cnpj = model.cnpj;
                institution.tipo = model.tipo;

                await Context.SaveChangesAsync();

                return institution;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }
    }
}