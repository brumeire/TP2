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

        Move();
	}

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h * speed, v * speed, 0);
    }

    public void CatchCat()
    {

    }

    public void VaccinateCat()
    {

    }

    public void AnesthesiaCat()
    {

    }

    public void CastrateCat()
    {

    }

    public void RegisterCat()
    {

    }

}
