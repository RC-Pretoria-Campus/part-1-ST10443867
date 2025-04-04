using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Threading;

class ConsoleApp1
{
    static SpeechSynthesizer synth = new SpeechSynthesizer();  // Speech synthesizer

    static Dictionary<string, string> responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "phishing", "Phishing is a cyber attack where scammers trick you into revealing personal or financial information." },
        { "password", "A strong password should be at least 12 characters long, with uppercase, lowercase, numbers, and symbols." },
        { "2fa", "Two-Factor Authentication (2FA) adds an extra layer of security by requiring a secondary verification step." },
        { "firewall", "A firewall monitors and filters incoming and outgoing network traffic based on security rules." },
        { "malware", "Malware is any software designed to harm, exploit, or otherwise compromise a device or network." },
        { "ransomware", "Ransomware is a type of malware that encrypts your files and demands payment to restore access." },
        { "vpn", "A VPN (Virtual Private Network) encrypts your internet connection to protect your privacy online." },
    };

    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
   ██████╗██╗   ██╗██████╗ ███████╗███████╗██████╗ ██╗   ██╗
  ██╔════╝██║   ██║██╔══██╗██╔════╝██╔════╝██╔══██╗╚██╗ ██╔╝
  ██║     ██║   ██║██████╔╝███████╗█████╗  ██████╔╝ ╚████╔╝ 
  ██║     ██║   ██║██╔═══╝ ╚════██║██╔══╝  ██╔═══╝   ╚██╔╝  
  ╚██████╗╚██████╔╝██║     ███████║███████╗██║        ██║   
   ╚═════╝ ╚═════╝ ╚═╝     ╚══════╝╚══════╝╚═╝        ╚═╝   
  Enhancing Your Digital Fortress
        ");
        Console.ResetColor();
    }

    static void Main()
    {
        // Configure the SpeechSynthesizer
        synth.Volume = 100; // Set volume (0-100)
        synth.Rate = 0;     // Set speaking rate (-10 to 10)

        // Display ASCII Art
        DisplayAsciiArt();

        // Welcome message and user input
        Console.WriteLine("\nWelcome to the Cybersecurity Awareness Bot!");
        synth.Speak("Welcome to the Cybersecurity Awareness Bot!");

        Console.Write("Enter your name: ");
        string userName = Console.ReadLine()?.Trim();

        // Validate input
        while (string.IsNullOrEmpty(userName))
        {
            Console.Write("Please enter a valid name: ");
            userName = Console.ReadLine()?.Trim();
        }

        Console.WriteLine($"\nHello, {userName}! Ask me anything about cybersecurity.");
        synth.Speak($"Hello, {userName}! Ask me anything about cybersecurity.");
        Thread.Sleep(1000);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nAsk me a question (or type 'exit' to quit): ");
            Console.ResetColor();

            string userInput = Console.ReadLine()?.Trim();

            if (string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nStay safe online! Goodbye.");
                synth.Speak("Stay safe online! Goodbye.");
                break;
            }

            HandleComplexQuestions(userInput);
        }
    }

    static void HandleComplexQuestions(string input)
    {
        // Check for 'What is' type queries
        if (input.StartsWith("what is", StringComparison.OrdinalIgnoreCase))
        {
            string term = input.Replace("what is", "", StringComparison.OrdinalIgnoreCase).Trim();
            RespondToUser(term);
        }
        else
        {
            RespondToUser(input);
        }
    }

    static void RespondToUser(string input)
    {
        if (responses.TryGetValue(input, out string response))
        {
            Console.WriteLine(response);
            synth.Speak(response);
        }
        else
        {
            string defaultResponse = "I didn't quite understand that. Could you rephrase?";
            Console.WriteLine(defaultResponse);
            synth.Speak(defaultResponse);
        }
    }
}
