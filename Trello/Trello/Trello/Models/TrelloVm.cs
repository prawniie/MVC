using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Models
{
    public class TrelloVm
    {
        public List<TrelloRoot> Boards { get; set; }
        public TrelloRoot Board { get; set; }
        public TrelloList List { get; set; }
        public List<TrelloList> Lists { get; set; }
    }
}
