using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class Statut {

	public string name;
	public int age;
	public enum sexe {male, female, castrated_male, castrated_female};
	public int ID;
	public enum ask {vaccin, castration, identify};

	public Text statut;

	public void OnScreenStatut (){

		//affiché le status au dessus du chat
		statut.text = "Name : " +  name + '\n'+"Age : " + age +'\n'+ "Sexe : " +  sexe + '\n'+"Identity : " + ID + '\n'+"Ask : " + ask; 

	}

}
