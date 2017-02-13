using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Veto : MonoBehaviour {

    public static Veto instance;

    public float hp = 100;

    public float speed = 1;

    public bool isHoldingCat = false;

    public CatManager catHeld;

    public Text heldText;
    

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);

	}
	
	// Update is called once per frame
	void Update () {
		
        if (hp <= 0)
        {
            Debug.Log("Game Lost");
            Destroy(gameObject);
        }


        if (isHoldingCat)
        {
            isHoldingCat = IsCatStillHeld();
        }


        Actions();
        UpdateHeldText();
    }
    private void UpdateHeldText()
    {
        if (isHoldingCat)
        {
            heldText.text = catHeld.cat.statut.OnScreenStatut();
        }
        else
        {
            heldText.text = "";
        }
    }
    private void Actions()
    {
        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h * speed, v * speed, 0);

        if (isHoldingCat)
        {
            catHeld.transform.position += new Vector3(h * speed, v * speed, 0);
        }

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

    public void CatchCat()
    {
        if (!isHoldingCat)
        {
            int layerMask = 1 << 9;
            Collider[] surroundings = Physics.OverlapSphere(transform.position, 1, layerMask);
            if (surroundings.Length > 0)
            {
                CatchCat(surroundings[0]);
            }
        }
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
        if (isHoldingCat)
        {
            catHeld.cat.statut.iD = Random.Range(1, 99999);
        }
    }

}
