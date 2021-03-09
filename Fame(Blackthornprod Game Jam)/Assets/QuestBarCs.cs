using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestBarCs : MonoBehaviour
{
    public GameManagerCs GameManagerCs;

    public bool Mission1Time = false;
    public bool Mission2Time = false;
    public bool Mission3Time = false;
    public bool Mission4Time = false;
    public bool MissionTime = true;

    public Image GoalImage;

    public TextMeshProUGUI GoalText;

    public GameObject Mission2Slimes;
    public GameObject Mission3Mashrooms;
    public GameObject Mission4Skeletons;

    public Sprite Goal1Sprite;
    public Sprite Goal2Sprite;
    public Sprite Goal3Sprite;
    public Sprite Goal4Sprite;    
    public Sprite BedSprite;
    public Sprite PostBoxSprite;

    private string Goal1Text = "Pick Up the seeds and grow 3 corns";
    private string Goal2Text = "Kill and collect 5 slimes";
    private string Goal3Text = "Forage 8 mashrooms from the forest beyond the village";
    private string Goal4Text = "Kill 6 Skeletons that are attacking the village!";    

    public string ToPostBox = "Deliver the goods to the post box";
    public string ToBed = "Sleep!";

    void Update()
    {
        if(MissionTime == true)
        {
            if(GameManagerCs.DayComplete1 == false && GameManagerCs.DayComplete2 == false && GameManagerCs.DayComplete3 == false && GameManagerCs.DayComplete4 == false)
            {
                Mission1Time = true;
                GoalImage.sprite = Goal1Sprite;
                GoalText.SetText(Goal1Text);
            }
            if(GameManagerCs.DayComplete1 == true && GameManagerCs.DayComplete2 == false && GameManagerCs.DayComplete3 == false && GameManagerCs.DayComplete4 == false)
            {
                Mission1Time = false;
                Mission2Time = true;
                Mission2Slimes.active = true;
                GoalImage.sprite = Goal2Sprite;
                GoalText.SetText(Goal2Text);
            }
            if(GameManagerCs.DayComplete1 == true && GameManagerCs.DayComplete2 == true && GameManagerCs.DayComplete3 == false && GameManagerCs.DayComplete4 == false)
            {
                Mission1Time = false;
                Mission2Time = false;
                Mission3Time = true;
                Mission3Mashrooms.active = true;
                GoalImage.sprite = Goal3Sprite;
                GoalText.SetText(Goal3Text);
            }
            if(GameManagerCs.DayComplete1 == true && GameManagerCs.DayComplete2 == true && GameManagerCs.DayComplete3 == true && GameManagerCs.DayComplete4 == false)
            {
                Mission1Time = false;
                Mission2Time = false;
                Mission3Time = false;
                Mission4Time = true;
                Mission4Skeletons.active = true;
                GoalImage.sprite = Goal4Sprite;
                GoalText.SetText(Goal4Text);
            }
        }
    }
}
