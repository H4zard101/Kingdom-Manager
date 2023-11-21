using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMenuManager : MonoBehaviour
{
    public enum IconMenu
    { 
        none,
        build,
        settings,
        characterSheet,
        research
    }

    public IconMenu iconMenu;

    public GameObject iconPannel;


    public void Update()
    {
        if(iconMenu == IconMenu.build)
        {
            iconPannel.SetActive(true);
        }
        if (iconMenu == IconMenu.none)
        {
            iconPannel.SetActive(false);
        }
    }
}
