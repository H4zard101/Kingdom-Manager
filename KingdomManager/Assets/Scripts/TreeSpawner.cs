using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treeObject;

    public GameObject treesInWorldObject; 

    public int treeAmount;

    List<GameObject> treeList = new List<GameObject>();

    GameObject[] treesArray;

    void Start()
    {
        for (int i = 0; i < treeAmount; i++)
        {
            treeList.Add(Instantiate<GameObject>(treeObject));
            treesArray = treeList.ToArray();
            treesArray[i].transform.position = new Vector3(Random.Range(-500, 500), 0, Random.Range(-500, 500));

            treesArray[i].transform.parent = treesInWorldObject.transform;
        }
    }

}
