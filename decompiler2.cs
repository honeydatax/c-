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
			lbl.Text = "input file exe file";
			lbl.Size = new Size(140, 20);
			this.Controls.Add(lbl);
			Label lbl1 = new Label();
			lbl1.Location = new Point(10,50);
			lbl1.Text = "output file .asm";
			lbl1.Size = new Size(140, 20);
			this.Controls.Add(lbl1);
			lbl2.Location = new Point(10,100);
			lbl2.Text = "___________________________:";
			lbl2.Size = new Size(140, 20);
			this.Controls.Add(lbl2);

			lbl3.Location = new Point(10,150);
			lbl3.Text = " ";
			lbl3.Size = new Size(200, 100);
			this.Controls.Add(lbl3);
			
			
			txt.Text = "hello.exe";
			txt.Location = new Point(10,30);;
			txt.Size = new Size(140, 20);
			this.Controls.Add(txt);

			txt2.Text = "hello.s";
			txt2.Location = new Point(10,70);;
			txt2.Size = new Size(140, 20);
			this.Controls.Add(txt2);


            
			button1.Size = new Size(180, 20);
            button1.Location = new Point(10, 250);
            button1.Text = "decompile file";
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
			psi.Arguments = "-c \"/usr/bin/x86_64-w64-mingw32-objdump -S  "  + a + "  > " +b +"\" ";
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			Process p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
			p.WaitForExit();
			p.Close();

			psi.FileName = "mousepad" ;
			psi.UseShellExecute = false;
			psi.Arguments =b;
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			p = Process.Start(psi);
			Console.WriteLine(p.StandardOutput.ReadToEnd());
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
