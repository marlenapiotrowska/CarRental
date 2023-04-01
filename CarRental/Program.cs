using CarRental.Presentation;

namespace CarRental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var viewService = new MenuViewService();
            viewService.Render();
        }
    }
}
