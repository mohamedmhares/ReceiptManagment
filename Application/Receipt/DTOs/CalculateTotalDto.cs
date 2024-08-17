using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Application.Receipt.DTOs
{
    public class CalculateTotalDto
    {
        public List<ReceiptItemDTO> items { get; set; }
    }
}
