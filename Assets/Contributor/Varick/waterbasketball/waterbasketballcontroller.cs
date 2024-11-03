using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waterbasketballcontroller : MonoBehaviour
{
    public bool can = true;

    public List<Rigidbody2D> rblist = new List<Rigidbody2D>();

    public KeyCode action;

    public float power;
    public AudioClip clip;

    void Update()
    {
        if(Input.GetKeyDown(action) && can){
            SoundManager.Instance.PlaySFXFromMonitor(clip);
            StartCoroutine(cooldown());
        }
    }

    IEnumerator cooldown(){
        can = false;
        foreach(Rigidbody2D rb in rblist){
            rb.AddForce(transform.up * power * Random.Range(0.6f, 1f), ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.5f);
        can = true;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "waterbasketball"){
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb != null){
                rblist.Add(rb);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "waterbasketball"){
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb != null){
                rblist.Remove(rb);
            }
        }
    }

}
