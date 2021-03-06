﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Satori.Rtm;
using Satori.Rtm.Client;

class Program
{
    const string endpoint = "YOUR_ENDPOINT";
    const string appkey = "YOUR_APPKeY";

    static void Main()
    {
        // Log messages from SDK to the console
        Trace.Listeners.Add(new ConsoleTraceListener());

        IRtmClient client = new RtmClientBuilder(endpoint, appkey).Build();

        client.OnEnterConnected += cn => Console.WriteLine("Connected to Satori RTM!");

        client.OnError += ex => 
            Console.WriteLine("Failed to connect: " + ex.Message);

        client.Start();

        // Publish, subscribe, and perform other operations here

        Console.ReadKey();

        // Stop and clean up the client before exiting the program
        client.Dispose().Wait();
    }
}