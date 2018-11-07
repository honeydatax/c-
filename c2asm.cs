using System;
using System.Diagnostics;


namespace c2asm
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String a;
			String b;
			Console.WriteLine ("file c to convert");
			Console.Beep ();
			a=Console.ReadLine ();
			Console.WriteLine ("file asm to output");
			Console.Beep ();
			b=Console.ReadLine ();
			
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = "/usr/bin/x86_64-w64-mingw32-g++";
			psi.UseShellExecute = false;
			psi.Arguments = "-S -m16 -masm=intel -o " + b + " " + a;
			psi.RedirectStandardOutput = true;
			Process p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();
			

			psi.FileName = "mousepad" ;
			psi.UseShellExecute = false;
			psi.Arguments =  b;
			psi.RedirectStandardOutput = true;
			p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();
			
			
			
		}
	}
}
