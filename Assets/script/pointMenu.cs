using UnityEngine;
using System.Collections;

public class pointMenu : MonoBehaviour {

    public GameObject cam;
	
	void Update () {
        transform.position = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);
	}
}
