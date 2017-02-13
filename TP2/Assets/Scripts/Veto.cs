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
                CatchCat(surroundings[0]);
            }
        }

        else if (isHoldingCat && Input.GetKeyDown(KeyCode.E))
        {
            ReleaseCat();
        }
    }

    private bool IsCatStillHeld()
    {
        if (!catHeld.cat.catched)
        {
            catHeld = null;
            return false;
        }

        else
        {
            return true;
        }

    }

    public void CatchCat(Collider col)
    {
        isHoldingCat = true;
        catHeld = col.GetComponent<CatManager>();
        catHeld.cat.Catch();
    }

    public void ReleaseCat()
    {
        isHoldingCat = false;
        catHeld.cat.Catch();
        catHeld = null;
    }

    public void VaccinateCat()
    {
        if (isHoldingCat)
        {
            catHeld.cat.statut.vaccinated = true;
        }
    }

    public void AnesthesiateCat()
    {
        if (isHoldingCat)
        {
            catHeld.cat.Anesthetize();
        }
    }

    public void CastrateCat()
    {
        if (isHoldingCat)
        {
            if (catHeld.cat.statut.sex == Statut.sexe.male)
                catHeld.cat.statut.sex = Statut.sexe.castrated_male;

            else if (catHeld.cat.statut.sex == Statut.sexe.female)
                catHeld.cat.statut.sex = Statut.sexe.castrated_female;
        }
    }

    public void RegisterCat()
    {

    }

}
