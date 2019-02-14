using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Models
{
    public class TrelloList
    {

        public class List
        {
            public string id { get; set; }
            public string name { get; set; }
            public bool closed { get; set; }
            public string idBoard { get; set; }
            public int pos { get; set; }
            public bool subscribed { get; set; }
            public object softLimit { get; set; }
            public Limits limits { get; set; }
            public string creationMethod { get; set; }
        }

        public class OpenPerList
        {
            public string status { get; set; }
            public int disableAt { get; set; }
            public int warnAt { get; set; }
        }

        public class TotalPerList
        {
            public string status { get; set; }
            public int disableAt { get; set; }
            public int warnAt { get; set; }
        }

        public class Cards
        {
            public OpenPerList openPerList { get; set; }
            public TotalPerList totalPerList { get; set; }
        }

        public class Limits
        {
            public Cards cards { get; set; }
        }



    }
}
