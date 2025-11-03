using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("SoundManager is not initialized!");
            }
            return _instance;
        }
    }
    
    private AudioSource _audioSource;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        
        _audioSource = GetComponent<AudioSource>();
    }

    public float GetCurrentVolume()
    {
        return _audioSource.volume;
    }

    public bool IsMuted()
    {
        return _audioSource.mute;
    }

    public void ToggleMute(bool mute)
    {
        _audioSource.mute = mute;
    }

    public void AdjustSoundVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}