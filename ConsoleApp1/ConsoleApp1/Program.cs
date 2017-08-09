using System;
using System.Threading.Tasks;
using NSubstitute;

namespace ConsoleApp1
{
    public class Foo
    {
        internal virtual async Task<(bool Succeeded, string Message)> DoStuff(string str)
        {
            await Task.Delay(10);
            return (true, "hello");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sub = Substitute.ForPartsOf<Foo>();
            sub.WhenForAnyArgs(async x => await x.DoStuff(Arg.Any<string>())).DoNotCallBase();
        }
    }
}