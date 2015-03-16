using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowUIJardin : MonoBehaviour {

    public GameObject ui;
    public GameObject ui2;
    public GameObject ui3;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transform.parent.GetComponent<jardin>().ViderPot();
            if (transform.parent.GetComponent<jardin>().GetPotVide() > 0)
            {
                ui.SetActive(true);
                ui2.SetActive(true);
                ui3.SetActive(true);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transform.parent.GetComponent<jardin>().ViderPot();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            ui.SetActive(false);
            ui2.SetActive(false);
            ui3.SetActive(false);
        }
    }

    public void disable(int id)
    {
        if(id == 0)
            ui.GetComponent<Button>().interactable = false;
        else if (id == 1)
            ui2.GetComponent<Button>().interactable = false;
        else if (id == 2)
            ui3.GetComponent<Button>().interactable = false;
    }

    public void enable(int id)
    {
        if (id == 0)
            ui.GetComponent<Button>().interactable = true;
        else if (id == 1)
            ui2.GetComponent<Button>().interactable = true;
        else if (id == 2)
            ui3.GetComponent<Button>().interactable = true;
    }

    public void Hide()
    {
        ui.SetActive(false);
        ui2.SetActive(false);
        ui3.SetActive(false);
    }
}
