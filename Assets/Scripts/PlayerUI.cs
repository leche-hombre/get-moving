using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public Canvas crossHair;
    

    void Update()
    {
        Vector3 centerScreen = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        crossHair.transform.position = centerScreen;
    }
}
