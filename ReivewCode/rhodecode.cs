using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReivewCode
{
	class rhodecode
	{
		public void Start()
		{
			// Create the delegate for the Timer type.
			TimerCallback timeCB = new TimerCallback( PullRequestAPI );

			// Establish timer settings.
			Timer t = new Timer(
			  timeCB,             // The TimerCallback delegate type.
			  "Hello From Main",  // Any info to pass into the called method (null for no info).
			  0,                  // Amount of time to wait before starting.
			  12000 );   //一秒鐘呼叫一次 Interval of time between calls (in milliseconds).

			Console.WriteLine( "Hit key to terminate..." );
			Console.ReadLine();

		}

		internal void PullRequestAPI( object state )
		{
			string szResult = string.Empty;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create( "https://code.rhodecode.com/_admin/api" );
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			using( var streamWriter = new StreamWriter( request.GetRequestStream() ) ) {
				string json = "{ \"id\": 1, \"auth_token\": \"6094d82fefa2e6c50bc2b43c5da022913c598d95\", \"method\": \"pull\", \"args\": { \"repoid\": \"u/10101436/ReviewToolTEST\"}}";
				streamWriter.Write( json );
			}

			var httpResponse = (HttpWebResponse)request.GetResponse();
			using( var streamReader = new StreamReader( httpResponse.GetResponseStream() ) ) {
				szResult = streamReader.ReadToEnd();
			}
			Console.WriteLine( szResult );
			Console.WriteLine( DateTime.Now );
		}
	}
}
