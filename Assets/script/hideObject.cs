using UnityEngine;
using System.Collections;

public class hideObject : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "jardin")
        {
            //other.transform.GetComponent<transparancy>().transp();
            other.transform.GetComponent<MeshRenderer>().enabled = false;
            other.transform.gameObject.layer = 2;
            for (int i = 0; i < other.transform.childCount; i++)
            {
                if (other.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                    other.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else if (other.transform.tag == "kitchen")
        {
            other.transform.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (other.transform.tag == "interaction")
        {
            other.transform.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (other.transform.tag == "personnage")
        {
            other.transform.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (other.transform.tag == "poubelle")
        {
            other.transform.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "jardin")
        {
            other.transform.GetComponent<MeshRenderer>().enabled = true;
            other.transform.gameObject.layer = 0;
            for (int i = 0; i < other.transform.childCount; i++)
            {
                if (other.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                    other.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else if (other.transform.tag == "kitchen")
        {
            other.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (other.transform.tag == "interaction")
        {
            other.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (other.transform.tag == "personnage")
        {
            other.transform.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (other.transform.tag == "poubelle")
        {
            other.transform.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
