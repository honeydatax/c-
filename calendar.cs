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
			lbl.Text = "year :";
			lbl.Size = new Size(140, 20);
			this.Controls.Add(lbl);
			
			
			txt.Text = "2019";
			txt.Location = new Point(10,30);;
			txt.Size = new Size(140, 20);
			this.Controls.Add(txt);



            
			button1.Size = new Size(180, 20);
            button1.Location = new Point(10, 250);
            button1.Text = "genarate year cal";
            this.Controls.Add(button1);
            button1.Click += new EventHandler(button1_Click);
        }
        private void button1_Click(object sender, EventArgs e)
        {
                            
        String a;
        a = txt.Text ;
             
		lbl3.Text ="on progress " +a ;
		try{
						
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = "bash";
			psi.UseShellExecute = false;
			psi.Arguments = "-c \"cal "  + a+ "  > " +a+"cal.txt\"";
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			Process p = Process.Start(psi);
			lbl3.Text=p.StandardOutput.ReadToEnd();
			p.WaitForExit();
			p.Close();



			String[] lines = File.ReadAllLines( a + "cal.txt");
			using (StreamWriter file =  new StreamWriter(a+".txt"))
			{
			foreach (string line in lines)
			{
				String sss;
				String s;
				s=line;
				s=s.Replace("_","");
				
				

				
				file.WriteLine(s);
			}
			}
			String ss;
			ss="";
			
			using (StreamWriter file =  new StreamWriter(a+".txt",true))
			{
				file.WriteLine(ss);
			}

			psi.FileName = "mousepad" ;
			psi.UseShellExecute = false;
			psi.Arguments = ""+a +".txt";
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			p = Process.Start(psi);
			lbl3.Text =p.StandardOutput.ReadToEnd();
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
