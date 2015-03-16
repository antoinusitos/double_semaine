using UnityEngine;
using System.Collections;

public class poubelle : MonoBehaviour {

    public GameObject UI;

	void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if (Camera.main.GetComponent<gamecamera>().GetEquipe())
            {
                UI.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            UI.SetActive(false);
        }
    }
}
