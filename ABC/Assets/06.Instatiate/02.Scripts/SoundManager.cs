using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip[] audioClips;
}

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmSourece;
    [SerializeField] AudioSource sfxSource;

    public static SoundManager instance = null;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void Sound(AudioClip clip)
    {
        // PlayOneShot : 동시에 여러 위치에서 사운드를 호출하는 함수입니다.
        sfxSource.PlayOneShot(clip);
    }
}