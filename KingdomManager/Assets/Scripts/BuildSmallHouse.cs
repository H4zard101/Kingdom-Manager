using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSmallHouse : MonoBehaviour
{
    public GameObject smallHouse;
    public GameObject houseMenu;
    public GameObject BuildButton;


    public void PlaceSmallHouse()
    {
        houseMenu.SetActive(false);
        BuildingSystem.current.InitializeWithObject(smallHouse);
        BuildButton.SetActive(true);
    }
}
