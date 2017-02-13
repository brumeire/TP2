using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veto : MonoBehaviour {


    public float hp = 100;

    public float speed = 1;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (hp <= 0)
        {
            Debug.Log("Game Lost");
            Destroy(gameObject);
        }
	}

    private void Move()
    {

    }

    public void CatchCat()
    {

    }

    public void VaccinateCat()
    {

    }

    public void KillCat()
    {

    }

    public void CastrateCat()
    {

    }

    public void RegisterCat()
    {

    }

}
