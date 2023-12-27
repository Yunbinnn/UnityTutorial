public class Slime : Unit
{
    public Slime()
    {
        health = 50;
        maxHealth = health;
        traceSpeed = 1.5f;
        lerpSpeed = 3f;
    }

    protected override void Move()
    {
        base.Move();
    }
}