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
		public int steps;
		public int min;
		public string text;
		public System.Timers.Timer T ;
        public Form1()
        {
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=0;
			y=0;
			
			w=this.Width;
			h=this.Height;
			steps=2;
			min=w/24;
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			T= new System.Timers.Timer(600);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;
        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;

			this.Refresh();     
			min=min/12+min;
		    if (min > 600) {
				min=w/24;
			}
			
			T.Enabled=true;
		}
        void draw(){
			int value;
			int c1;
			int c2;
			int i;
			int ii;
			ii=256;
			if (steps<2) steps=2;
			value=steps;
			c1=0;
        
			for (i=0;i<9;i++){
				canvas.DrawLine(Pens.Black,(w/2-min/2)+((min/8)*i),y,((w/8)*i),y+h);
				canvas.DrawLine(Pens.Black,x,(h*(ii))/256,x+w,(h*(ii))/256);
				ii=ii/2;
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
