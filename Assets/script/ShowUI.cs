using UnityEngine;
using System.Collections;

public class ShowUI : MonoBehaviour {

    public GameObject ui;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            ui.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            ui.SetActive(false);
        }
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
