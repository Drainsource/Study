using DIDemoLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependecyInversionPrinciple
{
    public class App
    {
        private readonly IMessages _messages;

        public App(IMessages messages)
        {
            _messages = messages;
        }
        public void Run()
        {
            Console.WriteLine(_messages.SayHello());
        }
    }
}
