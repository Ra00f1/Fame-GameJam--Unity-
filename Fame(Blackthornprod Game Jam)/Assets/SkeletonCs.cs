using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCs : MonoBehaviour
{
    public PlayerMovementCs PlayerMovementCs;
    public PickUpCs PickUpCs;

    public Animator Animator;

    public GameObject FalshingE;
    public GameObject DeadSkeletonGO;

    public Rigidbody2D RB;

    public Transform Attackpos;
    public Transform DeadSkeletonSpawn;

    public LayerMask PlayerLayer;

    public int Health = 5;

    public float speed;
    public float AttackRange;
    public float TimeBetweenAttacks = 1.5f;

    public bool damagedbefore = false;
    public bool InRange;
    private bool SetAnimatordead = false;
    
    void Start()
    {
        GameObject PLayerGO = GameObject.Find("Player");
        PlayerMovementCs = PLayerGO.GetComponent<PlayerMovementCs>();
        FalshingE.active = false;
        RB = GetComponent<Rigidbody2D>();
        Animator = gameObject.GetComponent<Animator>();
        //PickUpCs.enabled = false;
    }
    void Update()
    {
        TimeBetweenAttacks -= Time.deltaTime;
		transform.Translate(-2* Time.deltaTime * speed, 0,0);
		transform.localScale= new Vector2 (-1,1);
		
        if(Health <= 0)
        {
            if(SetAnimatordead == false)
            {
                InRange = false;
                TimeBetweenAttacks = 1000000;
                Animator.SetTrigger("Death");
                SetAnimatordead = true;
            }
            //Destroy(gameObject.transform.parent.gameObject);
        }

        if(InRange == true)
        {
            speed = 0;
        }
    }
	public void OnTriggerEnter2D(Collider2D coll)
	{
        if(coll.gameObject.tag == "Player")
        {
            if(TimeBetweenAttacks <= 0.0f)
            {
                Attack();
            }
        }
	}
    public void OnTriggerStay2D(Collider2D coll)
	{
        if(coll.gameObject.tag == "Player")
        {
            if(TimeBetweenAttacks <= 0)
            {
                Attack();
            }
        }
	}
    public void OnTriggerExit2D(Collider2D coll)
	{
        if(coll.gameObject.tag == "Player")
        {
            InRange = false;
            Animator.SetBool("InRange", false);
        }
	}
    public void Takedamage()
    {
        Health = Health - 1;
        Animator.SetTrigger("Hit");
    }

    public void Attack()
    {
        TimeBetweenAttacks = 1.5f;
        InRange = true;
        Animator.SetTrigger("Attack");
    }

    public void DealDamage()
    {
        Collider2D[] Player = Physics2D.OverlapCircleAll(Attackpos.position, AttackRange, PlayerLayer);
        for(int i =0; i < Player.Length; i++)
        {
            if(PlayerMovementCs.DamagedBefore == false)
            {
                if(PlayerMovementCs.Blocking == false)
                {
                    PlayerMovementCs.TakeDamage();
                    PlayerMovementCs.DamagedBefore = true;
                }
            }
        }
        for(int i =0; i < Player.Length; i++)
        {
            PlayerMovementCs.DamagedBefore = false;
        }
    }

    public void AfterDeath()
    {
        GameObject newGO = Instantiate(DeadSkeletonGO,DeadSkeletonSpawn.position,transform.rotation);
        newGO.name = "Dead Skeleton";
        Destroy(gameObject.transform.parent.gameObject);
    }
}
