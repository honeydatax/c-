//mcs hello.cs -r:System.Drawing.dll -r:System.Windows.Forms.dll 

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Timers;
//using System.IO;

namespace FormWithButton
{

   public class Form1 : Form
		
		 
    {
		public Graphics canvas;
		public Bitmap bitmap;
		public int x;
		public int y;
		public int w;
		public int h;
		public int bx;
		public int by;
		public int counter;
		public int size;
		public string text;
		public System.Timers.Timer T ;
        public Form1()
        {
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=10;
			y=10;
			size=50;
			w=250;
			h=50;
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			T= new System.Timers.Timer(300);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;
        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;

			counter=counter+1;
			if (counter>60) {
				counter=0;
			}
			
			this.Refresh();     
			T.Enabled=true;
		}
        void draw(){
			int value;
			int i ;
			float xn;
			float yn;
			Font ff;
			string text2;
			StringFormat ss;
			ss=new StringFormat();
			text=Convert.ToString(counter);
			ff = new Font("Arial",h-10);
			if ((text.Length)*(h-10) > w){
				i=w/h;
				text2="";
				text2.CopyTo(0,text.ToCharArray(),0,i);
			}
			xn=x;
			yn=y;
	        canvas.DrawRectangle(Pens.Silver,x,y,w,h);
			canvas.DrawString(text,ff,Brushes.Silver,xn,xn,ss);
			canvas.DrawRectangle(Pens.Black,x+1,y+1,w,h);
			canvas.DrawString(text,ff,Brushes.Black,xn+5.0f,xn+5.0f,ss);

			
		}

        void OnPaints(object ender,PaintEventArgs e){
				canvas=e.Graphics;
				draw();

		}
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

}
