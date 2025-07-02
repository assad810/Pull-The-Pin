using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBalls : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject particle;
    public int countColorBall;
    public GameObject controle;
    public GameObject player;
    Player playerScript;
    ControleGame controleGameScript;
    // Start is called before the first frame update
    void Start()
    {
        controleGameScript = controle.GetComponent<ControleGame>();
        playerScript = player.GetComponent<Player>();
    }

    private void OnTriggerExit(Collider other) {

        if(other.gameObject.tag == "colorball")
        {
            if(GameManager.instant.getSound() == 1)
                SoundManager.instance.Play("detect");
            other.GetComponent<Balls>().InBasket = true;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.GetComponent<SphereCollider>().material = null;
            countColorBall++;
            print(countColorBall);
        }
        if(other.gameObject.tag == "emptyball")
        {
            if(GameManager.instant.getSound() == 1)
                SoundManager.instance.Play("detect");

            Instantiate(particle , other.transform.position , particle.transform.rotation);
            Destroy(other.gameObject);
            controleGameScript.lose = true;
            playerScript.RunGame = false;
            Invoke("showLosePanel" , 2f);
        }
        
    }

    void showLosePanel()
    {
        losePanel.SetActive(true);
    }
}
