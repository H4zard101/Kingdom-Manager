using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Selection : MonoBehaviour
{

    public GameObject selectedObject;
    public GameObject pannel;
    public TextMeshProUGUI objectNameText;
    public WorldStateManager gameState;


    private void Start()
    {
        gameState = GameObject.Find("GameWorld").GetComponent<WorldStateManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameState.worldState == WorldStateManager.ResourceType.InGame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.gameObject.CompareTag("Object") && gameState.worldState == WorldStateManager.ResourceType.InGame)
                {
                    pannel.gameObject.SetActive(true);
                    gameState.worldState = WorldStateManager.ResourceType.InBuildDescription;
                    Select(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && gameState.worldState == WorldStateManager.ResourceType.InBuildDescription)
        {
            Deselect();
        }
    }

    public void Select(GameObject obj)
    {
        if (obj == selectedObject)
        {
            return;
        }

        if (selectedObject != null)
        {
            Deselect();
        }

        Outline outline = obj.GetComponent<Outline>();

        if (outline == null)
        {
            obj.AddComponent<Outline>();
        }

        else
        {
            outline.enabled = true;
        }

       
        selectedObject = obj;
        objectNameText.text = obj.name;
    }
    public void Deselect()
    {
        gameState.worldState = WorldStateManager.ResourceType.InGame;
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
        pannel.gameObject.SetActive(false);
    }
    public void Delete()
    {
        GameObject objectToDestroy = selectedObject;
        Deselect();
        Destroy(objectToDestroy);
        pannel.gameObject.SetActive(false);
    }
    public void Upgrade()
    {

    }
}
