using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    GroundPlacementController buildManager;
    ResourceManager resourceManager;
    ResourceCost cost;

    private void Start()
    {
        buildManager = GameObject.Find("GroundPlacementController").GetComponent<GroundPlacementController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Object"))
        {
            buildManager.canPlace = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            buildManager.canPlace = true;
            
        }        

    }
}
