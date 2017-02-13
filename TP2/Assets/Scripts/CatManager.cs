using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour {

    public Cat cat;

    public Vector3 target;

	// Use this for initialization
	void Start () {

        string[] names = Resources.Load<TextAsset>("Names").ToString().Split('\n');

        switch (Random.Range(0, 7))
        {
            case 0:
                cat = new Cat(new Statut(names[Random.Range(0, names.Length)]));
                break;

            case 1:
                cat = new BatCat(new Statut(names[Random.Range(0, names.Length)]));
                break;

            case 2:
                cat = new ZenCat(new Statut(names[Random.Range(0, names.Length)]));
                break;

            case 3:
                cat = new StressedCat(new Statut(names[Random.Range(0, names.Length)]));
                break;

            case 4:
                cat = new WarCat(new Statut(names[Random.Range(0, names.Length)]));
                break;

            case 5:
                cat = new AlmostACat(new Statut(names[Random.Range(0, names.Length)]));
                break;

            case 6:
                cat = new HackerCat(new Statut(names[Random.Range(0, names.Length)]));
                break;

        }
        

        cat.StartCat();

        RandomizeTarget();
	}
	
	// Update is called once per frame
	void Update () {
        cat.UpdateCat();

        transform.position = Vector3.MoveTowards(transform.position, target, cat.moveSpeed * Time.deltaTime);
        if (transform.position == target)
            RandomizeTarget();
	}

    private void RandomizeTarget()
    {
        target = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            cat.CollideACat(other.GetComponent<CatManager>().cat);
        }
    }
}
