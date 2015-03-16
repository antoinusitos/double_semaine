using UnityEngine;
using System.Collections;

public class UIbouton : MonoBehaviour {

    public bool isQuit;
    public bool isPlay;

    public GameObject cam;

    public void OnClick()
    {
        if(isPlay)
        {
            cam.GetComponent<menu>().Play();
        }
        else
        {
            cam.GetComponent<menu>().Monte();
        }
    }
}
