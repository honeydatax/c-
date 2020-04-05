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
		public Random rnds;
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
			rnds=new Random();
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			img=new Bitmap(64,64);
			T= new System.Timers.Timer(400);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;
        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			x = rnds.Next(320);
			y = rnds.Next(240);
			w = rnds.Next(320)+rnds.Next(320)-x  ;
			h = rnds.Next(240)+rnds.Next(240)-y  ;
			this.Refresh();     
			T.Enabled=true;
		}
        void draw(){
			canvas.FillRectangle(Brushes.Black,x,y,w,h);
			
			
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
