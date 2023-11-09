using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildingManager : MonoBehaviour
{
    public GameObject[] objects;
    public Material[] materials;


    private Vector3 pos;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    public GameObject pendingObject;

    public float gridSize;
    public bool gridOn;
    public Toggle gridToggle;

    public float rotateAmount;

    public bool canPlace = true;

    public ResourceManager manager;

    private Vector3 offset;

    private void Start()
    {
        manager = GameObject.Find("ResourceSystem").GetComponent<ResourceManager>();
    }
    void Update()
    {
        if(pendingObject != null)
        {          
            if (gridOn)
            {
                pendingObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x), 
                    RoundToNearestGrid(pos.y), 
                    RoundToNearestGrid(pos.z));

            }
            else
            {
                pendingObject.transform.position = pos;
                
            }
            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceObject();
            }
            if(Input.GetKey(KeyCode.R))
            {
                RotateObject();
            }
            updateMaterials();
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;

        }

    }

    public void updateMaterials()
    {
        if (canPlace)
        {
            pendingObject.GetComponentInChildren<MeshRenderer>().material = materials[0];
        }
        else if (!canPlace)
        {
            pendingObject.GetComponentInChildren<MeshRenderer>().material = materials[1];
        }
    }
    public void PlaceObject()
    {
        if(pendingObject.GetComponent<ResourceCost>().resourceType == ResourceCost.ResourceType.Wood)
        {

            manager.woodValue -= pendingObject.GetComponent<ResourceCost>().woodCost;
        }
        if (pendingObject.GetComponent<ResourceCost>().resourceType == ResourceCost.ResourceType.Stone)
        {
            manager.stoneValue -= pendingObject.GetComponent<ResourceCost>().stoneCost;
        }
        if (pendingObject.GetComponent<ResourceCost>().resourceType == ResourceCost.ResourceType.Food)
        {
            manager.foodValue -= pendingObject.GetComponent<ResourceCost>().foodCost;
        }
        if (pendingObject.GetComponent<ResourceCost>().resourceType == ResourceCost.ResourceType.Metal)
        {
            manager.metalValue -= pendingObject.GetComponent<ResourceCost>().metalCost;
        }
        pendingObject.GetComponentInChildren<MeshRenderer>().material = pendingObject.GetComponentInChildren<storedMat>().savedMat;
        pendingObject = null;
    }

    public void RotateObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }
    public void SelectedObject(int index)
    {
        pendingObject = Instantiate(objects[index], pos, transform.rotation);
        //pendingObject = Instantiate(objects[index], pos, Quaternion.FromToRotation(Vector3.up, hit.normal));
    }

    public void ToggleGrid()
    {
        if(gridToggle.isOn)
        {
            gridOn = true;
        }
        else
        {
            gridOn = false;
        }
    }

    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if(xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}
