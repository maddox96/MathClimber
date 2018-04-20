using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour
{
    const float BACKGROUND_MOVE_OFFSET = 23.28f;

    public Transform[] backgrounds;

    int jumpCounter = 0;

    int _nextBackground = 0;
    public int nextBackground
    {
        get
        {
            if (_nextBackground >= backgrounds.Length)
                _nextBackground = 0;
            return _nextBackground;
        }

        set
        {
            _nextBackground = value;
        }
    }

    void Start()
    {
        GameManager.instance.OnGoodAnswer += moveNextBackground;
    }

    void moveNextBackground()
    {
        jumpCounter++;
        if (jumpCounter % 2 == 0)
        {
            backgrounds[nextBackground].position += new Vector3(0.0f, BACKGROUND_MOVE_OFFSET, 0.0f);
            nextBackground++;
        }
    }
    
    void OnDestroy()
    {
        GameManager.instance.OnGoodAnswer -= moveNextBackground;
    }


}
