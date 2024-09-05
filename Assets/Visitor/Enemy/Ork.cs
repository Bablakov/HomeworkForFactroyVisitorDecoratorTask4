namespace Assets.Visitor
{
    public class Ork: Enemy
    {
        public override void Accept(IEnemyVisitor visiter) => visiter.Visit(this);
    }
}
