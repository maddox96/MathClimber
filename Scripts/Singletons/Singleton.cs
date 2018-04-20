using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{

    static T _instance;
    static bool alreadyExists = false;

    public static T instance
    {
        get
        {
            return _instance;
        }
    }

    public virtual void Awake()
    {

        if (!alreadyExists || FindObjectsOfType<Singleton<T>>().Length < 2)
        {    
            if (instance == null)
                _instance = GetComponent<T>();
           
            if(instance == null)
            {
                Destroy(gameObject);
                Debug.LogError("Null manager");
            }

            alreadyExists = true;

        }else
        {
            Debug.LogError("Manager of type " + GetType() + " already exists.");
            Destroy(gameObject);
        }    
    }

    void OnDestroy()
    {
        Debug.Log("ye");
        if (alreadyExists)
            alreadyExists = false;
    }

}

