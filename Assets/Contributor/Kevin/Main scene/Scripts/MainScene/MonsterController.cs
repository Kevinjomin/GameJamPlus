using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] List<GameObject> monsterParts = new List<GameObject>();

    private void OnEnable()
    {
        StartCoroutine(PickRandomPart());
    }

    private IEnumerator PickRandomPart()
    {
        while (true)
        {
            int random = Random.Range(0, monsterParts.Count);
            PickPart(random);

            yield return new WaitForSeconds(10f);
        }
    }

    private void PickPart(int random)
    {
        for(int i = 0; i < monsterParts.Count; i++)
        {
            if (i == random)
            {
                monsterParts[i].gameObject.SetActive(true);
            }
            else
            {
                monsterParts[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
