using UnityEngine;
using System.Collections;

public class lookAt : MonoBehaviour {
	
	void Update () {
        transform.LookAt(Camera.main.transform.position);
	}
}
