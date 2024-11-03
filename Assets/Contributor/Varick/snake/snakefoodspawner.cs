using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class snakefoodspawner : MonoBehaviour
{
    public GameObject food;
    void FixedUpdate()
    {
        if(transform.childCount <= 0){
            Transform a = Instantiate(food, transform).transform;
            a.position += new Vector3(Random.Range(-6, 6) * 0.5f, Random.Range(-6, 6) * 0.5f, 0);
            a.gameObject.GetComponent<SpriteRenderer>().sprite = humansprite;
        }
    }

    public TMP_Text timertxt;

    public Sprite humansprite;

    void Start(){
        StartCoroutine(timer());
    }

    IEnumerator timer(){
        yield return new WaitForSeconds(3);
        int t = 120;
        while(t > 0){
            timertxt.text = "Timer: " + t.ToString() + " sec";
            t--;
            yield return new WaitForSeconds(1);
        }
        MinigameManager.Instance.TriggerGameLose();
    }
}
