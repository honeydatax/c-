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
		public class goption{
			public string [] caption=null;
			public int x=0;
			public int y=0;
			public int w=0;
			public int h=0;
			public int size=0;
			public int length=0;
			public bool [] checks=null;
			private glabel label1 = new glabel();
			private gball ball1 = new gball();
			public goption(int size){
				int i=0;
				length=size;
				caption=new string[size];
				checks=new bool[size];
				for (i=0;i<size;i++){
					caption[i]="";
					checks[i]=false;
				}
				checks[0]=true;
			}
			public void drawoption(Graphics canvas){
				int i=0;
				for(i=0;i<length;i++){
					label1.drawLabel(x+w,y+(i*(h+8))-4,caption[i].Length*(h*10/24)+8,h,h*10/24,caption[i],canvas);
					ball1.drawBall(x,y+(i*(h+8))-4,w,h,checks[i],canvas);
				}
			}
			public int check(MouseEventArgs e){
				int i=0;
				int ii=-1;
				int iii=0;
			    if(e.Button>0){
					for (i=0;i<length;i++){
						if(e.X>x && e.Y>(y+(i*(h+8))) && e.X<x+w && e.Y < (y+((i+1)*(h+8)))){
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


		
   public class Form1 : Form
		 
    {
		public int selected=-1;
		public goption option1 = new goption(5);
		private glabel bar1 = new glabel();
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
			option1.x=100;
			option1.y=20;
			option1.w=30;
			option1.h=30;
			
			for(i=0;i<option1.length;i++)option1.caption[i]=" option " + Convert.ToString(i);
			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){
			selected=option1.check(e);
			if(selected>-1){
				this.Refresh();
			}
		}
        void draw(){
			string s="";
			option1.drawoption(canvas);
			if (selected>-1)s=" selected :" + option1.caption[selected];
			bar1.drawLabel(0,300,620,40,12,s,canvas);
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
