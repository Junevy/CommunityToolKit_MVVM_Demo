## 关于ToolKit.MVVM

CommunityToolKit.MVVM
|
|-Component
|---ObservableObject
|-----ObservableRecipient
|-Attribute
|-RelayCommand
|---AsyncRelayCommand
|-Messenger
|---WeakReferenceMessenger
|---StrongReferenceMessenger
|-IoC

### RecipientDemo
> Recipient 和 isActive 使用方法的测试。

## SimpleDemo -- IoC
>- 测试容器的注册模式
>> 0) Auto wiring
>> 1) Singleton总是只有一个实例。
>> 2) Transient总是一个新的实例。
>> 3) 如果注册某个对象时是Singleton，也总是只有一个实例。 

>- 测试容器的作用域
>> scoped内所生成的对象不是唯一的，
   但是使用 service.AddScoped()，service获取到的对象是唯一的！

>- 测试自动装配
>> 可以在构建ServiceProvider之前，指定注入对象的构造方式
