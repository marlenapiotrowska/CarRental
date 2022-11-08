using CarRental.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace CarRental.Presentation
{
    public class MenuViewService : IViewService
    {
        public void Render()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                  "------------- Hello in Car Rental -------------" +
                  "\nPress the button:" +
                  "\n[1] To register new car" +
                  "\n[2] To rent a car" +
                  "\n[3] To ride a car" +
                  "\n[4] To see available cars" +
                  "\n[5] To return the car " +
                  "\n[6] To quit");

                var usersCommand = Console.ReadLine();

                if (usersCommand == "1")
                {
                    Console.Clear();
                    var view = new RegisterCarViewService();
                    view.Render();
                }
                else if (usersCommand == "2")
                {
                    Console.Clear();
                    var view = new RentCarViewService();
                    view.WriteWantedCarToRent();
                }
                else if (usersCommand == "3")
                {
                    Console.Clear();
                    var view = new RideCarViewService();
                    view.WriteWantedCarToRide();
                }
                else if (usersCommand == "4")
                {
                    Console.Clear();
                    var view = new DisplayCarsViewService();
                    view.Render();                    
                }
                else if (usersCommand == "5")
                {
                    Console.Clear();
                    var view = new ReturnCarViewService();
                    view.WriteWantedCarToReturn();
                }               
                else if (usersCommand == "6")
                {
                    break;
                }
                else
                {
                    throw new InvalidOperationException("You pressed an invalid number");
                }
            }
        }
    
    }
}
