using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostBoxCs : MonoBehaviour
{
    public PlayerMovementCs PlayerMovementCs;
    public MissionCompleteCs MissionCompleteCs;

    public GameObject FlasingE;

    public Sprite[] Sprites;

    private SpriteRenderer renderer;

    public bool Open = true;
    public bool Bedready = false;

    public bool MissionDelivered1 = false;
    public bool MissionDelivered2 = false;
    public bool MissionDelivered3 = false;
    public bool MissionDelivered4 = false;    

    
    public QuestBarCs QuestBarCs;

    public TextMeshProUGUI QuestText;
    public Image QuestImage;
    public Sprite BedSprite;
    void Start()
    {
        GameObject PlayerGO = GameObject.Find("Player");
        PlayerMovementCs = PlayerGO.GetComponent<PlayerMovementCs>();
        MissionCompleteCs = PlayerGO.GetComponent<MissionCompleteCs>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        Open = true;
        FlasingE.active = false;
    }
    void Update()
    {
        if(MissionCompleteCs.MissionComplete == true && Open == true)
        {
            FlasingE.active = true;
        }
        if(Open == true)
        {
            renderer.sprite = Sprites[0];
        }
        if(Open == false)
        {
            renderer.sprite = Sprites[1];
            FlasingE.active = false;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(MissionCompleteCs.MissionComplete == true)
                {
                    Open = false;
                    PlayerMovementCs.InventoryItemCount = 0;
                    MissionDelivered1 = true;
                    Bedready = true;
                    QuestImage.sprite = BedSprite;
                    QuestText.SetText(QuestBarCs.ToBed);
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
                if(MissionCompleteCs.MissionComplete == true)
                {
                    Open = false;
                    PlayerMovementCs.InventoryItemCount = 0;
                    MissionDelivered1 = true;
                    Bedready = true;
                    QuestImage.sprite = BedSprite;
                    QuestText.SetText(QuestBarCs.ToBed);
                }
            }
        }
    }
}
