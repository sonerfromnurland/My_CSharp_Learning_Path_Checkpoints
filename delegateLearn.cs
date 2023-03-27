#nullable enable

/*
 * My Delegate Exercise with EventHandler
 * Soner
 */

/*
 Source:
C# 10 and .NET 6 – Modern Cross-Platform Development: Build apps, websites
Mark J. Price
https://books.google.com/books?id=OyNMEAAAQBAJ&pg=PA227&lpg=PA227&dq=%22EventHandler?+Shout%22&source=bl&ots=cNReaNfszB&sig=ACfU3U2Eg_3S-IhbU8PBvVGtNiyeej86eQ&hl=en&sa=X&ved=2ahUKEwjL4Mfk6_v9AhUrgf0HHbqJBpUQ6AF6BAgnEAM#v=onepage&q=%22EventHandler%3F%20Shout%22&f=false
 */

// EventHandler is a DELEGATE !

var f = new Foo();
f.Poke();
f.Poke();
f.Poke();
f.Poke();
f.Poke();
f.Poke();



class Foo
{
    public Foo()
    {
        Shout = Foo_Handler;
        Shout += (sender, args) =>
                {
                    if (sender is not Foo f) return;
                    Console.WriteLine("soner's eventhandler is invoked!" + $"  {i}");
                };

        Shout += delegate(object? sender, EventArgs args)
                {
                    if (sender is not Foo f) return;
                    Console.WriteLine("soner's eventhandler is invoked!" + $"  {i}");
                };
    }

    public EventHandler? Shout;
    int i = 0;
    public void Foo_Handler(object? sender, EventArgs e)
    {
        Foo? f = sender as Foo;
        if (f is null) return;
        Console.WriteLine("soner's eventhandler is invoked!" + $"  {i}");
    }

    public void Poke()
    {
        i++;
        if (i >= 3) Shout?.Invoke(this, EventArgs.Empty);
    }
}
