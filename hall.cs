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
			w=this.Width;
			h=this.Height;
			steps=5;
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			T= new System.Timers.Timer(600);
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
				h=300;
				steps=6;

			}
			T.Enabled=true;
		}
        void draw(){
			int value;
			int c1;
			int c2;
			int i;
			int ii;
			if (steps<2) steps=2;
			value=steps;
			c1=0;
        
			for (i=y;i<(y+h);i=i+value){
				canvas.DrawLine(Pens.Black,x,i,x+w,i);
			}
			
			for (ii=y;ii<(y+h);ii=ii+(value*2)){
				for (i=x;i<(x+w);i=i+(value*2)){
					canvas.DrawLine(Pens.Black,i,ii,i,ii+value);
				}
			}


			for (ii=y;ii<(y+h);ii=ii+(value*2)){
				for (i=x;i<(x+w);i=i+(value*2)){
					canvas.DrawLine(Pens.Black,i+value,ii+value,i+value,ii+(value*2));
				}
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
