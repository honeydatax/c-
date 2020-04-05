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
	public class windowss{
		public int x=0;
		public int y=0;
		public int w=0;
		public int h=0;
		public Bitmap dc;
	}

   public class Form1 : Form
		
		 
    {
		public Graphics canvas;
		public Bitmap bitmap;
		public windowss [] ww;
		public int x;
		public int y;
		public int w;
		public int h;
		public int bx;
		public int by;
		public int counter;
		public int size;
		public string text;
		public Bitmap img ;
		public Graphics fg;
		public Random rnds;
		public System.Timers.Timer T ;
        public Form1()
        {
			int value;
			int i ;
			float xn;
			float yn;
			Font ff;
			StringFormat ss;
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=10;
			y=10;
			size=50;
			w=540;
			h=30;
			ss=new StringFormat();
			ff = new Font("Arial",h-10);
			rnds=new Random();
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			ww=new windowss[8];
			for (i=0;i<8;i++){
				ww[i]=new windowss();
				ww[i].x=10+i*10;
				ww[i].y=10+i*10;
				ww[i].w=this.Width/4;
				ww[i].h=this.Height/4;
				ww[i].dc=new Bitmap(ww[i].w,ww[i].h);
				fg=Graphics.FromImage(ww[i].dc);
				fg.FillRectangle(Brushes.White,0,0,ww[i].w,ww[i].h);
				fg.DrawRectangle(Pens.Black,0,0,ww[i].w,ww[i].h);
				fg.DrawString(Convert.ToString(i),ff,Brushes.Silver,2.00f,2.00f,ss);
				fg.DrawString(Convert.ToString(i),ff,Brushes.Black,5.00f,5.00f,ss);

			}
        }
        void ttimer(object sender, System.EventArgs e){
		}
        void draw(){
			int i;
			for (i=0;i<8;i++){
				drawWindows(i);
			}
			
			
		}

		void drawWindows(int i){
			canvas.DrawImage(ww[i].dc,ww[i].x,ww[i].y);		
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











