using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

class App
{
    public static void Main(string[] args)
    {
        var messenger = WeakReferenceMessenger.Default;
        ORViewModel<ValueChangedMessage<string>> oRViewModel = new(messenger);
        
        messenger.Send(new ValueChangedMessage<string>("Value Changed."));
        Console.WriteLine("---");
    }
}