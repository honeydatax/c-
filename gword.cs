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
		public class gword{
			public string [] caption=null;
			public int x=0;
			public int y=0;
			public int w=0;
			public int h=0;
			public int size=0;
			public int length=0;
			public string text="";
			private gbox box1 = new gbox();
			private gline line1 = new gline();
			public gword(int size){
				int i=0;
				length=size;
				caption=new string[size];
				
				for (i=0;i<size;i++)caption[i]="";
			}
			public void drawview(Graphics canvas){
				int i=0;
				fline();
				box1.drawbox(x,y,w,length*(size+4),size,caption[i],canvas);
				for(i=0;i<length;i++)line1.drawLabel(x,y+(i*(size+4)),w,h,size,caption[i],canvas);
			}
			public int check(MouseEventArgs e){
				int i=0;
				int ii=-1;
			    if(e.Button>0){
					for (i=0;i<length;i++){
						if(e.X>x && e.Y>(y+i*(size+4)) && e.X<x+w && e.Y < (y+(i+1)*(size+4))){
							ii=i;
							i=length+1;
						}
					}
				}
				return ii;
			}
			private void fline(){
				string wword="";
				int i=0;
				int lline=0;
				int ccol=0;
				int ncoll=w/size;
				int pos=0;
				for(i=0;i<length;i++)caption[i]="";
				for(i=0;i<text.Length;i++){
					if(lline<length && text[i]==' '){
						caption[lline]=caption[lline]+wword;
						wword=" ";
						ccol++;
					}
					if(lline<length && text[i]>' '){
						wword=wword+text[i];
						ccol++;
					}
					if(text[i]=='\n'){
						
						ccol=0;
						caption[lline]=caption[lline]+wword;
						lline++;
						wword="";
						
						
					}

					if(ccol>ncoll){
						
						ccol=0;
						lline++;
						
						if (lline<length)caption[lline]=wword;
						wword="";
					}

					if(lline>=length){
						i=text.Length+1;
					}
						
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

		public class gline{
			public void drawLabel(int x,int y,int w,int h,int size,string s,Graphics canvas){
			float xn;
			float yn;
			string sss=s;
			Font ff;
			StringFormat ss;
			ss=new StringFormat();

			ff = new Font("Mono",size);
			xn=(float) x;
			yn=(float) y;

			canvas.DrawString(sss,ff,Brushes.White,xn,yn,ss);			
			}
		}
		public class gbox{
			public void drawbox(int x,int y,int w,int h,int size,string s,Graphics canvas){

			canvas.FillRectangle(Brushes.Black,x,y,w,h);
			

			}
		}

		
   public class Form1 : Form
		 
    {
		public int selected=-1;
		public gword word1 = new gword(8);
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
			word1.x=100;
			word1.y=20;
			word1.w=200;
			word1.h=30;
			word1.size=12;
			for(i=0;i<65;i++)word1.text=word1.text+"word cut " + Convert.ToString(i) + " ";
			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){
			selected=word1.check(e);
			if(selected>-1){
				this.Refresh();
			}
		}
        void draw(){
			string s="";
			word1.drawview(canvas);
			if (selected>-1)s=" selected :" + word1.caption[selected];
			bar1.drawLabel(0,250,630,40,12,s,canvas);
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
