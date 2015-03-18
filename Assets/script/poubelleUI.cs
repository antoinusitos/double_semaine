using UnityEngine;
using System.Collections;

public class poubelleUI : MonoBehaviour {

	public void OnClick()
    {
        if (Camera.main.GetComponent<gamecamera>().GetEquipe())
        {
            Camera.main.GetComponent<gamecamera>().Desequiper();
            Camera.main.GetComponent<gamecamera>().ResetIdle();
            gameObject.SetActive(false);
        }
    }
}
