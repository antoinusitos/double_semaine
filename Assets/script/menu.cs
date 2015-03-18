using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu : MonoBehaviour {

    public GameObject positionfini;
    public GameObject positionHaut;

    public GameObject play;
    public GameObject quit;
    public GameObject logo;

    public GameObject jardin1;
    public GameObject jardin2;
    public GameObject jardin3;
    public GameObject scroll;
    public GameObject cuisine;
    public GameObject interaction;
    public GameObject jeu;
    public GameObject jour;

    public GameObject personnage;

    private bool descente;
    private bool monte;

    private bool bas;

    void start()
    {
        descente = false;
        monte = false;
        bas = false;
    }

    public void Play()
    {
        if (!monte)
        {
            if (!personnage.GetComponent<personnage>().GetAlive())
            {
                personnage.GetComponent<personnage>().Reset();
                personnage.transform.GetChild(2).GetComponent<Paul_matColorShift>().ResetHealth();
            }
            descente = true;
            monte = false;
        }
    }

    public GameObject GetScroll()
    {
        return scroll;
    }

    public bool GetBas()
    {
        return bas;
    }

    public void Monte()
    {
        StartCoroutine("coolDownMonte");
    }

    IEnumerator coolDownMonte()
    {
        yield return new WaitForSeconds(6);
        if (!descente)
        {
            monte = true;
            descente = false;
            jardin1.SetActive(false);
            jardin2.SetActive(false);
            jardin3.SetActive(false);
            scroll.SetActive(false);
            cuisine.SetActive(false);
            interaction.SetActive(false);
            jeu.SetActive(false);
            jour.SetActive(false);

        }
    }

    void Update()
    {
        if(descente && !monte)
        {
            float alpha = play.GetComponent<Image>().color.a;
            play.GetComponent<Image>().color = new Color(255, 255, 255, alpha - 0.01f);
            if (Vector3.Distance(transform.position, positionfini.transform.position) < 2)
            {
                quit.SetActive(true);
                float alpha2 = quit.GetComponent<Image>().color.a;
                quit.GetComponent<Image>().color = new Color(255, 255, 255, alpha2 + 0.05f);
            }
            float alpha3 = logo.GetComponent<Image>().color.a;
            logo.GetComponent<Image>().color = new Color(255, 255, 255, alpha3 - 0.01f);
            transform.position = Vector3.MoveTowards(transform.position, positionfini.transform.position, Time.deltaTime * 2);
            if(Vector3.Distance (transform.position, positionfini.transform.position) < 0.1f)
            {
                play.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                play.SetActive(false);
                logo.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                logo.SetActive(false);
                quit.GetComponent<Image>().color = new Color(255, 255, 255, 1);
                transform.position = positionfini.transform.position;
                descente = false;
                bas = true;
                jour.SetActive(true);
                Camera.main.GetComponent<gamecamera>().Debloquer();
            }
        }
        else if (monte && !descente)
        {
            bas = false;
            if (Vector3.Distance(transform.position, positionHaut.transform.position) < 3)
            {
                play.SetActive(true);
                logo.SetActive(true);
                float alpha = play.GetComponent<Image>().color.a;
                play.GetComponent<Image>().color = new Color(255, 255, 255, alpha + 0.05f);
                float alpha3 = logo.GetComponent<Image>().color.a;
                logo.GetComponent<Image>().color = new Color(255, 255, 255, alpha3 + 0.05f);
            }
            float alpha2 = quit.GetComponent<Image>().color.a;
            quit.GetComponent<Image>().color = new Color(255, 255, 255, alpha2 - 0.01f);
            transform.position = Vector3.MoveTowards(transform.position, positionHaut.transform.position, Time.deltaTime * 2);
            if (Vector3.Distance(transform.position, positionHaut.transform.position) < 0.1f)
            {
                quit.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                quit.SetActive(false);
                logo.GetComponent<Image>().color = new Color(255, 255, 255, 1);
                play.GetComponent<Image>().color = new Color(255, 255, 255, 1);
                transform.position = positionHaut.transform.position;
                monte = false;
                Camera.main.GetComponent<gamecamera>().Debloquer();
            }
        }
    }



}
