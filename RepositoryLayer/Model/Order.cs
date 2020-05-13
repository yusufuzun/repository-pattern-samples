using RepositoryLayer.Core;
using RepositoryLayer.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Model
{
    public class Order : IAggregateRoot
    {
        public DateTime LastModifiedDate { get; set; }

        public int Status { get; set; }

        public Guid RowGuid { get; set; }

        public int Id { get; set; }

        public string OrderCode { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual IEnumerable<OrderLineItem> LineItems { get; set; }
    }

}
