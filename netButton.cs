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
		public class gbutton{
			public int x=0;
			public int y=0;
			public int w=140;
			public int h=40;
			public int size=12;
			public string caption="";
			private glabel label1=new glabel();
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

		public class glabel{
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
	

   public class Form1 : Form
		
		 
    {
		public gbutton [] button1 = new gbutton[6];
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
			for(i=0;i<button1.Length;i++){
				button1[i] = new gbutton(10,10+(i*53),"Buttons"+Convert.ToString(i));
			}
			button1[5].w=610;
			button1[5].caption="";
			this.Paint += new PaintEventHandler(OnPaints);
			
			this.MouseUp += new MouseEventHandler(OnMouseUps);
			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){
			int i=0;
			
			for(i=0;i<button1.Length-1;i++){
				if (button1[i].check(e)){
					button1[5].caption="Buttons"+Convert.ToString(i)+ " pressed";
					i=button1.Length+1;
					this.Refresh();
				}
			}
		}
        void OnMouseUps(object sender,MouseEventArgs e){
		}

        void draw(){
			int i=0;
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
}
