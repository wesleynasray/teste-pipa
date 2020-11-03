using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Text label;

    public int Number
    {
        get => int.Parse(label.text);
        set => label.text = value.ToString();
    }
}
