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
	public class Orizont{
		public int x=0;
		public int y=0;
		public int w=600;
		public int h=300;
		public int per=0;
		public Brush sky =Brushes.Cyan;
		public Brush land =Brushes.Brown;
		public void draws(Graphics canvas){
			canvas.FillRectangle(sky,x,y,w,(y+h-((h*per)/100)));
			canvas.FillRectangle(land,x,y+h-((h*per)/100),w,y+((h*per)/100));
		}
		
	}
   public class Form1 : Form
		
		 
    {	
		public Orizont ori= new Orizont();
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
			y=20;
			w=(int) this.Width;
			h=(int) this.Height-h;
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			T= new System.Timers.Timer(100);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;
        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			steps=steps+1;
			this.Text=Convert.ToString(steps)+" % ";
			this.Refresh();     
			if (steps > 100){
				steps=1;
			}
			T.Enabled=true;	
		}
        void draw(){
			ori.per=100-steps;
			ori.draws(canvas);
			
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
