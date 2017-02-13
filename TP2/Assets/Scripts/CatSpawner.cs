using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour {

    public GameObject prefabCat;

    public List<CatManager> cats = new List<CatManager>();

    public float playTime = 300;

    private float timer = 0;

	// Use this for initialization
	void Start ()
    {
        

        for (int i = 0; i < 10; i++)
        {
            GameObject go = Instantiate(prefabCat);

            go.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0);

            cats.Add(go.GetComponent<CatManager>());
        }
	}
	
	// Update is called once per frame
	void Update () {

        bool isSomeoneNotOk = false;

        foreach (CatManager catM in cats)
        {
            switch (catM.cat.statut.asking)
            {
                case Statut.ask.castration:
                    if (catM.cat.statut.sex == Statut.sexe.female || catM.cat.statut.sex == Statut.sexe.male)
                        isSomeoneNotOk = true;
                    break;

                case Statut.ask.identify:
                    if (catM.cat.statut.iD == 0)
                        isSomeoneNotOk = true;
                    break;

                case Statut.ask.vaccin:
                    if (!catM.cat.statut.vaccinated)
                        isSomeoneNotOk = true;
                    break;
            }

            if (isSomeoneNotOk)
                break;

        }

        if (!isSomeoneNotOk)
            Debug.Log("You Won !");


        timer += Time.deltaTime;

        if (timer >= playTime)
        {
            Destroy(GameObject.Find("Veto"));
            Debug.Log("You Lost !");
        }

	}
}
