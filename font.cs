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
		public int size;
		public string text;
		public System.Timers.Timer T ;
        public Form1()
        {
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=0;
			y=20;
			size=50;
			bx=10;
			by=bx;
			w=250;
			h=20;
			text="Planet Source Code";
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			T= new System.Timers.Timer(100);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;
        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			w=w+35;
			h=h+4;
			if (h>50){
				h=20;
				w=250;
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
			StringFormat ss;
			ss=new StringFormat();

			ff = new Font("Arial",h-10);
			if (((text.Length))*(h-10) > w) { 
				i=w/h;

			}
			xn=(float) x;
			yn=(float) y;

			canvas.DrawRectangle(Pens.White,x,y,w,h);
			canvas.DrawString(text,ff,Brushes.White,xn,yn,ss);
			canvas.DrawRectangle(Pens.Black,x+3,y+3,w,h);
			canvas.DrawString(text,ff,Brushes.Black,xn+5.0f,yn+5.0f,ss);

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
