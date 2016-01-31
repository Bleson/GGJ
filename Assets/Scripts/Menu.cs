using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public void StartScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void ShutDown()
    {
        Application.Quit();
    }
}
