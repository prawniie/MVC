using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Trello.Test
{
    [TestClass]
    public class LabTrello
    {
        [TestMethod]
        public void get_all_boards()
        {
            var ts = new TrelloService();
            List<TrelloRoot> result = ts.GetAllBoards().Result;


        }

        [TestMethod]
        public void get_all_lists_for_a_specific_board()
        {
            var ts = new TrelloService();
            List<TrelloList> result = ts.GetAllListsForBoard("5835f3cff7ac11db7d03192c").Result;
        }

        [TestMethod]
        public void add_a_post_to_a_specific_list()
        {
            var ts = new TrelloService();
            //ts.CreateAcardOnAlist("583ee6794a6d084557ae5c44", "en post", "beskrivning").Wait();
        }
    }
}
