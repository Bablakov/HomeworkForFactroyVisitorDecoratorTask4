namespace Assets.Visitor
{
    public class Human : Enemy
    {
        public override void Accept(IEnemyVisitor visiter) => visiter.Visit(this);
    }
}
