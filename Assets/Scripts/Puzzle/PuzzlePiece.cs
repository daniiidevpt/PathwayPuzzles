using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [Header("Connection Ports")]
    [SerializeField] private List<PuzzleConnection> connections;

    [Header("Piece Conditions")]
    [SerializeField] private bool allConnected;
    [SerializeField] private bool canRotate;

    public bool AllConnected => allConnected;

    private void OnEnable()
    {
        PuzzleManager.OnPuzzleCompleted += HandleCompletion;
    }

    private void OnDisable()
    {
        PuzzleManager.OnPuzzleCompleted -= HandleCompletion;
    }

    private void Update()
    {
        HandleConnections();
    }

    private void OnMouseDown()
    {
        AudioManager.Instance.PlayOneShot();
        HandlePieceRotation();
    }

    private void HandlePieceRotation()
    {
        if (!canRotate) return;

        transform.Rotate(0f, 0f, -90f);
    }

    private void HandleConnections()
    {
        foreach (var connection in connections)
        {
            if (!connection.IsConnected)
            {
                allConnected = false;
                break;
            }
            else
            {
                allConnected = true;
            }
        }

        //Debug.Log($"{gameObject.name}: {(allConnected ? "All connections are connected." : "Not all connections are connected.")}");
    }

    private void HandleCompletion()
    {
        canRotate = false;
    }
}
