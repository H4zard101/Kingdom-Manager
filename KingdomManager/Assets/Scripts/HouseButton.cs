using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseButton : MonoBehaviour
{
    public GameObject HouseMenu;
    public GameObject _BuildMenuButton;

    public void OnBuildButtonClicked()
    {
        HouseMenu.SetActive(true);
        _BuildMenuButton.SetActive(false);
    }
}
