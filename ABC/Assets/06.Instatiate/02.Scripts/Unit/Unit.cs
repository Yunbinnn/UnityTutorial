using UnityEngine;

public enum State
{
    Move,
    Attack,
    Die,
}

public abstract class Unit : MonoBehaviour
{
    protected float traceSpeed;
    protected float lerpSpeed;

    [SerializeField] State state;
    [SerializeField] Animator animator;
    [SerializeField] GameObject target;

    private void Awake()
    {
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (state)
        {
            case State.Move: Move();
                break;
            case State.Attack: Attack();
                break;
            case State.Die: Die();
                break;
        }
    }

    protected virtual void Move()
    {
        animator.SetBool("Attack", false);

        transform.Translate(Time.deltaTime * traceSpeed * Vector3.forward);

        Vector3 direction = target.transform.position - transform.position;

        direction.y = 0;

        direction = direction.normalized;

        transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * lerpSpeed);
    }

    protected virtual void Attack()
    {
        animator.SetBool("Attack", true);
    }

    protected void Die()
    {

    }

    // OnTriggerEnter() : Trigger와 충돌이 되었을 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerEnter(Collider other)
    {
        state = State.Attack;
    }

    // OnTriggerStay() : Trigger가 충돌 중일 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // OnTriggerExit() : Trigger와 충돌이 끝났을 때 이벤트를 호출하는 함수입니다.
    private void OnTriggerExit(Collider other)
    {
        state = State.Move;
    }
}