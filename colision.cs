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
	    public int colision;
	    public int counter;
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
	    public int clocker;
	    public int raised;

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
			w=this.Width;
			h=this.Height;
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			ww=new windowss[2];

			for (i=0;i<2;i++){

				ww[i]=new windowss();
				ww[i].w=this.Width/10;
				ww[i].h=this.Height/10;
				ww[i].x=0;
				ww[i].y=this.Height/2;
				ww[i].dc=new Bitmap(ww[i].w,ww[i].h);

				fg=Graphics.FromImage(ww[i].dc);
				if (i == 0) fg.FillEllipse(Brushes.Black,new Rectangle(0,0,ww[i].w/2,ww[i].h/2));
				if (i == 1) fg.FillEllipse(Brushes.White,new Rectangle(0,0,ww[i].w/2,ww[i].h/2));
        
			}
			ww[1].x=ww[1].x-ww[1].w;
			bx=10;
			by=10;


			T= new System.Timers.Timer(300);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;

        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			ants();
			if (raised==1) {
				this.Refresh();

			}
			T.Enabled=true;

		}
		void ants(){

			int x0h;
			int x1h;
			int x2h;
			int x3h;
			x0h=ww[0].x + ww[0].w/2;
			x1h=ww[1].x + ww[0].w/2;
			if (clocker > 1) clocker=0;
			if (clocker==0 && ww[0].colision==0) ww[clocker].x=ww[clocker].x+20;
			if (clocker==0 && ww[clocker].x > 600) ww[clocker].x=0;
			if (clocker==1 && ww[0].colision==0) ww[clocker].x=ww[clocker].x-20;
			if (clocker==1 && ww[clocker].x < ww[clocker].w ) ww[clocker].x=w-ww[1].w;

			if (ww[1].colision==0 && ww[0].colision==0  && ww[0].counter==0 && ww[1].counter==0 && x1h < x0h+50  && x1h > x0h){
	        		this.Text = "colision";
					ww[0].colision=1;
					ww[1].colision=1;
					ww[0].counter=10;
					ww[1].counter=10;
			}
			ww[0].counter=ww[0].counter-1;
			ww[1].counter=ww[1].counter-1;
			if (ww[0].counter < 0) ww[0].counter = 0; 
			if (ww[1].counter < 0) ww[1].counter = 0 ;
	
			if (ww[0].colision==1 && ww[0].counter == 0) ww[0].x=0;
			if (ww[1].colision==1 && ww[1].counter == 0) ww[1].x=w-ww[1].w;
			if (ww[0].counter == 0 && ww[0].colision==1) { 
				ww[0].colision=0;
				this.Text = "ON RUN";
			}
			if (ww[1].counter == 0 && ww[1].colision==1) ww[1].colision=0;
			if (ww[0].counter == 0) ww[0].colision=0;
			if (ww[1].counter == 0) ww[1].colision=0;
			if (clocker == 1) raised=1;
			clocker=clocker+1;



		}
        void draw(){
			int i;
			raised=0;
			for (i=0;i<2;i++){
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











