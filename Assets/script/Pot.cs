using UnityEngine;
using System.Collections;

public class Pot : MonoBehaviour {

    private bool plein;
    private bool fini;

    private int type;

    private float tempPousse;
    private float tempFini;
    private float tempIntermediaire;

    private GameObject[] plantes;

    public GameObject DecorPlante;

    void Start()
    {
        plein = false;
        type = -1;
        tempPousse = 0;
        tempFini = 300;
        tempIntermediaire = 150;
    }

    void Update()
    {
        if(plein && !fini)
        {
            tempPousse++;
            if (tempPousse >= tempFini)
            {
                fini = true;
                //mettre anim fini
                Destroy(transform.GetChild(1).gameObject);
                GameObject plante = (GameObject)Instantiate(plantes[1], transform.GetChild(1).position, Quaternion.identity);
                plante.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                plante.transform.parent = transform;
            }
            else if (tempPousse >= tempIntermediaire)
            {
                Destroy(transform.GetChild(1).gameObject);

                GameObject plante = (GameObject)Instantiate(plantes[0], transform.GetChild(0).position, Quaternion.identity);
                plante.transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));
                plante.transform.parent = transform;
            }
        }
    }

    public void Remplir(int theType, GameObject[] go)
    {
        //mettre anim petit
        plantes = go;
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
            Destroy(transform.GetChild(1).gameObject);
        }
        else if (type == 1)
        {
            //rajouter un objet dans le décor
            Destroy(transform.GetChild(1).gameObject);
            int number = 0;
            Transform deco = DecorPlante.transform.GetChild(number);
            while(deco.gameObject.activeSelf == true && number < 5)
            {
                number++;
                deco = DecorPlante.transform.GetChild(number);
            }
            deco.gameObject.SetActive(true);
        }
        else if (type == 2)
        {
            Camera.main.GetComponent<gamecamera>().AddSound();
            Destroy(transform.GetChild(1).gameObject);
        }
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
