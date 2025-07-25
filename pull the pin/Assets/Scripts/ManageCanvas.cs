﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ManageCanvas : MonoBehaviour
{
    public Text LevelNumber;
    public GameObject guide;
    public GameObject SoundMuteImg;
    public GameObject[] loseImages;
    public GameObject[] WinImages;

    public Text WinComment;
    public Text LoseComment;

    // Start is called before the first frame update
    void Start()
    {
        LevelNumber.text = "Level "+SceneManager.GetActiveScene().buildIndex;
        //sound
        manageSound();

        // comments
        manageComments();

        // images 
        manageImageWinAndLose();
    }

private void Update() {
    if(guide != null)
    {
        if(Input.GetMouseButtonDown(0))
        guide.SetActive(false);
    }
    
}
    public void soundBtn()
    {
        if(GameManager.instant.getSound() == 1)
        {
            SoundMuteImg.SetActive(true);
            GameManager.instant.setSound(0);
        }
        else
        {
            SoundMuteImg.SetActive(false);
            GameManager.instant.setSound(1);
        }
    }

    public void RepeatBtn()
    {
        // ads
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevelBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void manageSound()
    {
        if(GameManager.instant.getSound() == 1)
        {
            SoundMuteImg.SetActive(false);
        }
        else
        {
            SoundMuteImg.SetActive(true);
        }
    }

    void manageComments()
    {
        List<string> wincommentList = new List<string>() {"Amazing !" , "Brilliant !" , "Impressive !" , "Fantastic !" , "Epic !"};
        List<string> LosecommentList = new List<string>() {"So close !" , "Almost !" , "Pretty close !"};

        WinComment.text = wincommentList[Random.Range(0,wincommentList.Count)];
        LoseComment.text = LosecommentList[Random.Range(0,LosecommentList.Count)];
    }
    void manageImageWinAndLose()
    {
        int rnd = Random.Range(0 , WinImages.Length);

        for (int i = 0; i < WinImages.Length; i++)
        {
            WinImages[i].SetActive(false);
            loseImages[i].SetActive(false);
        }
        WinImages[rnd].SetActive(true);
        loseImages[rnd].SetActive(true);
    }
}
