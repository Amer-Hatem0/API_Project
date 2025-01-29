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


        [HttpPost("{ticketId}")]
        [Authorize]
        public async Task<IActionResult> Checkout(int ticketId)
        {
             var ticket = await _ticketRepo.GetTicketById(ticketId);
            if (ticket == null)
            {
                return NotFound("Ticket not found.");
            }

             ticket.Updated_At = DateTime.UtcNow;
            ticket.Event.TicketSold++;
            ticket.PaymentCount++;  

             await _ticketRepo.Update(ticket);

             return Ok(new
            {
                Message = $"Payment successful. You have purchased this ticket {ticket.PaymentCount} time(s).",
                TicketId = ticket.Id,
           
                PaymentCount = ticket.PaymentCount
            });
        }


    }
}
    
            


   
