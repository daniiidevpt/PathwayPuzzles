using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Manager Settings")]
    [SerializeField] private List<PuzzlePiece> pieces;
    [SerializeField] private GameObject nextLevelUI;

    private List<GameObject> allPieces;

    public static event Action OnPuzzleCompleted;

    private void Start()
    {
        allPieces = GameObject.FindGameObjectsWithTag("PuzzleConnection").ToList();
    }

    private void Update()
    {
        if (pieces.Count == 0) return;

        HandlePieces();
    }

    private void HandlePieces()
    {
        bool allConnected = true;

        foreach (var piece in pieces)
        {
            if (!piece.AllConnected)
            {
                allConnected = false;
                break;
            }
        }

        if (allConnected)
        {
            Debug.Log("PUZZLE SOLVED");
            OnPuzzleCompleted?.Invoke();

            foreach (var piece in allPieces)
            {
                piece.SetActive(false);
            }

            nextLevelUI.SetActive(true);
        }
    }
}
