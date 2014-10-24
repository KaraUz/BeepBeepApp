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
			ParseClient.Initialize("TyylXkoIKmLbb9jOYJOF9gOR0Qke85SCaOUfh36v",
				"acbJZUzURCLBTIcRkvpVDLRJ4Snt9oMcH7NkI3do");
		}
	}
}