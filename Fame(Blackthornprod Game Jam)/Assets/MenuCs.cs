using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCs : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitApllication()
    {
        QuitApllication();
    }
    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
