using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Vector3 direction;

    private void FixedUpdate()
    {
        //PlayerMove();
    }

    private void Update()
    {
        //Move_Input();

        // Input.GetAxis() : Ư���� key�� ���� �� -1 ~ 1 ������ ���� ��ȯ�ϴ� �Լ��Դϴ�.
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        // Time.deltaTime : ���� �������� �Ϸ�Ǳ� ���� �ɸ� �ð��� �ǹ��մϴ�.
        Debug.Log(Time.deltaTime);
        transform.position += (speed * Time.deltaTime * direction).normalized;
    }

    private void Move_Input()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction =  new Vector3(horizontal, vertical, 0).normalized;
    }

    private void PlayerMove()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }
}
