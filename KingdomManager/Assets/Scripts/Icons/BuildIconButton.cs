using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildIconButton : MonoBehaviour
{
    public IconMenuManager manager;

    public void Start()
    {
        manager = GameObject.Find("IconManager").GetComponent<IconMenuManager>();
    }
    public void Appear()
    {
        if (manager.iconMenu != IconMenuManager.IconMenu.build)
        {
            manager.iconMenu = IconMenuManager.IconMenu.build;
        }
        else if (manager.iconMenu == IconMenuManager.IconMenu.build)
        {
            manager.iconMenu = IconMenuManager.IconMenu.none;
        }
    }
}
