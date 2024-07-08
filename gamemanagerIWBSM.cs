using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{ 
    private Vector2 screenbounds;

    private Spawner spawner;
    public GameObject title;

    public GameObject playerprefab;
    private GameObject player;
    private bool gamestarted = false;
    public GameObject splash;

    public TMP_Text scoretext;
    public int pointsworth = 1;
    public int score;

    public int bestscore = 0;
    // public TMP_Text bestscoretext;
    private bool beatbestscore;
    public Color normalcolor;
    public Color bestscorecolor;

    private bool smokecleared = true;

   
    void Awake()
    {
        bscoremanage= GetComponent<bestscoremanager>();

        scoretext.enabled = false;
        
        spawner = GameObject.Find("spawner").GetComponent<Spawner>();
        bestscore= bscoremanage.loadhs()
    }
    // Start is called before the first frame update
    void Start()
    {
         
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
           
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);
        bestscore = PlayerPrefs.GetInt("bestscore");
        bestscoretext.text = "High Score:  " + bestscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        var nextbomb = GameObject.FindGameObjectsWithTag("Bomb");
        if (!gamestarted)
        {
            if (Input.anyKeyDown && smokecleared)
            {
                // spawner.active = true;
                // title.SetActive(false);
                resetGame();
                
            }
        }
        else
        {
            if (!player)
            {
                OnplayerKilled();
            }
        }
       
        foreach(GameObject bomb in nextbomb)
        {
            if (bomb.transform.position.y < (-screenbounds.y -12))
            {
                if (gamestarted)
                {
                    score += pointsworth;
                    scoretext.text = "Score: " + score.ToString();

                }
                Destroy(bomb);
            }
        }
    }
    void resetGame()
    {
        scoretext.enabled = true;
         
      
        score = 0;
        scoretext.text = "Score: " + score.ToString();
        
       
        
        spawner.active = true;
        title.SetActive(false);
        player = Instantiate(playerprefab, new Vector3(0, 0, 0), playerprefab.transform.rotation);
        
        gamestarted = true;
        splash.SetActive(false);
    }
    void OnplayerKilled()
    {
        spawner.active = false;
        gamestarted = false;
        
        
        Invoke("splashscreen", 2);
        bscoremanage.isbeaths(bestscore,score,normalcolor,bestscorecolor);
        
    }
    void splashscreen()
    {
        smokecleared = true;
        splash.SetActive(true);
    }
}