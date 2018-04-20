using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    public AnimationCurve fadeCurve;
    public List<MaskableGraphic> objectsToFade;
    public float fadingSpeed;
    enum FADE { IN, OUT };
    
    void OnEnable()
    {
        InitObjectList();
        FadeObjects();
    }

    void FadeObjects()
    {
        foreach (MaskableGraphic obj in objectsToFade)
            StartCoroutine(FadeCoroutine(obj));
    }

    void InitObjectList()
    {
        objectsToFade = new List<MaskableGraphic>();

        MaskableGraphic temp = GetComponent<MaskableGraphic>();
        if (temp != null)
            objectsToFade.Add(temp);

        foreach (Transform obj in transform)
        {
            temp = obj.GetComponent<MaskableGraphic>();
            if(temp != null) objectsToFade.Add(temp);
        }
    }
    
    IEnumerator FadeCoroutine(MaskableGraphic obj)
    {
        float t = 0.0f;
        Color color = obj.color;
        while (t < 1.0f)
        {
            t += Time.deltaTime;
            color.a = t;
            obj.color = color;
            yield return 0;
        }

        yield return 0;
    }

}
