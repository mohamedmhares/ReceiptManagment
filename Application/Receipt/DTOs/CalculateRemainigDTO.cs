using ReceiptManagment.Core.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Application.Receipt.DTOs
{
    public class CalculateRemainigDTO
    {
       public decimal paidAmount { get; set; }
        public List<ReceiptItemDTO> items { get; set; }
    }
}
