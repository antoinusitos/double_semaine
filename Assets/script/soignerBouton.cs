using UnityEngine;
using System.Collections;

public class soignerBouton : MonoBehaviour {

    public GameObject personnage;

	public void Onclick()
    {
        if(player.medoc > 0)
        {
            personnage.GetComponent<personnage>().Medecine();
        }
    }
}
