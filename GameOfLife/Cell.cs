namespace GameOfLife
{
    public class Cell
    {
        public bool IsDead { get; private set; } = true;
        public bool IsAlive => !IsDead;

        public void SetAlive()
        {
            IsDead = false;
        }

        public void Kill()
        {
            IsDead = true;
        }
    }
}
