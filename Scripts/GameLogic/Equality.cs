public class Equality
{

    public int firstNumber, secondNumber;
    public int fakeSolve1, fakeSolve2;
    public int solvePosition;

    public enum operation { ADDING, SUBTRACTION, MULTIPLICATION, DIVISION};
    public operation mark;

    public string markString
    {
        get
        {
            switch(mark)
            {
                case operation.ADDING:
                    return "+";
                case operation.DIVISION:
                    return "/";
                case operation.MULTIPLICATION:
                    return "X";
                case operation.SUBTRACTION:
                    return "-";
                default:
                    return string.Empty;
            }
        }
    }

    public int solve
    {
        get
        {
            switch (mark)
            {
                case operation.ADDING:
                    return firstNumber + secondNumber;

                case operation.SUBTRACTION:
                    return firstNumber - secondNumber;

                case operation.MULTIPLICATION:
                    return firstNumber * secondNumber;

                case operation.DIVISION:
                    return firstNumber / secondNumber;

                default:
                    return 0;
            }
        }
    }


}

	
