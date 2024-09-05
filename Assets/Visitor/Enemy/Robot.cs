namespace Assets.Visitor
{
    public class Robot : Enemy
    {
        public override void Accept(IEnemyVisitor visiter) => visiter.Visit(this);
    }
}
