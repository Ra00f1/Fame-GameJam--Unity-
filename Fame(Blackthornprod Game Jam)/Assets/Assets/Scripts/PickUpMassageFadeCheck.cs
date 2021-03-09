using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpMassageFadeCheck : MonoBehaviour
{
    public CanvasGroup canvasgroup;
    void Update()
    {
        if(canvasgroup.alpha == 0)
        {
            gameObject.active = false;
        }
    }
}
