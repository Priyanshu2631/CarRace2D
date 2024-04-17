using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject[] car;
    int carNo;
    public float delayTimer=1f;
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer=delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer<=0){
            Vector3 carPos=new Vector3(Random.Range(-2.2f,2.2f),transform.position.y,transform.position.z);
            carNo=Random.Range(0,5);
            Instantiate(car[carNo],carPos,transform.rotation);
            timer=delayTimer;
        }
        
    }
}
