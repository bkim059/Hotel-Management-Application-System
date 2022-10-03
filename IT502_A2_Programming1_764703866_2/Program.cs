﻿/* 
 * Project Name: Hotel Management Application System for 'LANGHAM Hotels'
 * Author Name: Melissa Kim
 * Date: 23/09/2022
 * Application Purpose:Develop software application for 'LANGHAM Hotels' to manage their day-to-day operations 
 * like the allocatin of rooms, deallocation of rooms, displaying the status of rooms, and other functionality.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assessment2Task2
{
    // Custom Class - Room
    public class Room
    {
        public int RoomNo { get; set; }
        public bool IsAllocated { get; set; }
    }
    // Custom Class - Customer
    public class Customer
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
    }
    // Custom Class - RoomAllocation
    public class RoomlAllocaltion
    {
        public int AllocatedRoomNo { get; set; }
        public Customer AllocatedCustomer { get; set; }
    }

    // Custom Main Class - Program
    internal class Program
    {
        // Variables declaration and initialization
        public static Room[] listofRooms;
        public static List<RoomlAllocaltion> listOfRoomlAllocaltions = new List<RoomlAllocaltion>();
        public static string filePath;

        // Main function
        static void Main(string[] args)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Path.Combine(folderPath, "HotelManagement.txt");


            char ans;
            do
            {
                Console.Clear();
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine("                 LANGHAM HOTEL MANAGEMENT SYSTEM                  ");
                Console.WriteLine("                            MENU                                 ");
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine("1. Add Rooms");
                Console.WriteLine("2. Display Rooms");
                Console.WriteLine("3. Allocate Rooms");
                Console.WriteLine("4. De-Allocate Rooms");
                Console.WriteLine("5. Display Room Allocation Details");
                Console.WriteLine("6. Billing");
                Console.WriteLine("7. Save the Room Allocations To a File");
                Console.WriteLine("8. Show the Room Allocations From a File");
                Console.WriteLine("9. Exit");
                // Add new option 0 for Backup 
                Console.WriteLine("***********************************************************************************");
                Console.Write("Enter Your Choice Number Here:");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // adding Rooms function
                        break;
                    case 2:
                        // display Rooms function;
                        break;
                    case 3:
                        // allocate Room To Customer function
                        break;
                    case 4:
                        // De-Allocate Room From Customer function
                        break;
                    case 5:
                        // display Room Alocations function;
                        break;
                    case 6:
                        //  Display "Billing Feature is Under Construction and will be added soon…!!!"
                        break;
                    case 7:
                        // SaveRoomAllocationsToFile
                        break;
                    case 8:
                        //Show Room Allocations From File
                        break;
                    case 9:
                        // Exit Application
                        break;
                    default:
                        break;
                }

                Console.Write("\nWould You Like To Continue(Y/N):");
                ans = Convert.ToChar(Console.ReadLine());
            } while (ans == 'y' || ans == 'Y');
        }
    }

}