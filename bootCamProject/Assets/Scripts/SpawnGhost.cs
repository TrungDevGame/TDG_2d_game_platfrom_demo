using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    public GameObject prefabsGhost;
    public float duration=2;
    public Transform parrentGhosts;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if(duration<=0)
        {

            Instantiate(prefabsGhost,transform.GetChild(Random.Range(0,transform.childCount)).position,Quaternion.identity, parrentGhosts);
            duration = Random.Range(1f,3f) ;
        }
    }
}
