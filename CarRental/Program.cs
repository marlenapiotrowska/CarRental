using CarRental.Presentation;
using System;
using System.Collections.Generic;

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
