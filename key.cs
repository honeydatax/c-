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
		public string text;
		public System.Timers.Timer T ;
        public Form1()
        {
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=10;
			y=10;
			w=540;
			h=30;
			text="";
			this.Paint += new PaintEventHandler(OnPaints);
			
			this.KeyPress += new KeyPressEventHandler(KeyPresss);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void KeyPresss(object sender,KeyPressEventArgs e){
				text=text+e.KeyChar;
				this.Refresh();     


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
