using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectCs : MonoBehaviour
{
    public PlayerMovementCs PlayerMovementCs;
    public PickUpCs PickUpCs;
    public InteractableObjectCs interactableObjectCs;

    public Sprite[] Sprites;

    public GameObject FlasingE;

    private SpriteRenderer renderer;

    private float time;

    public int Stage;

    private bool StaertedGrowing;
    private bool Planetd = false;
    void Start()
    {
        GameObject PlayerGO = GameObject.Find("Player");
        PlayerMovementCs = PlayerGO.GetComponent<PlayerMovementCs>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        PickUpCs = gameObject.GetComponent<PickUpCs>();
        Stage = 1;
        StaertedGrowing = false;
        interactableObjectCs.enabled = true;
        FlasingE.active = false;
    }
    void Update()
    {
        if(PlayerMovementCs.HaveSeeds == true && FlasingE != null)
        {
            FlasingE.active = true;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(gameObject.tag == "DirtSpots")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(Planetd == false)
                    {
                        if(PlayerMovementCs.InventoryItemName == "Seeds")
                        {
                            if(PlayerMovementCs.InventoryItemCount >= 1)
                            {
                                if(StaertedGrowing == false)
                                {
                                    InvokeRepeating("Grow", 0f, 2f);
                                    Destroy(FlasingE);
                                }
                                PlayerMovementCs.InventoryItemCount--;
                                Planetd = true;
                            }
                        }
                    }
                }
            }
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(gameObject.tag == "DirtSpots")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(Planetd == false)
                    {
                        if(PlayerMovementCs.InventoryItemName == "Seeds")
                        {
                            if(PlayerMovementCs.InventoryItemCount >= 1)
                            {
                                if(StaertedGrowing == false)
                                {
                                    InvokeRepeating("Grow", 0f, 2f);
                                    Destroy(FlasingE);
                                }
                                PlayerMovementCs.InventoryItemCount--;
                                Planetd = true;
                            }
                        }
                    }
                }
            }
        }
    }

    void Grow()
    {
        if(Stage == 3)
        {
            renderer.sprite = Sprites[2];
            Stage++;
            PickUpCs.PickUpable = true;
        }
        if(Stage == 2)
        {
            renderer.sprite = Sprites[1];
            Stage++;
        }
        if(Stage == 1)
        {
            renderer.sprite = Sprites[0];
            StaertedGrowing = true;
            Stage++;
        }
    }
}
