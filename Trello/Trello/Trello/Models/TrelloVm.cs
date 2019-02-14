using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Models
{
    public class TrelloVm
    {
        public List<TrelloBoard> Boards { get; set; }
        public TrelloBoard Board { get; set; }
        public TrelloList List { get; set; }
        public List<TrelloList> Lists { get; set; }
    }
}
