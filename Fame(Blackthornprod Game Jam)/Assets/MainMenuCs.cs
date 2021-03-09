using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuCs : MonoBehaviour
{
    public GameObject CreditsWindow;
    public Button CreditBack;

    public void Loadgame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Credits()
    {
        CreditBack.gameObject.active = true;
        CreditsWindow.active = true;
    }

    public void CreditGoBack()
    {
        CreditBack.gameObject.active = false;
        CreditsWindow.active = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
