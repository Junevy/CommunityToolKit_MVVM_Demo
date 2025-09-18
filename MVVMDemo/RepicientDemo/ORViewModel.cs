
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

/// <summary>
/// ObservableRecipient ViewModel
/// </summary>
partial class ORViewModel<T> : ObservableRecipient, IRecipient<ValueChangedMessage<string>> where T : class
{
    public ORViewModel(IMessenger messenger)
    {
        messenger.Register<T>(this, (o, m) =>
        {
            if (m is ValueChangedMessage<string>)
            {
                Console.WriteLine((m as ValueChangedMessage<string>)?.Value ?? "None");
            }
        });
    }

    public void Receive(ValueChangedMessage<string> message)
    {
        Console.WriteLine(message.Value);
    }
}