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
			Console.WriteLine ("file com file to output");
			Console.Beep ();
			b=Console.ReadLine ();
			
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = "/usr/bin/x86_64-w64-mingw32-g++";
			psi.UseShellExecute = false;
			psi.Arguments = "-S -m16 -masm=intel -o " + b + ".asm " + a;
			psi.RedirectStandardOutput = true;
			Process p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();

			String[] lines = File.ReadAllLines( b + ".asm");
			using (StreamWriter file =  new StreamWriter(b+".txt"))
			{
				file.WriteLine("section .text");
				file.WriteLine("org 0x100");
				file.WriteLine(" ");
				file.WriteLine("main:");
				file.WriteLine("	mov	ax,cs");
				file.WriteLine("	mov	bx,0x14");
				file.WriteLine("	add	ax,bx");
				//file.WriteLine("	mov	ds,ax");
				//file.WriteLine("	mov	es,ax");
				file.WriteLine("	mov	di,0");
				file.WriteLine("	jmp	_main");
				file.WriteLine(" ");
				file.WriteLine("_puts:");
				file.WriteLine("	push	ebp");
				file.WriteLine("	mov	ebp, esp");
				file.WriteLine("	sub	esp, 16");
				file.WriteLine("	mov	eax, DWORD [ebp+6]");
				file.WriteLine("	mov	edx, eax");
				file.WriteLine("	mov	ah,9");
				file.WriteLine("	int	0x21");
				file.WriteLine("	nop");
				file.WriteLine("	leave");
				file.WriteLine("	ret");
				file.WriteLine(" ");
				file.WriteLine("_exit:");
				file.WriteLine("	push	ebp");
				file.WriteLine("	mov	ebp, esp");
				file.WriteLine("	sub	esp, 16");
				file.WriteLine("	mov	eax, DWORD [ebp+6]");
				file.WriteLine("	mov	edx, eax");
				file.WriteLine("	mov	ax,0");
				file.WriteLine("	int	0x21");
				file.WriteLine("	nop");
				file.WriteLine("	leave");
				file.WriteLine("	ret");

				
				file.WriteLine(" ");
				file.WriteLine("___main:");
				file.WriteLine("	;put your initial code here");
				file.WriteLine("	ret");
				file.WriteLine(";end head");
				file.WriteLine(" ");
			foreach (string line in lines)
			{
				String sss;
				String s;
				s=line;
				s=s.Replace(".file",";.file");
				s=s.Replace(".code16gcc",";.code16gcc");
				s=s.Replace(".code32gcc",";.code32gcc");
				s=s.Replace(".intel_syntax",";.intel_syntax");
				s=s.Replace(".def",";.global ");
				s=s.Replace(".section",";.section ");
				s=s.Replace(".globl",";.global ");
				s=s.Replace(".ascii","db ");
				s=s.Replace(".text","db \"$\\0\"");
				s=s.Replace("OFFSET","");
				s=s.Replace("PTR","");
				s=s.Replace("FLAT:","");
				s=s.Replace(".ident",";.ident");
				s=s.Replace(".align",";.align");
				s=s.Replace(".section",";.section");
				s=s.Replace(".ident",";.ident");
				s=s.Replace("\\12","\",13,10,\"");
				s=s.Replace("\\13","\",13,10,\"");
				s=s.Replace("\\10","\",13,10,\"");
				
				if (s.Contains(".space"))
				{
					s=s.Replace(".space","	times ");
					s=s+"	db \" \"";
				}
				
				if (s.Contains("[ebp+"))
				{
					int iii;
					int iiii;
					int iiiii;
					String ssss;

					iii=s.IndexOf("[ebp+",0);
					iiii=s.IndexOf("]",iii);
					iiiii=iiii-iii;
					sss=s.Substring(iii,iiiii);
					ssss=sss.Substring(5,iiiii-5);
					Int32.TryParse(ssss,out iii);
					iii=iii-2;
					s=s.Replace(sss,"[ebp+" + (iii.ToString()));


				}
				


				
				if (s.Contains("movzx"))
					{
					if (s.Contains("WORD"))
					{

						if (s.Contains("esi"))
						{
						
							s=s.Replace("movzx	esi","xor	esi,esi\n	mov si");	
							goto escapesf;
						}

						if (s.Contains("edi"))
						{

						s=s.Replace("movzx	edi","xor	edi,edi\n	mov");	
						goto escapesf;
						}

						if (s.Contains("ecx"))
						{
						
							s=s.Replace("movzx	ecx","xor	ecx,ecx\n	mov cx");	
							goto escapesf;
						}



						if (s.Contains("edx"))
						{
						
							s=s.Replace("movzx	edx","xor	edx,edx\n	mov dx");	
							goto escapesf;
						}


						if (s.Contains("ebx"))
						{
							s=s.Replace("movzx	ebx","xor	ebx,ebx\n	mov bx");	
							goto escapesf;
						}


						if (s.Contains("eax"))
						{
							s=s.Replace("movzx	eax","xor	eax,eax\n	mov ax");	
							goto escapesf;
						}
					
					
				


					}
				if (s.Contains("BYTE"))
				{
				

						if (s.Contains("ecx"))
						{
						
							s=s.Replace("movzx	ecx","xor	ecx,ecx\n	mov cl");	
							goto escapesf;
						}



						if (s.Contains("edx"))
						{
						
							s=s.Replace("movzx	edx","xor	edx,edx\n	mov dl");	
							goto escapesf;
						}


						if (s.Contains("ebx"))
						{
							s=s.Replace("movzx	ebx","xor	ebx,ebx\n	mov bl");	
							goto escapesf;
						}


						if (s.Contains("eax"))
						{
							s=s.Replace("movzx	eax","xor	eax,eax\n	mov al");	
							goto escapesf;
						}
					
	


				
				}
	
			}



				
				escapesf:


				
				file.WriteLine(s);
			}
			}
			String ss;
			ss="section .data";
			
			using (StreamWriter file =  new StreamWriter(b,true))
			{
				file.WriteLine(ss);
			}

			psi.FileName = "nasm" ;
			psi.UseShellExecute = false;
			psi.Arguments = "-o "+b +" "+b+".txt ";
			psi.RedirectStandardOutput = true;
			p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();
			
			
			
		}
	}
}
