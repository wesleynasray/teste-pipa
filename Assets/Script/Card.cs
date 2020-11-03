using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] GameObject slotPrefab;
    [SerializeField] Vector2 padding;

    private void Awake()
    {
        for (int col = -2; col <= 2; col++)
        {
            for (int row = -2; row <= 2; row++)
            {
                var slot = Instantiate(slotPrefab, transform);
                
                slot.transform.localPosition = new Vector2 {
                    x = col * padding.x,
                    y = row * padding.y
                };
            }
        }
    }
}
