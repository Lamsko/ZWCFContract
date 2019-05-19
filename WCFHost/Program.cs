using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using ZWCFContract;

namespace WCFHost
{
	class Program
	{
		static void Main(string[] args)
		{
			Uri baseAddress = new Uri("http://localhost:10016/ZService1");
			ServiceHost selfHost = new ServiceHost(typeof(Service1), baseAddress);

			try
			{
				selfHost.AddServiceEndpoint(typeof(Service1), new WSHttpBinding(), "Service1");

				ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true;
				selfHost.Description.Behaviors.Add(smb);
				selfHost.Open();
				Console.WriteLine("Service1 wystartowal.");

				Console.WriteLine("Nacisnij <ENTER> aby zakonczyc.");
				Console.WriteLine();
				Console.ReadLine();
				selfHost.Close();
			}
			catch (CommunicationException ce)
			{
				Console.WriteLine("Wystapil wyjatek: {0}", ce);
				selfHost.Abort();
			}

		}
	}
}
