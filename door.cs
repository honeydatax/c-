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
	public class door{
		public int x=0;
		public int y=0;
		public int w=600;
		public int h=300;
		private int v=28;
		private int vv=28;
		private int hh=290;
		private int ww=300;
		public int ndoor=0;
		private int nndoor=0;
		public int [] axxx= new int[50];
		public int [] ayyy= new int[50];
		public int [] awww= new int[50];
		public int [] ahhh= new int[50];
		private string [] s= new string[50];
		public string caption="";
		public door(){
			
		}
		public void draw(Graphics canvas){
			int www=0;
			int hhh=0;
			int hhhh=h/2;
			int wwww=v;
			bool exits=false;
			vv=v;
			ww=w/2;
			hh=h-10;
			hhh=8;
			www=ww-v*2;
			int i=0;
			canvas.DrawRectangle(Pens.Black,x,y,w,hh);
			canvas.DrawLine(Pens.Black,x,y,w+x,hh+y);
			canvas.DrawLine(Pens.Black,w+x,y,x,hh+y);
			i=0;
			while(!exits){
				nndoor=i;
				canvas.FillRectangle(Brushes.Black,ww+30+((hhh*2)*i),hhhh-((hhh*2)*i)/2,hhh,((hhh*2)*i));
				axxx[i]=ww+30+((hhh*2)*i);
				ayyy[i]=hhhh-((hhh*2)*i)/2;
				awww[i]=hhh;
				ahhh[i]=((hhh*2)*i);
				hhh=hhh+2;
				i++;
				ndoor=i;
				if (((hhh*2)*i)>ww)exits=true;
			}
			for (i=0;i<ndoor;i++){
				s[i]="door "+i.ToString();
			}
		}
		public int check(MouseEventArgs e){
			int i=0;
			int ii=-1;
			caption="";
			for (i=0;i<ndoor;i++){
				if(e.X>axxx[i] && e.Y>ayyy[i] && e.X < awww[i]+axxx[i] && e.Y < ahhh[i]+ayyy[i] && e.Button>0){
					caption=s[i];
					ii=i;
					i=ndoor+2;
					
				}
			}
			return ii;
		}
	}
   public class Form1 : Form
		
		 
    {
		public door door1=new door();
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
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=0;
			y=0;
			w=(int) this.Width;
			h=(int) this.Height-20;
			this.Paint += new PaintEventHandler(OnPaints);
			
			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){
			int i=door1.check(e);
			    if (i>-1){
					this.Text=door1.caption;
					this.Refresh();     
				}
				

		}
        void draw(){
			door1.draw(canvas);
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
