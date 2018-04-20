using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    const int START_DIFFICULTY = 5;
    const int MAX_DIFFICULTY = 500;
    public int score, difficulty;

    public delegate void GameEventsHandler();
    public event GameEventsHandler OnGoodAnswer;
    public event GameEventsHandler OnBadAnswer;

    EqualityGenerator EqualityGenerator;
    public Equality Equality;

 
    void Start()
    {
        Equality = new Equality();
        EqualityGenerator = new EqualityGenerator();

        Init();
 
        OnGoodAnswer += GainScore;
        OnGoodAnswer += IncreaseDifficulty;
        OnGoodAnswer += GenerateAndDisplayEquality;
        OnBadAnswer += setHighscore;
    }

    public void Answer(int buttonIndex)
    {
        if (buttonIndex == Equality.solvePosition)
        {
            if (OnGoodAnswer != null)
            {
                OnGoodAnswer();
            }
        }
        else if(OnBadAnswer != null)
            OnBadAnswer();
    }

    public void GameOver()
    {
        OnBadAnswer();
    }

    public void Init()
    {
        difficulty = START_DIFFICULTY;
        GenerateAndDisplayEquality();
    }

    void GainScore()
    {
        score++;
    }

    void IncreaseDifficulty()
    {
        difficulty++;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void setHighscore()
    {
        if (score > PlayerPrefs.GetInt("highscore"))
            PlayerPrefs.SetInt("highscore", score);
    }

    void GenerateAndDisplayEquality()
    {
        Equality = GenerateEquality(difficulty);
        GUIManager.instance.UpdateGUI(Equality);
    }

    Equality GenerateEquality(int difficulty)
    {
        difficulty = Mathf.Clamp(difficulty, 5, MAX_DIFFICULTY);
        return EqualityGenerator.GenerateEquality(difficulty);
    }

    void OnDestroy()
    {
        OnGoodAnswer -= GainScore;
        OnGoodAnswer -= IncreaseDifficulty;
        OnBadAnswer -= setHighscore;
    }
}
