using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class personnage : MonoBehaviour {

    //PARTICULES

    public GameObject particule_mort;
    public GameObject particule_puant;
    public GameObject particule_propre;
    public GameObject particule_dodo;

    //FIN PARTICULES


    //ANIMS

    public AnimationClip clean;
    public AnimationClip warm;
    public AnimationClip eat;
    public AnimationClip hug;
    public AnimationClip play;
    public AnimationClip talk;
    public AnimationClip sleep;
    public AnimationClip liedown;

    //FIN ANIM


    //SPRITES

    public Sprite sprite_endolori;
    public Sprite sprite_sale;
    public Sprite sprite_froid;
    public Sprite sprite_fatigue;
    public Sprite sprite_endormi;
    public Sprite sprite_repu;
    public Sprite sprite_affame;
    public Sprite sprite_content;
    public Sprite sprite_triste;
    public Sprite sprite_stresse;
    public Sprite sprite_confiant;
    public Sprite sprite_ennuye;

    public GameObject emotion;
    public GameObject bulle;

    //FIN SPRITES

    //TIMER

    //normal = temps passé dans l'état, max = temps pour infliger un malus

    private float temps_endolori;
    private float temps_endolori_max;
    private float temps_froid;
    private float temps_froid_max;
    private float temps_affame;
    private float temps_affame_max;
    private float temps_triste;
    private float temps_triste_max;
    private float temps_stress;
    private float temps_stress_max;
    private float temps_ennui;
    private float temps_ennui_max;

    private float regenSommeil;

    private float temps_emoticone;

    //FIN TIMER

    //VIE

    private float dps_endolori;
    private float dps_froid;
    private float dps_sale;
    private float dps_affame;
    private float dps_triste;
    private float dps_stress;
    private float dps_ennui;

    private float dps_vie;

    public float vie;
    private float seuil_bas;
    private float seuil_haut;

    private bool Alive;

    //FIN VIE

    //MALUS

    private float malus_endolori_sommeil;
    private float malus_endolori_tempcorp;
    private float malus_froid;
    private float malus_affame;
    private float malus_triste_hygiene;
    private float malus_triste_confiance;
    private float malus_stresse_hygiene;
    private float malus_stresse_sommeil;
    private float malus_stresse_epanouissement;
    private float malus_ennuye_faim;
    private float malus_ennuye_tempcorp;

    //FIN MALUS

    //INTERACTION

    private float soin;
    private float rechauffe;
    private float nettoyer;
    private float faireManger;
    private float parler;
    private float jouer;
    private float calin;

    //FIN INTERACTION


    //ETATS

    public bool endolori;
    public bool froid;
    public bool sale;
    public bool propre;
    public bool fatigue;
    public bool endormi;
    public bool repus;
    public bool affame;
    public bool content;
    public bool triste;
    public bool stresse;
    public bool confiant;
    public bool ennuye;

    //FIN DES ETATS


    //STATISTIQUES

    public float douleur;
    public float temperature;
    public float hygiene;
    public float faim;
    public float social;
    public float sommeil;
    public float epanouissement;
    public float confiance;

    //FIN DES STATISTIQUES


	void Start () {
        Reset();

        InvokeRepeating("baisserStats", 1.0f, 1.0f);

	}

    public bool GetAlive()
    {
        return Alive;
    }

    public void Reset()
    {
        particule_mort.GetComponent<ParticleSystem>().enableEmission = false;
        particule_puant.GetComponent<ParticleSystem>().enableEmission = false;
        particule_puant.transform.GetChild(0).transform.GetComponent<ParticleSystem>().enableEmission = false;
        particule_propre.GetComponent<ParticleSystem>().enableEmission = false;
        particule_propre.transform.GetChild(0).transform.GetComponent<ParticleSystem>().enableEmission = false;
        particule_dodo.GetComponent<ParticleSystem>().enableEmission = false;

        Alive = true;

        //ETATS

        endolori = false;
        froid = false;
        sale = false;
        propre = false;
        fatigue = false;
        endormi = false;
        repus = false;
        affame = false;
        content = false;
        triste = false;
        stresse = false;
        confiant = false;
        ennuye = false;

        //FIN DES ETATS

        //TIMERS

        temps_affame = 0;
        temps_affame_max = 60;
        temps_endolori = 0;
        temps_endolori_max = 60;
        temps_ennui = 0;
        temps_ennui_max = 60;
        temps_froid = 0;
        temps_froid_max = 60;
        temps_stress = 0;
        temps_stress_max = 60;
        temps_triste = 0;
        temps_triste_max = 60;

        regenSommeil = .1f;

        temps_emoticone = 5;

        //FIN DES TIMERS

        //VIE

        dps_endolori = .1f;
        dps_froid = .1f;
        dps_sale = .1f;
        dps_affame = .1f;
        dps_triste = .1f;
        dps_stress = .1f;
        dps_ennui = .1f;

        dps_vie = 0.1f;

        vie = 100;
        seuil_haut = 50;
        seuil_bas = 15;

        //FIN VIE

        //MALUS

        malus_endolori_sommeil = .1f;
        malus_endolori_tempcorp = .1f;
        malus_froid = .1f;
        malus_affame = .1f;
        malus_triste_hygiene = .1f;
        malus_triste_confiance = .1f;
        malus_stresse_hygiene = .1f;
        malus_stresse_sommeil = .1f;
        malus_stresse_epanouissement = .1f;
        malus_ennuye_tempcorp = .1f;
        malus_ennuye_faim = .1f;

        //FIN MALUS

        //INTERACTION

        soin = 20;
        rechauffe = 20;
        nettoyer = 20;
        faireManger = 20;
        parler = 20;
        jouer = 20;
        calin = 20;

        //FIN INTERACTION


        //STATISTIQUES

        douleur = 85;
        social = 50;
        epanouissement = 50;
        faim = 80;
        sommeil = 100;
        temperature = 75;
        hygiene = 50;
        confiance = 50;

        //FIN DES STATISTIQUES
    }
	
    public bool GetEndormi()
    {
        return endormi;
    }

    public bool GetRepu()
    {
        return repus;
    }

    void baisserStats()
    {
        if (Alive)
        {
            if (Camera.main.GetComponent<menu>().GetBas())
            {
                if (douleur > 0)
                    douleur -= 0.5f;
                if (douleur <= 0)
                    douleur = 0;
                if (social > 0)
                    social -= 0.33f;
                if (social <= 0)
                    social = 0;
                if (epanouissement > 0)
                    epanouissement -= 0.25f;
                if (epanouissement <= 0)
                    epanouissement = 0;
                if (faim > 0)
                    faim -= 0.5f;
                if (faim <= 0)
                    faim = 0;

                if (!endormi)
                {
                    if (sommeil > 0)
                        sommeil -= 0.5f;
                    if (sommeil <= 0)
                        sommeil = 0;
                }
                if (hygiene > 0)
                    hygiene -= 0.2f;
                if (hygiene <= 0)
                    hygiene = 0;

                vie -= dps_vie;

                if (endolori)
                    vie -= dps_endolori;
                if (froid)
                    vie -= dps_froid;
                if (sale)
                    vie -= dps_sale;
                if (affame)
                    vie -= dps_affame;
                if (triste)
                    vie -= dps_triste;
                if (stresse)
                    vie -= dps_stress;
                if (ennuye)
                    vie -= dps_ennui;

                Paul_matColorShift.health = vie / 100;

                CheckVie();

                RefreshState();
            }
        }
    }

    void CheckVie()
    {
        if(vie <= seuil_haut)
        {
            Debug.Log("seuil haut");
            //opacite 50%
        }
        if (vie <= seuil_bas)
        {
            Debug.Log("seuil bas");
            //opacite 25%
        }

        if(vie <= 0)
        {
            vie = 0;
            Alive = false;
            Paul_matColorShift.isDead = true;
            Camera.main.GetComponent<menu>().Monte();
            particule_mort.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }

    void Update()
    {
        if (Alive)
        {
            if (endolori)
            {
                temps_endolori++;
                if (temps_endolori >= temps_endolori_max)
                {
                    Endolori();
                    temps_endolori = 0;
                }
            }
            if (froid)
            {
                temps_froid++;
                if (temps_froid >= temps_froid_max)
                {
                    Froid();
                    temps_froid = 0;
                }
            }
            if (endormi)
            {
                sommeil += regenSommeil;
                if(sommeil >= 100)
                {
                    sommeil = 100;
                }
            }
            if (affame)
            {
                temps_affame++;
                if (temps_affame >= temps_affame_max)
                {
                    Affame();
                    temps_affame = 0;
                }
            }
            if (triste)
            {
                temps_triste++;
                if (temps_triste >= temps_triste_max)
                {
                    Triste();
                    temps_triste = 0;
                }
            }
            if (stresse)
            {
                temps_stress++;
                if (temps_stress >= temps_stress_max)
                {
                    Stress();
                    temps_stress = 0;
                }
            }
            if (ennuye)
            {
                temps_ennui++;
                if (temps_ennui >= temps_ennui_max)
                {
                    Ennui();
                    temps_ennui = 0;
                }
            }
        }
    }

    //MALUS

    void Endolori()
    {
        if (!endormi)
        {
            if (sommeil > 0)
                sommeil -= malus_endolori_sommeil;
            if (sommeil <= 0)
                sommeil = 0;
        }
        if (temperature > 0)
            temperature -= malus_endolori_tempcorp;
        if (temperature <= 0)
            temperature = 0;
    }

    void  Froid()
    {
        //if (temperature > 0)
            //temperature -= malus_froid;
        if (temperature <= 0)
            temperature = 0;
    }

    void Dodo()
    {
        //aucune action realisable
    }

    void Repu()
    {
        //impossible de manger
    }

    void Affame()
    {
        if (douleur > 0)
            douleur -= malus_affame;
        if (douleur <= 0)
            douleur = 0;
    }

    void Triste()
    {
        if (hygiene > 0)
            hygiene -= malus_triste_hygiene;
        if (hygiene <= 0)
            hygiene = 0;
        if (confiance > 0)
            confiance -= malus_triste_confiance;
        if (confiance <= 0)
            confiance = 0;
    }

    void Stress()
    {
        if (hygiene > 0)
            hygiene -= malus_stresse_hygiene;
        if (hygiene <= 0)
            hygiene = 0;
        if (endormi)
        {
            if (sommeil > 0)
                sommeil -= malus_stresse_sommeil;
            if (sommeil <= 0)
                sommeil = 0;
        }
        if (epanouissement > 0)
            epanouissement -= malus_stresse_epanouissement;
        if (epanouissement <= 0)
            epanouissement = 0;
    }

    void Ennui()
    {
        if (temperature > 0)
            temperature -= malus_ennuye_tempcorp;
        if (temperature <= 0)
            temperature = 0;

        if (faim > 0)
            faim -= malus_ennuye_faim;
        if (faim <= 0)
            faim = 0;
    }

    //FIN MALUS


    //INTERACTION

    public void Medecine()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("eat");
        StartCoroutine(coolDownAnim(eat.length));
        douleur += soin;
        if (douleur >= 100)
            douleur = 100;

        temperature += rechauffe;
        if (temperature >= 100)
            temperature = 100;
    }

    public void Rechauffer()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("warm");
        StartCoroutine(coolDownAnim(warm.length));
        temperature += rechauffe;
        if (temperature >= 100)
            temperature = 100;
    }

    public void Nettoyer()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("clean");
        StartCoroutine(coolDownAnim(clean.length));
        hygiene += nettoyer;
        if (hygiene >= 100)
            hygiene = 100;
    }

    public void FaireManger()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("eat");
        StartCoroutine(coolDownAnim(eat.length));
        faim += faireManger;
        if (faim >= 100)
            faim = 100;
    }

    public void Parler()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("talk");
        StartCoroutine(coolDownAnim(talk.length));
        social += parler;
        if (social >= 100)
            social = 100;
    }

    public void Jouer()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("play");
        StartCoroutine(coolDownAnim(play.length));
        social += jouer;
        if (social >= 100)
            social = 100;
        epanouissement += jouer;
        if (epanouissement >= 100)
            epanouissement = 100;
    }

    public void Calin()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("hug");
        StartCoroutine(coolDownAnim(hug.length));
        confiance += calin;
        if (confiance >= 100)
            confiance = 100;
    }

    //FIN INTERACTION


    void RefreshState()
    {
        //douleur
        if (douleur <= 60)
        {
            if (!endolori)
            {
                emotion.gameObject.SetActive(true);
                bulle.gameObject.SetActive(true);
                emotion.GetComponent<Image>().sprite = sprite_endolori;
                StartCoroutine("Bulle", temps_emoticone);
            }
            endolori = true;
        }
        else
        {
            endolori = false;
        }

        //temperature
        if (temperature <= 35)
        {
            if (!froid)
            {
                emotion.gameObject.SetActive(true);
                bulle.gameObject.SetActive(true);
                emotion.GetComponent<Image>().sprite = sprite_froid;
                StartCoroutine("Bulle", temps_emoticone);
            }
            froid = true;
        }
        else
        {
            froid = false;
        }

        //hygiene
        if (hygiene <= 30)
        {
            if (!sale)
            {
                particule_puant.GetComponent<ParticleSystem>().enableEmission = true;
                particule_puant.transform.GetChild(0).transform.GetComponent<ParticleSystem>().enableEmission = true;
                emotion.gameObject.SetActive(true);
                bulle.gameObject.SetActive(true);
                emotion.GetComponent<Image>().sprite = sprite_sale;
                StartCoroutine("Bulle", temps_emoticone);
            }
            sale = true;
            propre = false;
        }
        else if (hygiene >= 80)
        {
            if (!propre)
            {
                particule_propre.GetComponent<ParticleSystem>().enableEmission = true;
                particule_propre.transform.GetChild(0).transform.GetComponent<ParticleSystem>().enableEmission = true;
            }
            sale = false;
            propre = true;
        }
        else
        {
            particule_propre.GetComponent<ParticleSystem>().enableEmission = false;
            particule_propre.transform.GetChild(0).transform.GetComponent<ParticleSystem>().enableEmission = false;
            particule_puant.GetComponent<ParticleSystem>().enableEmission = false;
            particule_puant.transform.GetChild(0).transform.GetComponent<ParticleSystem>().enableEmission = false;
            sale = false;
            propre = false;
        }

        //sommeil
        if (!endormi)
        {
            if (sommeil <= 30)
            {
                if (!fatigue)
                {
                    emotion.gameObject.SetActive(true);
                    bulle.gameObject.SetActive(true);
                    emotion.GetComponent<Image>().sprite = sprite_fatigue;
                    StartCoroutine("Bulle", temps_emoticone);
                }
                fatigue = true;
            }
            else
            {
                fatigue = false;
            }

            if (sommeil <= 0)
            {
                particule_dodo.GetComponent<ParticleSystem>().enableEmission = true;
                GetComponent<Animator>().SetTrigger("liedown");
                endormi = true;
            }
        }
        else
        {
            //en train de dormir
            if (sommeil <= 50)
            {
                //s'il ne dormait pas avant
                if (!endormi)
                {
                   // GetComponent<Animator>().SetTrigger("liedown");
                    //coolDownAnim(warm.length);
                }
                endormi = true;
                fatigue = false;
            }
            else
            {
                particule_dodo.GetComponent<ParticleSystem>().enableEmission = false;
                GetComponent<Animator>().SetTrigger("wakeup");
                coolDownAnim(liedown.length); ;
                fatigue = false;
                endormi = false;
            }
        }

        //faim
        if (faim >= 80)
        {
            if (!repus)
            {
                emotion.gameObject.SetActive(true);
                bulle.gameObject.SetActive(true);
                emotion.GetComponent<Image>().sprite = sprite_repu;
                StartCoroutine("Bulle", temps_emoticone);
            }
            repus = true;
            affame = false;
        }
        else if (faim <= 35)
        {
            if (!affame)
            {
                emotion.gameObject.SetActive(true);
                bulle.gameObject.SetActive(true);
                emotion.GetComponent<Image>().sprite = sprite_affame;
                StartCoroutine("Bulle", temps_emoticone);
            }
            repus = false;
            affame = true;
        }
        else
        {
            repus = false;
            affame = false;
        }

        //social
        if (social >= 60 && epanouissement >= 75)
        {
            if (!content)
            {
                emotion.gameObject.SetActive(true);
                bulle.gameObject.SetActive(true);
                emotion.GetComponent<Image>().sprite = sprite_content;
                StartCoroutine("Bulle", temps_emoticone);
            }
            content = true;
            triste = false;
        }
        else if (social <= 30)
        {
            if (!triste)
            {
                emotion.gameObject.SetActive(true);
                bulle.gameObject.SetActive(true);
                emotion.GetComponent<Image>().sprite = sprite_triste;
                StartCoroutine("Bulle", temps_emoticone);
            }
            content = false;
            triste = true;
        }
        else
        {
            content = false;
            triste = false;
        }

        //epanouissement
        if (epanouissement <= 30)
        {
            if (!ennuye)
            {
                emotion.gameObject.SetActive(true);
                bulle.gameObject.SetActive(true);
                emotion.GetComponent<Image>().sprite = sprite_ennuye;
                StartCoroutine("Bulle", temps_emoticone);
            }
            ennuye = true;
        }
        else
        {
            ennuye = false;
        }

        //stress
        if (confiance <= 20)
        {
            if (!stresse)
            {
                emotion.gameObject.SetActive(true);
                bulle.gameObject.SetActive(true);
                emotion.GetComponent<Image>().sprite = sprite_stresse;
                StartCoroutine("Bulle", temps_emoticone);
            }
            stresse = true;
        }
        else
        {
            stresse = false;
        }
    }

    public IEnumerator coolDownAnim(float amount)
    {
        Debug.Log("debut cooldown:" + amount);
        yield return new WaitForSeconds(amount +1);
        GetComponent<Animator>().SetTrigger("anim_end");
        Camera.main.GetComponent<menu>().GetScroll().transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("fin cooldown:" + amount);
    }

    public IEnumerator Bulle(float amount)
    {
        yield return new WaitForSeconds(amount);
        emotion.gameObject.SetActive(false);
        bulle.gameObject.SetActive(false);
    }
}
