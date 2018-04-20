using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

    [SerializeField]
    AudioClip fallingStone;

    [SerializeField]
    AudioClip stoneHit;

    public static event GameManager.GameEventsHandler hasLanded;
    Transform playerPosition;
    Vector3 offset;
    public bool isFalling = false;
    float speed;
    float fallingTime = 2.0f;

    void Start()
    {
        playerPosition = FindObjectOfType<Jump>().transform;
        if (playerPosition == null)
            Debug.LogError("Player not found!");

        GameManager.instance.OnBadAnswer += MoveAndActiveStone;
        offset = new Vector3(0.0f, 30.0f, 0.0f);
    }

    void MoveAndActiveStone()
    {
        MoveStone();
        isFalling = true;
        MusicManager.instance.PlaySound(fallingStone);
    }

    void MoveStone()
    {
        transform.position = playerPosition.position + offset;
        speed = Vector2.Distance(transform.position, playerPosition.position) / fallingTime;
    }

    void Update()
    {
        if(isFalling)
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 360.0f * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
            if (transform.position == playerPosition.position)
            {

                isFalling = false;
                transform.eulerAngles = Vector3.zero;
                MusicManager.instance.PlaySound(stoneHit);
                if (hasLanded != null)
                    hasLanded();
            }
        }
    }

    void OnDestroy()
    {
        GameManager.instance.OnBadAnswer -= MoveAndActiveStone;
    }

}
