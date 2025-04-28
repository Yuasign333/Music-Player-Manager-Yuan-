using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.AccessControl;

class Program
{
    static void Main()
    {
        bool Stop = false; // Variable to control the whole loop
        List<string> playlist = new List<string>(); // List to store the playlist

        while (!Stop)
        {
            // Display Menu
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\n1.Add Songs");
            Console.WriteLine("\n2.Display Playlist");
            Console.WriteLine("\n3.Search for Songs");
            Console.WriteLine("\n4.Shuffle Playlist");
            Console.WriteLine("\n5.Remove Song");
            Console.WriteLine("\n6.Reverse Playlist");
            Console.WriteLine("\n7.Exit");

            Console.Write("\nChoose an option: ");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":  // Add Songs

                    bool addingSongs = true;

                    while (addingSongs)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nEnter the song to add (or type 'done' to stop adding): ");
                        string songToAdd = Console.ReadLine(); // user input for case 1

                        if (songToAdd.ToLower() == "done")
                        {
                            addingSongs = false; // Stop adding songs and return to main menu
                        }
                        else
                        {
                            playlist.Add(songToAdd); // keep adding songs
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine("\nSong added!");
                            Console.ReadKey();
                            Console.WriteLine("\nYou can check now your playlist for the updated one (press done to return to the home page) ");
                            Console.ReadKey();
                            Console.WriteLine("\nor keep adding until you are satisfied");
                            Console.ReadKey();

                            
                        }
                    }
                    break;

                case "2":  // Display Playlist
                    Console.Clear();
                    if (playlist.Count == 0)
                    {
                        Console.WriteLine("\nCurrent Playlist: No songs in the playlist yet.");
                    }
                    else
                    {
                        Console.Write("\nUpdated Playlist: ");
                        foreach (string song in playlist)
                        {
                            Console.Write(song + " ");
                           
                        }
                        Console.WriteLine();
                    }
                    break;

                case "3":  // Search for Songs
                    Console.Clear();
                    Console.Write("Enter the song name to search for: ");
                    string searchTerm = Console.ReadLine(); // Case-insensitive search // user input for case 3
                    bool found = false;

                    foreach (string  song in playlist)
                    {
                        if (song.Contains(searchTerm)) 
                        {
                            Console.WriteLine($"\nSong '{song}' was found in your playlist.");
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("\nNo songs found matching that search term.");
                    }
                    break;


                case "4":  // Shuffle Playlist
                    Console.Clear();
                    if (playlist.Count < 2)
                    {
                        Console.WriteLine("Cannot shuffle. Playlist needs at least two songs.");
                    }
                    else
                    {
                        Random rand = new Random();
                        //  swap each element with another random element
                        for (int i = 0; i < playlist.Count; i++)
                        {
                            int j = rand.Next(playlist.Count);  // Random index between 0 and playlist.Count - 1
                                                                // Swap playlist[i] with playlist[j]

                            // shuffle logic  ( just to mix up songs)                                
                            string temp = playlist[i]; 
                            playlist[i] = playlist[j];
                            playlist[j] = temp;
                        }

                        Console.WriteLine("\nPlaylist shuffled!");
                    }
                    break;
                    

                case "5":  // Remove Song
                    Console.Clear();
                    Console.Write("Enter the song name to remove: ");
                    string songToRemove = Console.ReadLine(); // user input for case 5

                    if (playlist.Contains(songToRemove))
                    {
                        playlist.Remove(songToRemove);
                        Console.WriteLine($"\nSong '{songToRemove}' removed!");
                    }
                    else
                    {
                        Console.WriteLine($"\nSong '{songToRemove}' not found in the playlist.");
                    }
                    break;

                case "6":  // Reverse Playlist
                    Console.Clear();
                    if (playlist.Count < 2)
                    {
                        Console.WriteLine("Cannot reverse. Playlist needs at least two songs.");
                    }
                    else
                    {
                        playlist.Reverse(); // Reverse the playlist
                        Console.WriteLine("\nPlaylist reversed!");
                    }
                    break;

                case "7":  // Exit
                    Stop = true;
                    Console.WriteLine("\nExiting program...");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nWrong Input. Choose only numbers 1-7.");
                    Console.ResetColor();
                    break;
            }

            // Wait for user to press a key before continuing
            if (userChoice != "7")
                
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
