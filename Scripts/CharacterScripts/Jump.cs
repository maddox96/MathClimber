using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    static public event GameManager.GameEventsHandler AfterLanding;
    float hopHeight = 1.25f;
    public bool hopping = false;

    public IEnumerator Hop(Vector2 dest)
    {
        hopping = true;
        Vector2 startPos = transform.position;
        float timer = 0.0f;

        while (timer <= 1.0f)
        {
            float height = Mathf.Sin(Mathf.PI * timer) * hopHeight;
            transform.position = Vector2.Lerp(startPos, dest, timer) + Vector2.up * height;

            timer += Time.fixedDeltaTime / 0.75f;
            yield return null;
        }

        transform.position = dest;
        hopping = false;
        if(AfterLanding != null)
            AfterLanding();
    }


}