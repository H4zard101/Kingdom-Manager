using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameAndMottoData : MonoBehaviour
{
    public string nameInput;
    public string mottoInput;


    public void ReadNameStringInput(string name)
    {
        nameInput = name;
        Debug.Log(nameInput);
    }
    public void ReadMottoStringInput(string motto)
    {
        mottoInput = motto;
        Debug.Log(mottoInput);
    }
}
