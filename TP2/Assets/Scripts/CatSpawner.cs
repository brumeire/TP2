using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour {

    public GameObject prefabCat;
	// Use this for initialization
	void Start ()
    {
        

        for (int i = 0; i < 10; i++)
        {
            GameObject go = Instantiate(prefabCat);

            go.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
