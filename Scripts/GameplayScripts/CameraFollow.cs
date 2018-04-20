using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    Transform target;
    Vector3 cameraTemp;
    float distance;


    void Start()
    {
        target = FindObjectOfType<Jump>().transform;
        cameraTemp = new Vector3(0.0f, 0.0f, -10.0f);
        distance = Vector2.Distance(target.position, transform.position); 
    }

    void Update()
    {
        cameraTemp.y = target.position.y + distance;
        transform.position = cameraTemp;
    }

}
