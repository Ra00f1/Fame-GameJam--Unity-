using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayCompleteTextCs : MonoBehaviour
{
    public GameManagerCs GameManagerCs;
    public QuestBarCs QuestBarCs;
    public BedCs BedCs;
    public PostBoxCs PostBoxCs;
    public MissionCompleteCs MissionCompleteCs;
    public Image img;
    public TextMeshProUGUI Text;

    public Button MainMenuButton;

    public GameObject OutroGO;

    public GameObject Crowed1;
    public GameObject Crowed2;
    public GameObject Crowed3;

    public bool LastSlide = false;
    public bool DayCompleteTime = true; 

    public float fadetime;
    
    public int i = 0;

    private Color Imgcolor;
    private Color Textcolor;

    void Start()
    {
        Imgcolor = img.color;
        Textcolor = Text.color;
        GameObject BedGO = GameObject.Find("Bed");
        GameObject PostBoxGO = GameObject.Find("American Post Box");
        GameObject PlayerGO = GameObject.Find("Player");
        GameObject imgGO = GameObject.Find("OutroImage");
        GameObject TextGO = GameObject.Find("OutroText");
        GameManagerCs = GameObject.Find("GameManager").GetComponent<GameManagerCs>();
        QuestBarCs = GameObject.Find("QuestBar").GetComponent<QuestBarCs>();
        //OutroGO = GameObject.Find("Outro");
        img = imgGO.GetComponent<Image>();
        Text = TextGO.GetComponent<TextMeshProUGUI>();
        MissionCompleteCs = PlayerGO.GetComponent<MissionCompleteCs>();
        BedCs = BedGO.GetComponent<BedCs>();
        PostBoxCs = PostBoxGO.GetComponent<PostBoxCs>();
    }
    void Update()
    {
        
        if(DayCompleteTime == true)
        {
            if(GameManagerCs.DayComplete1 == true && GameManagerCs.DayComplete2 == false && GameManagerCs.DayComplete3 == false && GameManagerCs.DayComplete4 == false)
            {
                Text.SetText("Day one done!");
            }
            if(GameManagerCs.DayComplete1 == true && GameManagerCs.DayComplete2 == true && GameManagerCs.DayComplete3 == false && GameManagerCs.DayComplete4 == false)
            {
                Text.SetText("Day two done!");
            }
            if(GameManagerCs.DayComplete3 == true)
            {
                Text.SetText("Day three done!");
            }
            if(GameManagerCs.DayComplete4 == true)
            {
                Text.SetText("Day four done!");
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(LastSlide == true)
            {
                PostBoxCs.Open = true;
                PostBoxCs.Bedready = false;
                BedCs.FalshingE.active = false;
                PostBoxCs.FlasingE.active = false;
                QuestBarCs.MissionTime = true;
                MissionCompleteCs.MissionComplete = false;
                StartCoroutine(FadeImage(true));
            }
            SetOutroText();
            DayCompleteTime = false;
        }
    }
    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            for (fadetime = 1; fadetime >= 0; fadetime -= Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, fadetime);
                Text.color = new Color(1, 1, 1, fadetime);
                yield return null;
            }
            LastSlide = false;
            img.color = Imgcolor;
            Text.color = Textcolor;
            i = 0;
            DayCompleteTime = true;
            OutroGO.active = false;
        }
    }

    public void SetOutroText()
    {
        if(GameManagerCs.DayComplete1 == true && GameManagerCs.DayComplete2 == false && GameManagerCs.DayComplete3 == false && GameManagerCs.DayComplete4 == false)
        {
            if(i == 1)
            {
                Text.SetText("But should I have done that? now they will rely on me more and less on themselves. adn they started to bring offerings and cheer me which intruots with my sleep. Maybe that wasn't the best move.");
                LastSlide = true;
                Crowed1.active = true;
            }
            if(i == 0)
            {
                Text.SetText("Nice! With these corns villagers won't go hungry for quite some time and now back to Sleeping.");
                i = 1;
            }
        }
        if(GameManagerCs.DayComplete1 == true && GameManagerCs.DayComplete2 == true && GameManagerCs.DayComplete3 == false && GameManagerCs.DayComplete4 == false)
        {
            if(i == 2)
            {
                Text.SetText("And villiagers are comeing over way to much. I can't get any sleep. Maybe helping them really isn't a good idea.");
                LastSlide = true;
                Crowed2.active = true;
                Debug.Log("3");
            }
            if(i == 1)
            {
                Text.SetText("But why where here in the first place? They usually eat leftovers and live near villages but never come inside one.");
                i = 2;
                Debug.Log("2");
            }
            if(i == 0)
            {
                Text.SetText("Ok slimes are dealt with! Now villagers can return to their normal lives");
                i = 1;
                Debug.Log("1");
            }
        }
        if(GameManagerCs.DayComplete1 == true && GameManagerCs.DayComplete2 == true && GameManagerCs.DayComplete3 == true && GameManagerCs.DayComplete4 == false)
        {
            if(i == 2)
            {
                Text.SetText("Maybe I should just leave this place.");
                LastSlide = true;
                Crowed3.active = true;
                Debug.Log("3");
            }
            if(i == 1)
            {
                Text.SetText("But they don't seem to care for my privacy that much anymore.");
                i = 2;
                Debug.Log("2");
            }
            if(i == 0)
            {
                Text.SetText("Got more food for them and I also asked them not to distrub me in my sleep.");
                i = 1;
                Debug.Log("1");
            }
        }
        if(GameManagerCs.DayComplete1 == true && GameManagerCs.DayComplete2 == true && GameManagerCs.DayComplete3 == true && GameManagerCs.DayComplete4 == true)
        {
            if(i == 3)
            {
                Text.SetText("Tanks for playing the game! :)");
                MainMenuButton.gameObject.active = true;
            }
            if(i == 2)
            {
                Text.SetText("But little did our hero now that those skeletons actually didn't let the Golem nearby roam too close to the village and they even weren't looking for a fight only for mashrooms!");
                Debug.Log("3");
                i = 3;
            }
            if(i == 1)
            {
                Text.SetText("Although it was ver strange! Those monsters should not have attacked humans. They might look scary but they are pretty peacefull monsters. ANd these villagers are killing me, I can't get any sleep now maybe I really should run away.");
                i = 2;
                Debug.Log("2");
            }
            if(i == 0)
            {
                Text.SetText("So Village is saved once more! Skeletons are defeted and not a scratch on anybody.");
                i = 1;
                Debug.Log("1");
            }
        }
    }
}
