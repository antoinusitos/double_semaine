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
                PotVide++;
                pots[i].GetComponent<Pot>().Vider();
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
                pots[i].GetComponent<Pot>().Remplir(id);
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
