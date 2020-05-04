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
		public class canva{
			public int x=0;
			public int y=0;
			private int x1=0;
			private int y1=0;
			private int x2=0;
			private int y2=0;
			public bool todo=false;
			public int selected=0;
			public int colors=0;
			public bool visible=true;
			public Bitmap img =null;
			public Graphics fg=null;
			public bool toChange=true;
			public canva(int w,int h){
				img=new Bitmap(w,h);
			}
			public void check(MouseEventArgs e){
				bool b=false;
				if(toChange && e.Button==System.Windows.Forms.MouseButtons.Left){
					todo=true;
					b=true;
					x1=e.X;
					y1=e.Y;
				}
			}
			public bool released(MouseEventArgs e){
				bool b=false;
				if(toChange && todo && e.Button==System.Windows.Forms.MouseButtons.Left){
					b=true;
					fg=Graphics.FromImage(img);
					todo=false;
					x2=e.X-x1;
					y2=e.Y-y1;
					if (selected==0) fg.FillRectangle(Brushes.Black,x1,y1,x2,y2);
					if (selected==1) fg.DrawRectangle(Pens.Black,x1,y1,x2,y2);
					if (selected==2) fg.FillEllipse(Brushes.Black,x1,y1,x2,y2);
					if (selected==3) fg.DrawEllipse(Pens.Black,x1,y1,x2,y2);
					if (selected==4) fg.DrawLine(Pens.Black,x1,y1,x2+x1,y2+y1);
					Console.WriteLine("debug {0}",selected);
				}
				return b;
			}
			public void draws(Graphics canvas){
				canvas.DrawImage(img,x,y);
			}
		}
		public class gmenu{
			public string [] caption=null;
			public int x=0;
			public int y=0;
			public int w=0;
			public int h=0;
			public int size=0;
			public int length=0;
			public bool visible=true;
			private glabel label1 = new glabel();
			public gmenu(int size){
				int i=0;
				length=size;
				caption=new string[size];
				for (i=0;i<size;i++)caption[i]="";
			}
			public void drawMenu(Graphics canvas){
				int i=0;
				for(i=0;i<length;i++)label1.drawLabel(x,y+(i*h),w,h,size,caption[i],canvas);
			}
			public int check(MouseEventArgs e){
				int i=0;
				int ii=-1;
			    if(e.Button==System.Windows.Forms.MouseButtons.Left){
					for (i=0;i<length;i++){
						if(e.X>x && e.Y>(y+(i*h)) && e.X<x+w && e.Y < (y+((i+1)*h))){
							ii=i;
							i=length+1;
							visible=false;
						}
					}
				}
				return ii;
			}
			public bool verify(MouseEventArgs e){
				bool b=false;
				if(e.Button==System.Windows.Forms.MouseButtons.Right){
					b=true;
					visible=!visible;
				}
				return b;
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
			xn=(float) x+8;
			yn=(float) y+8;


			canvas.FillRectangle(Brushes.Black,x,y,w,h);
			canvas.DrawRectangle(Pens.White,x+6,y+6,w-12,h-12);
			canvas.DrawString(sss,ff,Brushes.White,xn,yn,ss);			
			}
		}
		
   public class Form1 : Form
		 
    {
		public int selected=-1;
		public canva canvas1 =null;
		public gmenu menu1 = new gmenu(5);
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
			h=(int) this.Height;
			this.Paint += new PaintEventHandler(OnPaints);
			canvas1=new canva(w,h);
			menu1.x=100;
			menu1.y=20;
			menu1.w=140;
			menu1.h=30;
			menu1.size=12;
			menu1.caption[0]="fill rect";
			menu1.caption[1]="rect";
			menu1.caption[2]="fill oval";
			menu1.caption[3]="oval";
			menu1.caption[4]="line";
			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.MouseUp += new MouseEventHandler(OnMouseUps);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){
			bool bb=false;
			bool b=menu1.verify(e);
			if (!b && menu1.visible){
				selected=menu1.check(e);
				canvas1.selected=selected;
			}else{
				canvas1.check(e);
			}
			if(selected>-1 || b){
					this.Refresh();
			}
		}
        void OnMouseUps(object sender,MouseEventArgs e){
			bool b=false;
			if (canvas1.todo)b= canvas1.released(e);
			if (b)this.Refresh();
		}

        void draw(){
			string s="";
			if (menu1.visible){
				canvas1.visible=!menu1.visible;
				menu1.drawMenu(canvas);
			}else{
				canvas1.visible=!menu1.visible;
				canvas1.draws(canvas);
				
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
