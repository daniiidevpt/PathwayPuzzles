using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    #region SINGLETON

    public static SceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [Header("SceneManager Settings")]
    [SerializeField] private Image fillImage;
    [SerializeField] private float fillDuration = .3f;
    [SerializeField] private AnimationCurve fillCurve;

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(FillOutIn(sceneName));
    }

    private IEnumerator FillOutIn(string sceneName)
    {
        yield return StartCoroutine(Fill(1));

        AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        UpdateImageReference();

        yield return StartCoroutine(Fill(0));
    }

    private IEnumerator Fill(float targetFill)
    {
        float startFill = fillImage.fillAmount;

        for (float t = 0; t < fillDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fillDuration;
            fillImage.fillAmount = Mathf.Lerp(startFill, targetFill, fillCurve.Evaluate(normalizedTime));
            yield return null;
        }

        fillImage.fillAmount = targetFill;
    }

    private void UpdateImageReference()
    {
        fillImage = GameObject.Find("FillImage").GetComponent<Image>();
        if (fillImage != null)
        {
            fillImage.fillAmount = 1;
        }
        else
        {
            Debug.LogError("FillImage not found in the new scene.");
        }
    }
}
