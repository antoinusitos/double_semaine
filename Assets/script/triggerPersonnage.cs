﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class triggerPersonnage : MonoBehaviour {

    private personnage perso;
    public GameObject scroll;

    public GameObject soignerBouton;

    void Start()
    {
        perso = transform.parent.GetComponent<personnage>();
        soignerBouton.GetComponent<Button>().interactable = false;
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!perso.GetEndormi())
            {
                if (Camera.main.GetComponent<gamecamera>().GetEquipe() && !perso.GetRepu())
                {
                    perso.FaireManger();
                    Camera.main.GetComponent<gamecamera>().Desequiper();
                }
                else
                {
                    scroll.SetActive(true);
                    if (player.medoc > 0)
                    {
                        soignerBouton.GetComponent<Button>().interactable = true;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            scroll.SetActive(false);
            soignerBouton.GetComponent<Button>().interactable = false;
        }
    }
}
