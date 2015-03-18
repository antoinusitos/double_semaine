using UnityEngine;
using System.Collections;

public class Paul_CamZoom : MonoBehaviour {

	public float zoomIntensity = 0.3f;
	public float zoomDuration = 1f;

	float iniDistanceToPivot;
	float iniY;
	public Transform pivot;

	public bool zooming = false;
	bool wasZooming = false;


	// Use this for initialization
	void Start () {
		iniDistanceToPivot = Vector3.Distance (new Vector3(transform.position.x, GameObject.Find ("menuFin").transform.position.y, transform.position.z), pivot.position);
		iniY = /*transform.position.y;*/GameObject.Find ("menuFin").transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (zooming && !wasZooming) {
			StopAllCoroutines();
			StartCoroutine("zoom");
			wasZooming = true;
		}
		else if (!zooming && wasZooming){
			StopAllCoroutines();
			StartCoroutine("deZoom");
			wasZooming = false;
		}

	}

	IEnumerator zoom()
	{
		Debug.Log ("ZOOM");
		float _tempTime = Time.time;
		float _currentDistanceToPivot = Vector3.Distance (transform.position, pivot.position);
		float _currentY = transform.position.y;

		while (Time.time <= _tempTime + zoomDuration) 
		{
			transform.Translate (-(Vector3.forward * Time.deltaTime * ((1f-zoomIntensity) * iniDistanceToPivot - _currentDistanceToPivot))/zoomDuration);
			transform.Translate (-(Vector3.up * Time.deltaTime * (_currentY-(iniY-0.5f)))/zoomDuration);
			yield return null;
		}
	}

	IEnumerator deZoom()
	{
		Debug.Log ("DEZOOM");
		float _tempTime = Time.time;
		float _currentDistanceToPivot = Vector3.Distance (transform.position, pivot.position);
		float _currentY = transform.position.y;

		while (Time.time <= _tempTime + zoomDuration) 
		{
			transform.Translate (-(Vector3.forward * Time.deltaTime * (iniDistanceToPivot - _currentDistanceToPivot))/zoomDuration);
			transform.Translate ((Vector3.up * Time.deltaTime * (iniY-_currentY))/zoomDuration);
			yield return null;
		}
	}
}
