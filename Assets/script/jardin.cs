using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class jardin : MonoBehaviour {

    private int PotMax;
    private int PotVide;

    private int GrainesMedoc;
    private int GrainesDeco;
    private int GrainesMusic;

    public GameObject[] pots;

    public GameObject indiceMedoc;
    public GameObject indiceDeco;
    public GameObject indiceMusic;

    public GameObject plante0;

    public GameObject[] plantesMedoc1;
    public GameObject[] plantesMedoc2;
    public GameObject[] plantesMedoc3;
    public GameObject[] plantesDeco1;
    public GameObject[] plantesDeco2;
    public GameObject[] plantesDeco3;
    public GameObject[] plantesMusic1;
    public GameObject[] plantesMusic2;
    public GameObject[] plantesMusic3;

    public GameObject garden;

    public GameObject effet0;
    public GameObject effet1;
    public GameObject effet2;

    public AudioClip planterSound;
    public AudioClip collectersound;


	void Start () 
    {
        PotMax = 3;
        PotVide = 3;

        GrainesMedoc = player.GrainesMedoc;
        GrainesDeco = player.GrainesDeco;
        GrainesMusic = player.GrainesMusic;
	}

    void Update()
    {
        indiceMedoc.GetComponent<Text>().text = GrainesMedoc.ToString();
        indiceDeco.GetComponent<Text>().text = GrainesDeco.ToString();
        indiceMusic.GetComponent<Text>().text = GrainesMusic.ToString();
    }

    void CheckPotVide()
    {
        if(PotVide == 0)
        {
            transform.GetChild(0).GetComponent<ShowUIJardin>().Hide();
        }
    }

    public void ViderPot()
    {
        for (int i = 0; i < pots.Length; i++)
        {
            bool fini = pots[i].GetComponent<Pot>().GetFini();
            if (fini == true)
            {
                if (i == 0)
                    effet0.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                else if (i == 1)
                    effet1.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                else if (i == 2)
                    effet2.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                PotVide++;
                pots[i].GetComponent<Pot>().Vider();
                GetComponent<AudioSource>().PlayOneShot(collectersound);
            }
        }
    }

    public int GetPotVide()
    {
        return PotVide;
    }

    void CheckGraines()
    {
        GrainesMedoc = player.GrainesMedoc;
        GrainesDeco = player.GrainesDeco;
        GrainesMusic = player.GrainesMusic;
        if(GrainesMedoc == 0)
        {
            transform.GetChild(0).GetComponent<ShowUIJardin>().disable(0);
        }
        if (GrainesDeco == 0)
        {
            transform.GetChild(0).GetComponent<ShowUIJardin>().disable(1);
        }
        if (GrainesMusic == 0)
        {
            transform.GetChild(0).GetComponent<ShowUIJardin>().disable(2);
        }
    }

    public void RemplirPot(int id)
    {
        for(int i=0; i < pots.Length; i++)
        {
            bool plein = pots[i].GetComponent<Pot>().GetPlein();
            if(plein == false)
            {
                int random = (int)Random.Range(1, 4);

                GameObject plante = (GameObject)Instantiate(plante0, pots[i].transform.GetChild(0).transform.position, Quaternion.identity);
                plante.transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));
                plante.transform.parent = pots[i].transform;
                if(id == 0)
                {
                    if(random == 1)
                    {
                        pots[i].GetComponent<Pot>().Remplir(id, plantesMedoc1);
                    }
                    else if (random == 2)
                    {
                        pots[i].GetComponent<Pot>().Remplir(id, plantesMedoc2);
                    }
                    else if (random == 3)
                    {
                        pots[i].GetComponent<Pot>().Remplir(id, plantesMedoc3);
                    }
                }
                else if (id == 1)
                {
                    if (random == 1)
                    {
                        pots[i].GetComponent<Pot>().Remplir(id, plantesDeco1);
                    }
                    else if (random == 2)
                    {
                        pots[i].GetComponent<Pot>().Remplir(id, plantesDeco2);
                    }
                    else if (random == 3)
                    {
                        pots[i].GetComponent<Pot>().Remplir(id, plantesDeco3);
                    }
                }
                else if (id == 2)
                {
                    if (random == 1)
                    {
                        pots[i].GetComponent<Pot>().Remplir(id, plantesMusic1);
                    }
                    else if (random == 2)
                    {
                        pots[i].GetComponent<Pot>().Remplir(id, plantesMusic2);
                    }
                    else if (random == 3)
                    {
                        pots[i].GetComponent<Pot>().Remplir(id, plantesMusic3);
                    }
                }
                    
                return;
            }
        }
    }

    public void Planter(int idGraine)
    {
        if(idGraine == 0)
        {
            if(GrainesMedoc > 0 && PotVide > 0)
            {
                GetComponent<AudioSource>().PlayOneShot(planterSound);
                garden.GetComponent<Animator>().SetTrigger("move");
                GrainesMedoc--;
                player.GrainesMedoc--;
                PotVide--;
                RemplirPot(0);
                CheckPotVide();
                CheckGraines();
            }
        }
        else if (idGraine == 1)
        {
            if (GrainesDeco > 0 && PotVide > 0)
            {
                GetComponent<AudioSource>().PlayOneShot(planterSound);
                garden.GetComponent<Animator>().SetTrigger("move");
                GrainesDeco--;
                player.GrainesDeco--;
                PotVide--;
                RemplirPot(1);
                CheckPotVide();
                CheckGraines();
            }
        }
        else if (idGraine == 2)
        {
            if (GrainesMusic > 0 && PotVide > 0)
            {
                GetComponent<AudioSource>().PlayOneShot(planterSound);
                garden.GetComponent<Animator>().SetTrigger("move");
                PotVide--;
                player.GrainesMusic--;
                GrainesMusic--;
                RemplirPot(2);
                CheckPotVide();
                CheckGraines();
            }
        }
    }
}
