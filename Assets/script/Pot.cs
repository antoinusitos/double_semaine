using UnityEngine;
using System.Collections;

public class Pot : MonoBehaviour {

    private bool plein;
    private bool fini;

    private int type;

    private float tempPousse;
    private float tempFini;



    void Start()
    {
        plein = false;
        type = -1;
        tempPousse = 0;
        tempFini = 300;
    }

    void Update()
    {
        if(plein && !fini)
        {
            tempPousse++;
            if (tempPousse > tempFini)
            {
                fini = true;
                //mettre anim fini
                transform.GetComponent<MeshRenderer>().material.color = Color.black;
            }
        }
    }

    public void Remplir(int theType)
    {
        //mettre anim petit
        type = theType;
        plein = true;
        if(theType == 0)
            transform.GetComponent<MeshRenderer>().material.color = Color.red;
        else if (theType == 1)
            transform.GetComponent<MeshRenderer>().material.color = Color.cyan;
        else if (theType == 2)
            transform.GetComponent<MeshRenderer>().material.color = Color.green;

    }

    public void Vider()
    {
        if (type == 0)
        {
            player.medoc++;
        }
        else if (type == 1)
            //rajouter un objet dans le décor
            transform.GetComponent<MeshRenderer>().material.color = Color.white;
        else if (type == 2)
            //changer le son
            transform.GetComponent<MeshRenderer>().material.color = Color.white;
        Reset();
    }

    public void Reset()
    {
        type = -1;
        plein = false;
        fini = false;
        tempPousse = 0;
        transform.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public bool GetPlein()
    {
        return plein;
    }

    public bool GetFini()
    {
        return fini;
    }

}
