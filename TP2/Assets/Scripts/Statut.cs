using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Statut {

	public string name;
	public int age;
	public enum sexe {male, female, castrated_male, castrated_female};
	public int iD = 0;
	public enum ask {vaccin, castration, identify};
    public bool vaccinated = false;

	public Text statut;
	public sexe sex;
	public ask asking;

    public Statut(string name)
    {
        this.name = name;
        age = Random.Range(1, 8);
        vaccinated = false;
        iD = 0;

        switch (Random.Range(0, 2))
        {
            case 0:
                sex = sexe.male;
                break;

            case 1:
                sex = sexe.female;
                break;
        }


        switch (Random.Range(0, 3))
        {
            case 0:
                asking = ask.castration;
                break;

            case 1:
                asking = ask.identify;
                break;

            case 2:
                asking = ask.vaccin;
                break;
        }


    }

	public void OnScreenStatut (){

		//affiché le status au dessus du chat
		statut.text = "Name : " +  name + '\n'+"Age : " + age +'\n'+ "Sexe : " +  sex + '\n'+"Identity : " + iD + '\n'+"Ask : " + asking; 

	}

}
