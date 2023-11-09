using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public TMP_Text FoodText;
    public TMP_Text StoneText;
    public TMP_Text WoodText;
    public TMP_Text MetalText;

    public TMP_Text PopulationText;

    public int foodValue = 100;
    public int stoneValue = 100;
    public int woodValue = 100;
    public int metalValue = 100;

    public int populationValue = 0;

    void Update()
    {
        FoodText.text = "Food: " + foodValue;
        StoneText.text = "Stone: " + stoneValue;
        WoodText.text = "Wood: " + woodValue;
        MetalText.text = "Metal: " + metalValue;

    }

        
}
