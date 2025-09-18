
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

/// <summary>
/// ObservableRecipient ViewModel
/// </summary>
partial class ORViewModel : ObservableRecipient, IRecipient<ValueChangedMessage<string>>
{
    /// <summary>
    /// isActive = true;
    /// </summary>

    // public ORViewModel(IMessenger messenger)
    // {
    //     messenger.Register<ValueChangedMessage<string>>(this, MsgHandler);
    // }

    // public ORViewModel(IMessenger messenger, int token)
    // {
    //     messenger.Register<ValueChangedMessage<string>, int>(this, token, MsgHandler);
    // }
    // public ORViewModel() { }
    
    public void RegisterMessage(IMessenger messenger)
    {
        // Type t = typeof(T);
        // var instance = Activator.CreateInstance(t);
        // messenger.Register<T>(instance);

        messenger.Register<ValueChangedMessage<string>>(this, MsgHandler);
    }

    private void MsgHandler(object recipient, ValueChangedMessage<string> message)
    {
        Console.WriteLine($"Handler:: {message.Value} from {recipient.ToString()}");
    }

    public void Receive(ValueChangedMessage<string> message)
    {
        Console.WriteLine(message.Value);
    }
}