using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APINetCoreDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        //GET api/values/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult Sum(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber));
                return Ok(sum.ToString());
            }
            return BadRequest ("Invalid Input");
        }

        //GET api/values/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public ActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var subtraction = (ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber));
                return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //GET api/values/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public ActionResult Division(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var division = (ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber));
                return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //GET api/values/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public ActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var multiplication = (ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber));
                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //GET api/values/mean/5/5
        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public ActionResult Mean(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //GET api/values/square-root/5
        [HttpGet("square-root/{number}")]
        public ActionResult SquareRoot(string number)
        {
            if (isNumeric(number))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
