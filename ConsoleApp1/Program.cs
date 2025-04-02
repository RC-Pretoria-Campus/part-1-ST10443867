using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Threading;

class ConsoleApp1
{
    static SpeechSynthesizer synth = new SpeechSynthesizer();  // Speech synthesizer

    static Dictionary<string, string> responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        // 🔐 Basic Cybersecurity Terms
        { "phishing", "Phishing is a cyber attack where scammers trick you into revealing personal or financial information." },
        { "password", "A strong password should be at least 12 characters long, with uppercase, lowercase, numbers, and symbols." },
        { "2fa", "Two-Factor Authentication (2FA) adds an extra layer of security by requiring a secondary verification step." },
        { "firewall", "A firewall monitors and filters incoming and outgoing network traffic based on security rules." },
        { "malware", "Malware is any software designed to harm, exploit, or otherwise compromise a device or network." },
        { "ransomware", "Ransomware is a type of malware that encrypts your files and demands payment to restore access." },
        { "vpn", "A VPN (Virtual Private Network) encrypts your internet connection to protect your privacy online." },

        // 🌐 Network & Internet Security
        { "public wifi", "Avoid using public Wi-Fi for sensitive activities. Use a VPN to encrypt your connection." },
        { "cookies", "Cookies store website data. Regularly clearing them helps protect your privacy." },
        { "social engineering", "Social engineering tricks people into revealing confidential information through deception." },
        { "zero-day attack", "A zero-day attack exploits a software vulnerability before the developer can fix it." },
        { "denial of service", "A DoS attack floods a server with traffic, making a website or service unavailable." },

        // 🏦 Financial & Online Shopping Security
        { "is it safe to shop online?", "Yes, but only use websites with HTTPS and avoid saving payment details online." },
        { "credit card fraud", "Monitor your transactions and report suspicious activity to your bank immediately." },
        { "fake websites", "Check the URL, ensure HTTPS is present, and avoid clicking on links in unknown emails." },

        // 🔍 Dark Web & AI Threats
        { "dark web", "The Dark Web is a hidden part of the internet where illegal activities often take place." },
        { "deepfake", "Deepfake is AI-generated fake content, often used for misinformation or fraud." },
        { "ai in cybersecurity", "AI is used for both cyber attacks and defense, making cybersecurity more advanced than ever." },

        // ☁️ Cloud Security & Data Privacy
        { "cloud security", "Use strong passwords, enable 2FA, and avoid storing sensitive data in unsecured cloud services." },
        { "data breach", "A data breach occurs when hackers gain unauthorized access to confidential information." },
        { "gdpr", "The General Data Protection Regulation (GDPR) is a law that protects personal data privacy in Europe." },

        // 📱 Mobile Security
        { "how to secure my phone?", "Use strong passwords, enable 2FA, install updates, and avoid downloading apps from unknown sources." },
        { "spyware", "Spyware is software that secretly collects your personal data without your knowledge." },

        // 🔑 Authentication & Password Safety
        { "password manager", "A password manager securely stores and generates strong passwords for different accounts." },
        { "brute force attack", "A brute force attack is when hackers try multiple password combinations until they guess correctly." },

        // 🛡️ Cyber Hygiene & Best Practices
        { "how often should I change my password?", "Change your passwords every few months or after a data breach." },
        { "how do I recognize a scam?", "Scams often have urgent messages, bad grammar, and suspicious links." },
        { "what to do if I get hacked?", "Change your passwords, enable 2FA, and check for unauthorized transactions or activity." }
    };

    static void Main()
    {
        // Configure the SpeechSynthesizer
        synth.Volume = 100; // Set volume (0-100)
        synth.Rate = 0; // Set speaking rate (-10 to 10)

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
        // Check for complex questions
        if (input.StartsWith("what is", StringComparison.OrdinalIgnoreCase))
        {
            string term = input.Replace("what is", "").Trim();
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