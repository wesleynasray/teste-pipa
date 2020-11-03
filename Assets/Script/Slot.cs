using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    public static event Action<Slot> OnSlotMarked;

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
        set => marker.gameObject.SetActive(value);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (BallHistory.HasNumber(Number))
        {
            marker.SetActive(true);
            OnSlotMarked?.Invoke(this);
        }
    }
}
