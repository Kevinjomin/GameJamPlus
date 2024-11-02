using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class goalwaterbasket : MonoBehaviour
{
    public TMP_Text scoretxt;
    int score = 0;
    bool won = false;

    public TMP_Text timertxt;

    void Start(){
        StartCoroutine(timer());
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "waterbasketball"){
            score++;
            scoretxt.text = "Score: " + score.ToString() + " / 30";
            if(score > 30 && !won){
                won = true;
                MinigameManager.Instance.TriggerGameWin();
            }
        }
    }

    IEnumerator timer(){
        int t = 60;
        while(t > 0){
            timertxt.text = "Timer: " + t.ToString() + " sec";
            t--;
            yield return new WaitForSeconds(1);
        }
        MinigameManager.Instance.TriggerGameLose();
    }
}
