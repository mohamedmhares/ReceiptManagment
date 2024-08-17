using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Application.Receipt.DTOs
{
    public class CreateReceiptDTO
    {
        public List<ReceiptItemDTO> ReceiptItems { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
    }
    public class ReceiptItemDTO 
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
