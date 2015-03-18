using UnityEngine;
using System.Collections;

public class Paul_matColorShift : MonoBehaviour {

	public Color iniColor;
	public Color endColor;
	Renderer rend;
	public float deathFadeDuration = 2.5f;

	///////////////////////////////////////////////////////// STATIC 
	static public float health = 1f; //btween 0 & 1;
	static public bool isDead = false;

	////////////////////////////////////////////////////////

	void Start () {
		isDead = false;
		health = 1f;
		rend = transform.GetComponent<Renderer> ();
		//iniCol = Color.white;
		rend.sharedMaterial.SetColor ("_EmissionColor", iniColor);
		rend.sharedMaterial.SetFloat ("_Cutoff", 0f);
	}


	void Update () {
		if (isDead && health > -1f || Input.GetKeyDown(KeyCode.Space)) 
		{
			health = -2f; //sert à éviter de lancer l'instruction en boucle
			StartCoroutine ("fadeAway");
		} 
		else if (health > 0f) 
		{
			rend.sharedMaterial.SetColor ("_EmissionColor", Color.Lerp(endColor, iniColor, health));
		};
	}

	
	public void ResetHealth()
	{
		health = 1f;
		isDead = false;
		rend.sharedMaterial.SetColor ("_EmissionColor", iniColor);
		rend.sharedMaterial.SetFloat ("_Cutoff", 0f);
	}

	IEnumerator fadeAway(){
		float _tempTime = Time.time;
		while (_tempTime > Time.time - deathFadeDuration)
		{
			rend.sharedMaterial.SetFloat ("_Cutoff", (Time.time-_tempTime)/deathFadeDuration);
			yield return null;
		}
		rend.sharedMaterial.SetFloat ("_Cutoff", 1f);
	}
}
