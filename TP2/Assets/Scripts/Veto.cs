using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veto : MonoBehaviour {


    public float hp = 100;

    public float speed = 1;

    public bool isHoldingCat = false;

    public CatManager catHeld;
    

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

        

        isHoldingCat = IsCatStillHeld();

        Actions();
    }

    private void Actions()
    {
        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h * speed, v * speed, 0);


        if (!isHoldingCat && Input.GetKeyDown(KeyCode.E))
        {
            int layerMask = 1 << 9;
            Collider[] surroundings = Physics.OverlapSphere(transform.position, 1, layerMask);
            if (surroundings.Length > 0)
            {
                isHoldingCat = true;
                catHeld = surroundings[0].GetComponent<CatManager>();
                catHeld.cat.Catch();
            }
        }

        else if (isHoldingCat && Input.GetKeyDown(KeyCode.E))
        {
            isHoldingCat = false;
            catHeld.cat.Catch();
            catHeld = null;
        }
    }

    private bool IsCatStillHeld()
    {
        return catHeld.cat.catched;  
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
