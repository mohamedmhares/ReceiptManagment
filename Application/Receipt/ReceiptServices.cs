using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ReceiptManagment.Application.Receipt.DTOs;
using ReceiptManagment.Application.Receipt.Interfaces;
using ReceiptManagment.Core.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReceiptManagment.Core.Receipt;
using Core.Shared;

namespace ReceiptManagment.Application.Receipt
{
    public class ReceiptServices : IReceiptService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IReceiptRepository _receiptRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReceiptServices(IItemRepository itemRepository, IReceiptRepository receiptRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _receiptRepository = receiptRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<decimal> CalculateTotal(CalculateTotalDto calculateTotalDto)
        {
            var items = await _itemRepository.GetRangeAsync(x => calculateTotalDto.items.Select(c => c.Id).Contains(x.Id));

            decimal total = 0;
            foreach (var item in items)
            {
                var quantity = calculateTotalDto.items.FirstOrDefault(c => c.Id == item.Id)?.Quantity ?? 0;
                total = total + (item.ItemPrice * quantity);

            }
            return total;

        }
        public async Task<decimal> CalculateRemaining(CalculateRemainigDTO calculateRemainigDTO)
        {
            var calculateTotal = new CalculateTotalDto() { items = calculateRemainigDTO.items };
            var total = await CalculateTotal(calculateTotal);
            if (calculateRemainigDTO.paidAmount < total)
                return -1;
            return calculateRemainigDTO.paidAmount - total;

        }
        public async Task<(Guid, string ErrorMess)> CreateReceipt(CreateReceiptDTO createReceiptDTO)
        {
            var items = await _itemRepository.GetRangeAsync(x => createReceiptDTO.ReceiptItems.Select(c => c.Id).Contains(x.Id));
            if (!createReceiptDTO.ReceiptItems.Select(c => c.Id).All(x => items.Select(c => c.Id).Contains(x)))
                return (Guid.Empty, "Some Ids Not Found");


            foreach (var item in items)
            {
                var quantity = createReceiptDTO.ReceiptItems.FirstOrDefault(c => c.Id == item.Id)?.Quantity ?? -1;
                if (quantity > item.Balance)
                    return (Guid.Empty, $"Item with Id {item.Id} {item.Name} Out of Stock ");

            }
            var calculateTotal = new CalculateTotalDto() { items = createReceiptDTO.ReceiptItems };
            var total = await CalculateTotal(calculateTotal);
            if (createReceiptDTO.TotalAmount != total)
                return (Guid.Empty, "TotalAmount Isn't Valid");
            var calculateRemaining = new CalculateRemainigDTO
            { items = createReceiptDTO.ReceiptItems, paidAmount = createReceiptDTO.PaidAmount };
            var remaining = await CalculateRemaining(calculateRemaining);
            if (createReceiptDTO.RemainingAmount != remaining)
                return (Guid.Empty, "PaidAmount Isn't Valid");
            var receipt = new ReceiptManagment.Core.Receipt.Receipt()
            {
                RemainingAmount = createReceiptDTO.RemainingAmount,
                PaidAmount = createReceiptDTO.PaidAmount,
                TotalAmount = total,
                ReceibtItems = createReceiptDTO.ReceiptItems.Select(x => new ReceiptItem()
                {
                    Id = Guid.NewGuid(),
                    ItemId = x.Id,
                    Quantities = x.Quantity
                }).ToList()
            };
            await _receiptRepository.InsertAsync(receipt);
            foreach (var item in items)
            {
                var quantity = createReceiptDTO.ReceiptItems.FirstOrDefault(c => c.Id == item.Id)?.Quantity ?? 0;
                item.Balance = item.Balance - quantity;
                await _itemRepository.UpdateAsync(item);
            }
            await _unitOfWork.CommitAsync();
            return (receipt.Id, null);



        }

        //public async Task<GetReceiptDTO> GetReceipt(Guid id)
        //{

        //    var Item = await _receiptRepository.GetByIdAsync(id);
        //    if (Item == null)
              //  return null;
            //    var receiptdto = new GetReceiptDTO()
            //    {

            //        RemainingAmount =Item.RemainingAmount,
            //        PaidAmount = Item.PaidAmount,
            //        TotalAmount = Item.TotalAmount,
            //        ReceiptItems =receiptdto.Select(x => new ReceiptItem()
            //        {
            //            ItemId = Item.Id,
            //            Quantities = Item.
            //        }).ToList()

            //    };


            //    return receiptdto;
            //}
       
    }
}


