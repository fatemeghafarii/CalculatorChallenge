using System;

namespace CalculatorChallenge_SecondSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            do
            {
                var undelineChar = new string('-', 18);
                System.Console.WriteLine(undelineChar);
                System.Console.WriteLine("Calculator Program");
                System.Console.WriteLine(undelineChar);
                CalcOperations calcOperations = new CalcOperations();
                try
                {
                    calcOperations.GetUserInput();
                    calcOperations.SetOperator();
                    calcOperations.Operate = Console.ReadLine();
                    System.Console.WriteLine(calcOperations.ToString());
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                System.Console.WriteLine("Would you like to continue? (Y = yes, N = no)");
                var answer = Console.ReadLine().ToLower();
                again = answer == "y";
            }while(again);
            System.Console.WriteLine("Bye!");
        }
    }
    class CalcOperations
    {
        private double firstNum ;
        private double secondNum;
        private string _op;
        public string Operate 
        {
            get{return _op;}
            set{_op = value;}
        }
        private double _result;
        public void SetOperator()
        {
            System.Console.WriteLine("Options:{0}\t+ : Add{0}\t- : Subtract{0}\t* : Multiply{0}\t/ : Divide",  Environment.NewLine);
            System.Console.Write("Enter an option: ");
        }
        public void GetUserInput()
        {
            Console.Write("Enter number 1: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("Enter number 2: ");
            double num2 = double.Parse(Console.ReadLine());
            this.firstNum = num1;
            this.secondNum = num2;
        }
        public override string ToString()
        {
            switch(Operate)
            {
                case "+":
                    _result =  firstNum + secondNum;
                    break;
                case "-":
                    _result = firstNum - secondNum;
                    break;
                case "*":
                    _result = firstNum * secondNum;
                    break;
                case "/":
                    if(secondNum == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    _result = firstNum / secondNum;
                    break;
                default :
                    throw new Exception("That was not a valid option");
            }
            return $"Your result: {firstNum} {Operate} {secondNum} = {_result}"; 
        }     
    }
}
