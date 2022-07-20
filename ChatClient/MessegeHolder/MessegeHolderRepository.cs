using ChatClient.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace ChatClient.MessegeHolder
{
    class MessegeHolderRepository : IMessegeHolder
    {
        private HttpClient client = new HttpClient();
        private Uri link = new Uri("https://localhost:7034/");
        private const string requestURL = "https://localhost:7034/chat";

        public MessegeHolderRepository()
        {
            client.BaseAddress = link;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Messege>> GetAllMessegesAsync()
        {
            var r = await client.GetAsync(requestURL);
            return (await r.Content.ReadAsAsync<IEnumerable<Messege>>()).ToList();
        }

        public async Task PostMessegeAsync(Messege messege)
        {
            await client.PostAsync<Messege>(requestURL, messege, new JsonMediaTypeFormatter());
        }
    }
}
