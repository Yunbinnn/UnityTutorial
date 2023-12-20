public class StoneMonster : Unit
{
    protected override void Move()
    {
        traceSpeed = 2f;
        lerpSpeed = 3f;
        base.Move();
    }
}