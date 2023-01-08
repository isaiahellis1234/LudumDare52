using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] npc;
    public GameObject npc1;
    public Transform spawner;

    public bool npcGood;

    public static bool canvas;
    public static bool nextCanvas;

    public Canvas canvasObj;
    public Canvas nextCanvasObj;
    public Canvas deathCanvas;

    public TextMeshProUGUI nameCanvas;
    public TextMeshProUGUI goodCanvas;
    public TextMeshProUGUI badCanvas;

    public static bool DeathSwitch = false;
    public static bool letLive = false;
    public static bool respawn = false;

    public static int relationship = 0;
    public TextMeshProUGUI relationShipText;

    public static bool live;
    public static bool die;

    public static int health = 4;
    public TextMeshProUGUI healthText;

    // Arrays of Information
    public string[] names = { "Liam", "Noah", "Oliver", "Elijah", "James", "William", "Benjamin", "Lucas",
        "Henry", "Theodore", "Jack", "Levi", "Alexander", "Jackson", "Mateo", "Daniel", "Michael", "Mason", "Sebastian", "Ethan", "Logan", "Owen", "Samuel", "Jacob", "Asher",
            "Aiden", "John", "Joseph", "Wyatt", "David", "Leo", "Luke", "Julian", "Hudson", "Grayson", "Matthew", "Ezra", "Gabriel", "Carter", "Isaac", "Jayden", "Luca",
            "Anthony", "Dylan", "Lincoln", "Thomas", "Maverick", "Elias", "Josiah", "Charles", "Olivia", "Emma", "Charlotte", "Amelia", "Ava", "Sophia", "Isabella", "Mia", 
    "Evelyn", "Harper", "Luna", "Camila", "Gianna", "Elizabeth", "Eleanor", "ella", "Abigail", "Sofia", "Avery", "Scarlett", "Emily", "Aria", "Penelope", "Chloe", "Layla",
    "Mila", "Nora", "Hazel", "Madison", "Ellie", "Lily", "Nova", "Isla", "Grace", "Violet", "Aurora", "Riley", "Zoey", "Willow", "Emilia", "Stella", "Zeo", "Victoria",
    "Hannah", "Addison", "Leah", "Lucy", "Eliana", "Ivy", "Everly"};

    // 
    public string[] goodThings1 = {"Helps Walk Old ladies down the street", "Brought Toys to the Homeless Shelter", "Holds the Elevator Door", "Gives Strangers Compliments",
    "Helps People Put Groceries in Their Cars", "Sends Flowers to Someone for no Reason", "Ran an Errand For Someone", "Made a Music Plalist for Someone", "Mowed Someone's Yard",
    "Baked Cookies for The Office", "Read a Book to an Elderly Person", "Gave his favorite book to a friend", "Left someone a Nice Note on Someone's Car", "Let Someone Cut in Front of Them in Line",
    "Bought the Person Behind Them Coffee", "Hid a Love Note", "Picked Up Litter at the Park", "Donated to a Friend's Charity", "Sent a Care Package to a Soldier",
    "Took a Neighboy's Dog for a Walk", "Told a Boss about a Good Employee"};

    public int[] goodThings1Value = { 3, 3, 2, 2, 3, 3, 3, 2, 1, 2, 3, 1, 1, 2, 3, 1, 2, 3, 4, 2, 3 };

    public string[] badThings1 = { "Pushed Old Ladies Onto the Street", "Stole toys from a Homeless Shelter", "Shut the Elevator Door Before People Could Walk In", "Was mean to a Stranger",
    "Stole Groceries From People's Cars", "Destroyed Neighbor's flowers", "Made Someone Late to Work on Purpose", "Deleted Flappy Bird on Someone's Phone", "Broke Someone's Phone",
        "Knocked on Someone's Door and Ran Away", "Double Dipped in Salsa", "Plugged Friend's Toilet and Didn't Tell Anyone", "Littered", "Spit on the Ground", "Jaywalked",
        "Plagiarised an Essay"};
    public int[] badThings1Value = { 4, 4, 1, 2, 4, 3, 3, 4, 4, 1, 2, 4, 1, 1, 1, 2 };

    // Make each array have different points and if the points are high enough makes player be right. And make the points take away or add from the Devil's opinion.

    // Make the things go from 1 good and 2 bad or 2 good and 1 bad or 3 good one bad 3 bad 1 good.

    // GOOD ADDS, BAD SUBTRACTRS FROM SCORE

    // ACUTALLY MAKE IT ONE GOOD THING AND ONE BAD THING AND THEY HAVE DECIDE WHICH IS MORE IMPORTANT THE GOOD THINGS THEY DID OR THE BAD THINGS.
    // IF HE CHOOSES WHICH ONE IS THE HIGHER NUMBER THAN HE WINS. LIKE STEALING OUTWAYS DONATING SO IF HE SAID HELL THAN HE WINS IF HE SAID LIVE THEM HE LOST.

   // private static GameManager instance = null;


