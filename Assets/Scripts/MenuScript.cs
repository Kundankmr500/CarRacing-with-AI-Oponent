using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    /// <summary>
    /// Gos to gamet scene.
    /// </summary>
    public void GoToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitApplication()
    {
        Application.Quit();
    }
}
