public class Turtle : Unit
{
    public Turtle()
    {
        health = 70;
        maxHealth = health;
        traceSpeed = 1.25f;
        lerpSpeed = 3f;
    }

    protected override void Move()
    {
        base.Move();
    }
}