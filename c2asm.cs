using System;
using System.Diagnostics;
using System.IO;


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
			psi.Arguments = "-S -m16 -masm=intel -o " + b + ".txt " + a;
			psi.RedirectStandardOutput = true;
			Process p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();

			String[] lines = File.ReadAllLines( b + ".txt");
			using (StreamWriter file =  new StreamWriter(b))
			{
			foreach (string line in lines)
			{
				String s;
				s=line;
				s=s.Replace("esp","sp");
				s=s.Replace("esp","sp");
				s=s.Replace("ebp","bp");
				s=s.Replace("ebp","bp");

				s=s.Replace("ESP","SP");
				s=s.Replace("ESP","SP");
				s=s.Replace("EBP","BP");
				s=s.Replace("EBP","BP");

				file.WriteLine(s);
			}
			}
			String ss;
			ss="";
			
			using (StreamWriter file =  new StreamWriter(b,true))
			{
				file.WriteLine(ss);
			}

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
