using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakoutbloocspawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0, 2) == 0 && MinigameManager.Instance.section > 1){
            spawnblood();
        }
    }
    public GameObject bloodobject;
    public void spawnblood(){
        for(int i = 0; i < Random.Range(4, 5); i++){
            Transform a = Instantiate(bloodobject, transform).transform;
            a.position += new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            a.localScale = new Vector3(Random.Range(4, 5), Random.Range(4, 5), 0);
        }
    }
}
