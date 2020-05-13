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


		public class shapes{
			public int x=0;
			public int y=0;
			public int w=1;
			public int h=1;
			public int types=0;
			public Brush brush=Brushes.Black;
			public Pen pen=Pens.Black;
			public shapes(int type){
				types=type;
			}
			public void draw(Graphics canvas){
				if (types>4)types=0;
				if(types==0)canvas.DrawLine(pen,x,y,w+x,h+y);
				if(types==1)canvas.DrawRectangle(pen,x,y,w,h);
				if(types==2)canvas.DrawEllipse(pen,x,y,w,h);
				if(types==3)canvas.FillRectangle(brush,x,y,w,h);
				if(types==4)canvas.FillEllipse(brush,x,y,w,h);
			}
		}
		 
	public class Form1 : Form
    {
		public shapes shape1= new shapes(0);
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
			shape1.x=1;
			shape1.y=1;
			shape1.w=100;
			shape1.h=100;
			this.Paint += new PaintEventHandler(OnPaints);
			
			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){

			    if (e.Button>0){
					shape1.w=e.X+1;
					shape1.h=e.Y+1;
					if (shape1.w<2)shape1.w=2;
					if (shape1.h<2)shape1.h=2;
					shape1.types++;
					this.Refresh();     
				
				}


		}
        void draw(){
			shape1.draw(canvas);

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
