using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoatOfArmsManager : MonoBehaviour
{

    public Color[] backgroundColours;
    public Sprite[] images;
    public Color[] imageColours;

    int backgroundColourValue = 0;

    public Material material;

    public Image image;

    int imagesValue = 0;

    int imageColourValue = 0;

    public Material material2;
    public void Start()
    {
        material.color = backgroundColours[backgroundColourValue];
        material2.color = imageColours[imageColourValue];
        image.sprite = images[imagesValue];
    }

    // Background Colours
    public void CycleThroughColours(int value)
    {
        backgroundColourValue += value;

        if (backgroundColourValue >= backgroundColours.Length)
        {
            backgroundColourValue = 0;
        }
        else if(backgroundColourValue < 0)
        {
            backgroundColourValue = backgroundColours.Length - 1;
        }


        material.color = backgroundColours[backgroundColourValue];
    }


    public void CycleThroughImages(int value)
    {
        imagesValue += value;

        if(imagesValue >= images.Length)
        {
            imagesValue = 0;
        }
        else if(imagesValue < 0)
        {
            imagesValue = images.Length;
        }

        image.sprite = images[imagesValue]; 
    }

    public void CycleThroughImageColours(int value)
    {
        imageColourValue += value;

        if (imageColourValue >= imageColours.Length)
        {
            imageColourValue = 0;
        }
        else if (imageColourValue < 0)
        {
            imageColourValue = imageColours.Length - 1;
        }


        material2.color = imageColours[imageColourValue];
    }
}
