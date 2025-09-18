using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

class App
{
    public static void Main(string[] args)
    {
        /*
            @ Date：2025年9月18日16:25:44
            @ TestContent: 测试 Recipient<T> 的作用
            @ Result：
                1) 实现 IRecipient<T> 后，不必再注册 T 类型的消息，
                在接收到 T 类型的消息时，框架将会自动调用Receive方法。参考PropViewModel
        */
        var messenger = WeakReferenceMessenger.Default;
        ORViewModel oRViewModel = new();
        oRViewModel.IsActive = true;

        messenger.Send(new ValueChangedMessage<string>("Value Changed."));
        Console.WriteLine("----------  --------------");

        /*
            @ Date：2025-09-18 16:26:10
            @ TestContent: 测试isActive和携带Token的Message
            @ Result:
                1) 在继承 ObservableRecipient 的同时实现 IRecipient<T> 接口，
                   程序将会自动调用Receive方法处理 Message。
                2）isActive属性如果未设置为 true，Recipient将处于未激活状态，不会处理任何Message，
                   除非显式注册某个类型的消息。
        */
        //with token
        ORViewModel oRViewModel_1 = new();
        oRViewModel_1.RegisterMessage(messenger); //显式注册某个类型的消息
        messenger.Send(new ValueChangedMessage<string>("with token message"));
        Console.WriteLine("----------  --------------");

        // Message type : PropertyChangedMessage.
        // Broadcast message
        PropViewModel propVM = new();

        //isActive属性
        propVM.IsActive = true; //不激活Recipient，Recipient将Unregistered任何消息。

        messenger.Send(new PropertyChangedMessage<string>(
            propVM,
            default,
            "default",
            "Broad Cast:: PropertyChanged.")
        );
        Console.WriteLine("----------  --------------");
    }
}