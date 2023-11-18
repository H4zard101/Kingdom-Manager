using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateManager : MonoBehaviour
{
    public enum ResourceType
    {
        InGame,
        InBuild,
        InBuildDescription
    }
    public ResourceType worldState;
}
