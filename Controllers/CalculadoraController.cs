using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {

        [HttpGet("Sum/{firstNumber}/{secondNumber}", Name = "Sum")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Input Inválido");
        }

        [HttpGet("Sub/{firstNumber}/{secondNumber}", Name = "Sub")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Input Inválido");
        }

        [HttpGet("Mult/{firstNumber}/{secondNumber}", Name = "Mult")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Input Inválido");
        }

        [HttpGet("Div/{firstNumber}/{secondNumber}", Name = "Div")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Input Inválido");
        }

        [HttpGet("Med/{firstNumber}/{secondNumber}", Name = "Med")]
        public IActionResult Med(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
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
