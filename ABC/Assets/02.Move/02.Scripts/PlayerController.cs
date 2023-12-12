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

        // Input.GetAxis() : 특정한 key를 누를 때 -1 ~ 1 사이의 값을 반환하는 함수입니다.
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        // Time.deltaTime : 이전 프레임이 완료되기 까지 걸린 시간을 의미합니다.
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
