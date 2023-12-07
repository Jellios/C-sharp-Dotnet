using System;
using System.Threading;

// Delegate for the event
public delegate void KeystrokeEventHandler(object sender, KeystrokeEventArgs e);

// Event arguments class
public class KeystrokeEventArgs : EventArgs
{
    public int KeystrokeCount { get; set; }
}

// Publisher class
public class KeyCounter
{
    // Event
    public event KeystrokeEventHandler KeystrokeEvent;

    private int keystrokeCount = 0;

    public void IncrementKeystrokeCount()
    {
        keystrokeCount++;

        // Check if the keystroke count is divisible by 10
        if (keystrokeCount % 10 == 0)
        {
            // Raise the event
            KeystrokeEvent?.Invoke(this, new KeystrokeEventArgs { KeystrokeCount = keystrokeCount });
        }
    }
}

// Subscriber class
public class MessageBoard
{
    private int messageCount = 0;

    public MessageBoard(KeyCounter keyCounter)
    {
        // Subscribe to the event
        keyCounter.KeystrokeEvent += OnKeystrokeEvent;
    }

    // Event handler
    private void OnKeystrokeEvent(object sender, KeystrokeEventArgs e)
    {
        messageCount++;
        Console.WriteLine($"MessageBoard{messageCount}: {e.KeystrokeCount} keystrokes");
    }
}

// Program class
public class Program
{
    public static void Main(string[] args)
    {
        KeyCounter keyCounter = new KeyCounter();
        MessageBoard messageBoard1 = new MessageBoard(keyCounter);
        MessageBoard messageBoard2 = new MessageBoard(keyCounter);
        MessageBoard messageBoard3 = new MessageBoard(keyCounter);

        // Simulate keystrokes
        /*      for (int i = 0; i < 50; i++)
              {
                  keyCounter.IncrementKeystrokeCount();
              } */
        do
        {
            if (System.Console.ReadKey().Key != ConsoleKey.Enter)
            {
                keyCounter.IncrementKeystrokeCount();
               Thread.Sleep(1);
            }
        } while (true);
    }
}
