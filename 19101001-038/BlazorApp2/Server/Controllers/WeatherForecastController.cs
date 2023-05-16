using BlazorApp2.Server.Data;
using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //    private static readonly string[] Summaries = new[]
        //    {
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //    private readonly ILogger<WeatherForecastController> _logger;

        //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //    {
        //        _logger = logger;
        //    }

        //    [HttpGet]
        //    public IEnumerable<WeatherForecast> Get()
        //    {
        //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //        {
        //            //Date = DateTime.Now.AddDays(index),
        //            //TemperatureC = Random.Shared.Next(-20, 55),
        //            //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //        })
        //        .ToArray();
        //    }

        private readonly ContactContext _dbContext;

        //create constructor
        public WeatherForecastController(ContactContext dbcontaxt)
        {
            _dbContext = dbcontaxt;
        }


        [HttpGet("Check")]
        public IEnumerable<ContactUs> Check()
        {
            IList<ContactUs> contact = new List<ContactUs>();
            contact.Add(new ContactUs { Id = 1, name = "Test1", email = "abdbutt2001@gmail.com1", subject = "English", message = "Hey sir" });
            contact.Add(new ContactUs { Id = 2, name = "Test2", email = "abdbutt2001@gmail.com2", subject = "English", message = "Hey sir" });
            contact.Add(new ContactUs { Id = 3, name = "Tes3", email = "abdbutt2001@gmail.com3", subject = "English", message = "Hey sir" });
            contact.Add(new ContactUs { Id = 4, name = "Test4", email = "abdbutt2001@gmail.com4", subject = "English", message = "Hey sir" });

            return contact;
        }


        //Get all record from database
        [HttpGet("GetContact")]
        public async Task<ActionResult<IEnumerable<ContactUs>>> GetContact()
        {
            if (_dbContext.contact == null)
            {
                return NotFound();
            }
            return await _dbContext.contact.ToListAsync();
        }

        //Store data in database
        [HttpPost("saveContact")]
        public async Task<ActionResult<ContactUs>> saveContact(ContactUs con_us)
        {
            _dbContext.contact.Add(con_us);
            await _dbContext.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetContact), new { id = con_us.Id }, con_us);
            return Ok();
        }



        ////update data in database
        //[HttpPut("update/{id}")]
        //public async Task<ActionResult<ContactUs>> putContact(int id, ContactUs contact)
        //{
        //    if (id != contact.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _dbContext.Entry(contact).State = EntityState.Modified;

        //    try
        //    {
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ContactAvailable(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return Ok();
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, ContactUs contact)
        {
            // Get the existing contact from the database
            var savedContact = await _dbContext.contact.FindAsync(id);

            if (savedContact == null)
            {
                return NotFound();
            }

            // Update the contact with the new data
            savedContact.name = contact.name;
            savedContact.email = contact.email;
            savedContact.subject = contact.subject;
            savedContact.message = contact.message;

            // Save the changes to the database
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _dbContext.contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _dbContext.contact.Remove(contact);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }




        //This method is used to check contact have or not in database using id
        private bool ContactAvailable(int id)
        {
            return (_dbContext.contact?.Any(x => x.Id == id)).GetValueOrDefault();
        }

    }
}