using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cuisineUI : MonoBehaviour {

    public GameObject player;
    public GameObject cuisineObject;

    public void OnClick()
    {
        GetComponent<Button>().interactable = false;
        player.GetComponent<NavMeshAgent>().SetDestination(cuisineObject.transform.position);
        Camera.main.GetComponent<gamecamera>().SetDestination(cuisineObject);
    }
}
