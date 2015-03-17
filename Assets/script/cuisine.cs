using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cuisine : MonoBehaviour {

    public GameObject plat;

    public GameObject slider;

    public GameObject GetPlat()
    {
        return plat;
    }

    public void Addvalue()
    {
        slider.GetComponent<Slider>().value += 0.25f;
    }

    public void Resetvalue()
    {
        slider.GetComponent<Slider>().value = 0;
    }

}
