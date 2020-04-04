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
		public int steps;
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
			w=600;
			h=50;
			steps=2;
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			T= new System.Timers.Timer(300);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;
        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			steps=steps+1;
			
			this.Refresh();     
			
			if (steps > 64) {
				x=10;
				y=10;
				size=50;
				w=600;
				h=50;
				steps=2;

			}
			T.Enabled=true;
		}
        void draw(){
			int value;
			int c1;
			int c2;
			int i;
			if (steps<2) steps=2;
			value=steps;
			c1=0;
			c2=0;

			canvas.DrawLine(Pens.Black,x,y,x,y+h);
			for (i=x;i<x+w;i+=value){
				canvas.DrawLine(Pens.Black,i,y,i,y+h/4);
				if (c1==5){ 
					canvas.DrawLine(Pens.Black,i,y,i,y+h/2);
					c1=0;
				}
				if (c2==10) {
					canvas.DrawLine(Pens.Black,i,y,i,y+h);
					c2=0;
				}

				c1=c1+1;
				c2=c2+1;
			}

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
