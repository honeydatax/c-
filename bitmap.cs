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
		public int counter;
		public int size;
		public string text;
		public Bitmap img ;
		public Graphics fg;
		public System.Timers.Timer T ;
        public Form1()
        {
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=10;
			y=10;
			size=50;
			w=540;
			h=30;
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			img=new Bitmap(64,64);
			fg=Graphics.FromImage(img);
			fg.DrawLine(Pens.Black,32,0,64,64);
			fg.DrawLine(Pens.Black,0,64,32,0);
			fg.DrawLine(Pens.Black,0,63,64,63);

			T= new System.Timers.Timer(300);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;
        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			x=x+10;
			if (x > 600) {
				x=0;
				y=y+50;
			}
			if (y > 200) {
				x=0;
				y=10;
			}

			this.Refresh();     
			T.Enabled=true;
		}
        void draw(){
			canvas.DrawImage(img,x,y);
			
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
