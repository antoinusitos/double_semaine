using UnityEngine;
using System.Collections;

public class gamecamera : MonoBehaviour {

    private GameObject mur;

    private Vector3 panOrigin;
    private float rotSpeed;
    public bool bDragging;

    public GameObject pivot;
    public GameObject player;
    public GameObject personnage;
    private GameObject objet;
    private GameObject destination;

    public bool equipe;
    private int interactionid;
    private int objetid;
    private bool preparing;

    private bool reseting;

    private bool UIclick;

    private float distanceObjetJoueur;
    private float distancePersonnageJoueur;
    private float distanceInteractionJoueur;

    private Vector3 campos;
    private Quaternion camrot;

    private bool bloque;

    void Start()
    {
        UIclick = false;

        bloque = true;

        rotSpeed = 6;

        equipe = false;
        preparing = false;
        objetid = -1;
        interactionid = -1;

        distanceObjetJoueur = 1.5f;
        distancePersonnageJoueur = 2f;

        reseting = false;
    }

    public bool GetEquipe()
    {
        return equipe;
    }

    public void Desequiper()
    {
        equipe = false;
        Destroy(objet);
    }

    public void Reset()
    {
        reseting = true;
    }

    public void KeepCamera()
    {
        campos = Camera.main.transform.position;
        camrot = Camera.main.transform.rotation;
    }

    public void Debloquer()
    {
        bloque = false;
    }

    public void SetDestination(GameObject obj)
    {
        destination = obj;
    }

	void Update () {

        if (reseting)
        {
            bloque = true;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, campos, Time.deltaTime * 1);
            if (Vector3.Distance(Camera.main.transform.position, campos) < 1)
            {
                Camera.main.transform.position = campos;
                reseting = false;
                Camera.main.transform.LookAt(pivot.transform);
                Camera.main.transform.rotation = camrot;
                bloque = false;
            }
        }

        if (destination != null)
        {
            if (Vector3.Distance(player.transform.position, destination.transform.position) < distanceObjetJoueur)
            {
                if(destination.tag == "objet")
                {
                    destination.transform.GetChild(0).GetComponent<ShowUI>().Hide();
                    interactionid = destination.GetComponent<objet>().GetId();
                    destination = null;
                }
                else if (destination.tag == "interaction")
                {
                    destination.transform.GetChild(0).GetComponent<ShowUI>().Hide();
                    interactionid = destination.GetComponent<interaction>().GetId();
                    destination = null;
                }
                else if (destination.tag == "cuisine" && !equipe)
                {
                    preparing = true;
                    destination.transform.GetChild(0).GetComponent<showUICuisine>().Hide();
                    destination.transform.GetChild(1).GetComponent<Animator>().SetBool("click", true);
                    GameObject plat = (GameObject)Instantiate(destination.GetComponent<cuisine>().GetPlat(), transform.position, Quaternion.identity);
                    StartCoroutine(Preparation(4, plat.transform, destination));
                    destination = null;
                }
            }
            else if (Vector3.Distance(player.transform.position, destination.transform.position) < distancePersonnageJoueur)
            {
                if (destination.tag == "personnage")
                {
                    if (!destination.GetComponent<personnage>().GetEndormi() && !destination.GetComponent<personnage>().GetRepu())
                    {
                        if (equipe)
                        {
                            equipe = false;
                            Destroy(objet);
                            destination = null;
                        }
                    }
                }
            }
        }

        if (!bloque)
        {

            if (Input.GetMouseButtonDown(0))
            {
                panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                UIclick = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

                //decommenter ici pour la build finale

                /*int pointerID = Input.GetTouch(0).fingerId;
                if (pointerID != null)
                    UIclick = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(pointerID);*/
            }

            if (Input.GetMouseButton(0))
            {
                if (!UIclick)
                {
                    if (Vector3.Distance(Camera.main.ScreenToViewportPoint(Input.mousePosition), panOrigin) > 0.1f)
                        bDragging = true;
                    if (bDragging)
                    {
                        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;
                        if (pos.x > 0)
                            transform.RotateAround(pivot.transform.position, Vector3.up, pos.magnitude * rotSpeed);
                        else
                            transform.RotateAround(pivot.transform.position, Vector3.up, pos.magnitude * -rotSpeed);
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (bDragging == false)
                {
                    if (!preparing && !UIclick)
                    {
                        bDragging = true;
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, 1000))
                        {
                            if (hit.transform.tag == "scroll")
                            {
                                Debug.Log("scroll");
                            }
                            else
                            {
                                //deplacement
                                if (hit.transform.tag == "sol")
                                {
                                    player.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                                }
                                //ramassage d'objets
                                else if (hit.transform.tag == "objet")
                                {
                                    player.GetComponent<NavMeshAgent>().SetDestination(hit.transform.position);
                                }
                                //aller voir le personnage
                                else if (hit.transform.tag == "personnage")
                                {
                                    player.GetComponent<NavMeshAgent>().SetDestination(personnage.transform.position);
                                }
                                //effectuer une action
                                else if (hit.transform.tag == "interaction")
                                {
                                    player.GetComponent<NavMeshAgent>().SetDestination(hit.transform.position);
                                }
                                //aller à la cuisine
                                else if (hit.transform.tag == "cuisine")
                                {
                                    player.GetComponent<NavMeshAgent>().SetDestination(hit.transform.position);
                                }
                                //aller au jardin
                                else if (hit.transform.tag == "jardin")
                                {
                                    player.GetComponent<NavMeshAgent>().SetDestination(hit.transform.position);
                                }
                                else
                                {
                                    bDragging = true;
                                    panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                                }
                            }
                        }

                    }
                }
                bDragging = false;
                UIclick = false;
            }
        }

	}

    public IEnumerator Preparation(float amount, Transform theObject, GameObject from)
    {
        player.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        yield return new WaitForSeconds(amount);
        Debug.Log(theObject.name);
        theObject.parent = player.transform;
        theObject.transform.position = new Vector3(player.transform.position.x+1, 1, player.transform.position.z);
        equipe = true;
        objetid = theObject.GetComponent<objet>().GetId();
        objet = theObject.gameObject;
        preparing = false;
        from.transform.GetChild(1).GetComponent<Animator>().SetBool("click", false);
    }
}