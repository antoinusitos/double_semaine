﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class jours : MonoBehaviour {

    private int jour;

    public GameObject texte;

    private int longeurJour;
    private int tempsActuel;

	void Start () {
        tempsActuel = 0;
        longeurJour = 3600;
        jour = 1;
        texte.GetComponent<Text>().text = jour.ToString();
	}
	
    public void Reset()
    {
        tempsActuel = 0;
        longeurJour = 3600;
        jour = 1;
        texte.GetComponent<Text>().text = jour.ToString();
    }

	void Update () {
        tempsActuel++;
        if(tempsActuel == longeurJour)
        {
            jour++;
            texte.GetComponent<Text>().text = jour.ToString();
            tempsActuel = 0;
            player.GrainesDeco++;
            player.GrainesMedoc++;
            player.GrainesMusic++;

        }
	}
}
