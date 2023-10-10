using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBuildMenu : MonoBehaviour
{
    public GameObject BuildMenu;
    public GameObject BuildButton;


    public void closeBuildMenu()
    {
        BuildMenu.SetActive(false);
        BuildButton.SetActive(true);
    }
}
