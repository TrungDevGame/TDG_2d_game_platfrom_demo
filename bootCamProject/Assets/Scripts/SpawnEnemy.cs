using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefabs;
    public float timeSpawn = 2;
    public Transform rootEnemies;

    public Player player;

    void Update()
    {
        if (player.isDie == true)
        {
            return;
        }
        timeSpawn -= Time.deltaTime;
        if (timeSpawn < 0)
        {
            //spawn 1 enemy
            Spawn();

        }
    }
    void Spawn()
    {
        Vector3 pos = transform.GetChild(Random.Range(0, transform.childCount)).position;
        pos.z = 0;
        Instantiate(prefabs, pos, Quaternion.identity, rootEnemies);
        timeSpawn = Random.Range(1, 3);


    }
}
