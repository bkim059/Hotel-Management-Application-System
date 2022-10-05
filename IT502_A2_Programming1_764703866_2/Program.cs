/* 
 * Project Name: Hotel Management Application System for 'LANGHAM Hotels'
 * Author Name: Melissa Kim
 * Date: 23/09/2022
 * Application Purpose:Develop software application for 'LANGHAM Hotels' to manage their day-to-day operations 
 * like the allocation of rooms, deallocation of rooms, displaying the status of rooms, and other functionality.
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
        //Declare integer variable for room number
        public int RoomNo { get; set; }
        //Declare boolean variable for whether room is allocated or not
        public bool IsAllocated { get; set; }
    }
    // Custom Class - Customer
    public class Customer
    {
        //Declare integer variable for customer number
        public int CustomerNo { get; set; }
        //Declare string variable for customer name
        public string CustomerName { get; set; }
    }
    // Custom Class - RoomAllocation
    public class RoomAllocation
    {
        //Declare integer variable for allocated room number
        public int AllocatedRoomNo { get; set; }
        //Declare variable for allocated customer from class Customer
        public Customer AllocatedCustomer { get; set; }
    }
    // Custom Main Class - Program
    internal class Program
    {
        //Variables declaration and initialisation
        //Initialising array of class Room
        public static Room[] listOfRooms;
        //Initialisng integer variable for number of room
        public static int noOfRoom;
        //Create a list of room allocations
        public static List<RoomAllocation> listOfRoomAllocations = new List<RoomAllocation>();
        //Initialising file path for both save allocations and back up file
        public static string filePath, filePathBackUp;

        // Main function
        static void Main(string[] args)
        {
            //Initialising and declaring path for location of the file 
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Create specific file for both save allocations and back up
            filePath = Path.Combine(folderPath, "lhms_764703866.txt");
            filePathBackUp = Path.Combine(folderPath, "lhms_764703866_backup.txt");
            //Display main menu
            Menu();
        }
        //Method for main menu
        public static void Menu()
        {
            //Format exception, invalid operation exception
            try
            {
                //Initialise integer variable
                int choice;
                //Do while loop for continuing with menu or not
                do
                {
                    //Display main menu
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine("                 LANGHAM HOTEL MANAGEMENT SYSTEM                  ");
                    Console.WriteLine("                            MENU                                 ");
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Add Rooms");
                    Console.WriteLine("2. Display Rooms");
                    Console.WriteLine("3. Allocate Rooms");
                    Console.WriteLine("4. De-Allocate Rooms");
                    Console.WriteLine("5. Display Room Allocation Details");
                    Console.WriteLine("6. Billing");
                    Console.WriteLine("7. Save the Room Allocations To a File");
                    Console.WriteLine("8. Show the Room Allocations From a File");
                    // Add new option 9 for Backup
                    Console.WriteLine("9. Backup");
                    Console.WriteLine("***********************************************************************************");
                    //Ask user to enter a number for menu choice
                    Console.Write("Enter Your Choice Number Here (0-9): ");
                    //Convert and save user input as a variable
                    choice = Convert.ToInt32(Console.ReadLine());
                    //Switch case for menu choice
                    switch (choice)
                    {
                        //Exit menu
                        case 0:
                            //Exit Application function called
                            Environment.Exit(0);
                            break;
                        //Add rooms menu
                        case 1:
                            //Adding Rooms function called
                            AddRooms();
                            break;
                        //Display rooms menu
                        case 2:
                            //Display Rooms function called
                            DisplayRooms();
                            break;
                        //Allocate rooms menu
                        case 3:
                            //Allocate Room To Customer function called
                            AllocateRooms();
                            break;
                        //De-allocate rooms menu
                        case 4:
                            //De-Allocate Room From Customer function called
                            DeAllocateRooms();
                            break;
                        //Display room allocations details menu
                        case 5:
                            //Display Room Alocations Details function called
                            DisplayRoomAllocations();
                            break;
                        //Billing menu
                        case 6:
                            //Display message for billing
                            Console.WriteLine("Billing Feature is Under Construction and will be added soon...!!!");
                            break;
                        //Save the room allocation to a file menu
                        case 7:
                            //Save Room Allocations To File function called
                            SaveRoomAllocations();
                            break;
                        //Show the room allocation from a file menu
                        case 8:
                            //Show Room Allocations From File function called
                            ShowRoomAllocations();
                            break;
                        //Back up menu
                        case 9:
                            //Backup function called
                            BackUp();
                            break;
                        //For invalid input
                        default:
                            //Display invalid input message, ask user to input valid number
                            Console.WriteLine("Please enter a valid number between 0-9");
                            break;
                    }
                //menu continues until user press 0
                } while (choice != 0);
            }
            catch (FormatException ex)
            {
                //Display format exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
            }
            catch (InvalidOperationException ex)
            {
                //Display invalid operation exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
            }
            finally
            {
                //Calling the Main menu function again to give another chance
                Menu();
            }
        }
        //Method to add rooms
        public static void AddRooms()
        {
            //Format exception
            try
            {
                //Display 'add rooms' choice selected
                Console.WriteLine("You have selected 'ADD ROOMS' from menu");
                //Ask user how many rooms to add, and convert and save as integer variable
                Console.Write("Please enter the total number of rooms in the Hotel: ");
                noOfRoom = Convert.ToInt32(Console.ReadLine());
                //Display how many rooms are there in total
                Console.WriteLine($"Hotel has {noOfRoom} rooms in total");
                Console.WriteLine("***********************************************************************************");
                //Create new array with number of rooms to add
                listOfRooms = new Room[noOfRoom];
                //Use for loop to ask user to input room details and save it
                for (int i = 0; i < noOfRoom; i++)
                {
                    //Create new object called room for class Room 
                    Room room = new Room();
                    //Ask user to enter room number
                    Console.Write($"Please enter room number {i + 1}: ");
                    //Convert user input to integer and save it
                    room.RoomNo = Convert.ToInt32(Console.ReadLine());
                    //Declare room allocation status to false(not allocated)
                    room.IsAllocated = false;
                    //Save the new room object to array of Room
                    listOfRooms[i] = room;
                    //If condition to check the same room number exist or not when there is more than 1 room added
                    if (i > 0)
                    {
                        //Use for loop to check the listOfRooms with the same room number
                        for (int j = 0; j < i; j++)
                        {
                            //Use while loop to check the user input room number is equal to previous inputs
                            while (listOfRooms[i].RoomNo == listOfRooms[j].RoomNo)
                            {
                                //Display message for the same room exist and ask to input new room number
                                Console.Write($"Same room number already exist\nPlease enter a new room number {i + 1}: ");
                                //Convert user input to integer and save it
                                room.RoomNo = Convert.ToInt32(Console.ReadLine());
                                //Declare room allocation status to false(not allocated)
                                room.IsAllocated = false;
                                //Save the new room object to array of Room
                                listOfRooms[i] = room;                               
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                //Display format exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                //Call the function again to give user another chance
                AddRooms();
            }
        }
        //Method to display rooms
        public static void DisplayRooms()
        {
            //If condition to check there is any rooms to display
            if(listOfRooms != null)
            {
                //Display 'display rooms' choice selected
                Console.WriteLine("You have selected 'DISPLAY ROOMS' from menu");
                Console.WriteLine("***********************************************************************************");
                Console.WriteLine($"Following rooms have been added");
                //Use foreach loop to display details of each room
                foreach (Room room in listOfRooms)
                {
                    Console.WriteLine($"Room Number: {room.RoomNo}");
                }
            }
            //If nothing to display, display following message
            else
            {
                Console.WriteLine("No rooms to display\nPlease add rooms first");
            }
        }
        //Method to allocate rooms to customer
        public static void AllocateRooms()
        {
            //Format exception, Invalid operation exception
            try
            { 
                //Display 'allocate rooms' choice selected
                Console.WriteLine("You have selected 'ALLOCATE ROOMS' from menu");
                //Ask user to input how many rooms to allocate
                Console.Write("How many rooms would you like to allocate?: ");
                //Declare integer variable, convert user input to integer and save it
                int allRoom = Convert.ToInt32(Console.ReadLine());
                //Use while loop to check user input is correct
                while (allRoom > noOfRoom)
                {
                    //Display input is incorrect message and give another chance
                    Console.Write($"You cannot allocate more rooms than total number of rooms in the Hotel\n" +
                        $"Please enter number between 1-{noOfRoom}: ");
                    allRoom = Convert.ToInt32(Console.ReadLine());
                }
                //Display how many room will be allocated
                Console.WriteLine($"You are allocating {allRoom} room(s)");
                //Use for loop to each room and customer details for allocation
                for (int i = 0; i < allRoom; i++)
                {
                    Console.WriteLine("***********************************************************************************");
                    //Create new object called roomAllocation for class RoomAllocation
                    RoomAllocation roomAllocation = new RoomAllocation();
                    //Create new object called customer for class Customer
                    Customer customer = new Customer();
                    //Display allocation number
                    Console.WriteLine($"Room Allocation {i + 1}:");
                    //Ask user to input room number to search
                    Console.Write("Please search Room Number to allocate: ");
                    //Declare integer variable, convert user input to integer and save it
                    int searchRoom = Convert.ToInt32(Console.ReadLine());
                    //Use for loop to search matching room from list of rooms that has been added
                    for (int j = 0; j < noOfRoom; j++)
                    {
                        //If condition to find matching room number
                        //If room number matches, display found message
                        if (searchRoom == listOfRooms[j].RoomNo)
                        {
                            //Display matching room found message
                            Console.WriteLine("Found matching room number to allocate");
                            //If condition to check for room is already allocated or not
                            //If room is not allocated, display allocation message
                            if (listOfRooms[j].IsAllocated == false)
                            {
                                //Display room searched is empty
                                Console.WriteLine($"Room {listOfRooms[j].RoomNo} is empty");
                                //Ask user to enter customer number
                                Console.Write("Please enter Customer Number to allocate: ");
                                //Convert user input to integer and save it
                                customer.CustomerNo = Convert.ToInt32(Console.ReadLine());
                                //Ask user to enter customer name
                                Console.Write("Please enter Customer Name to allocate: ");
                                //Save user input
                                customer.CustomerName = Console.ReadLine();
                                //Change room allocation status to allocated
                                listOfRooms[j].IsAllocated = true;
                                //Display allocation done message
                                Console.WriteLine("Allocation has been done");
                                //Save room number for allocation and customer details into the object
                                roomAllocation.AllocatedRoomNo = searchRoom;
                                roomAllocation.AllocatedCustomer = customer;
                                //Add object to the list
                                listOfRoomAllocations.Add(roomAllocation);
                                break;
                            }
                            //If room is already allocated, display message: room is occupied 
                            else
                            {
                                Console.WriteLine($"Room {listOfRooms[j].RoomNo} is already occupied\n" +
                                    $"Please enter another room to allocate");
                                //Give user another chance
                                i -= 1;
                                break;
                            }
                        }
                        //For no match found
                        else
                        {
                            //If no matching room number found, display message
                            while (j == noOfRoom - 1)
                            {
                                Console.WriteLine("Could not find matching room number to allocate\n" +
                                    "Please enter correct room number or add room first");
                                //Give user another chance
                                i -= 1;
                                break;
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                //Display format exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                //Call the function again to give user another chance
                AllocateRooms();
            }
            catch (InvalidOperationException ex)
            {
                //Display invalid operation exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                //Call the function again to give user another chance
                AllocateRooms();
            }
        }
        //Method to deallocate rooms from customer
        public static void DeAllocateRooms()
        {
            //Format exception, invalid operation exception
            try
            {
                //Display 'deallocate rooms' choice selected
                Console.WriteLine("You have selected 'DEALLOCATE ROOMS' from menu");
                //Ask user how many rooms to deallocate
                Console.Write("How many rooms would you like to deallocate?: ");
                //Declare integer variable, convert user input to integer and save it
                int deAllRoom = Convert.ToInt32(Console.ReadLine());                
                //Use while loop to check user input is correct (needs to be less than number of rooms allocated)
                while (deAllRoom > listOfRoomAllocations.Count)
                {
                    //Display input is incorrect message and give user another chance
                    Console.Write($"You cannot deallocate more rooms than you have allocated\n" +
                        $"Please enter number between 1-{listOfRoomAllocations.Count}: ");
                    deAllRoom = Convert.ToInt32(Console.ReadLine());
                }
                //Display how many rooms will be deallocated
                Console.WriteLine($"You are deallocating {deAllRoom} room(s)");
                //Use for loop for deallocating each room
                for (int i = 0; i < deAllRoom; i++)
                {
                    //Display each deallocation
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine($"Room Deallocation {i + 1}:");
                    //Ask user to enter room number to deallocate
                    Console.Write("Please search Room Number to deallocate: ");
                    //Convert user input to integer and save it
                    int searchRoom = Convert.ToInt32(Console.ReadLine());
                    //Use for loop to search matching room from list of rooms
                    for (int j = 0; j < noOfRoom; j++)
                    {
                        //If condition to find matching room number
                        //If room number matches, display found message
                        if (searchRoom == listOfRooms[j].RoomNo)
                        {
                            //Display matching room found message
                            Console.WriteLine("Found matching room number to deallocate");
                            //If condition to check for room is already allocated or not
                            //If room is allocated, display deallocation message
                            if (listOfRooms[j].IsAllocated == true)
                            {
                                //Display room searched is occupied
                                Console.WriteLine($"Room {listOfRooms[j].RoomNo} is occupied");
                                //Change room allocation status to deallocated
                                listOfRooms[j].IsAllocated = false;
                                //Display deallocation done message
                                Console.WriteLine($"Room {searchRoom} has been deallocated");
                                //Find the room number to deallocate from the list and remove
                                RoomAllocation roomAllocation = listOfRoomAllocations.Find(x => x.AllocatedRoomNo == searchRoom);
                                listOfRoomAllocations.Remove(roomAllocation);
                                break;
                            }
                            //If room is not allocated, display room not allocated message, and give user another chance
                            else
                            {
                                Console.WriteLine($"Room {listOfRooms[j].RoomNo} is empty" +
                                    $"\nPlease find another room to deallocate");
                                //Give user another chance
                                i -= 1;
                                break;
                            }
                        }
                        //For no match found
                        else
                        {
                            //If no matching room number found, display message, and give user another chance
                            while (j == noOfRoom - 1)
                            {
                                Console.WriteLine("Could not find matching room number to deallocate\n" +
                                    "Please enter correct room number or add room first");
                                //Give user another chance
                                i -= 1;
                                break;
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                //Display format exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                //Call the function again to give user another chance
                DeAllocateRooms();
            }
            catch (InvalidOperationException ex)
            {
                //Display invalid operation exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again");
                //Call the function again to give user another chance
                DeAllocateRooms();
            }
        }
        //Method to display room allocations details
        public static void DisplayRoomAllocations()
        {
            //If condition to check there is any allocated rooms to display
            if (listOfRoomAllocations.Count != 0)
            {
                //Display 'display room allocation details' choice selected
                Console.WriteLine("You have selected 'DISPLAY ROOM ALLOCATION DETAILS' from menu");
                //Foreach loop to display details of allocated rooms and customers
                foreach (RoomAllocation roomAllocation in listOfRoomAllocations)
                {
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine($"Room Number: {roomAllocation.AllocatedRoomNo}");
                    Console.WriteLine($"Customer Number: {roomAllocation.AllocatedCustomer.CustomerNo}");
                    Console.WriteLine($"Customer Name: {roomAllocation.AllocatedCustomer.CustomerName}");
                }
            }
            //If nothing to display, display following message
            else
            {
                Console.WriteLine("No allocated rooms to display\nPlease allocate rooms first");
            }
        }
        //Method to save the room allocations to file
        public static void SaveRoomAllocations()
        {
            //Unauthorized access exception
            try
            {
                //Display 'save the room allocations to a file' choice selected
                Console.WriteLine("You have selected 'SAVE THE ROOM ALLOCATIONS TO A FILE' from menu");
                Console.WriteLine("***********************************************************************************");
                //Initialise FileStream class with specified path, creation mode, and write permission
                FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                //Declare new object for writing file
                StreamWriter streamWriter = new StreamWriter(file);
                //Save current date and time
                DateTime now = DateTime.Now;
                //Foreach loop to write all the details for room allocations and customer, and adds to file
                foreach (RoomAllocation roomAllocation in listOfRoomAllocations)
                {
                    string addToFile = "***********************************************************************************\n" +
                        $"Room Number: {roomAllocation.AllocatedRoomNo}\n" +
                        $"Customer Number: {roomAllocation.AllocatedCustomer.CustomerNo}\n" +
                        $"Customer Name: {roomAllocation.AllocatedCustomer.CustomerName}\n" +
                        $"Current date and time is {now}";
                    //Writes specified string to the file
                    streamWriter.WriteLine(addToFile);
                }
                //Closing the file
                streamWriter.Close();
                //Display file saved message
                Console.WriteLine("File saved as 'lhms_764703866.txt' under Documents folder");
            }
            catch (UnauthorizedAccessException ex)
            {
                //Display unauthorized access exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("File unable to write");
            }
        }
        //Method to show room allocations from file
        public static void ShowRoomAllocations()
        {
            //File not found exception, unauthorized access exception
            try
            {
                //Display 'show the room alocations from a file' choice selected
                Console.WriteLine("You have selected 'SHOW THE ROOM ALLOCATIONS FROM A FILE' from menu");
                //Initialise FileStream class with specified path, creation mode, and read permission
                FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                //Declare new object for reading file
                StreamReader streamReader = new StreamReader(file);
                //Declare string variable
                string line = streamReader.ReadLine();
                //Use while loop to read and display lines from the file until the end of the file is reached
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = streamReader.ReadLine();
                }
                //Closing the file
                streamReader.Close();
            }
            catch (FileNotFoundException ex)
            {
                //Display file not found exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again after 'save room allocations to a file' option first");
            }
        }
        //Method to backup
        public static void BackUp()
        {
            //File not found exception, unauthorized access exception
            try
            {
                //Display 'backup' choice selected
                Console.WriteLine("You have selected 'BACKUP' from menu");
                Console.WriteLine("***********************************************************************************");
                //While loop to check back up file with the same name already exist or not
                //If exist, display existing message and delete the back up file
                while (File.Exists(filePathBackUp) == true)
                {
                    //Display message back up file already exist
                    Console.WriteLine("'lhms_764703866_backup.txt' file already exist\nExisting file will be deleted");
                    //Delete existing back up file
                    File.Delete(filePathBackUp);
                    Console.WriteLine("***********************************************************************************");
                } 
                //Copy saved file to back up file
                File.Copy(filePath, filePathBackUp);
                //Delete original file
                File.Delete(filePath);
                //Display message of back up file saved and original file deleted
                Console.WriteLine("Now your file 'lhms_764703866.txt' is saved as 'lhms_764703866_backup.txt'\n" +
                    "under Documents folder and orignial file will be deleted");
            }
            catch (FileNotFoundException ex)
            {
                //Display file not found exception message
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again after 'save room allocations to a file' option first");
            }
            catch (UnauthorizedAccessException ex)
            {
                //Display unauthorized access exception message
                Console.WriteLine(ex.Message);
            }
        }
    }
}