using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    int s=0;
    bool gameOver;
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
       s=0; 
       InvokeRepeating("scoreUpdate",1.0f,0.5f);
       gameOver=false;
    }

    // Update is called once per frame
    void Update()
    {
        score.text="Score: "+s;
        
    }
    public void Pause(){
        if(Time.timeScale==1){
            Time.timeScale=0;
        }
        else{
            Time.timeScale=1;
        }
    }
    void scoreUpdate(){
        if(!gameOver){
            s++;
        }
    }
    public void Over(){
        gameOver=true;
        foreach(Button button in buttons){
            button.gameObject.SetActive(true);
        }
    }
    public void Replay(){
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Exit(){
        Application.Quit();
    }
}
