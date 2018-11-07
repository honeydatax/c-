using System;
using System.Diagnostics;


namespace decompiler
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String a;
			String b;
			a=args[0];
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = "/usr/bin/x86_64-w64-mingw32-objdump";
			psi.UseShellExecute = false;
			psi.Arguments = "-S  " + a  ;
			psi.RedirectStandardOutput = true;
			Process p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();
			

			
			
		}
	}
}
