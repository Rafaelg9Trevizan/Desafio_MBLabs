using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using g9events.Models;
using g9events.Api.Brokers;

namespace g9events.Controllers
{
    [Route("v1/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Event>>> Get([FromServices] DataBroker Context)
        {
            try
            {
                var Events = await Context.Events.ToListAsync();

                if (Events.Count == 0)
                    return Ok("Event not Found!");

                return Events;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Event>> GetById([FromServices] DataBroker Context, int id)
        {
            try
            {
                var evento = await Context.Events.FirstOrDefaultAsync(x => x.id_event == id);

                if (evento == null)
                    return Ok("Event not found!");

                return evento;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Event>> Post([FromServices] DataBroker Context, [FromBody] Event model)
        {
            if (ModelState.IsValid)
            {
                Context.Events.Add(model);
                await Context.SaveChangesAsync();
                return model;
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        [Route("")]
        public async Task<ActionResult<Event>> Delete([FromServices] DataBroker Context, int id)
        {
            try
            {
                var evento = await Context.Events.FirstOrDefaultAsync(x => x.id_event == id);

                if (evento == null)
                    return Ok("Event not found!");

                var delete_evento = Context.Remove(evento);

                await Context.SaveChangesAsync();

                return evento;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpPut("{id}")]
        [Route("")]
        public async Task<ActionResult<Event>> Put([FromServices] DataBroker Context, int id, Event model)
        {
            try
            {
                var evento = await Context.Events.FirstOrDefaultAsync(x => x.id_event == id);

                if (evento == null)
                    return Ok("Event not found!");

                evento.event_name = model.event_name;
                evento.local = model.local;
                evento.description = model.description;
                evento.categories = model.categories;
                evento.institution_id = model.institution_id;
                evento.event_date = model.event_date;

                await Context.SaveChangesAsync();

                return evento;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }
    }
}