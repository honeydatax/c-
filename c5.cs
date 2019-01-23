//mcs hello.cs -r:System.Drawing.dll -r:System.Windows.Forms.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


namespace FormWithButton
{

   public class Form1 : Form
    {
		public TextBox txt2 ;
		public TextBox txt3 ;
		public Label lbl ;
		public Label lbl1 ;
		public Label lbl2 ;
		public Label lbl3 ;
		public TextBox txt ;
        public Button button1;

        public Form1()
        {
			txt2 = new TextBox();
			txt3 = new TextBox();			
			lbl = new Label();
			// lbl1 = new Label();
			lbl2 = new Label();
			lbl3 = new Label();
			txt = new TextBox();
			button1 = new Button();

			
			lbl.Location = new Point(10, 10);
			lbl.Text = "input file c file:";
			lbl.Size = new Size(140, 20);
			this.Controls.Add(lbl);
			Label lbl1 = new Label();
			lbl1.Location = new Point(10,50);
			lbl1.Text = "outpu file";
			lbl1.Size = new Size(140, 20);
			this.Controls.Add(lbl1);
			lbl2.Location = new Point(10,100);
			lbl2.Text = "___________________________:";
			lbl2.Size = new Size(140, 20);
			this.Controls.Add(lbl2);

			lbl3.Location = new Point(10,150);
			lbl3.Text = " ";
			lbl3.Size = new Size(280, 100);
			this.Controls.Add(lbl3);
			
			
			txt.Text = "hello.c";
			txt.Location = new Point(10,30);;
			txt.Size = new Size(140, 20);
			this.Controls.Add(txt);

			txt2.Text = "hello.com";
			txt2.Location = new Point(10,70);;
			txt2.Size = new Size(140, 20);
			this.Controls.Add(txt2);


            
			button1.Size = new Size(180, 20);
            button1.Location = new Point(10, 250);
            button1.Text = "C compiler 16 bits";
            this.Controls.Add(button1);
            button1.Click += new EventHandler(button1_Click);
        }
        private void button1_Click(object sender, EventArgs e)
        {
                            
        String a;
        String b;
        String c;
		
        a = txt.Text ;
             
        b = txt2.Text ;
        c = txt3.Text ;
		lbl3.Text ="on progress " +a ;
		try{
						
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = "bash";
			psi.UseShellExecute = false;
			psi.Arguments = "-c \"/usr/bin/x86_64-w64-mingw32-g++ -S -m16 -masm=intel -o " + b + ".txt " + a+ "  2> error.txt\"";
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			Process p = Process.Start(psi);
			lbl3.Text=p.StandardOutput.ReadToEnd();
			p.WaitForExit();
			p.Close();


			psi.FileName = "mousepad";
			psi.UseShellExecute = false;
			psi.Arguments = "error.txt";
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			p = Process.Start(psi);
			p.WaitForExit();
			p.Close();




			String[] lines = File.ReadAllLines( b + ".txt");
			using (StreamWriter file =  new StreamWriter(b+".asm"))
			{
				file.WriteLine("section .text");
				file.WriteLine("org 0x100");
				file.WriteLine(" ");
				file.WriteLine("main:");
				file.WriteLine("	mov	ax,cs");
				file.WriteLine("	mov	di,0");
				file.WriteLine("	mov	si,0");
				file.WriteLine("	jmp	_main");
				file.WriteLine(" ");
				file.WriteLine("_puts:");
				file.WriteLine("	push	ebp");
				file.WriteLine("	mov	ebp, esp");
				file.WriteLine("	sub	esp, 16");
				file.WriteLine("	mov	eax, DWORD [bp+8]");
				file.WriteLine("	mov	edx, eax");
				file.WriteLine("	mov	ah,9");
				file.WriteLine("	int	0x21");
				file.WriteLine("	nop");
				file.WriteLine("	leave");
				file.WriteLine("	ret");
				file.WriteLine(" ");
				file.WriteLine("_exit:");
				file.WriteLine("	mov	ax,0");
				file.WriteLine("	int	0x21");
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

				if (s.Contains("[esp"))
				{

					s="	push sp\n	pop si\n	 	\n"+s;
					s=s.Replace("[esp","[si");


				}


				if (s.Contains("[ebp"))
				{

					s="	push bp\n	pop si\n	 	\n"+s;
					s=s.Replace("[ebp","[si");


				}



				
				if (s.Contains(".space"))
				{
					s=s.Replace(".space","	times ");
					s=s+"	db \" \"";
				}
				
				if (s.Contains("call"))
				{
					
					s="	push word 0 	;ajust 32 address  address into 16 bits\n"+s+"\n	add sp,2 	;ajust 32 address into 16 bits";


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
			
			using (StreamWriter file =  new StreamWriter(b+".asm",true))
			{
				file.WriteLine(ss);
			}

			psi.FileName = "bash" ;
			psi.UseShellExecute = false;
			psi.Arguments = "-c \"nasm -o "+b +" "+b+".asm  2> error.txt \"";
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();
			
			
			
			psi.FileName = "mousepad";
			psi.UseShellExecute = false;
			psi.Arguments = "error.txt";
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			p = Process.Start(psi);
			p.WaitForExit();
			p.Close();


		

			
			
			
			
			
			
			
			lbl3.Text ="prosses is over.";
           }catch(IOException ee ){
			   lbl3.Text =lbl3.Text + "\nERROR same data is not correct";
			   }
          
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

}
