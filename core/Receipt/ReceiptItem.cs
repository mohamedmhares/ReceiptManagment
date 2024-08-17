using Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Core.Receipt
{
    public class ReceiptItem : BaseEntity
    {
        [Range(1,int.MaxValue)]
        public int Quantities { get; set; }

        public Item Item { get; set; }
        public Receipt Receipt { get; set; }
        [ForeignKey(nameof(Item))]
        public Guid ItemId { get; set; }
        [ForeignKey(nameof(Receipt))]
        public Guid ReceietId { get; set; }
    }
}
