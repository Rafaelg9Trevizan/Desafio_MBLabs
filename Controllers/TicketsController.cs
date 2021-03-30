using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using g9events.Models;
using g9events.Api.Brokers;

namespace g9events.Controllers
{
    [Route("v1/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Ticket>>> Get([FromServices] DataBroker Context)
        {
            try
            {
                var Tickets = await Context.Tickets.ToListAsync();

                if (Tickets.Count == 0)
                    return Ok("Ticket not Found!");

                return Tickets;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Ticket>> GetById([FromServices] DataBroker Context, int id)
        {
            try
            {
                var tickets = await Context.Tickets.FirstOrDefaultAsync(x => x.id_ticket == id);

                if (tickets == null)
                    return Ok("Ticket not found!");

                return tickets;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Ticket>> Post([FromServices] DataBroker Context, [FromBody] Ticket model)
        {
            if (ModelState.IsValid)
            {
                Context.Tickets.Add(model);
                await Context.SaveChangesAsync();
                return model;
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        [Route("")]
        public async Task<ActionResult<Ticket>> Delete([FromServices] DataBroker Context, int id)
        {
            try
            {
                var tickets = await Context.Tickets.FirstOrDefaultAsync(x => x.id_ticket == id);

                if (tickets == null)
                    return Ok("Ticket not found!");

                var delete_tickets = Context.Remove(tickets);

                await Context.SaveChangesAsync();

                return tickets;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpPut("{id}")]
        [Route("")]
        public async Task<ActionResult<Ticket>> Put([FromServices] DataBroker Context, int id, Ticket model)
        {
            try
            {
                var tickets = await Context.Tickets.FirstOrDefaultAsync(x => x.id_ticket == id);

                if (tickets == null)
                    return Ok("Ticket not found!");

                tickets.price = model.price;
                tickets.type = model.type;
                tickets.event_id = model.event_id;

                await Context.SaveChangesAsync();

                return tickets;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }
    }
}