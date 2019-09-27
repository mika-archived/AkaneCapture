using System.Threading.Tasks;

namespace QuickCapture.Models.ReadingResults
{
    internal class Others : ResultBase
    {
        public override Task FillAsync()
        {
            // NOTHING TO DO
            return Task.CompletedTask;
        }
    }
}