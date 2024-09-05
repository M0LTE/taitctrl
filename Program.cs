using tait_ccdi;

if (!ValidateArgs(args, out string port, out int? channelInput))
{
    Console.WriteLine("Usage: taitctrl <port> chan [n]");
    Console.WriteLine("examples:");
    Console.WriteLine("  taitctrl /dev/ttyUSB0 chan      -   get current channel");
    Console.WriteLine("  taitctrl /dev/ttyUSB0 chan 1    -   set channel to 1");
    return -1;
}

using CancellationTokenSource cts = new(TimeSpan.FromSeconds(1));

try
{
    var radio = new TaitRadio(port, 28800);

    if (channelInput == null)
    {
        var channel = radio.GetCurrentChannel(cts.Token);
        if (channel == -1)
        {
            Console.WriteLine("Failed to get current channel.");
            WriteAdvice();
            return -1;
        }

        Console.WriteLine(channel);
        return 0;
    }
    else
    {
        if (radio.GoToChannel(channelInput.Value, cts.Token))
        {
            return 0;
        }

        Console.WriteLine("Failed to set channel.");
        WriteAdvice();
        return -2;
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    WriteAdvice();
    return -1;
}

static void WriteAdvice() => Console.WriteLine("Ensure the radio is powered and connected, its data port is set (Mic/Aux)" + 
    Environment.NewLine +
    "and baud rate is set to 28800 under Data -> Serial Communications.");

static bool ValidateArgs(string[] args, out string port, out int? setChan)
{
    bool isSet = args.Length == 3;

    int c = 0;
    if (args.Length > 3 || args.Length < 2 || args[1] != "chan" || (isSet && !int.TryParse(args[2], out c)))
    {
        port = "";
        setChan = 0;
        return false;
    }

    port = args[0];
    setChan = isSet ? c : null;

    return true;
}
