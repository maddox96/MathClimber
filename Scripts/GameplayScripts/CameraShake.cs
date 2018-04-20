using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{



    public float shake = 0.5f;
    public float shakeAmount = 0.4f;
    public float decreaseFactor = 0.8f;

    Vector3 originalPos;

    private void Start()
    {
        Stone.hasLanded += startShake;
        originalPos = transform.position;
    }
    
    void Update()
    {
        if (shake > 0)
        {
            transform.position = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
        }    
    }

    void startShake()
    {
        StartCoroutine(Shake(0.5f));
    }
    private void OnDestroy()
    {
        Stone.hasLanded -= startShake;
    }

    public IEnumerator Shake(float duration)
    {
        shake = duration;
        originalPos = transform.position;
        
        while (shake > 0.0f)
        {
            transform.position = originalPos + Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
            yield return null;
        }

        transform.position = originalPos;
    }
}
