using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

partial class PropViewModel : ObservableRecipient, IRecipient<PropertyChangedMessage<string>>
{
    public void Receive(PropertyChangedMessage<string> message)
    {
        Console.WriteLine($"Prop :: Auto registed and received message : {message}");
    }
}