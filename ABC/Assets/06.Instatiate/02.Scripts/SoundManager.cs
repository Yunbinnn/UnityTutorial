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
        // PlayOneShot : ���ÿ� ���� ��ġ���� ���带 ȣ���ϴ� �Լ��Դϴ�.
        sfxSource.PlayOneShot(clip);
    }
}