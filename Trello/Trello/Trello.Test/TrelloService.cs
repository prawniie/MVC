using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Test
{
    public class TrelloService
    {
        private async Task<string> Get(string url)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await content.ReadAsStringAsync();
            }
        }

        private async Task<string> Post(string url)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.PostAsync(url, null))
            using (HttpContent content = response.Content)
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await content.ReadAsStringAsync();
            }
        }

        public async Task<List<TrelloRoot>> GetAllBoards()
        {
            List<TrelloRoot> list = new List<TrelloRoot>();
            return list;
        }

        public async Task<List<TrelloList>> GetAllListsForBoard(string v)
        {
            List<TrelloList> list = new List<TrelloList>();

            return list;
        }

        public async void CreateAcardOnAlist(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}
