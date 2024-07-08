using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class bestscoremanager : MonoBehaviour
{ 
 
    public GameObject splash;

    public TMP_Text scoretext;
    public int pointsworth = 1;
    private int score;

    private int bestscore = 0;
     public TMP_Text bestscoretext;
    private bool beatbestscore;
    //public Color normalcolor;
    //public Color bestscorecolor;

    private bool smokecleared = true;
 
   int loadhs(){
     int bsv =PlayerPrefs.GetInt("highscore");
    return bsv;
   }
   
   
    // Start is called before the first frame update
   
   =void isbeaths(bsv,ssv,hscolor,normalcolor)
   { 

 if (ssv > bsv){
    bsv= ssv;
     PlayerPrefs.SetInt("highscore", bsv);
   bestscoretext.text = "High Score: " + bsv;
   bestscoretext.color = hscolor; 
 }else if (ssv <=  bsv)
 {
  
  bestscoretext.color = normalcolor;
  bestscoretext.text = "High Score: "+ bsv;
 }


    }
    void splashscreen()
    {
        smokecleared = true;
        splash.SetActive(true);
    }
}