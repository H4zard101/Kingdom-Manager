using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCost : MonoBehaviour
{
    public enum ResourceType
    {
        Wood,
        Stone,
        Metal,
        Food
    }
    public ResourceType resourceType;

    public int woodCost;
    public int stoneCost;
    public int metalCost;
    public int foodCost;

}
