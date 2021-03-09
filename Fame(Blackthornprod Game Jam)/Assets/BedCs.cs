using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedCs : MonoBehaviour
{
    public GameObject FalshingE;
    public GameObject Outro;

    public PostBoxCs PostBoxCs;
    public PlayerMovementCs PlayerMovementCs;
    public GameManagerCs GameManagerCs;

    public bool daycomplete1 = false;
    public bool daycomplete2 = false;
    public bool daycomplete3 = false;
    public bool daycomplete4 = false;    

    void Start()
    {
        GameObject PLayerGO = GameObject.Find("Player");
        GameObject PostBoxGO = GameObject.Find("American Post Box");
        GameObject GameMangaerGO = GameObject.Find("GameManager");
        GameManagerCs = GameMangaerGO.GetComponent<GameManagerCs>();
        PostBoxCs = PostBoxGO.GetComponent<PostBoxCs>();
        PlayerMovementCs = PLayerGO.GetComponent<PlayerMovementCs>();
        FalshingE.active = false;
        Outro.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PostBoxCs.Bedready == true)
        {
            FalshingE.active = true;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(PostBoxCs.Bedready == true)
                {
                    CompleteDay();
                }
            }
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(PostBoxCs.Bedready == true)
                {
                    CompleteDay();
                }
            }
        }
    }

    void CompleteDay()
    {
        Outro.active = true;
        PlayerMovementCs.enabled = false;
        if(PostBoxCs.MissionDelivered1 == true && PostBoxCs.MissionDelivered2 == false && PostBoxCs.MissionDelivered3 == false && PostBoxCs.MissionDelivered4 == false)
        {
            daycomplete1 = true;
            GameManagerCs.DayComplete1 = true;
        }
        if(PostBoxCs.MissionDelivered1 == true && PostBoxCs.MissionDelivered2 == true&& PostBoxCs.MissionDelivered3 == false && PostBoxCs.MissionDelivered4 == false)
        {
            daycomplete1 = true;
            daycomplete2 = true;
            GameManagerCs.DayComplete1 = true;
            GameManagerCs.DayComplete2 = true;
        }
        if(PostBoxCs.MissionDelivered1 == true && PostBoxCs.MissionDelivered2 == true && PostBoxCs.MissionDelivered3 == true && PostBoxCs.MissionDelivered4 == false)
        {
            daycomplete1 = true;
            daycomplete2 = true;
            daycomplete3 = true;
            GameManagerCs.DayComplete1 = true;
            GameManagerCs.DayComplete2 = true;
            GameManagerCs.DayComplete3 = true;
        }
        if(PostBoxCs.MissionDelivered1 == true && PostBoxCs.MissionDelivered2 == true && PostBoxCs.MissionDelivered3 == true && PostBoxCs.MissionDelivered4 == true)
        {
            daycomplete1 = true;
            daycomplete2 = true;
            daycomplete3 = true;
            daycomplete4 = true;
            GameManagerCs.DayComplete1 = true;
            GameManagerCs.DayComplete2 = true;
            GameManagerCs.DayComplete3 = true;
            GameManagerCs.DayComplete4 = true;
        }
    }
}
