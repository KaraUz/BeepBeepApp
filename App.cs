using System;
using Android.App;
using Android.Runtime;
using Parse;

namespace BeepBeep
{
	[Application]
	public class App : Application
	{
		public App (IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			// Initialize the parse client with your Application ID and .NET Key found on
			// your Parse dashboard
			ParseClient.Initialize("2Uk5usG8E4cn557qmZ6WdjMsm9EoxvNYg0e3lmeD",
				"pYAMA5FtY65uy5nqKrb7S06o64WfOv6Xo0H6TQWK");
		}
	}
}