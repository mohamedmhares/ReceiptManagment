using Microsoft.AspNetCore.Mvc;
using ReceiptManagment.Application.Receipt;
using ReceiptManagment.Application.Receipt.DTOs;
using ReceiptManagment.Application.Receipt.Interfaces;

namespace ReceiptManagment.Presentation.Controllers
{
    [Route("api/Receipt")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }
        [HttpPost("ClaculateTotal")]
        public async Task<IActionResult> CalcaulateTotal(CalculateTotalDto calculateTotalDto )
        
        {
            var total = await receiptService.CalculateTotal(calculateTotalDto);
            return Ok(total);
        }
        [HttpPost("CalculateRemaining")]
        public async Task<IActionResult> CalcaulateRemaing(CalculateRemainigDTO calculateRemainigDTO)

        {
            var remaining = await receiptService.CalculateRemaining(calculateRemainigDTO);
            if (remaining == -1)
                return BadRequest("The Paid Amount is Less than total Amount");
            return Ok(remaining);
        }
        [HttpPost("CreateReceipt")]
        public async Task<ActionResult<Guid>> CreateReceipt(CreateReceiptDTO createReceiptDTO) 
        {
            var result = await receiptService.CreateReceipt(createReceiptDTO);
            if (!string.IsNullOrEmpty(result.ErrorMess))
                return BadRequest(result.ErrorMess);
            return Ok(result.Item1);

        }
        //[HttpGet("GetReceiptByID")]
        //public async Task<ActionResult<GetReceiptDTO>> GetReceiptbyID(Guid id)
        //{
        //    var item = await receiptService.GetReceipt(id);
        //    if (item == null)
        //        return NotFound("Receipt With this Id not Found");
        //    return Ok(item);
        //}
    }
}
