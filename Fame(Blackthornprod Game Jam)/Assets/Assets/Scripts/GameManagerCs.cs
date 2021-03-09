using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerCs : MonoBehaviour
{
    public PlayerMovementCs PlayerMovementCs;
    public BedCs BedCs;

    public bool IntroTime = false;

    public bool DayComplete1 = true;
    public bool DayComplete2 = false;
    public bool DayComplete3 = false;
    public bool DayComplete4 = false;    
    public GameObject IntroGO;
    public GameObject OutroGo;

    public TextMeshProUGUI OutroText;
    void Start()
    {
        GameObject PlayeGO = GameObject.Find("Player");
        GameObject BedGO = GameObject.Find("Bed");
        BedCs = BedGO.GetComponent<BedCs>();
        PlayerMovementCs = PlayeGO.GetComponent<PlayerMovementCs>();
        IntroTime = true;
        if(IntroGO.active == false)
        {
            IntroTime = false;
        }
    }
    void Update()
    {
        if(IntroTime == true)
        {
            PlayerMovementCs.enabled = false;
        }if(IntroTime == false)
        {
            PlayerMovementCs.enabled = true;
        }
    }
}
