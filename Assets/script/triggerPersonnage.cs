using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class triggerPersonnage : MonoBehaviour {

    private personnage perso;
    public GameObject scroll;

    public GameObject soignerBouton;

    void Start()
    {
        perso = transform.parent.GetComponent<personnage>();
        soignerBouton.GetComponent<Button>().interactable = false;
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!perso.GetEndormi())
            {
                other.transform.rotation = Quaternion.Euler(transform.parent.transform.position);
                if (Camera.main.GetComponent<gamecamera>().GetEquipe() && !perso.GetRepu())
                {
                    perso.FaireManger();
                    other.transform.GetComponent<Animator>().SetBool("equipe", false);
                    other.transform.GetComponent<Animator>().SetTrigger("end_anim");
                    Camera.main.GetComponent<gamecamera>().Desequiper();
                    perso.StartCoroutine("afficherUI");
                }
                else
                {
                    scroll.SetActive(true);
                    if (player.medoc > 0)
                    {
                        soignerBouton.GetComponent<Button>().interactable = true;
                    }
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!perso.GetEndormi())
            {
                other.transform.rotation = Quaternion.Euler(new Vector3(0, 256, 0));
                Debug.Log(transform.parent.transform.name);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            scroll.SetActive(false);
            soignerBouton.GetComponent<Button>().interactable = false;
        }
    }
}
