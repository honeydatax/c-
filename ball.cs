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
		public int x;
		public int y;
		public int w;
		public int h;
		public int bx;
		public int by;
		public int size;
		public System.Timers.Timer T ;
        public Form1()
        {
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=0;
			y=20;
			size=50;
			bx=10;
			by=bx;
			w=(int) this.Width;
			h=(int) this.Height-50;
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			T= new System.Timers.Timer(100);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;
        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			if (x > w-size) bx=-10;
			if (y > h-size) by=-10;
			if (x < size) bx=10;
			if (y < size) by=10;
			x=x+bx;
			y=y+by;
		
			this.Refresh();     
			T.Enabled=true;	
		}
        void draw(){

			canvas.FillEllipse(Brushes.Black,new Rectangle(x-size/2,y-size/2,size,size));

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
