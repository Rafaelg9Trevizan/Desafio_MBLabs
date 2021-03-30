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
    [Route("v1/creditcards")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<CreditCard>>> Get([FromServices] DataBroker Context)
        {
            try
            {
                var CreditCards = await Context.CreditCards.ToListAsync();

                if (CreditCards.Count == 0)
                    return Ok("Clients not Found!");

                return CreditCards;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<CreditCard>> GetById([FromServices] DataBroker Context, int id)
        {
            try
            {
                var card = await Context.CreditCards.FirstOrDefaultAsync(x => x.card_id == id);

                if (card == null)
                    return Ok("Card not found!");

                return card;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<CreditCard>> Post([FromServices] DataBroker Context, [FromBody] CreditCard model)
        {
            var valid = Validacoes.ValidaCPF(model.owner_cpf);

            if (!valid)
                return Ok("CPF is Invalid!");

            if (ModelState.IsValid)
            {
                Context.CreditCards.Add(model);
                await Context.SaveChangesAsync();
                return model;
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        [Route("")]
        public async Task<ActionResult<CreditCard>> Delete([FromServices] DataBroker Context, int id)
        {
            try
            {
                var card = await Context.CreditCards.FirstOrDefaultAsync(x => x.card_id == id);

                if (card == null)
                    return Ok("Card not found!");

                var delete_card = Context.Remove(card);

                await Context.SaveChangesAsync();

                return card;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }

        }

        [HttpPut("{id}")]
        [Route("")]
        public async Task<ActionResult<CreditCard>> Put([FromServices] DataBroker Context, int id, CreditCard model)
        {
            try
            {
                var card = await Context.CreditCards.FirstOrDefaultAsync(x => x.card_id == id);

                if (card == null)
                    return Ok("Client not found!");

                var valid = Validacoes.ValidaCPF(model.owner_cpf);

                if (!valid)
                    return Ok("CPF is Invalid!");

                card.owner_name = model.owner_name;
                card.owner_cpf = model.owner_cpf;
                card.card_number = model.card_number;
                card.cvv = model.cvv;
                card.card_validity = model.card_validity;

                await Context.SaveChangesAsync();

                return card;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to request on database");
            }

        }
    }
}