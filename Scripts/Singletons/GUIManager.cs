using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager>
{

    [SerializeField]
    Text firstNumberText;
    [SerializeField]
    Text secondNumberText;
    [SerializeField]
    Text markText;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text gameOverScoreText;
    [SerializeField]
    Text HighscoreText;
    [SerializeField]
    Text[] SolvesText;

    [SerializeField]
    Button[] SolvesButton;

    [SerializeField]
    GameObject GameOverGUI;

    void Start()
    {
        Jump.AfterLanding += TurnOnButtons;
        Stone.hasLanded += ShowGameOverGUI;
        GameManager.instance.OnGoodAnswer += TurnOffButtons;
        GameManager.instance.OnBadAnswer += TurnOffButtons;
    }

    public void UpdateGUI(Equality _Equality)
    {
        firstNumberText.text = _Equality.firstNumber.ToString();
        markText.text = _Equality.markString;
        secondNumberText.text = _Equality.secondNumber.ToString();
        scoreText.text = "Score: " + GameManager.instance.score.ToString();
        AssignSolvesToRandomPositions(_Equality.solve, _Equality.solvePosition, _Equality.fakeSolve1, _Equality.fakeSolve2);
    }

    string createEqualityString(int firstNumber, int secondNumber, Equality.operation mark)
    {
        string question = firstNumber.ToString();
        if (mark == 0) question += " + ";
        else if ((int)mark == 1) question += " - ";
        else if ((int)mark == 2) question += " x ";
        else if ((int)mark == 3) question += " : ";

        question += secondNumber.ToString();
        return question;
    }

    void AssignSolvesToRandomPositions(int solve, int solvePosition, int fakeSolve, int fakeSolve2)
    {
        foreach (Text solveText in SolvesText)
            solveText.text = null;


        SolvesText[solvePosition].text = solve.ToString();
        SolvesText[solvePosition].fontSize = BestFontSize(solve);

        for (int j = 0; j < 3; j++)
            if (SolvesText[j].text == string.Empty)
            {
                SolvesText[j].text = fakeSolve.ToString();
                SolvesText[j].fontSize = BestFontSize(fakeSolve);
                break;
            }

        for (int j = 0; j < 3; j++)
        {
            if (SolvesText[j].text == string.Empty)
            {
                SolvesText[j].text = fakeSolve2.ToString();
                SolvesText[j].fontSize = BestFontSize(fakeSolve2);
            } 
        }
    }

    void TurnOnButtons()
    {
       foreach(Button button in SolvesButton)
        {
            button.enabled = true;
        }
    }

    void TurnOffButtons()
    {
        foreach (Button button in SolvesButton)
        {
            button.enabled = false;
        }
    }

    void ShowGameOverGUI()
    {
        HighscoreText.text = "Highscore: \n" + PlayerPrefs.GetInt("highscore").ToString();
        gameOverScoreText.text = "Score:\n" + GameManager.instance.score.ToString();
        GameOverGUI.SetActive(true);
    }

    void OnDestroy()
    {
        Jump.AfterLanding -= TurnOnButtons;
        GameManager.instance.OnGoodAnswer -= TurnOffButtons;
        Stone.hasLanded -= ShowGameOverGUI;
    }

    int BestFontSize(int number) // just to avoid using Unity's BestFit
    {
        if (number != Mathf.Abs(number)) number *= -10;
        if (number < 10) return 100;
        else if (number < 100) return 80;
        else if (number < 1000) return 70;
        else if (number < 10000) return 55;
        else if (number < 100000) return 40;
        else return 30;
    }
}