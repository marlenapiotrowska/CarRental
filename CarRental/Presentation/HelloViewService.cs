using CarRental.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Presentation
{
    internal class HelloViewService : IViewService
    {
        public void Render()
        {
            Console.WriteLine("Hello World");
        }
    }
}
