using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace CL.Services.WinService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(c =>
            {
                c.SetServiceName("LogServices");
                c.SetDisplayName("LogServices");
                c.SetDescription("LogServices");

                c.Service<TopshelfService>(s =>
                {
                    s.ConstructUsing(b => new TopshelfService());
                    s.WhenStarted(o => o.Start());
                    s.WhenStopped(o => o.Stop());
                });
            }
                         );
        }
    }
}
