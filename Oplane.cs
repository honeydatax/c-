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
		public int per=50;
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
			ori.sky=Brushes.White;
			ori.land=Brushes.Black;
			x=0;
			y=20;
			w=(int) this.Width;
			h=(int) this.Height-h;
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			this.Text="key up & down to move plane";
			
			
			this.KeyDown += new KeyEventHandler(Keyit);
			
        }
        void Keyit(object sender,KeyEventArgs e){
			
			if(e.KeyCode==Keys.Down)ori.per=ori.per+6;
			if(e.KeyCode==Keys.Up)ori.per=ori.per-6;

			    
			if (ori.per > 94){
				ori.per=94;
			}
			if (ori.per < 6){
				ori.per=6;
			}
			this.Text=Convert.ToString(ori.per)+" % ";
				this.Refresh();     
			this.Refresh();

		}

        			
        void ttimer(object sender, System.EventArgs e){
			//T.Enabled=false;
			//T.Enabled=true;	
		}
        void draw(){
			
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
