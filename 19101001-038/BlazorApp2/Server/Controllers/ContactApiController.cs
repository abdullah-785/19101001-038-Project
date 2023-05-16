//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using BlazorApp2.Shared;
//using BlazorApp2.Server.Data;
//using Microsoft.EntityFrameworkCore;
//using BlazorApp2.Client.Pages;
//using ContactUs = BlazorApp2.Shared.ContactUs;

//namespace BlazorApp2.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ContactApiController : ControllerBase
//    {
//        private readonly ContactContext _dbContext;

//        //Create constructor
//        public ContactApiController(ContactContext dbContaxt)
//        {
//            _dbContext = dbContaxt;
//        }


//            [HttpGet("check")]
//            public IEnumerable<ContactUs> check()
//            {
//                IList<ContactUs> contact = new List<ContactUs>();
//                contact.Add(new ContactUs { Id = 1, name = "Test1", email = "abdbutt2001@gmail.com1", subject="English", message="Hey sir"});
//                contact.Add(new ContactUs { Id = 2, name = "Test2", email = "abdbutt2001@gmail.com2", subject = "English", message = "Hey sir" });
//                contact.Add(new ContactUs { Id = 3, name = "Tes3", email = "abdbutt2001@gmail.com3", subject = "English", message = "Hey sir" });
//                contact.Add(new ContactUs { Id = 4, name = "Test4", email = "abdbutt2001@gmail.com4", subject = "English", message = "Hey sir" });

//                return contact;
//            }



//        //Get all record from database
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ContactUs>>> GetContact()
//        {
//            if (_dbContext.contact == null)
//            {
//                return NotFound();
//            }
//            return await _dbContext.contact.ToListAsync();
//        }


//        // Get specific record from database using id
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ContactUs>> getcontact(int id)
//        {
//            if (_dbContext.contact == null)
//            {
//                return NotFound();
//            }

//            var contact = await _dbContext.contact.FindAsync(id);
//            if (contact == null)
//            {
//                return NotFound();
//            }
//            return contact;
//        }


//        //Store data in database
//        [HttpPost]
//        public async Task<ActionResult<ContactUs>> saveContact(ContactUs con_us)
//        {
//            _dbContext.contact.Add(con_us);
//            await _dbContext.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetContact), new { id = con_us.Id }, con_us);
//        }


//        //Update data in database
//        [HttpPut]
//        public async Task<ActionResult<ContactUs>> putContact(int id, ContactUs contact)
//        {
//            if (id != contact.Id)
//            {
//                return BadRequest();
//            }

//            _dbContext.Entry(contact).State = EntityState.Modified;

//            try
//            {
//                await _dbContext.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ContactAvailable(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//            return Ok();
//        }


//        //This method is used to check contact have or not in database using id
//        private bool ContactAvailable(int id)
//        {
//            return (_dbContext.contact?.Any(x => x.Id == id)).GetValueOrDefault();
//        }


//        //Delete Record From database
//        //[HttpDelete("{id}")]

//        //public async Task<IActionResult> deleteContact(int id)
//        //{
//        //    if(_dbContext.contact == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    var con = await _dbContext.contact.FindAsync(id);

//        //    if(con != null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    _dbContext.contact.Remove(con);
//        //    await _dbContext.SaveChangesAsync();

//        //    return Ok();

//        //}

//    }
//}




using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactApiController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<ContactUs> Get()
        {
            IList<ContactUs> contact = new List<ContactUs>();
            contact.Add(new ContactUs { Id = 1, name = "Test1", email = "abdbutt2001@gmail.com1", subject="English", message="Hey sir"});
            contact.Add(new ContactUs { Id = 2, name = "Test2", email = "abdbutt2001@gmail.com2", subject = "English", message = "Hey sir" });
            contact.Add(new ContactUs { Id = 3, name = "Tes3", email = "abdbutt2001@gmail.com3", subject = "English", message = "Hey sir" });
            contact.Add(new ContactUs { Id = 4, name = "Test4", email = "abdbutt2001@gmail.com4", subject = "English", message = "Hey sir" });

            return contact;
        }
    }
}