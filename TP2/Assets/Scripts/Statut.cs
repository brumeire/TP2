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

    public Statut(string name, int age, sexe sex)
    {
        this.name = name;
        this.age = age;
        vaccinated = false;
        this.sex = sex;
        iD = 0;

        switch (Random.Range(0, 3))
        {

        }


    }

	public void OnScreenStatut (){

		//affiché le status au dessus du chat
		statut.text = "Name : " +  name + '\n'+"Age : " + age +'\n'+ "Sexe : " +  sex + '\n'+"Identity : " + ID + '\n'+"Ask : " + asking; 

	}

}
