using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private RawImage image;
    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;

    private void Update()
    {
        image.uvRect = new Rect(image.uvRect.position + new Vector2(xAxis, yAxis) * Time.deltaTime, image.uvRect.size);
    }
}
