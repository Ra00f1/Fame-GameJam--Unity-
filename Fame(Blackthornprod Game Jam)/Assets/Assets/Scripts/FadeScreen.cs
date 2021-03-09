using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeScreen : MonoBehaviour
{
    public GameManagerCs GameManagerCs;
    public Image img;
    public TextMeshProUGUI Text;
    public GameObject Games;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartCoroutine(FadeImage(true));
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            if(GameManagerCs.IntroTime == true)
            {
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    img.color = new Color(1, 1, 1, i);
                    Text.color = new Color(1, 1, 1, i);
                    yield return null;
                }
            }
                GameManagerCs.IntroTime = false;
        }
    }
}
