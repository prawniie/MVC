using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Trello.Models
{
    public class TrelloContext : DbContext
    {
        public TrelloContext (DbContextOptions<TrelloContext> options)
            : base(options)
        {
        }

        public DbSet<Trello.Models.Subscriber> Subscriber { get; set; }
    }
}
