using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    [SerializeField] private string nextLevel;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => SceneManager.Instance.ChangeScene(nextLevel));
        button.onClick.AddListener(() => AudioManager.Instance.PlayOneShot());
    }
}
