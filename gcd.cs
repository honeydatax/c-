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
			lbl.Text = "label name:";
			lbl.Size = new Size(140, 20);
			this.Controls.Add(lbl);
			Label lbl1 = new Label();
			lbl1.Location = new Point(10,50);
			lbl1.Text = "output file";
			lbl1.Size = new Size(140, 20);
			this.Controls.Add(lbl1);
			lbl2.Location = new Point(10,100);
			lbl2.Text = "directory of data files:";
			lbl2.Size = new Size(140, 20);
			this.Controls.Add(lbl2);

			lbl3.Location = new Point(10,150);
			lbl3.Text = " ";
			lbl3.Size = new Size(140, 100);
			this.Controls.Add(lbl3);
			
			
			txt.Text = "my_cd";
			txt.Location = new Point(10,30);;
			txt.Size = new Size(140, 20);
			this.Controls.Add(txt);

			txt2.Text = "my.iso";
			txt2.Location = new Point(10,70);;
			txt2.Size = new Size(140, 20);
			this.Controls.Add(txt2);

			txt3.Text = "data";
			txt3.Location = new Point(10,120);;
			txt3.Size = new Size(140, 20);
			this.Controls.Add(txt3);

            
			button1.Size = new Size(140, 20);
            button1.Location = new Point(10, 250);
            button1.Text = "generate iso cd:";
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
		lbl3.Text ="on progress";
		try{
           	ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = "genisoimage" ;
			psi.UseShellExecute = false;
			psi.Arguments = "-input-charset=utf-8 -V "+a +" -o " +b +" " +c+ " ";
			psi.RedirectStandardOutput = true;
			Process p = Process.Start(psi);
			p = Process.Start(psi);
			lbl3.Text =p.StandardOutput.ReadToEnd();
			p.WaitForExit();
			p.Close();
			lbl3.Text =lbl3.Text+"\nfinish";
           }catch(IOException ee ){
			   lbl3.Text ="ERROR same data is not correct";
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
