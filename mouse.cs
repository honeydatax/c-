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

   public class Form1 : Form
		
		 
    {
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
			    if (e.Button>0 && e.X>20 && e.Y >20){
					w=e.X-10;
					h=e.Y-10;
					this.Refresh();     
				}

		}
        void draw(){
			canvas.DrawRectangle(Pens.Black,x,y,w,h);
			canvas.DrawLine(Pens.Black,x,y,w+x,h+y);
			canvas.DrawLine(Pens.Black,w+x,y,x,h+y);


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
