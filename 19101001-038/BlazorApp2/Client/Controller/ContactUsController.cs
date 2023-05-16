using BlazorApp2.Shared;
using System.Net.Http.Json;
namespace BlazorApp2.Client.Controller
{
    public class ContactUsController
    {
        private readonly HttpClient _http;

        public ContactUsController(HttpClient http)
        {
            _http = http;
        }
        public List<ContactUs> contact { get; set; } = new List<ContactUs>();

        
        //public async Task<ContactUs> CreateContact()
        //{
        //    var result = await _http.GetFromJsonAsync<List<ContactUs>>("api/ContactApiController/GetContact");
        //    if (result != null)
        //    {
        //        contact = result;

        //    }
        //    return result;


        //}




    }
}
