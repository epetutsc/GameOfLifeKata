using System.Runtime.CompilerServices;

namespace GameOfLife.Tests
{

    public class ReadableFactAttribute : Xunit.FactAttribute
    {
        public ReadableFactAttribute([CallerMemberName] string testMethodName = "")
        {
            base.DisplayName = testMethodName
                ?.Replace("__", " - ")
                ?.Replace("_", " ");
        }
    }
}
