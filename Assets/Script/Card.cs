using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Card : MonoBehaviour
{
    public static Action<Card> OnBingo;
    
    [SerializeField] Transform slotsParent;
    [SerializeField] Slot slotPrefab;
    [SerializeField] Vector2 padding;
    [SerializeField] GameObject bingoOverlay;

    Slot[,] cardSlots = new Slot[5,5];

    #region Event Listening
    private void OnEnable() => Slot.OnSlotMarked += Slot_OnSlotMarked;
    private void OnDisable() => Slot.OnSlotMarked -= Slot_OnSlotMarked;
    private void Slot_OnSlotMarked(Slot slot) => CheckBingo();
    #endregion

    private void Awake() => SpawnSlots();

    private void SpawnSlots()
    {
        for (int col = 0; col < 5; col++)
        {
            for (int row = 0; row < 5; row++)
            {
                var slot = Instantiate(slotPrefab, slotsParent);

                slot.transform.localPosition = new Vector2
                {
                    x = (col - 2) * padding.x,
                    y = (row - 2) * padding.y
                };

                slot.Number = Random.Range(1, 16) + (col * 15);

                if (col == 2 && row == 2)
                    slot.IsMarked = true;

                cardSlots[col, row] = slot;
            }
        }
    }

    #region Bingo Checks
    public bool CheckBingo()
    {
        Func<bool>[] checks = { 
            CheckCollumnBingo,
            CheckRowBingo,
            CheckDiagonalBingo,
            CheckCornerBingo
        };

        foreach (var check in checks) {
            if (check())
            {
                bingoOverlay.SetActive(true);
                OnBingo?.Invoke(this);
                return true;
            }
        }

        return false;
    }
    private bool CheckCollumnBingo()
    {
        for (int col = 0; col < 5; col++)
        {
            for (int row = 0; row < 5; row++)
            {
                if (cardSlots[col, row].IsMarked == false)
                    break;
                else if (row == 4)
                    return true;
            }
        }
        return false;
    }
    private bool CheckRowBingo()
    {
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                if (cardSlots[col, row].IsMarked == false)
                    break;
                else if (col == 4)
                    return true;
            }
        }
        return false;
    }
    private bool CheckDiagonalBingo()
    {
        for (int i = 0; i < 5; i++)
        {
            if (cardSlots[i, i].IsMarked == false)
                break;
            else if (i == 4)
                return true;
        }

        for (int i = 0; i < 5; i++)
        {
            if (cardSlots[4 - i, i].IsMarked == false)
                break;
            else if (i == 4)
                return true;
        }

        return false;
    }
    private bool CheckCornerBingo()
    {
        Vector2[] corners = { new Vector2(0, 0), new Vector2(0, 4), new Vector2(4, 0), new Vector2(4, 4) };
        foreach (var corner in corners)
        {
            if (cardSlots[(int)corner.x, (int)corner.y].IsMarked == false)
                return false;
        }
        return true;
    }
    #endregion
}
