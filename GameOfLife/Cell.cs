namespace GameOfLife
{
    public record Cell
    {
        public bool IsDead { get; private set; } = true;
        public bool IsAlive => !IsDead;

        public static Cell Parse(string state)
        {
            return new Cell { IsDead = state == "x" };
        }

        public void SetAlive()
        {
            IsDead = false;
        }

        public void Kill()
        {
            IsDead = true;
        }

        public override string ToString()
        {
            return IsAlive ? "o" : " ";
        }
    }
}
