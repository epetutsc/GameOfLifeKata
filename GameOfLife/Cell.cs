namespace GameOfLife
{
    public class Cell
    {
        public bool IsDead { get; private set; } = true;

        public void SetAlive()
        {
            IsDead = false;
        }
    }
}
