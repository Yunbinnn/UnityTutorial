using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Vector3 direction;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        // Input.GetAxis() : Ư���� key�� ���� �� -1 ~ 1 ������ ���� ��ȯ�ϴ� �Լ��Դϴ�.
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        // Time.deltaTime : ���� �������� �Ϸ�Ǳ� ���� �ɸ� �ð��� �ǹ��մϴ�.
        direction.Normalize();

        transform.position += speed * Time.deltaTime * direction;
    }
}
