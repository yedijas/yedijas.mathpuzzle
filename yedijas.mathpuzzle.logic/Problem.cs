using System;
using System.Globalization;

namespace yedijas.mathpuzzle.logic
{
    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD,
        EXTREME
    }
    public class Problem
    {
        public String FirstNumber { get => firstnumber.ToString(); }
        public String SecondNumber { get => secondNumber.ToString(); }
        public string Operand { get; set; }
        public String Result { get => result.ToString("f4", CultureInfo.InvariantCulture); }

        private double firstnumber;
        private double secondNumber;
        private double result;

        public Problem()
        {
            firstnumber = 0;
            secondNumber = 0;
            Operand = "+";
            result = 0;
        }

        public void CreateProblem(Difficulty _diff)
        {
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            int maxNum = 100;
            int minNum = 1;
            int maxProblem = 4;
            firstnumber = 0;
            secondNumber = 0;


            switch (_diff)
            {
                case Difficulty.EASY:
                    maxNum = 100;
                    minNum = 1;
                    maxProblem = 3;
                    break;
                case Difficulty.MEDIUM:
                    maxNum = 100;
                    minNum = -100;
                    maxProblem = 5;
                    break;
                case Difficulty.HARD:
                    maxNum = 1000;
                    minNum = -1000;
                    maxProblem = 9;
                    break;
                case Difficulty.EXTREME:
                    maxNum = 5000;
                    minNum = -5000;
                    maxProblem = 9;
                    break;
                default:
                    break;
            }

            firstnumber = rng.Next(minNum, maxNum + 1);
            while (secondNumber == 0)
            {
                secondNumber = rng.Next(minNum, maxNum + 1);
                if (_diff == Difficulty.EASY && secondNumber > firstnumber)
                {
                    secondNumber = 0;
                }

            }
            switch (rng.Next(1, maxProblem + 1))
            {
                case 1:
                    Operand = "+";
                    result = firstnumber + secondNumber;
                    break;
                case 2:
                    Operand = "-";
                    result = firstnumber - secondNumber;
                    break;
                case 3:
                    Operand = "x";
                    result = firstnumber * secondNumber;
                    break;
                case 4:
                    Operand = "/";
                    result = firstnumber / secondNumber;
                    break;
                case 5:
                    Operand = "mod";
                    result = firstnumber % secondNumber;
                    break;
                case 6:
                    Operand = "ln";
                    result = firstnumber * Math.Log(secondNumber);
                    break;
                case 7:
                    Operand = "sin";
                    secondNumber = rng.Next(0, 360); // limiting the value to full circle only
                    secondNumber = secondNumber == 180 ? 0 : secondNumber;
                    result = firstnumber * Math.Sin(secondNumber);

                    break;
                case 8:
                    Operand = "cos";
                    secondNumber = rng.Next(-90, 270); // limiting the value to full circle only
                    secondNumber = secondNumber == 90 ? -90 : secondNumber;
                    result = firstnumber * Math.Cos(secondNumber);
                    break;
                case 9:
                    Operand = "tan";
                    // limiting the value to half circle only
                    while (secondNumber != 90)
                    {
                        secondNumber = rng.Next(0, 180);
                    }
                    result = firstnumber * Math.Tan(secondNumber);
                    break;
                default:
                    break;
            }
        }

        public bool CheckCorrectness(string _firstnum, string _operand, string _secondnum, string _result)
        {
            bool iscorrect = false;
            _result = double.Parse(_result).ToString("f4", CultureInfo.InvariantCulture);

            if (Operand == "mod") // any number shall work as long as the result is the same for modulo
            {
                iscorrect = _operand == Operand
                    && firstnumber % (double.Parse(_secondnum)) == result;
            }
            // degree calculation may use any second number as long as the value is the same
            // sample: sin(0) == sin(180) == sin(360)
            else if (Operand == "sin")
            {
                iscorrect = _firstnum == FirstNumber && _operand == Operand
                    && Math.Sin(double.Parse(_secondnum)) == Math.Sin(secondNumber)
                    && _result == Result;
            }
            else if (Operand == "cos")
            {
                iscorrect = _firstnum == FirstNumber && _operand == Operand
                    && Math.Cos(double.Parse(_secondnum)) == Math.Sin(secondNumber)
                    && _result == Result;
            }
            else if (Operand == "tan")
            {
                iscorrect = _firstnum == FirstNumber && _operand == Operand
                    && Math.Tan(double.Parse(_secondnum)) == Math.Sin(secondNumber)
                    && _result == Result;
            }
            else // the most basic
            {
                iscorrect = _firstnum == FirstNumber && _operand == Operand && _secondnum == SecondNumber && _result == Result;
            }

            return iscorrect;
        }

        public override string ToString()
        {
            return FirstNumber + " " + Operand + " " + SecondNumber + " = " + Result;
        }
    }
}
