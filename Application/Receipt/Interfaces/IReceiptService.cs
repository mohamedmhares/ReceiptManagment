using ReceiptManagment.Application.Receipt.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManagment.Application.Receipt.Interfaces
{
    public interface IReceiptService
    {
        Task<decimal> CalculateTotal(CalculateTotalDto calculateTotalDto);
        Task<decimal> CalculateRemaining(CalculateRemainigDTO calculateRemainigDTO);
        Task<(Guid, string ErrorMess)> CreateReceipt(CreateReceiptDTO createReceiptDTO);
      //  Task<GetReceiptDTO> GetReceipt(Guid id);
    }
}
