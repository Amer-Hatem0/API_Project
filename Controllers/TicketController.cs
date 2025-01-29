using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TicketPurchaseAPI.Extensions;
using TicketPurchaseAPI.Interface;
using TicketPurchaseAPI.Model;
using TicketPurchaseAPI.Services;
using static TicketPurchaseAPI.Model.Ticket;

namespace TicketPurchaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepo;
        private readonly IEventRepository _eventRepo;
        private readonly IQRGeneratorService _qrGeneratorService;
        private readonly IPaymentRepository _paymentRepo;
        private readonly UserManager<AppUser> _userManager;
       
        public TicketController(ITicketRepository ticketRepo, IEventRepository  eventRepo, IQRGeneratorService qRGeneratorService,IPaymentRepository paymentRepo
            ,UserManager<AppUser> userManager)
        {
            _ticketRepo = ticketRepo;
            _eventRepo = eventRepo;
            _qrGeneratorService = qRGeneratorService;
            _paymentRepo = paymentRepo;
            _userManager = userManager;
           
        }

        //Action method to create ticket
        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create (int eventId,string ticketType)
        {
            //check input
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

    
            var user = User.GetUsername();

            
            var eventObject = await _eventRepo.GetByIdAsync(eventId);
            if (eventObject == null)
            {
                return StatusCode(500, "Event not found");
            }
           
            else if (eventObject.TicketSold == eventObject.Capacity)
            {
                return BadRequest("Event has been sold out");
            }
           
         
            var newTicket = await _ticketRepo.CreateTicketAsync(eventObject, ticketType,user);

           
            var newPayment = await _paymentRepo.CreatePaymentAsync(user, newTicket.Id, newTicket.Price);
            return Ok(newTicket);
            
        }

  
        [HttpPost("{id}/QRrCodeGen")]
        [Authorize]
        public async Task<IActionResult> QRCodeData([FromRoute]int id)
        {
         
            var ticket = await _ticketRepo.GetTicketById(id);

         
            if (ticket.Status == TicketStatus.Pending)
            {
                return BadRequest("Can't Generate QRCode...Make Payment first"); 
            }

      
            await _qrGeneratorService.GenerateImage(ticket);

            return Ok();
        }



        [HttpGet("/Confirmpayment/{id}")]
        public async Task<IActionResult> ConfirmPayment(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             if (await _ticketRepo.TicketExists(id))
            {
                var ticket = await _ticketRepo.GetTicketById(id);

                if (ticket.Status == Ticket.TicketStatus.Paid)
                {
                    return Ok("Payment already confirmed. Ticket is already paid.");
                }

                 return BadRequest("Payment could not be confirmed because the ticket is not paid.");
            }

            return NotFound("Ticket was not found.");
        }


        //Action method to get list of tickets 
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Tickets()
        {
            
            var tickets = await _ticketRepo.GetTicketsAsync();
            if (tickets == null)
            {
                return NotFound();
            }
           
            return Ok(tickets);
        }


        //Action method to get a particular ticket
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> TicketById([FromRoute]int id)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

       
            var ticket = await _ticketRepo.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        //Action method to delete a particular ticket
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete (int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        
            var ticketToDelete = await _ticketRepo.DeleteTicket(id);
            if (ticketToDelete == null)
            {
                return NotFound();
            }
            return Ok(ticketToDelete);
        }

       
    }
}
