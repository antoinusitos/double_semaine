using UnityEngine;
using System.Collections;

public class interactionboutonpersonnage : MonoBehaviour {

    public bool jouer;
    public bool parler;
    public bool rechauffer;
    public bool calin;
    public bool nettoyer;

    public GameObject personnage;
    public GameObject player;

    public void OnClick()
    {
        if(jouer)
        {
            personnage.GetComponent<personnage>().Jouer();
            player.GetComponent<player>().Jouer();
        }
        else if (parler)
        {
            personnage.GetComponent<personnage>().Parler();
            player.GetComponent<player>().Parler();
        }
        else if (rechauffer)
        {
            personnage.GetComponent<personnage>().Rechauffer();
            player.GetComponent<player>().Rechauffer();
        }
        else if (calin)
        {
            personnage.GetComponent<personnage>().Calin();
            player.GetComponent<player>().Calin();
        }
        else if (nettoyer)
        {
            personnage.GetComponent<personnage>().Nettoyer();
            player.GetComponent<player>().Nettoyer();
        }

        transform.parent.transform.parent.gameObject.SetActive(false);
    }

}
