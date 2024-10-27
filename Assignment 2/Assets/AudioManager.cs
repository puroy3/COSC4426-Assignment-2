using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------Audio Clip------")]
    public AudioClip background;
    public AudioClip Throw;

    private void Start() 
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
