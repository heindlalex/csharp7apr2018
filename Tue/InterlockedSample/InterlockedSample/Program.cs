using System;
using System.Net;
using System.Threading;

namespace InterlockedSample
{
    class Program
    {
        public event EventHandler<string> MyEvent;


        private EventHandler<string> _myEvent2;
        public event EventHandler<string> MyEvent2
        {
            add => _myEvent2 += value;
            remove => _myEvent2 -= value;
        }

        static void Main(string[] args)
        {
            int x = 3;
            Interlocked.Increment(ref x);

            WebClient client = new WebClient();

            client.DownloadFileAsync(new Uri(""), "filename");
            client.DownloadFileCompleted += (sender, e) =>
            {
                textBox.Text = "completed";

            };
        }
    }
}
