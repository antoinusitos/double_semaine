using UnityEngine;
using System.Collections;

public class interactionUI : MonoBehaviour
{

    public GameObject player;
    public GameObject interactableObject;

    public void OnClick()
    {
        player.GetComponent<NavMeshAgent>().SetDestination(interactableObject.transform.position);
        Camera.main.GetComponent<gamecamera>().SetDestination(interactableObject);
    }
}
