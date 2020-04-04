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
			T= new System.Timers.Timer(4000);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;
        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			this.Refresh();     
			T.Enabled=true;
		}
		private string Rigths(string s,int lens){
			int i;
			int l;
			string ss;
			l=s.Length;
			char [] a;
			a=s.ToCharArray();
			ss="";
			if (lens<s.Length) l = lens;
			this.Text=Convert.ToString(l);
			for(i=0;i<l;i++){
				ss=ss+a[i].ToString();
			}
			return ss;
		}
        void draw(){
			int value;
			int i ;
			float xn;
			float yn;
			Font ff;
			string text2;
			text2="";
			StringFormat ss;
			ss=new StringFormat();
			ff = new Font("Arial",h-10);
			text="";
			for (i=0;i<9;i++){
				text=text+Convert.ToString(rnds.Next(49)+1);
				if (i != 9) text=text+"-";
		}
			text2=text;
			if ((text.Length)*h-10 > w){
				i=w/h;
				text2=Rigths(text,i);
			}
			xn=x;
			yn=y;
			canvas.DrawRectangle(Pens.Silver,x,y,w,h);
			canvas.DrawString(text2,ff,Brushes.Silver,xn,xn,ss);
			canvas.DrawRectangle(Pens.Black,x+1,y+1,w,h);
			canvas.DrawString(text2,ff,Brushes.Black,xn+5.0f,xn+5.0f,ss);

			
			
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
