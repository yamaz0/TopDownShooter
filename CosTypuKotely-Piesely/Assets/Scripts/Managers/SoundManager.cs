using UnityEngine;

public class SoundManager : SingletonPersistence<SoundManager>
{
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource effectSource;

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
}
