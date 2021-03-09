using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionCompleteCs : MonoBehaviour
{
    public bool mission1 = false;
    public bool mission2 = false;
    public bool mission3 = false;
    public bool mission4 = false;    

    public bool MissionComplete = false;

    public PlayerMovementCs playerMovementCs;
    public QuestBarCs QuestBarCs;
    public PostBoxCs PostBoxCs;

    public TextMeshProUGUI QuestText;
    public Image PostBoxImage;
    public Sprite PostBoxSprite;
    void Start()
    {
        playerMovementCs = GetComponent<PlayerMovementCs>();
        GameObject PostBoxGO = GameObject.Find("American Post Box");
        PostBoxCs = PostBoxGO.GetComponent<PostBoxCs>();
    }

    void Update()
    {
        Mission1();
        Mission2();
        Mission3();
        Mission4();
    }
    void Mission1()
    {
        if(playerMovementCs.InventoryItemName == "Corn")
        {
            if(playerMovementCs.InventoryItemCount == 3)
            {
                mission1 = true;
                playerMovementCs.Mission1 = true;
                QuestText.SetText(QuestBarCs.ToPostBox);
                PostBoxCs.MissionDelivered1 = true;
                PostBoxImage.sprite = PostBoxSprite;
                QuestBarCs.MissionTime = false;
                MissionComplete = true;
            }
        }
    }

    void Mission2()
    {
        if(playerMovementCs.InventoryItemName == "Dead Slime")
        {
            if(playerMovementCs.InventoryItemCount == 5)
            {
                mission2 = true;
                playerMovementCs.Mission2 = true;
                QuestText.SetText(QuestBarCs.ToPostBox);
                PostBoxCs.MissionDelivered2 = true;
                PostBoxImage.sprite = PostBoxSprite;
                QuestBarCs.MissionTime = false;
                MissionComplete = true;
            }
        }
    }
    

    void Mission3()
    {
        if(playerMovementCs.InventoryItemName == "Mashroom")
        {
            if(playerMovementCs.InventoryItemCount == 8)
            {
                mission3 = true;
                playerMovementCs.Mission3 = true;
                QuestText.SetText(QuestBarCs.ToPostBox);
                PostBoxCs.MissionDelivered3 = true;
                PostBoxImage.sprite = PostBoxSprite;
                QuestBarCs.MissionTime = false;
                MissionComplete = true;
            }
        }
    }
    void Mission4()
    {
        if(playerMovementCs.InventoryItemName == "Dead Skeleton")
        {
            if(playerMovementCs.InventoryItemCount == 6)
            {
                mission4 = true;
                playerMovementCs.Mission4 = true;
                QuestText.SetText(QuestBarCs.ToPostBox);
                PostBoxCs.MissionDelivered4 = true;
                PostBoxImage.sprite = PostBoxSprite;
                QuestBarCs.MissionTime = false;
                MissionComplete = true;
            }
        }
    }
}
