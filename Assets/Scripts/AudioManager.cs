using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.Stop(); // Stop the audio source before playing a new clip
        audioSource.PlayOneShot(clip);
    }
}
