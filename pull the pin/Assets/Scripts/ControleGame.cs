﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleGame : MonoBehaviour
{
    public GameObject celebrate;
    public GameObject winpanel;
    public GameObject losePanel;
    GameObject[] colorBalls;
    GameObject[] emptyBalls;
    Balls[] InBasket;
    float  CountBalls , counBallsInBasket;
    public GameObject detectBalls;
    DetectBalls detectBallScript;
    public GameObject score;
    public GameObject winimg;
    public GameObject player;
    Player playerScript;

    public bool win , lose;
    // Start is called before the first frame update
    void Start()
    {
        // camera position
        Camera.main.transform.position = new Vector3(-1.19f , 2.5f , -15.5f);
        
        //camera color background 
        Color color = new Color32(173, 216, 255, 255);
        Camera.main.backgroundColor  = color;
        
        // ads
        //Advertisements.Instance.Initialize();
        //Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM);

        // player script
        playerScript = player.GetComponent<Player>();

        //balls
        colorBalls = GameObject.FindGameObjectsWithTag("colorball");
        emptyBalls = GameObject.FindGameObjectsWithTag("emptyball");
        CountBalls = colorBalls.Length + emptyBalls.Length;

        // script detectball
        detectBallScript = detectBalls.GetComponent<DetectBalls>();
    }

    // Update is called once per frame
    void Update()
    {
        if(win || lose)
        return;

        checkTheWinAndLose();

        CountBallsInBasket();

        showScore();

        checkIfAllColoredBallInBasket();
    }

    void checkTheWinAndLose()
    {
        if(detectBallScript.countColorBall  == CountBalls){
            if(GameManager.instant.getSound() == 1)
                SoundManager.instance.Play("celebrate");
            win = true;
            GameManager.instant.setLevel(GameManager.instant.getlevel() +1);
            Instantiate(celebrate);
            Invoke("showWinPanel" , 3f);
            playerScript.RunGame = false;
            score.SetActive(false);
            winimg.SetActive(true);
            print("you wiiin");
            return;
        }
    }
    void CountBallsInBasket()
    {
        counBallsInBasket = 0;
        InBasket = GameObject.FindObjectsOfType<Balls>();
        foreach (Balls item in InBasket)
        {
            if(item.GetComponent<Balls>().InBasket)
                counBallsInBasket++;
        }
    }

    void showScore()
    {
        float scr = (counBallsInBasket / CountBalls ) *100;
        score.GetComponent<TextMesh>().text = (int)scr +"%";
    }

    void checkIfAllColoredBallInBasket()
    {
        colorBalls = GameObject.FindGameObjectsWithTag("colorball");

        if(colorBalls.Length == counBallsInBasket && colorBalls.Length != CountBalls)
        {
            lose = true;
            playerScript.RunGame = false;
            print("you lose");
            Invoke("showLosePanel" , 2f);
            
        }
        
    }

    void  showWinPanel()
    {
        winpanel.SetActive(true);
        if(GameManager.instant.getSound() == 1)
                SoundManager.instance.Play("win");

        //Advertisements
        //Advertisements.Instance.ShowInterstitial();
    }

    void showLosePanel()
    {
        losePanel.SetActive(true);
        
        //Advertisements
        //Advertisements.Instance.ShowInterstitial();
    }

    public void showpanelOutSideScript()
    {
        Invoke("showLosePanel" , 2f);
    }
}
