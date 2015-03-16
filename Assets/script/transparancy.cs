using UnityEngine;
using System.Collections;

public class transparancy : MonoBehaviour {

    private bool tranparancy;
    private bool normalMat;

    public Material matNormal;
    public Material mattransp;

    void Start()
    {
        tranparancy = false;
        normalMat = true;
        transform.GetComponent<MeshRenderer>().material = matNormal;
    }

    public void transp()
    {
        tranparancy = true;
        normalMat = false;
        transform.GetComponent<MeshRenderer>().material = mattransp;
    }

    public void normal()
    {
        tranparancy = false;
        normalMat = true;
    }

	void Update () {
	    if(tranparancy)
        {
            float alpha = transform.GetComponent<MeshRenderer>().material.color.a;
            transform.GetComponent<MeshRenderer>().material.color = new Color(255, 255, 255, alpha - 0.1f);
        }
        else if (normalMat)
        {
            float alpha = transform.GetComponent<MeshRenderer>().material.color.a;
            transform.GetComponent<MeshRenderer>().material.color = new Color(255, 255, 255, alpha + 0.1f);
        }
	}
}
