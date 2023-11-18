using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text theText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = new Color(1, (float)0.9764706, (float)0.6862745); //Or however you do your color
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.black; //Or however you do your color
    }
}
