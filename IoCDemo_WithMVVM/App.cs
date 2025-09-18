using Microsoft.Extensions.DependencyInjection;

class App
{
    public static void Main(string[] args)
    {

        /*
            @ Date: 2025年9月18日21:03:10
            @ Content: 测试容器的模式
            @ Result: 0) Auto wiring
                      1) Singleton总是只有一个实例。
                      2) Transient总是一个新的实例。
                      3) 如果注册某个对象时是Singleton，也总是只有一个实例。
        */
        var builder = new ServiceCollection();
        builder.AddSingleton<ILogger, SimpleDemo>();

        var services = builder.BuildServiceProvider();
        var logger = services.GetService<ILogger>();

        logger?.Log("hello");
        logger?.Log("world");
        Console.WriteLine("---------------------------");

        var builder_counter = new ServiceCollection();

        // Only one object.
        // builder_counter.AddSingleton<ICounter, Counter>();
        // builder_counter.AddSingleton<CounterService>();

        /* 
            Only one object too. 
            because of the ICounter and Counter are singleton inject to Container.
        */
        builder_counter.AddSingleton<ICounter, Counter>();
        builder_counter.AddTransient<CounterService>();

        var services_count = builder_counter.BuildServiceProvider();

        var cs_1 = services_count.GetService<CounterService>();
        var cs_2 = services_count.GetService<CounterService>();

        Console.WriteLine(cs_1?.Current);
        Console.WriteLine(cs_2?.Current);

        cs_1?.Increase();
        Console.WriteLine(cs_2?.Current);
        Console.WriteLine(cs_1?.Current);
        Console.WriteLine("---------------------------");


        /*
            @ Date: 2025年9月18日21:14:04
            @ Content: 测试容器的作用域
            @ Result: scoped内所生成的对象不是唯一的，
                      但是使用 service.AddScoped()，service获取到的对象是唯一的！
        */
        var builder_scope = new ServiceCollection();
        builder_scope.AddScoped<ICounter, Counter>();
        builder_scope.AddScoped<CounterService>();
        var services_scope = builder.BuildServiceProvider();
        using (var scoped = services_scope.CreateScope())
        {
            var cnt = scoped.ServiceProvider.GetService<CounterService>();
            cnt?.Increase();
            Console.WriteLine(cnt?.Current);
        }

        using (var scoped = services_scope.CreateScope())
        {
            var cnt = scoped.ServiceProvider.GetService<CounterService>();
            Console.WriteLine(cnt?.Current);
        }


        /*
            @ Date: 2025年9月18日21:34:05
            @ Content: 测试自动装配
            @ Result: 可以在构建ServiceProvider之前，指定注入对象的构造方式。code：85
        */
        var builder_construct = new ServiceCollection();
        builder_construct.AddSingleton<ILogger, Logger>();

        builder_construct.AddSingleton<Logger>( sp => new Logger("5,23", 23));
        var service_construct = builder_construct.BuildServiceProvider();

        var l = service_construct.GetService<Logger>();
        l.Log("test log");


    }
}

