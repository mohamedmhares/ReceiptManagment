using Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Core.Receipt
{
    public class Item :AuditableEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public int Balance { get; set; }
        public decimal ItemPrice { get; set; }
        public List<ReceiptItem> ReceibtItems { get; set; } = new List<ReceiptItem>();
       
        
    }
}
