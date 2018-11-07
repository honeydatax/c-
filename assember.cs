using System;
using System.Diagnostics;


namespace assember
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String a;
			String b;
			Console.WriteLine ("file asm to compile");
			Console.Beep ();
			a=Console.ReadLine ();
			Console.WriteLine ("file com file to output");
			Console.Beep ();
			b=Console.ReadLine ();
			
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = "/usr/bin/x86_64-w64-mingw32-as";
			psi.UseShellExecute = false;
			psi.Arguments = "-o  " + b + ".o  " + a + "";
			psi.RedirectStandardOutput = true;
			Process p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();
			
			psi = new ProcessStartInfo();
			psi.FileName = "/usr/bin/x86_64-w64-mingw32-ld";
			psi.UseShellExecute = false;
			psi.Arguments = "-o  " + b + " " + b + ".o -lmsvcrt";
			psi.RedirectStandardOutput = true;
			p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();
			

			

			
			
		}
	}
}
