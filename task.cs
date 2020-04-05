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
		public int steps;
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
			steps=0;
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
				ww[i].w=this.Width/10;
				ww[i].h=this.Height/10;
				ww[i].x=20*i;
				ww[i].y=ww[i].h*i+20;
				ww[i].dc=new Bitmap(ww[i].w,ww[i].h);
				fg=Graphics.FromImage(ww[i].dc);
				fg.FillEllipse(Brushes.Black,new Rectangle(0,0,ww[i].w/2,ww[i].h/2));

			}
			T= new System.Timers.Timer(300);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;

        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			steps=steps+1;
			ants(steps);
			this.Refresh();     
			
			if (steps > 6) {
				steps=-1;

			}
			T.Enabled=true;

		}
		void ants(int i){
			ww[i].x=ww[i].x+20;
			if(ww[i].x>600) ww[i].x=0;
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











