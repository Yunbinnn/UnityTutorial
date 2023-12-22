public class Turtle : Unit
{
    public Turtle()
    {
        health = 70;
    }

    protected override void Move()
    {
        traceSpeed = 1.25f;
        lerpSpeed = 3f;
        base.Move();
    }
}