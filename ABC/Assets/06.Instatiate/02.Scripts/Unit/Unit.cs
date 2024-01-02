using UnityEngine;

public enum State
{
    Move,
    Attack,
    Hit,
    Die,
    None,
}

public enum SOUND
{
    ATTACK,
    ONHIT,
    DIE,
}

[RequireComponent(typeof(HPBar))]
public abstract class Unit : MonoBehaviour
{
    protected float traceSpeed;
    protected float lerpSpeed;

    [SerializeField] State state;
    [SerializeField] Animator animator;
    [SerializeField] GameObject target;

    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;

    [SerializeField] HPBar healthBar;
    [SerializeField] Sound sound = new();

    private bool isCheck = false;

    private void Awake()
    {
        target = GameObject.Find("Player");
        healthBar = GetComponent<HPBar>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (state)
        {
            case State.Move:
                Move();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Die:
                Die();
                break;
            case State.None:
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

    protected void AttackSound()
    {
        SoundManager.instance.Sound(sound.audioClips[(int)SOUND.ATTACK]);
    }

    protected void OnHitSound()
    {
        SoundManager.instance.Sound(sound.audioClips[(int)SOUND.ONHIT]);
    }

    protected virtual void Attack()
    {
        animator.SetBool("Attack", true);
    }

    protected virtual void Die()
    {
        animator.Play("Die");

        SoundManager.instance.Sound(sound.audioClips[(int)SOUND.DIE]);

        state = State.None;
    }

    public void OnHit(float damage)
    {
        if (health <= 0) return;

        health -= damage;

        animator.SetTrigger("Hit");

        healthBar.UpdateHP(health, maxHealth);

        if (isCheck) state = State.Attack;
        else state = State.Move;

        if (health <= 0)
        {
            state = State.Die;
        }
    }

    public virtual void Release()
    {
        gameObject.SetActive(false);
    }

    // OnTriggerEnter() : Trigger�� �浹�� �Ǿ��� �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerEnter(Collider other)
    {
        state = State.Attack;
        isCheck = true;
    }

    // OnTriggerStay() : Trigger�� �浹 ���� �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerStay(Collider other)
    {

    }

    // OnTriggerExit() : Trigger�� �浹�� ������ �� �̺�Ʈ�� ȣ���ϴ� �Լ��Դϴ�.
    private void OnTriggerExit(Collider other)
    {
        state = State.Move;
        isCheck = false;
    }
}