/*    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }*/

    void Start()
    {
        health = 4;
        player = GameObject.FindGameObjectWithTag("Player");
        npc = GameObject.FindGameObjectsWithTag("NPC");
        //npc[0].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        npc[0].transform.GetChild(0).gameObject.SetActive(false);
        canvas = false;
        deathCanvas.enabled = false;

        int rand = Random.Range(0, names.Length);
        nameCanvas.text = names[rand];

        int randGood = Random.Range(0, goodThings1.Length);
        int randBad = Random.Range(0, badThings1.Length);

        goodCanvas.text = goodThings1[randGood];
        badCanvas.text = badThings1[randBad];
    }

    float minDist = 5;
    void Update()
    {
        if (health <= 0)
        {
            deathCanvas.enabled = true;
            canvasObj.enabled = false;
            nextCanvasObj.enabled = false;
        }
        healthText.text = health.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); 
        }

      /*  if (Input.GetKeyDown(KeyCode.L))
        {
            DeathSwitch = !DeathSwitch;
        }*/

        Canvas();
        NextCanvas();
        float distance = Vector3.Distance(player.transform.position, npc[0].transform.position);
        if (distance < minDist)
        {
            npc[0].transform.GetChild(0).gameObject.SetActive(true);

            //print("W");
            /*if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(npc[0]);
                npc[0] = Instantiate(npc1, spawner.position, spawner.rotation);
                int randNum = Random.Range(0, 10);
                if (randNum < 5)
                {
                    npcGood = false;
                }
                else
                {
                    npcGood = true;
                }
            }*/

            if (Input.GetKeyDown(KeyCode.E))
            {
                canvas = !canvas;
            }
        }
        else
        {
            canvas = false;
            npc[0].transform.GetChild(0).gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (npcGood)
            {
                Debug.Log("DS");
            }
        }

        if (letLive)
        {

        }
    }

    void Canvas()
    {
        if (canvas && health > 0)
        {
            canvasObj.enabled = true;
        }
        if (!canvas && health > 0)
        {
            canvasObj.enabled = false;
        }

/*        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas = false;
        }*/
    }

    void NextCanvas()
    {
        if (relationshipValue > 0)
            relationShipText.text = "Bad!";
        if (relationshipValue < 0)
        {
            relationShipText.text = "Good!";
        }
        if (relationshipValue == 0)
        {
            relationShipText.text = "Neutral!";
        }
   /*     if (live)
        {
            if (relationshipValue > 0)
            {
                health += 1;
            live = false;
            }
        }*/
       /* if (die)
        {
            if (relationshipValue < 0)
            {
                health--;
                die = false;
            }
        }*/
        if (nextCanvas && health > 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            nextCanvasObj.enabled = true;
        }
        if (!nextCanvas)
        {
            nextCanvasObj.enabled = false;
        }
    }

    public void DeathSwitchFunction()
    {
        DeathSwitch = true;
        canvas = false;
        if (die)
        {
            if (relationshipValue < 0)
            { 
                health--;
                die = false;
            }
        }
    }

    public void LetLiveFunction()
    {
        letLive = true;
        canvas = false;
        if (live)
        {
            if (relationshipValue > 0)
            {
                health--;
                live = false;
            }
        }
    }

    int relationshipValue = 0;

    public void RespawnFunction()
    {
        int rand = Random.Range(0, names.Length);
        nameCanvas.text = names[rand];

        int randGood = Random.Range(0, goodThings1.Length);
        int randBad = Random.Range(0, badThings1.Length);

        int good = goodThings1Value[randGood];
        int bad = badThings1Value[randBad];
        relationshipValue = good - bad;
            print("BAD: " + bad);
            print("GOOD: " + good);
        if (relationshipValue <= 0)
        {
            print("Bad");
        }
        if (relationshipValue > 0)
        {
            print("Good");
        }

        goodCanvas.text = goodThings1[randGood];
        badCanvas.text = badThings1[randBad];
        npc[0] = Instantiate(npc1, spawner.position, spawner.rotation);
        player.transform.position = new Vector3(0, 0, 0);
        nextCanvas = false;
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene(0);
        Application.Quit();

    }
}
