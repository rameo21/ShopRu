using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShopRu.Api.Model;
using ShopRu.EntityLayer.Entity;
using ShopRu.EntityLayer.Enums;
using ShopRu.Infrastructure;
using Swashbuckle.AspNetCore.Annotations;

namespace ShopRu.Api.Controllers
{
    [ApiController]
    [Route("api/bill")]
    public class BillController : Controller
    {
        private readonly ILogger<BillController> _logger;
        private readonly IBillService _billService;
        public BillController(ILogger<BillController> logger, IBillService billService)
        {
            _logger = logger;
            _billService = billService;
        }

        [HttpPost("calculate")]
        [SwaggerResponse(200, Type = typeof(decimal))]
        [SwaggerOperation(Summary = "Calculate", Description = "Get discount calculated price", OperationId = "getDiscountPrice")]
        public async Task<IActionResult> CalculateTotal(BillDto billRequest)
        {
            try
            {
                var bill = billRequest.Adapt<Bill>();
                decimal totalAmount = await _billService.CalculateTotalAmount(bill);
                return Ok(totalAmount);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("calculate:" + ex.Message);
                return BadRequest();
            }

        }

    }
}
