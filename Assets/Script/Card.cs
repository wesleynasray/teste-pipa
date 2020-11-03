using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] Slot slotPrefab;
    [SerializeField] Vector2 padding;

    private void Awake()
    {
        for (int col = 0; col < 5; col++)
        {
            for (int row = 0; row < 5; row++)
            {
                var slot = Instantiate(slotPrefab, transform);

                slot.transform.localPosition = new Vector2 {
                    x = (col - 2) * padding.x,
                    y = (row - 2) * padding.y
                };

                slot.Number = Random.Range(1, 16) + (col * 15);
            }
        }
    }
}
