using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyBig;
    public GameObject enemySmall;
    float spawnRate = 1.5f;
    public static bool isGameActive = true;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void Update()
    {

    }
    IEnumerator SpawnEnemy()
    {
        byte check = 0;
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            float x = Random.Range(-PlayerController.xBound, PlayerController.xBound);
            check++;
            if (check == 5)
            {
                Instantiate(enemyBig, new Vector3(x, 9f, -0.9f), enemyBig.transform.rotation);
                check = 0;
            }
            else
                Instantiate(enemySmall, new Vector3(x, 9f, -0.9f), enemySmall.transform.rotation);
        }
    }
}