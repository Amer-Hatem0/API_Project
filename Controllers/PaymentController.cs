using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
 using TicketPurchaseAPI.Interface;
using TicketPurchaseAPI.Model;

namespace TicketPurchaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITicketRepository _ticketRepo;
        public PaymentController(IConfiguration config, UserManager<AppUser> userManager, ITicketRepository ticketRepo )
        {
            _config = config;
            _userManager = userManager;
            _ticketRepo = ticketRepo;
        }


        //Action method to pay for a ticket
        [HttpPost("{ticketId}")]
        [Authorize]
      
        public async Task<IActionResult> Checkout(int ticketId)
        {
             var ticket = await _ticketRepo.GetTicketById(ticketId);
            if (ticket == null)
            {
                return NotFound("Ticket not found.");
            }

     
            if (ticket.Status == Ticket.TicketStatus.Paid)
            {
                return BadRequest("This ticket has already been paid.");
            }

            

             ticket.Status = Ticket.TicketStatus.Paid;
            ticket.Updated_At = DateTime.UtcNow;
            await _ticketRepo.Update(ticket);

            return Ok(new
            {
                Message = "Payment successful. Ticket status updated to Paid.",
                TicketId = ticket.Id,
                UpdatedStatus = ticket.Status.ToString()
            });
        }


    }
}
    
            


   
