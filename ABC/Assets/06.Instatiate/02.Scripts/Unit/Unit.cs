using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected float traceSpeed;
    protected float lerpSpeed;

    private bool isTrigger = false;

    [SerializeField] GameObject target;

    private void Awake()
    {
        target = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(Time.deltaTime * traceSpeed * Vector3.forward);

        Vector3 direction = target.transform.position - transform.position;

        direction.y = 0;

        direction = direction.normalized;

        transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * lerpSpeed);
    }

    // OnTriggerEnter() : Trigger와 충돌이 되었을 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerEnter(Collider other)
    {
        traceSpeed = 0;
        Debug.Log("OnTriggerEnter");
    }

    // OnTriggerStay() : Trigger가 충돌 중일 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // OnTriggerExit() : Trigger와 충돌이 끝났을 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }
}