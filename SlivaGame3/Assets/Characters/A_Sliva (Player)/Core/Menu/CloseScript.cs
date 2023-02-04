using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseScript : MonoBehaviour
{
    public void CloseMenu(GameObject whatClose)
    {
        whatClose.SetActive(false);
    }

    public void ReturnToMenu()
    {

        gameObject.SetActive(true);
    }
}
