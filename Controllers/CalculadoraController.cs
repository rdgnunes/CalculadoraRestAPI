using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("{firstNumber}/{secondNumber}", Name = "Sum")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Input Inválido");
        }

        private decimal ConvertToDecimal(string num)
        {
            decimal decimalValue;
            if (decimal.TryParse(num, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string num)
        {
            double number;
            bool isNumber = double.TryParse(num, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
