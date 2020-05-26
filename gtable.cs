//mcs hello.cs -r:System.Drawing.dll -r:System.Windows.Forms.dll 

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Timers;
using System.IO;


namespace FormWithButton
{
		public class gtable{
			public tables tabless;
			public captions [] caption=null;
			public int x=0;
			public int y=0;
			public int w=0;
			public int h=0;
			public int size=0;
			public int length=0;
			public int ppointer=0;
			public string path=".";
			private glabel label1 = new glabel();
			public gtable(int size,int conls){
				int i=0;
				length=size;
				caption=new captions[size];
				for (i=0;i<size;i++)caption[i]=new captions(conls);
				tabless = new tables(conls);
			}
			public void setPath(string s){
				path=s;

			}
			public void drawList(Graphics canvas){
				int i=0;
				int ii=0;
				int i1=0;
				int len=w/size;
				if (len<1)len=1;
				if (ppointer+length>tabless.length)ppointer=tabless.length-length;
				if (ppointer<0)ppointer=0;
				ii=length;
				if (tabless.length<length)ii=tabless.length;
				for (i=0;i<length;i++){
					for (i1=0;i1<caption[i].capt.Length;i1++){
						caption[i].capt[i1]="";
					}
				}	
				
				for(i=0;i<ii;i++){
					for (i1=0;i1<caption[i].capt.Length;i1++){
						caption[i].capt[i1]=limit(tabless.tabless[i+ppointer].colsn[i1],len);
					}
				}
				for(i=0;i<length;i++){
					for (i1=0;i1<caption[i].capt.Length;i1++){
						label1.drawLabel(x+(w*i1),y+(i*h),w,h,size,caption[i].capt[i1],canvas);
					}
				}
			}
			public int check(MouseEventArgs e){
				int i=0;
				int ii=-1;
			    if(e.Button>0){
					for (i=0;i<length;i++){
						if(e.X>x && e.Y>(y+(i*h)) && e.X<x+w && e.Y < (y+((i+1)*h))){
							ii=i;
							i=length+1;
						}
					}
				}
				return ii;
			}
			private string limit(string s,int max){
				int i=0;
				string ss="";
				int m=max;
				if (m>s.Length)m=s.Length;
				for(i=0;i<m;i++){
					ss=ss+s[i];
				}
				
				return ss;
				

			}
			public class captions{
				public string [] capt;
				public captions(int cols){
					int i=0;
					capt=new string[cols];
					for(i=0;i<cols;i++)capt[i]="";
				}
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
		
		public class gbutton{
			public int x=0;
			public int y=0;
			public int w=140;
			public int h=40;
			public int size=12;
			public string caption="";
			private gcaption label1=new gcaption();
			public gbutton(int xx,int yy,string s){
				x=xx;
				y=yy;
				caption=s;
			}
			public void draw(Graphics canvas){
				label1.drawLabel(x,y,w,h,size,caption,canvas);
			}
			public bool check(MouseEventArgs e){
				bool i=false;
				
			    if(e.Button==System.Windows.Forms.MouseButtons.Left){
					
						if(e.X>x && e.Y>y && e.X<x+w && e.Y < y+h){
							i=true;
						}
					
				}
				return i;
			}

		}


		public class gcaption{
			public void drawLabel(int x,int y,int w,int h,int size,string s,Graphics canvas){
			float xn;
			float yn;
			string sss=s;
			Font ff;
			StringFormat ss;
			ss=new StringFormat();

			ff = new Font("Mono",size);
			xn=(float) x+(h/2)+8;
			yn=(float) y+8;


			canvas.FillRectangle(Brushes.DarkGray,x+(h/2),y,w-h,h);
			canvas.FillEllipse(Brushes.DarkGray,x,y,h,h);
			canvas.FillEllipse(Brushes.DarkGray,x+w-h,y,h,h);
			canvas.DrawString(sss,ff,Brushes.Black,xn,yn,ss);			

		
		}
	}

		public class tables{
			public int length=0;
			public int max=1025;
			public int cols=0;
			public colsss [] tabless=null;
			public tables(int conls){
				int i=0;
				length=0;
				cols=conls;
				tabless=new colsss[max];
				for (i=0;i<max;i++)tabless[i]= new colsss(conls);
			}
			public void add (string text){
				int i=0;
				int ii=0;
				string [] s= text.Split(';');
				ii=s.Length;
				if (ii>tabless.Length)ii=tabless.Length;
				if (length<max){
					for(i=0;i<ii;i++){
						tabless[length].colsn[i]=s[i];
					}
					length++;
				}
			}
			public void remove(int index){
				int i=0;
				if (index<=length && index>-1){
					for(i=index;i<length;i++){
						tabless[i].colsn[0]=tabless[i+1].colsn[0];
					}
					if (length>0)length--;
				}
			}
		}
			public class colsss{
				public string [] colsn;
				public colsss(int size){
					int i=0;
					colsn=new string[size];
					for (i=0;i<size;i++)colsn[i]="";
			}

		}
   public class Form1 : Form
		 
    {
		public gbutton [] button1 = new gbutton[2];
		public int selected=-1;
		public gtable gtable1 = new gtable(8,3);
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
		public string s3="";
        public Form1()
        {
			string [] s1 = new string[]{"<",">"};
			int i=0;
			int i1=0;
			char cc=' ';
			string ss1="";
			int c1=0;
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			
			x=0;
			y=0;
			w=(int) this.Width;
			h=(int) this.Height-20;
			this.Paint += new PaintEventHandler(OnPaints);
			gtable1.x=0;
			gtable1.y=0;
			gtable1.w=180;
			gtable1.h=30;
			gtable1.size=12;
			for(i=0;i<64;i++){
				ss1="";
				for(i1=0;i1<gtable1.tabless.tabless[i].colsn.Length;i1++){
					c1=65+i1;
					cc=Convert.ToChar(c1);
					ss1=ss1+cc+","+Convert.ToString(i);
					if (i1!=gtable1.tabless.tabless[i].colsn.Length-1)ss1=ss1+";";
				}
				gtable1.tabless.add (ss1);
			}
			gtable1.w=60;
			for(i=0;i<button1.Length;i++){
				button1[i] = new gbutton(590,10+(i*53),s1[i]);
				button1[i].w=40;
			}
			

			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){
			int i=0;
			selected=gtable1.check(e);
			if(selected>-1){
				this.Refresh();
			}
			
			for(i=0;i<button1.Length;i++){
				if (button1[i].check(e)){
					if (i==0)gtable1.ppointer=gtable1.ppointer-gtable1.length;
					if (i==1)gtable1.ppointer=gtable1.ppointer+gtable1.length;
					i=button1.Length+1;
					this.Refresh();
				}
			}
			
		}
        void draw(){
			int i=0;
			
			gtable1.drawList(canvas);
			if (selected>-1)s3=" selected :" + gtable1.caption[selected].capt[0];
			bar1.drawLabel(0,250,630,40,12,s3,canvas);
			for(i=0;i<button1.Length;i++){
				button1[i].draw(canvas);
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

