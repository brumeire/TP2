﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour {

    public Cat cat;

	// Use this for initialization
	void Start () {

        string[] names = Resources.Load<TextAsset>("Names").ToString().Split('\n');

        switch (Random.Range(0, 7))
        {
            case 0:
                cat = new Cat(new Statut(names[Random.Range(0, names.Length)]));
                break;
        }
        cat = new Cat(new Statut(names[Random.Range(0, names.Length)]));
        cat.StartCat();
	}
	
	// Update is called once per frame
	void Update () {
        cat.UpdateCat();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            cat.CollideACat(other.GetComponent<CatManager>().cat);
        }
    }
}
