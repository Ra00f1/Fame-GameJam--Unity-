using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerMovementCs : MonoBehaviour 
{
    public MissionCompleteCs MissionCompleteCs;
    public GameManagerCs GameManagerCs;

    [SerializeField] float MovementSpeed = 4.0f;
    [SerializeField] float JumpSpeed = 7.5f;
    private Animator Aniamtor;

    public TextMeshProUGUI InventoryItemCountText;

    public Image InventoryItemImage;
    public Image[] HealthImage;

    public Button GameOverbutton;
    public Button ExitButton;

    private Rigidbody2D RB;

    public Transform GroundCheck;

    public AudioSource AudioScource;

    public AudioClip HurtSFX;
    public AudioClip HitSFX;

    public bool Grounded;
    public bool HaveSeeds = false;
    public bool Blocking = false;

    public bool Mission1 = false;
    public bool Mission2 = false;
    public bool Mission3 = false;
    public bool Mission4 = false;

    public bool DamagedBefore;
    
    private bool FacingRight = true;
    private bool Moving;

    public int Health = 3;

    private int m_facingDirection = 1;
    private int CurrentAttack = 0;

    public float AttackRange;

    public float CheckRadius;
    private float TimeSinceAttack = 0.0f;
    private float DelayToIdle = 0.0f;
    private float MoveInput;

    public LayerMask GroundLayer;
    public LayerMask EnemyLayer;
    public LayerMask SkeletonLayer;

    public Transform Attackpos;

    public int InventoryItemCount;
    public string InventoryItemName;

    // Use this for initialization
    void Start ()
    {
        GameObject GameManagerGO = GameObject.Find("GameManager");
        GameManagerCs = GameManagerGO.GetComponent<GameManagerCs>();
        Aniamtor = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        AudioScource = gameObject.GetComponent<AudioSource>();
        MissionCompleteCs = GetComponent<MissionCompleteCs>();
        Moving = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if(Health <= 0)
        {
            GameOver();
        }
        TimeSinceAttack += Time.deltaTime;
        
        Aniamtor.SetFloat("AirSpeedY", RB.velocity.y);

        InventoryItemCountText.SetText(InventoryItemCount.ToString());

        if(InventoryItemCount == 0)
        {
            InventoryItemCountText.enabled = false;
            InventoryItemImage.enabled = false;
        }
        if(InventoryItemCount > 0)
        {
            InventoryItemCountText.enabled = true;
            InventoryItemImage.enabled = true;
        }

        if(Input.GetMouseButtonDown(0) && TimeSinceAttack > 0.25f)
        {
            CurrentAttack++;

            // Loop back to one after third attack
            if (CurrentAttack > 3)
                CurrentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (TimeSinceAttack > 1.0f)
                CurrentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            Aniamtor.SetTrigger("Attack" + CurrentAttack);
            
            Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(Attackpos.position, AttackRange, EnemyLayer);
            for(int i = 0; i < EnemiesToDamage.Length; i++)
            {
                Debug.Log("Enemy");
                if(EnemiesToDamage[i].gameObject.tag == "Skeleton")
                {
                    Debug.Log("Skeleton");
                    SkeletonCs SkeletonCs = EnemiesToDamage[i].GetComponent<SkeletonCs>();
                    if(SkeletonCs.damagedbefore == false)
                    {
                        Animator enemyanimator = EnemiesToDamage[i].GetComponent<Animator>();
                        enemyanimator.SetTrigger("TakeDamage");
                        SkeletonCs.Takedamage();
                        AudioScource.clip = HitSFX;
                        AudioScource.Play();
                        SkeletonCs.damagedbefore = true;
                        Debug.Log("Take Damaeg!");
                    }
                }
                if(EnemiesToDamage[i].gameObject.tag == "Slime")
                {
                    Debug.Log("slime");
                    EnemyCs enemyCs = EnemiesToDamage[i].GetComponent<EnemyCs>();
                    if(enemyCs.damagedbefore == false)
                    {
                        Animator enemyanimator = EnemiesToDamage[i].GetComponent<Animator>();
                        enemyanimator.SetTrigger("TakeDamage");
                        enemyCs.Takedamage();
                        AudioScource.clip = HitSFX;
                        AudioScource.Play();
                        enemyCs.damagedbefore = true;
                        Debug.Log("Take Damaeg!");
                    }
                }
            }
            // Reset timer
            TimeSinceAttack = 0.0f;
            for(int i = 0; i < EnemiesToDamage.Length; i++)
            {
                if(EnemiesToDamage[i].gameObject.tag == "Slime")
                {
                    EnemyCs enemyCs = EnemiesToDamage[i].GetComponent<EnemyCs>();
                    enemyCs.damagedbefore = false;
                    Debug.Log("DamageReset");
                }
                if(EnemiesToDamage[i].gameObject.tag == "Skeleton")
                {
                    SkeletonCs SkeletonCs = EnemiesToDamage[i].GetComponent<SkeletonCs>();
                    SkeletonCs.damagedbefore = false;
                    Debug.Log("DamageReset");
                }
            }
        }

        // Block
        else if (Input.GetMouseButtonDown(1))
        {
            Aniamtor.SetTrigger("Block");
            Aniamtor.SetBool("IdleBlock", true);
            Blocking = true;
        }

        else if (Input.GetMouseButtonUp(1))
        {
            Aniamtor.SetBool("IdleBlock", false);
            Blocking = false;
        }

        else if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(Grounded == true)
            {
                Aniamtor.SetTrigger("Jump");
                Aniamtor.SetBool("Grounded", Grounded);
                RB.velocity = Vector2.up * JumpSpeed;
            }
        }
        //Run
        else if (MoveInput != 0 && Grounded == true)
        {
            // Reset timer
            DelayToIdle = 0.05f;
            Aniamtor.SetInteger("AnimState", 1);
        }
        //Idle
        else
        {
            // Prevents flickering transitions to idle
            DelayToIdle -= Time.deltaTime;
                if(DelayToIdle < 0)
                    Aniamtor.SetInteger("AnimState", 0);
        }
    }
    void FixedUpdate()
    {

        Grounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius,GroundLayer);
        Aniamtor.SetBool("Grounded", Grounded);
        if(Blocking == false)
        {
            MoveInput = Input.GetAxis("Horizontal");
            RB.velocity = new Vector2(MoveInput * MovementSpeed, RB.velocity.y);
        }
        if(MoveInput != 0)
        {
            Moving = true;
        }
        if(FacingRight == false && MoveInput > 0)
        {
            Flip();
        }
        else if(FacingRight == true && MoveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Attackpos.position, AttackRange);
    }  

    public void TakeDamage()
    {
        Health -=1;
        AudioScource.clip = HurtSFX;
        AudioScource.Play();
        if(Health == 5)
        {
            HealthImage[0].gameObject.active = true;
            HealthImage[1].gameObject.active = true;
            HealthImage[2].gameObject.active = true;
            HealthImage[3].gameObject.active = true;
            HealthImage[4].gameObject.active = true;
        }
        if(Health == 4)
        {
            HealthImage[0].gameObject.active = false;
            HealthImage[1].gameObject.active = true;
            HealthImage[2].gameObject.active = true;
            HealthImage[3].gameObject.active = true;
            HealthImage[4].gameObject.active = true;
        }
        if(Health == 3)
        {
            HealthImage[0].gameObject.active = false;
            HealthImage[1].gameObject.active = false;
            HealthImage[2].gameObject.active = true;
            HealthImage[3].gameObject.active = true;
            HealthImage[4].gameObject.active = true;
        }
        if(Health == 2)
        {
            HealthImage[0].gameObject.active = false;
            HealthImage[1].gameObject.active = false;
            HealthImage[2].gameObject.active = false;
            HealthImage[3].gameObject.active = true;
            HealthImage[4].gameObject.active = true;
        }
        if(Health == 1)
        {
            HealthImage[0].gameObject.active = false;
            HealthImage[1].gameObject.active = false;
            HealthImage[2].gameObject.active = false;
            HealthImage[3].gameObject.active = false;
            HealthImage[4].gameObject.active = true;
        }
        if(Health == 0)
        {
            HealthImage[0].gameObject.active = false;
            HealthImage[1].gameObject.active = false;
            HealthImage[2].gameObject.active = false;
            HealthImage[3].gameObject.active = false;
            HealthImage[4].gameObject.active = false;
        }
    }

    void GameOver()
    {
        GameManagerCs.OutroGo.active = true;
        PlayerMovementCs playerMovementCs = gameObject.GetComponent<PlayerMovementCs>();
        playerMovementCs.enabled = false;
        GameOverbutton.gameObject.active = true;
        ExitButton.gameObject.active = true;
        if(MissionCompleteCs.mission1 == false)
        {
            string GameOverText1 = "They trusted you, yet you couldn't deliver and they all suffered and passed away becuase of that.";
            GameManagerCs.OutroText.SetText(GameOverText1);
        }
        if(MissionCompleteCs.mission1 == true && MissionCompleteCs.mission2 == false)
        {
            string GameOverText2 = "After the Hero was defeated slimes ate and grow so big that they started to attack houses and ate entire houses! So Villagers decided to leave the village and find home elsewhere.";
            GameManagerCs.OutroText.SetText(GameOverText2);
        }
        if(MissionCompleteCs.mission1 == true && MissionCompleteCs.mission2 == true && MissionCompleteCs.mission3 == false)
        {
            string GameOverText3 = "How can somebody even die when picking up mashrooms!? anyway after Hero's death villagers started to think they should not asks others for help all the time and start to rely only on themselves.";
            GameManagerCs.OutroText.SetText(GameOverText3);
        }
        if(MissionCompleteCs.mission1 == true && MissionCompleteCs.mission2 == true && MissionCompleteCs.mission3 == true && MissionCompleteCs.mission4 == false)
        {
            string GameOverText4 = "Skeletons rampaged the village after Hero's death and apperantly they were looking for food, The mashrooms the Hero collected for villagers! Villagers suffered heavy losses but some could flee and live on.";
            GameManagerCs.OutroText.SetText(GameOverText4);
        }
    }
}
