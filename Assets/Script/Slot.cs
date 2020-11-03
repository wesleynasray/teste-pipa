using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Text label;
    [SerializeField] GameObject marker;

    public int Number
    {
        get => int.Parse(label.text);
        set => label.text = value.ToString();
    }

    public bool IsMarked
    {
        get => marker.activeInHierarchy;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (BallHistory.HasNumber(Number))
            marker.SetActive(true);
    }
}
