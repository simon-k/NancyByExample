using System;
using Nancy.Hosting.Self;

namespace NancyByExample.API
{
    public class API
    {
        private NancyHost _host;

        public void Start()
        {
            var port = 8150;
            var uri = new Uri("http://localhost:" + port);
            _host = new NancyHost(uri);

            _host.Start();
            Console.WriteLine("API is running on " + uri);
            Console.WriteLine("Press [Enter] to close the host.");
            Console.ReadLine();
        }

        public void Stop()
        {
            if (_host != null)
            {
                _host.Stop();
                _host.Dispose();
                Console.WriteLine("Host has been stopped.");
            }
        }
    }
}
