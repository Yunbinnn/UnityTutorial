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

    // OnTriggerEnter() : Trigger�� �浹�� �Ǿ��� �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerEnter(Collider other)
    {
        state = State.Attack;
    }

    // OnTriggerStay() : Trigger�� �浹 ���� �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // OnTriggerExit() : Trigger�� �浹�� ������ �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerExit(Collider other)
    {
        state = State.Move;
    }
}