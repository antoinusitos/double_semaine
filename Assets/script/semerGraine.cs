using UnityEngine;
using System.Collections;

public class semerGraine : MonoBehaviour {

    public GameObject jardin;
    public bool Medoc;
    public bool Deco;
    public bool Music;

    void Start()
    {
        Medoc = false;
        Deco = false;
        Music = false;

        if (name == "jardinButton1")
            Medoc = true;
        else if (name == "jardinButton2")
            Deco = true;
        else if (name == "jardinButton3")
            Music = true;
    }

    public void OnClick()
    {
        if(Medoc)
        {
            jardin.GetComponent<jardin>().Planter(0);
        }
        else if (Deco)
        {
            jardin.GetComponent<jardin>().Planter(1);
        }
        else if (Music)
        {
            jardin.GetComponent<jardin>().Planter(2);
        }
    }
}
