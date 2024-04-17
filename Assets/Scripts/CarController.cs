using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carSpeed;
    Vector3 position;
    public UIManager UI;

    bool currentPlatformAndroid=false;
    Rigidbody2D rb;

    void Awake(){
        rb=GetComponent<Rigidbody2D>();
        #if UNITY_ANDROID
                currentPlatformAndroid=true;
        #else
                currentPlatformAndroid=false;
        #endif

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        position=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlatformAndroid==true){
            TouchMove();
        }
        else{
            position.x+=Input.GetAxis("Horizontal")*carSpeed*Time.deltaTime;
            position.x=Mathf.Clamp(position.x,-2.2f,2.2f);
            transform.position=position;
        }
        position=transform.position;
        position.x=Mathf.Clamp(position.x,-2.2f,2.2f);
        transform.position=position;
        
    }

    void OnCollisionEnter2D(Collision2D obj){
        if(obj.gameObject.tag=="Enemy"){
            gameObject.SetActive(false);
            UI.Over();
        }
    }
    void TouchMove(){
        if(Input.touchCount>0){
            Touch touch=Input.GetTouch(0);
            float middle=Screen.width/2;
            if(touch.position.x<middle && touch.phase==TouchPhase.Began){
                MoveLeft();
            }
            else if(touch.position.x>middle && touch.phase==TouchPhase.Began){
                MoveRight();
            }
        }
        else{
            SetVelocityZero();
        }
    }
    public void MoveLeft(){
        rb.velocity= new Vector2(-carSpeed*Time.deltaTime,0);
    }

    public void MoveRight(){
        rb.velocity= new Vector2(carSpeed*Time.deltaTime,0);
    }

    public void SetVelocityZero(){
        rb.velocity=Vector2.zero;
    }
}
