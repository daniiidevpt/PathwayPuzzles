using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region SINGLETON

    public static AudioManager Instance { get; private set; }

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

    [Header("Background Music Settings")]
    [SerializeField] private AudioSource backgroundSource;
    [SerializeField] private AudioClip backgroundClip;

    [Header("One Shot Settings")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip sfxClip;

    private void Start()
    {
        PlayMusic(backgroundClip);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        backgroundSource.clip = musicClip;
        backgroundSource.loop = true;
        backgroundSource.Play();
    }

    public void PlayOneShot()
    {
        sfxSource.PlayOneShot(sfxClip);
    }
}

