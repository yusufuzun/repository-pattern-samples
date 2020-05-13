using RepositoryLayer.Core;
using RepositoryLayer.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Model
{
    public class OrderLineItem : IEntity
    {
        public int Id { get; set; }

        public string Product { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }
    }
}
