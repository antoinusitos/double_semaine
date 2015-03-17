using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class soignerBouton : MonoBehaviour {

    public GameObject personnage;

	public void Onclick()
    {
        if(player.medoc > 0)
        {
            personnage.GetComponent<personnage>().Medecine();
            player.medoc--;
            if(player.medoc == 0)
            {
                transform.GetComponent<Button>().interactable = false;
            }
        }
    }
}
