using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player : MonoBehaviour {

    //ANIMS

    public AnimationClip clean;
    public AnimationClip warm;
    public AnimationClip hug;
    public AnimationClip play;
    public AnimationClip talk;
    public AnimationClip cuisine;
    public AnimationClip jardin;
    public AnimationClip give;

    //FIN ANIM

    public static int medoc;

    public static int GrainesMedoc;
    public static int GrainesDeco;
    public static int GrainesMusic;

    void Awake()
    {
        medoc = 0;

        GrainesMedoc = 1;
        GrainesDeco = 1;
        GrainesMusic = 1;
    }

    public void Medecine()
    {
        Camera.main.GetComponent<gamecamera>().Bloquer();
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("give");
        StartCoroutine(coolDownAnim(give.length));

    }

    public void Rechauffer()
    {
        Camera.main.GetComponent<gamecamera>().Bloquer();
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("warm");
        StartCoroutine(coolDownAnim(warm.length));
    }

    public void Nettoyer()
    {
        Camera.main.GetComponent<gamecamera>().Bloquer();
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("clean");
        StartCoroutine(coolDownAnim(clean.length));
        
    }

    public void DonnerManger()
    {
        Camera.main.GetComponent<gamecamera>().Bloquer();
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("give");
        GetComponent<Animator>().SetBool("equipe", false);
        StartCoroutine(coolDownAnim(give.length));
    }

    public void FaireManger()
    {
        Camera.main.GetComponent<gamecamera>().Bloquer();
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("cuisine");
        StartCoroutine(coolDownAnim(cuisine.length));

    }

    public void Parler()
    {
        Camera.main.GetComponent<gamecamera>().Bloquer();
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("talk");
        StartCoroutine(coolDownAnim(talk.length));
        
    }

    public void Jouer()
    {
        Camera.main.GetComponent<gamecamera>().Bloquer();
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("play");
        StartCoroutine(coolDownAnim(play.length));
        
    }

    public void Calin()
    {
        Camera.main.GetComponent<gamecamera>().Bloquer();
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("hug");
        StartCoroutine(coolDownAnim(hug.length));
        
    }

    public void Jardiner()
    {
        Camera.main.GetComponent<gamecamera>().Bloquer();
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("jardin");
        StartCoroutine(coolDownAnim(jardin.length));

    }



    public IEnumerator coolDownAnim(float amount)
    {
        yield return new WaitForSeconds(amount + 1);
        GetComponent<Animator>().SetTrigger("end_anim");
        Camera.main.GetComponent<menu>().GetScroll().transform.GetChild(0).gameObject.SetActive(true);
        Camera.main.GetComponent<gamecamera>().Debloquer();
    }

}
