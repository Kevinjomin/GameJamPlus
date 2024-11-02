using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakoutcheckbrick : MonoBehaviour
{
    void FixedUpdate()
    {
        if(transform.childCount <= 0){
            Debug.Log("Win");
            MinigameManager.Instance.TriggerGameWin();
            gameObject.SetActive(false);
        }
    }
}
