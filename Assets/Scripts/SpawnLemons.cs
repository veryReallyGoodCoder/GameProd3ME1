using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLemons : MonoBehaviour
{
    [Header("Reference")]
    public GameObject LemonPrefab;

    public Vector3 minPos, maxPos;

    [Header("Object Pool")]
    private int poolSize = 20;

    private List<GameObject> lemonPool = new List<GameObject>();

    [Header("Timer")]
    public float setTimer = 2;
    private float timer;

    public float waitTime = 10f;

    private void Start()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(LemonPrefab);
            obj.SetActive(false);
            lemonPool.Add(obj);
        }

        timer = setTimer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            LemonSpawn();
            timer = setTimer;
        }
    }

    public GameObject GetLemons()
    {
        for(int i = 0; i < lemonPool.Count; i++)
        {
            if (!lemonPool[i].activeInHierarchy)
            {
                lemonPool[i].SetActive(true);
                return lemonPool[i];
            }
        }
        return null;
    }

    public void LemonSpawn()
    {
        GameObject lemon = GetLemons();

        if(lemon != null)
        {
            Vector3 randomPos = new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, minPos.y), Random.Range(minPos.z, maxPos.z));

            lemon.transform.position = randomPos;
        }

        StartCoroutine(ReturnLemonToPool(lemon));
    }

    IEnumerator ReturnLemonToPool(GameObject lemon)
    {
        yield return new WaitForSeconds(waitTime);

        if(lemon != null)
        {
            lemon.SetActive(false);
        }
    }


}
