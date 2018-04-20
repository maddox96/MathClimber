using UnityEngine;

public class EqualityGenerator
{
    Equality _Equality = new Equality();

    public Equality GenerateEquality(int difficulty)
    {
        if(difficulty < 20)
            _Equality.mark = (Equality.operation)(Random.Range(0, 2));
        else
            _Equality.mark = (Equality.operation)(Random.Range(0, 4));

        _Equality.firstNumber = GenerateRandomNumber(difficulty, _Equality.mark);
        _Equality.secondNumber = GenerateRandomNumber(difficulty, _Equality.mark);

        if(_Equality.mark == Equality.operation.DIVISION)
        {
            _Equality.firstNumber = _Equality.firstNumber * _Equality.secondNumber;
            //we are making second number the divisor
        }

        _Equality.fakeSolve1 = GenerateFakeSolves(_Equality.solve);

        do
        {
            _Equality.fakeSolve2 = GenerateFakeSolves(_Equality.solve);
        } while (_Equality.fakeSolve1 == _Equality.fakeSolve2);

        _Equality.solvePosition = Random.Range(0, 3);

        return _Equality;
    }

    int GenerateRandomNumber(int difficulty, Equality.operation mark)
    {
        switch (mark)
        {
            case Equality.operation.ADDING:
            case Equality.operation.SUBTRACTION:
                return Random.Range(1, 2 * difficulty);

            case Equality.operation.DIVISION:
            case Equality.operation.MULTIPLICATION:
                return Random.Range(1, (int)Mathf.Sqrt(difficulty * 2));

            default:
                return 0;
        }
    }

    int GenerateFakeSolves(int solve)
    {
        int fakeSolve = solve, squareRoot, fakeSolveDifference;
        squareRoot = (int)Mathf.Sqrt(Mathf.Abs(solve)) + 2;
        // 2 is added in case sqrt = 1 and we need 3 diffrent solves. so we make Random.Range Atleast (1, 4) 
        bool forcedPositive = false;

        if (solve > 0) forcedPositive = true;
        else forcedPositive = false;

        do
        {
            fakeSolveDifference = Random.Range(-squareRoot, squareRoot);
            if (forcedPositive && (solve + fakeSolveDifference < 1)) fakeSolveDifference = 0;
        }
        while (fakeSolveDifference == 0);
        // we need to prevent fakeSolve = solve - 0 
                
        fakeSolve += fakeSolveDifference;
        return fakeSolve;
    }
}
