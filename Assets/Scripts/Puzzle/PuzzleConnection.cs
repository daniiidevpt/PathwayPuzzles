using UnityEngine;

public class PuzzleConnection : MonoBehaviour
{
    [Header("Connection Settings")]
    [SerializeField] private string connectionTag = "PuzzleConnection";

    [Header("Connection Status")]
    [SerializeField] private bool isConnected;
    public bool IsConnected => isConnected;

    private Collider2D connectionCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(connectionTag))
        {
            connectionCollider = other;
            isConnected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == connectionCollider)
        {
            isConnected = false;
        }
    }
}
