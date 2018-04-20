using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    const float MIN_TIMER_SPEED = 0.5f;
    const float MAX_TIMER_SPEED = 10.0f;

    public float timerSpeed = 1.0f;
    Animator timerAnimation;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("timerState") == -1)
        {
            gameObject.SetActive(false);
        }
        else
        {
            timerAnimation = GetComponent<Animator>();
            SetSpeed(timerSpeed);
        }
    }

    private void Start()
    {
        GameManager.instance.OnGoodAnswer += RestartTimer;
        GameManager.instance.OnBadAnswer += StopTimer;
    }

    public void StopTimer()
    {
        timerAnimation.enabled = false;
    }

    void SetSpeed(float speed)
    {
        timerAnimation.speed = Mathf.Clamp(speed, MIN_TIMER_SPEED, MAX_TIMER_SPEED);
    }

    void EndOfTime()
    {
        GameManager.instance.GameOver();
    }
    
    void RestartTimer()
    {
        timerAnimation.Play("timerAnimation", -1, 0.0f);
    }

    void OnDestroy()
    {
        GameManager.instance.OnGoodAnswer -= RestartTimer;
        GameManager.instance.OnBadAnswer -= StopTimer;
    }
}
