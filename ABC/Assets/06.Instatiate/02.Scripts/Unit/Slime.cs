public class Slime : Unit
{
    public Slime()
    {
        health = 50;
    }

    protected override void Move()
    {
        traceSpeed = 1.5f;
        lerpSpeed = 3f;
        base.Move();
    }
}