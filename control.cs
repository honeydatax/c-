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
		public int top ;
	    public int [] order;
		public System.Timers.Timer T ;
		public int tt;
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
			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.CenterToScreen();
			ww=new windowss[8];
			order=new int[8];
			for (i=0;i<8;i++){
				ww[i]=new windowss();
				ww[i].x=10+i*(this.Width/10);
				ww[i].y=this.Height/3;
				ww[i].w=this.Width/11;
				ww[i].h=this.Height/4;
				ww[i].dc=new Bitmap(ww[i].w,ww[i].h);
				fg=Graphics.FromImage(ww[i].dc);
				order[i]=7-i;
				fg.FillRectangle(Brushes.White,0,0,ww[i].w,ww[i].h);
				fg.DrawRectangle(Pens.Black,0,0,ww[i].w,ww[i].h);
				fg.DrawString(Convert.ToString(i),ff,Brushes.Silver,2.00f,2.00f,ss);
				fg.DrawString(Convert.ToString(i),ff,Brushes.Black,5.00f,5.00f,ss);

			}
			T= new System.Timers.Timer(1100);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=false;

        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			tt=0;
			T.Enabled=true;
	
		}
        void draw(){
			int i;
			for (i=0;i<8;i++){
				drawWindows(i);
			}
			
			
		}

		void drawWindows(int i){
			canvas.DrawImage(ww[order[i]].dc,ww[order[i]].x,ww[order[i]].y);		
		}
        void OnPaints(object ender,PaintEventArgs e){
				canvas=e.Graphics;
				draw();

		}
		
        void OnMouseDowns(object sender,MouseEventArgs e){
		    /*if (e.Button>0 && e.X>20 && e.Y >20){
				w=e.X-10;
				h=e.Y-10;
				this.Refresh();     
			}*/
			int i;
			if (e.Button>0 && tt==0) {
				i=moveNext(e.X,e.Y);
				if (i>-1) { 
					tt=1;
					moveToTop(i);
					onTop();
					T.Enabled=true;
				}
				this.Refresh();
			}

		}
		void moveToTop(int n ){
			int i;
			int nw;
			int mm;
			mm=order[n];

			for (i=7;i>n-1;i--){
				nw=order[i];
				order[i]=mm;
				mm=nw;
			}
		}	


		 int moveNext(int x,int y){
			int i;
			int nw;
			int mm;
			nw=-1;
	
			for (i=7;i>-1;i--){ 
				if (x>ww[order[i]].x && x<ww[order[i]].x+ww[order[i]].w && y>ww[order[i]].y && y<ww[order[i]].y+ww[order[i]].h){
					if (nw==-1)nw=i;
					i=-1;
				}
			}

			
			return nw;
		}
		
		void onTop(){
			if (order[7]==0) this.Text="control 0 raised ";
			if (order[7]==1) this.Text="control 1 raised ";
			if (order[7]==2) this.Text="control 2 raised ";
			if (order[7]==3) this.Text="control 3 raised ";
			if (order[7]==4) this.Text="control 4 raised ";
			if (order[7]==5) this.Text="control 5 raised ";
			if (order[7]==6) this.Text="control 6 raised ";
			if (order[7]==7) this.Text="control 7 raised ";
		}



        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}











