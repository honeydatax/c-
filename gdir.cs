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
		public class glist{
			public lists listss = new lists();
			public string [] caption=null;
			public int x=0;
			public int y=0;
			public int w=0;
			public int h=0;
			public int size=0;
			public int length=0;
			public int ppointer=0;
			public string path=".";
			private glabel label1 = new glabel();
			public glist(int size){
				int i=0;
				length=size;
				caption=new string[size];
				for (i=0;i<size;i++)caption[i]="";
				setPath(path);
			}
			public void setPath(string s){
				path=s;
				getlist();
			}
			public void drawList(Graphics canvas){
				int i=0;
				int ii=0;
				int len=w/size;
				if (len<1)len=1;
				if (ppointer+length>listss.length)ppointer=listss.length-length;
				if (ppointer<0)ppointer=0;
				ii=length;
				if (listss.length<length)ii=listss.length;
				for (i=0;i<length;i++)caption[i]="";
				
				for(i=0;i<ii;i++){
					caption[i]=limit(listss.listss[i+ppointer],len);
				}
				for(i=0;i<length;i++)label1.drawLabel(x,y+(i*h),w,h,size,caption[i],canvas);
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
			private void getlist(){
				int i=0;
				int ii=listss.max;
				string [] llistss=Directory.GetDirectories(path);
				listss.length=0;
				if (ii>llistss.Length)ii=llistss.Length;
				for(i=0;i<ii;i++)listss.add(llistss[i].Replace(path,""));
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

		public class lists{
			public int length=0;
			public int max=1025;
			public string [] listss= new string[1025];
			public lists(){
				length=0;
			}
			public void add (string text){
				if (length<max){
					listss[length]=text;
					length++;
				}
			}
			public void remove(int index){
				int i=0;
				if (index<=length && index>-1){
					for(i=index;i<length;i++){
						listss[i]=listss[i+1];
					}
					if (length>0)length--;
				}
			}

		}
   public class Form1 : Form
		 
    {
		public gbutton [] button1 = new gbutton[2];
		public int selected=-1;
		public glist list1 = new glist(8);
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
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=0;
			y=0;
			w=(int) this.Width;
			h=(int) this.Height-20;
			this.Paint += new PaintEventHandler(OnPaints);
			list1.x=0;
			list1.y=0;
			list1.w=180;
			list1.h=30;
			list1.size=12;
			//for(i=0;i<64;i++)list1.listss.add (" item " + Convert.ToString(i));
			for(i=0;i<button1.Length;i++){
				button1[i] = new gbutton(250,10+(i*53),s1[i]);
			}

			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){
			int i=0;
			selected=list1.check(e);
			if(selected>-1){
				this.Refresh();
			}
			
			for(i=0;i<button1.Length;i++){
				if (button1[i].check(e)){
					if (i==0)list1.ppointer=list1.ppointer-list1.length;
					if (i==1)list1.ppointer=list1.ppointer+list1.length;
					i=button1.Length+1;
					this.Refresh();
				}
			}
			
		}
        void draw(){
			int i=0;
			
			list1.drawList(canvas);
			if (selected>-1)s3=" selected :" + list1.caption[selected];
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

