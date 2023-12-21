public class Slime : Unit
{
    protected override void Move()
    {
        traceSpeed = 1.5f;
        lerpSpeed = 3f;
        base.Move();
    }
}