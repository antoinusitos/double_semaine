using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player : MonoBehaviour {

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

}
