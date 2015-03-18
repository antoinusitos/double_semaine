using UnityEngine;
using System.Collections;

public class objet : MonoBehaviour {

    public int id;
    public GameObject holder;

    public int GetId()
    {
        return id;
    }

    void Update()
    {
        if(holder != null)
            transform.position = holder.transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(270, 0, 0));
    }
}
