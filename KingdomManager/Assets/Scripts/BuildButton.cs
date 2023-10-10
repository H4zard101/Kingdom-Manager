using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    public GameObject BuildMenu;
    public GameObject _BuildButton;

    public void OnBuildButtonClicked()
    {
        BuildMenu.SetActive(true);
        _BuildButton.SetActive(false);
    }
}
