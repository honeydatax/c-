using System;
using System.Diagnostics;


namespace compiler
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
			psi.FileName = "/usr/bin/nasm";
			psi.UseShellExecute = false;
			psi.Arguments = "-o  " + b + "  " + a + "";
			psi.RedirectStandardOutput = true;
			Process p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();
			

			
			
		}
	}
}
