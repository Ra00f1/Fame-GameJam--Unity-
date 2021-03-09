using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUpCs : MonoBehaviour
{
    public PlayerMovementCs PlayerMovementCs;

    public GameObject PickUpMassageGO;
    public GameObject PlayerGO;

    public Image PickUpMassageImage;
    public Image InventoryImage;

    public TextMeshProUGUI PickUpMassageText;
    public TextMeshProUGUI InventoryPickUpCountText;

    public Sprite Seeds;

    public int pickUpCount;

    public bool PickUpable = true;
    void Start()
    {
        PlayerGO = GameObject.Find("Player");
        PlayerMovementCs = PlayerGO.GetComponent<PlayerMovementCs>();
        PickUpMassageGO = GameObject.Find("PickUp Massage");
        GameObject InventoryImageGo = GameObject.Find("InImage");
        GameObject InventoryPickUpCountGO = GameObject.Find("InText");
        InventoryPickUpCountText = InventoryPickUpCountGO.GetComponent<TextMeshProUGUI>();
        InventoryImage = InventoryImageGo.GetComponent<Image>();
        GameObject PickUpImageGo = GameObject.Find("PiImage");
        GameObject PickUpTextGO = GameObject.Find("PiText");
        PickUpMassageText = PickUpTextGO.GetComponent<TextMeshProUGUI>();
        PickUpMassageImage = PickUpImageGo.GetComponent<Image>();
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(PickUpable == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    SpriteRenderer PMISR = gameObject.GetComponent<SpriteRenderer>();
                    if(gameObject.name == "Seeds")
                    {
                        PMISR.sprite = Seeds;
                        PlayerMovementCs.HaveSeeds = true;
                    }
                    PickUpMassageImage.sprite = PMISR.sprite;
                    InventoryImage.sprite = PMISR.sprite;
                    PickUpMassageText.SetText("Picked up "+ gameObject.name);
                    if(PlayerMovementCs.InventoryItemName == gameObject.name)
                    {
                        InventoryPickUpCountText.SetText(PlayerMovementCs.InventoryItemCount + pickUpCount.ToString());
                        PlayerMovementCs.InventoryItemCount = PlayerMovementCs.InventoryItemCount + pickUpCount;
                    }
                    else
                    {
                        InventoryPickUpCountText.SetText(pickUpCount.ToString());
                        PlayerMovementCs.InventoryItemName = gameObject.name;
                        PlayerMovementCs.InventoryItemCount = pickUpCount;
                    }
                    PickUpMassageGO.active = false;
                    PickUpMassageGO.active = true;
                    Destroy(gameObject);
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
            if(PickUpable == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    SpriteRenderer PMISR = gameObject.GetComponent<SpriteRenderer>();
                    if(gameObject.name == "Seeds")
                    {
                        PMISR.sprite = Seeds;
                        PlayerMovementCs.HaveSeeds = true;
                    }
                    PickUpMassageImage.sprite = PMISR.sprite;
                    InventoryImage.sprite = PMISR.sprite;
                    PickUpMassageText.SetText("Picked up "+ gameObject.name);
                    if(PlayerMovementCs.InventoryItemName == gameObject.name)
                    {
                        InventoryPickUpCountText.SetText(PlayerMovementCs.InventoryItemCount + pickUpCount.ToString());
                        PlayerMovementCs.InventoryItemCount = PlayerMovementCs.InventoryItemCount + pickUpCount;
                    }
                    else
                    {
                        InventoryPickUpCountText.SetText(pickUpCount.ToString());
                        PlayerMovementCs.InventoryItemName = gameObject.name;
                        PlayerMovementCs.InventoryItemCount = pickUpCount;
                    }
                    PickUpMassageGO.active = false;
                    PickUpMassageGO.active = true;
                    Destroy(gameObject);
                }
            }
        }
    }

}}
