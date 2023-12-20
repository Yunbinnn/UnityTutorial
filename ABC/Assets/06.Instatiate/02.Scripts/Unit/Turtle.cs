public class Turtle : Unit
{
    protected override void Move()
    {
        traceSpeed = 1.15f;
        lerpSpeed = 3f;
        base.Move();
    }
}