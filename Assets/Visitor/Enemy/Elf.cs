namespace Assets.Visitor
{
    public class Elf: Enemy
    {
        public override void Accept(IEnemyVisitor visiter) => visiter.Visit(this);
    }
}
