using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Vector3 direction;

    public Camera cam;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        // Input.GetAxis() : 특정한 key를 누를 때 -1 ~ 1 사이의 값을 반환하는 함수입니다.
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        // Time.deltaTime : 이전 프레임이 완료되기 까지 걸린 시간을 의미합니다.
        direction.Normalize();

        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
            cam.gameObject.SetActive(true);
        }
        else
        {
            cam.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}