using Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Core.Receipt
{
    public class Receipt : AuditableEntity
    {
        
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public List<ReceiptItem> ReceibtItems { get; set; } = new List<ReceiptItem>(); 

    }
}
