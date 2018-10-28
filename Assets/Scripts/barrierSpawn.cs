using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierSpawn : MonoBehaviour {

    public GameObject barrier;
    public Transform barrierSpawnTransform;
    public float spawnTime;

    float tmpSpawnTime;

	// Use this for initialization
	void Start () {
        tmpSpawnTime = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {

        spawnTime -= Time.deltaTime;

        if(spawnTime <= 0)
        {
           var obj = (GameObject)Instantiate(barrier, barrierSpawnTransform.position, Quaternion.identity);
 
            spawnTime = tmpSpawnTime;
        }


	}
}
