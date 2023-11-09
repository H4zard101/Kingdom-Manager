using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Selection : MonoBehaviour
{

    public GameObject selectedObject;
    public GameObject pannel;
    public TextMeshProUGUI objectNameText;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.gameObject.CompareTag("Object"))
                {
                    pannel.gameObject.SetActive(true);
                    Select(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
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
