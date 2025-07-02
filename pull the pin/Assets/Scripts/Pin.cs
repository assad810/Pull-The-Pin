using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public string Name;
    float speed = 40f;
    public bool MovePin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MovePin)
            MoveThePin();
    }

    public void MoveThePin()
    {
        if(transform.position.x <= 30f){
        transform.Translate(transform.right * Time.deltaTime * speed , Space.World);
        }
        else
            MovePin = false;
    }
}
