using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace LittleBoxOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS FileSystem = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(FileSystem);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("Welcome to LittleBox OS!");
        }

        protected override void Run()
        {
            Console.WriteLine("");
            Console.Write(": ");
            string input = Console.ReadLine();
            Console.WriteLine("");
            ExecuteCommand(input);
        }

        private void ExecuteCommand(string input)
        {
            if (input == "help")
            {
                Console.WriteLine("calcu      = open calculator");
                Console.WriteLine("clr        = clear all system text");
                Console.WriteLine("createdir  = create directory");
                Console.WriteLine("deletedir  = delete directory");
                Console.WriteLine("filesdir   = read files in directory");
                Console.WriteLine("showdir    = list all directories");
                Console.WriteLine("createfile = create file");
                Console.WriteLine("deletefile = delete file");
                Console.WriteLine("readfile   = read file");
                Console.WriteLine("showfile   = list all files");
                Console.WriteLine("writefile  = write on file");
                Console.WriteLine("help       = list all commands");
                Console.WriteLine("build      = build information");
                Console.WriteLine("restart    = restart system");
                Console.WriteLine("shutdown   = shutdown system");
            }

            else if (input == "calcu")
            {
                int firstnum, secondnum, result;
                Console.Write("First number: ");
                string firstnumstr = Console.ReadLine();

                bool isFirstnumValid = int.TryParse(firstnumstr, out firstnum);

                if (!isFirstnumValid)
                {
                    Console.WriteLine("Invalid input.");
                }

                Console.Write("Operation: ");
                string operation = Console.ReadLine();

                Console.Write("Second number: ");
                string secondnumstr = Console.ReadLine();

                bool isSecondnumValid = int.TryParse(secondnumstr, out secondnum);

                if (!isSecondnumValid)
                {
                    Console.WriteLine("Invalid input.");
                }

                if (operation == "+")
                {
                    result = firstnum + secondnum;
                    Console.WriteLine("");
                    Console.WriteLine($"Result: {result}");
                }
                else if (operation == "-")
                {
                    result = firstnum - secondnum;
                    Console.WriteLine("");
                    Console.WriteLine($"Result: {result}");
                }
                else if (operation == "/")
                {
                    result = firstnum / secondnum;
                    Console.WriteLine("");
                    Console.WriteLine($"Result: {result}");
                }
                else if (operation == "*")
                {
                    result = firstnum * secondnum;
                    Console.WriteLine("");
                    Console.WriteLine($"Result: {result}");
                }
                else
                {
                    Console.Write("Invalid Operation. ");
                }
            }

            else if (input == "clr")
            {
                Console.Clear();
                Console.WriteLine("Techron OS booted successfully. By Group 3.");
            }

            else if (input == "createdir")
            {
                Console.Write("Create Directory: ");
                string directoryname = Console.ReadLine();
                try
                {
                    Directory.CreateDirectory($@"0:\{directoryname}\");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "deletedir")
            {
                Console.Write("Delete directory: ");
                string directoryname = Console.ReadLine();
                try
                {
                    Directory.Delete($@"0:\{directoryname}\");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "filesdir")
            {
                Console.Write("Read Directory: ");
                string directoryname = Console.ReadLine();
                Console.WriteLine("");
                try
                {
                    var directory_list = Directory.GetFiles($@"0:\{directoryname}");
                    try
                    {
                        foreach (var file in directory_list)
                        {
                            Console.WriteLine(file);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "showdir")
            {
                var directory_list = Directory.GetDirectories(@"0:\");

                foreach (var directory in directory_list)
                {
                    Console.WriteLine(directory);
                }
            }

            else if (input == "createfile")
            {
                try
                {
                    Console.Write("Create file: ");
                    string filename = Console.ReadLine();
                    var file_stream = File.Create($@"0:\{filename}.txt");
                    Console.Write("Write on file: ");
                    string filecontent = Console.ReadLine();
                    File.WriteAllText($@"0:\{filename}.txt", $"{filecontent}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "deletefile")
            {
                try
                {
                    Console.Write("Delete file: ");
                    string filename = Console.ReadLine();
                    File.Delete($@"0:\{filename}.txt");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "readfile")
            {
                try
                {
                    Console.Write("Read file: ");
                    string filename = Console.ReadLine();
                    Console.WriteLine("");
                    Console.WriteLine(File.ReadAllText($@"0:\{filename}.txt"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "showfile")
            {
                var files_list = Directory.GetFiles(@"0:\");
                foreach (var file in files_list)
                {
                    Console.WriteLine(file);
                }
            }

            else if (input == "writefile")
            {
                try
                {
                    Console.Write("Write on file: ");
                    string filename = Console.ReadLine();
                    Console.Write("Content: ");
                    string filecontent = Console.ReadLine();
                    File.WriteAllText($@"0:\{filename}.txt", $"{filecontent}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "build")
            {
                Console.WriteLine("Operating System Build:");
                Console.WriteLine("- Operating System: LittleBox OS");
                Console.WriteLine("- Build Date: April 2024");
                Console.WriteLine("- Build Version: 1.0");
            }

            else if (input == "restart")
            {
                Console.Write("Restarting system");
                Sys.Power.Reboot();
            }

            else if (input == "shutdown")
            {
                Console.Write("Shutting down system");
                Sys.Power.Shutdown();
            }
        }
    }
}
