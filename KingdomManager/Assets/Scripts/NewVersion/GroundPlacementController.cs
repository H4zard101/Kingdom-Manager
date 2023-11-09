using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementController : MonoBehaviour
{
    [SerializeField] private GameObject placeableObjectPrefab;

    public GameObject currentPlaceableObject;
    public LayerMask groundLayer;
    private float mouseWheelRotation;

    public Material[] materials;
    public GameObject[] objects;

    public bool canPlace = true;
    public bool hasEnoughResources = true;

    public ResourceManager manager;

    private void Start()
    {
        manager = GameObject.Find("ResourceSystem").GetComponent<ResourceManager>();
    }
    private void Update()
    {
        //HandelNewObjectHotKey();
        if(currentPlaceableObject != null)
        {

            MoveCurrentPlaceableObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(currentPlaceableObject);
            }
            updateMaterials();

            if (currentPlaceableObject.GetComponent<ResourceCost>().woodCost > manager.woodValue ||
               currentPlaceableObject.GetComponent<ResourceCost>().stoneCost > manager.stoneValue ||
               currentPlaceableObject.GetComponent<ResourceCost>().metalCost > manager.metalValue ||
               currentPlaceableObject.GetComponent<ResourceCost>().foodCost > manager.foodValue)
            {
                hasEnoughResources = false;
            }
            else
            {
                hasEnoughResources = true;
            }

        }
    }

    private void ReleaseIfClicked()
    {
        if(Input.GetMouseButtonDown(0) && canPlace && hasEnoughResources)
        {
            currentPlaceableObject.GetComponentInChildren<MeshRenderer>().material = currentPlaceableObject.GetComponentInChildren<storedMat>().savedMat;

            if (currentPlaceableObject.GetComponent<ResourceCost>().resourceType == ResourceCost.ResourceType.Wood)
            {

                manager.woodValue -= currentPlaceableObject.GetComponent<ResourceCost>().woodCost;
            }
            if (currentPlaceableObject.GetComponent<ResourceCost>().resourceType == ResourceCost.ResourceType.Stone)
            {
                manager.stoneValue -= currentPlaceableObject.GetComponent<ResourceCost>().stoneCost;
            }
            if (currentPlaceableObject.GetComponent<ResourceCost>().resourceType == ResourceCost.ResourceType.Food)
            {
                manager.foodValue -= currentPlaceableObject.GetComponent<ResourceCost>().foodCost;
            }
            if (currentPlaceableObject.GetComponent<ResourceCost>().resourceType == ResourceCost.ResourceType.Metal)
            {
                manager.metalValue -= currentPlaceableObject.GetComponent<ResourceCost>().metalCost;
            }

            currentPlaceableObject = null;
        }
    }

    private void RotateFromMouseWheel()
    {
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, groundLayer))
        {
            currentPlaceableObject.transform.position = hit.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }

    
    public void SelectedObject(int index)
    {
        currentPlaceableObject = Instantiate(objects[index]);

    }
    private void updateMaterials()
    {
        if (canPlace && hasEnoughResources)
        {
            currentPlaceableObject.GetComponentInChildren<MeshRenderer>().material = materials[0];
        }
        else if (!canPlace || !hasEnoughResources)
        {
            currentPlaceableObject.GetComponentInChildren<MeshRenderer>().material = materials[1];
        }
    }
}
