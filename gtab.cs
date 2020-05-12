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
		public class gtab{
			public string [] caption=null;
			public int x=0;
			public int y=0;
			public int w=0;
			public int h=0;
			public int size=0;
			public int length=0;
			private int [] x1=null;
			private int [] w1=null;
			public bool [] checks=null;
			private glabel label1 = new glabel();
			private gball ball1 = new gball();
			public gtab(int size){
				int i=0;
				length=size;
				caption=new string[size];
				checks=new bool[size];
				x1=new int[size];
				w1=new int[size];
				for (i=0;i<size;i++){
					caption[i]="";
					checks[i]=false;
					x1[i]=x;
					w1[i]=w;
				}
				checks[0]=true;
			}
			public void drawtab(Graphics canvas){
				int i=0;
				int xx1=x;
				
				for(i=0;i<length;i++){
					x1[i]=xx1;
					label1.drawLabel(x1[i]+w,y,caption[i].Length*(h*10/24)+8,h,h*10/24,caption[i],canvas);
					ball1.drawBall(x1[i],y,w,h,checks[i],canvas);
					w1[i]=+caption[i].Length*(h*10/24)+w+20;
					xx1=xx1+w1[i];
					
					
				}
			}
			public int check(MouseEventArgs e){
				int i=0;
				int ii=-1;
				int iii=0;
			    if(e.Button>0){
					for (i=0;i<length;i++){
						if(e.X>x1[i] && e.Y>y && e.X<x1[i]+w1[i] && e.Y < (y+h)){
							ii=i;
							for(iii=0;iii<length;iii++)checks[iii]=false;
							checks[i]=true;
							i=length+1;
							
						}
					}
				}
				return ii;
			}
		}
		public class glabel{
			public void drawLabel(int x,int y,int w,int h,int size,string s,Graphics canvas){
			float xn;
			float yn;
			string sss=s;
			Font ff;
			StringFormat ss;
			ss=new StringFormat();

			ff = new Font("Mono",size);
			xn=(float) x+4;
			yn=(float) y+8;


			canvas.FillRectangle(Brushes.Black,x,y,w,h);
			canvas.DrawRectangle(Pens.White,x+6,y+6,w-12,h-12);
			canvas.DrawString(sss,ff,Brushes.White,xn,yn,ss);			
			}
		}

		public class gball{
			public void drawBall(int x,int y,int w,int h,bool checks,Graphics canvas){

				canvas.FillRectangle(Brushes.Black,x,y,w,h);
				
				canvas.DrawEllipse(Pens.White,x+2,y,w-4,h);
				if (checks){
					canvas.FillEllipse(Brushes.White,x+4,y,w-8,h);
					
				}
			}
		}

		public class gpanel{
			public void drawLabel(int x,int y,int w,int h,int size,Brush b,Pen p,Graphics canvas){

			canvas.FillRectangle(b,x,y,w,h);
			canvas.DrawRectangle(p,x+6,y+6,w-12,h-12);

			}
		}


		
   public class Form1 : Form
		 
    {
		public int selected=-1;
		public gtab tab1 = new gtab(3);
		private gpanel panel1 = new gpanel();
		public Graphics canvas;
		public Bitmap bitmap;
		public int steps;
		public int x;
		public int y;
		public int w;
		public int h;
		public int min;
		public System.Timers.Timer T ;
        public Form1()
        {
			int i=0;
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=0;
			y=0;
			w=(int) this.Width;
			h=(int) this.Height-20;
			this.Paint += new PaintEventHandler(OnPaints);
			tab1.x=10;
			tab1.y=20;
			tab1.w=30;
			tab1.h=30;
			selected=0;
			for(i=0;i<tab1.length;i++)tab1.caption[i]=" tab " + Convert.ToString(i);
			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){
			selected=tab1.check(e);
			if(selected>-1){
				this.Refresh();
			}
		}
        void draw(){
			Brush [] b1=new Brush[]{Brushes.Black,Brushes.White,Brushes.DarkGray};
			Pen [] p1=new Pen[]{Pens.White,Pens.DarkGray,Pens.Black};
			string s="";
			tab1.drawtab(canvas);
			if (selected>-1)s=" selected :" + tab1.caption[selected];
			if (selected>-1) panel1.drawLabel(0,50,620,280,12,b1[selected],p1[selected],canvas);
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
