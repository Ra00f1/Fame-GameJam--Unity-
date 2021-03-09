using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCs : MonoBehaviour
{
    public PickUpCs PickUpCs;

    public GameObject FalshingE;
    public GameObject DeadSlime;

    public BoxCollider2D Trigcoll;
    public BoxCollider2D coll;

    public Rigidbody2D RB;

    public int Health = 3;

    public float speed;

	public bool MoveRight = false;
    public bool damagedbefore = false;
    
    void Start()
    {
        FalshingE.active = false;
        //GameObject ParentGO = gameObject.transform.parent.gameObject;
        //PickUpCs = ParentGO.GetComponent<PickUpCs>();
        RB = GetComponent<Rigidbody2D>();
        PickUpCs.enabled = false;
        coll.enabled = true;
        Trigcoll.enabled = false;
    }
    void Update()
    {
        if(MoveRight) 
        {
			transform.Translate(2* Time.deltaTime * speed, 0,0);
			transform.localScale= new Vector2 (1,1);
 		}
		else
        {
			transform.Translate(-2* Time.deltaTime * speed, 0,0);
			transform.localScale= new Vector2 (-1,1);
		}

        if(Health <= 0)
        {
            GameObject NewGO =Instantiate(DeadSlime,transform.position,transform.rotation);
            NewGO.name = "Dead Slime";
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Trun")
        {
			if (MoveRight == true)
            {
				MoveRight = false;
			}
			else
            {
				MoveRight = true;
			}	
		}
	}
    public void Takedamage()
    {
        Health = Health - 1;
    }
}
