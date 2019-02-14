using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Trello.Test.TrelloRoot;

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

            string page = $"https://api.trello.com/1/members/me/boards?key=7d7a36afe44b9e5fd79ae2c2d03b319e&token=98b5e984ee3607b1718c52978038a78927fb9bd8f5edb1c031de7ee32d3035e9";

            var ts = new TrelloService();
            var result = await ts.Get(page);
            return JsonConvert.DeserializeObject<List<TrelloRoot>>(result);

        }

        public async Task<List<TrelloList>> GetAllListsForBoard(string boardId)
        {
            List<TrelloList> list = new List<TrelloList>();

            //slänga in boardId i page så den inte är hårdkodad
            string page = $"https://api.trello.com/1/boards/5c5bec8b2e25ff7be13fb912/lists?cards=none&card_fields=all&filter=open&fields=all&key=7d7a36afe44b9e5fd79ae2c2d03b319e&token=98b5e984ee3607b1718c52978038a78927fb9bd8f5edb1c031de7ee32d3035e9";

            var ts = new TrelloService();
            var result = await ts.Get(page);
            return JsonConvert.DeserializeObject<List<TrelloList>>(result);

        }

        public async Task<string> CreateAcardOnAlist(string listId, string cardName, string cardDescription)
        {
            //inte hårdkoda token och key-id
            string page = $"https://api.trello.com/1/cards?name={cardName}&desc={cardDescription}&idList={listId}&key=7d7a36afe44b9e5fd79ae2c2d03b319e&token=98b5e984ee3607b1718c52978038a78927fb9bd8f5edb1c031de7ee32d3035e9";

            var ts = new TrelloService();
            string result = await ts.Post(page);
            return result;

        }

        //public async Task<Rootobject> GetMeteorologicalForecast(decimal longitude, decimal latitude)
        //{
        //    string sLongitude = Math.Round(longitude, 3).ToString(new CultureInfo("en"));
        //    string sLatitude = Math.Round(latitude, 3).ToString(new CultureInfo("en"));

        //    string page = $"https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/{sLongitude}/lat/{sLatitude}/data.json";

        //    var smhi = new SmhiService();

        //    var result = await smhi.Get(page);
        //    return JsonConvert.DeserializeObject<Rootobject>(result);

        //}
    }
}
