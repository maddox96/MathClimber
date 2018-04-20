using UnityEngine;
using UnityEngine.UI;
public class Options : MonoBehaviour {


    int _timerState;

    [SerializeField]
    GameObject panel;

    public int timerState
    {
        set
        {
            PlayerPrefs.SetInt("timerState", value);
            setImage(value);
        }

        get
        {
            return PlayerPrefs.GetInt("timerState");
        }
    }

    [SerializeField]
    Sprite onImage, offImage;

    [SerializeField]
    Button timerToggler;
    Image togglerImage;

    [SerializeField]
    Text highScore;

    void Start ()
    {
        togglerImage = timerToggler.GetComponent<Image>();
        if (PlayerPrefs.GetInt("timerState") != 1 && PlayerPrefs.GetInt("timerState") != -1)
            PlayerPrefs.SetInt("timerState", 1);
        displayHighscore();
        setImage(timerState);
	}
	
    public void timerToggle()
    {
        timerState *= -1;
    }

    void setImage(int timerState)
    {
        if (timerState == 1)
        {
            togglerImage.sprite = onImage;
        }
        else togglerImage.sprite = offImage;
    }

    public void OptionsToggle()
    {
        panel.SetActive(!panel.activeSelf);
    }

    void displayHighscore()
    {
        highScore.text = PlayerPrefs.GetInt("highscore").ToString();
    }

}
