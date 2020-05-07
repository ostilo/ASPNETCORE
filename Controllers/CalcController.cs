using Microsoft.AspNetCore.Mvc;
using Microsoft.CSharp.RuntimeBinder;
using System;


namespace CalculatorWeb.Controllers
{

    public class CalcController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Add(string firstNumber, string secondNumber)
        {
            // int numberOne =  int.Parse (firstNumber);
            // int numberTwo = int.Parse (secondNumber);
            // int result = numberOne + numberTwo;
            // ViewBag.Result = result;
            GetBiggerSquare(firstNumber, secondNumber);
            return View();
        }

        private String GetBiggerSquare(string firstNumber, string secondNumber)
        {
            bool intResultTryParseOne = false;
            bool intResultTryParseTwo = false;
            int numberOne;
            int numberTwo;
            String text = null;
            intResultTryParseOne = int.TryParse(firstNumber, out numberOne);
            intResultTryParseTwo = int.TryParse(secondNumber, out numberTwo);
            //Console.WriteLine($"Your age is: {age}");
            if (intResultTryParseOne == false || intResultTryParseTwo == false)
            {
                text = "ERROR!... ONLY NUMBERS ARE EXPECTED";
            }

            else if (intResultTryParseOne == true && intResultTryParseTwo)
            {
                double numberOneSquare = Math.Sqrt(numberOne);
                double numberTwoSquare = Math.Sqrt(numberTwo);
                if (numberOne < 0 || numberTwo < 0)
                {
                    text = "Number Cannot be negative, enter another value";
                }
                else if (numberOneSquare == numberTwoSquare)
                {
                    text = "The square root are same, enter another value";
                }
                else if (numberOneSquare > numberTwoSquare)
                {
                    text = "The number " + numberOne + " with Square root " + numberOneSquare + " has a higher square root than the number " + numberTwo + " with square root " + numberTwoSquare;
                   
                   
                }
                else
                {
                    text = "The number " + numberTwo + " with Square root " + numberTwoSquare + " has a higher square root than the number " + numberOne + " with square root " + numberOneSquare;
                }

            }
            ViewBag.Result = text;
            return ViewBag.Result;
        }

    }

}