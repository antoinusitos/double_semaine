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
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("give");
        StartCoroutine(coolDownAnim(give.length));

    }

    public void Rechauffer()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("warm");
        StartCoroutine(coolDownAnim(warm.length));
    }

    public void Nettoyer()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("clean");
        StartCoroutine(coolDownAnim(clean.length));
        
    }

    public void DonnerManger()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("give");
        StartCoroutine(coolDownAnim(give.length));
        
    }

    public void FaireManger()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("cuisine");
        StartCoroutine(coolDownAnim(cuisine.length));

    }

    public void Parler()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("talk");
        StartCoroutine(coolDownAnim(talk.length));
        
    }

    public void Jouer()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("play");
        StartCoroutine(coolDownAnim(play.length));
        
    }

    public void Calin()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("hug");
        StartCoroutine(coolDownAnim(hug.length));
        
    }

    public void Jardiner()
    {
        StopCoroutine("coolDownAnim");
        GetComponent<Animator>().SetTrigger("jardin");
        StartCoroutine(coolDownAnim(jardin.length));

    }



    public IEnumerator coolDownAnim(float amount)
    {
        yield return new WaitForSeconds(amount + 1);
        GetComponent<Animator>().SetTrigger("end_anim");
        Camera.main.GetComponent<menu>().GetScroll().transform.GetChild(0).gameObject.SetActive(true);
    }

}
