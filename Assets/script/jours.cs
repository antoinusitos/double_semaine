using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class jours : MonoBehaviour
{

    private int jour;

    public GameObject texte;
    public GameObject garden;

    public GameObject personnage;

    private int longeurJour;
    private float tempsActuel;

    void Start()
    {
        tempsActuel = 0;
        longeurJour = 60;
        jour = 1;
        texte.GetComponent<Text>().text = jour.ToString();
    }

    public void Reset()
    {
        tempsActuel = 0;
        longeurJour = 60;
        jour = 1;
        texte.GetComponent<Text>().text = jour.ToString();
    }

    void Update()
    {
        tempsActuel += Time.deltaTime;
        if (tempsActuel >= longeurJour)
        {
            jour++;
            texte.GetComponent<Text>().text = jour.ToString();
            tempsActuel -= longeurJour;
            if (personnage.GetComponent<personnage>().GetEpanouissement() > 60)
            {
                player.GrainesMedoc++;
                int Rand;
                for (int i = 0; i < 2; i++)
                {
                    Rand = (int)Random.Range(0, 2);
                    if (Rand == 0)
                    {
                        player.GrainesDeco++;
                    }
                    else
                    {
                        player.GrainesMusic++;
                    }
                }
            }
            else if (personnage.GetComponent<personnage>().GetEpanouissement() > 30)
            {
                player.GrainesMedoc++;
                int Rand = (int)Random.Range(0, 2);
                if (Rand == 0)
                {
                    player.GrainesDeco++;
                }
                else
                {
                    player.GrainesMusic++;
                }
            }
            else
            {
                player.GrainesMedoc++;
            }
            garden.GetComponent<jardin>().CheckGraines();
        }
    }
}
