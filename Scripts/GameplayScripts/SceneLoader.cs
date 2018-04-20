using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public static SceneLoader sceneLoader;
    
    void Start()
    {
        sceneLoader = this;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("game");
        GameManager.instance.Init();
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
