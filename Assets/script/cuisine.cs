using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cuisine : MonoBehaviour {

    public GameObject plat;

    public GameObject slider;

    public AudioClip cuisiner;

    public GameObject GetPlat()
    {
        return plat;
    }

    public void playSound()
    {
        GetComponent<AudioSource>().PlayOneShot(cuisiner);
    }

    public void stopSound()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void Addvalue()
    {
        slider.GetComponent<Slider>().value += 0.25f;
    }

    public void Resetvalue()
    {
        slider.GetComponent<Slider>().value = 0;
    }

    public void Enablebutton()
    {
        slider.transform.GetChild(0).transform.GetComponent<Button>().interactable = true;
    }

}
