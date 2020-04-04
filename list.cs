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
		public string [] name;
		public int [] score;
        public Form1()
        {
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=10;
			y=10;
			size=50;
			w=this.Height*10/12;
			h=30;
			
			score=new int[30];
			name=new string[30];
			name[0]="loser";
			name[1]="jack";
			name[2]="bill";
			name[3]="hunter";
			name[4]="sony";
			name[5]="jonas";
			name[6]="jeny";
			name[7]="beny";
			score[0]=32000;
			score[1]=31000;
			score[2]=30000;
			score[3]=29000;
			score[4]=28000;
			score[5]=27000;
			score[6]=26000;
			score[7]=2000;
			
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
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
			canvas.DrawString(text2,ff,Brushes.Silver,xn,yn,ss);
			canvas.DrawRectangle(Pens.Black,x+1,y+1,w,h);
			canvas.DrawString(text2,ff,Brushes.Black,xn+5.0f,yn+5.0f,ss);

			
			
		}

        void OnPaints(object ender,PaintEventArgs e){
				int i;
				canvas=e.Graphics;
				for(i=0;i<8;i++){
					x=10;
					y=10+(i*h);
					text=name[i];
					draw();
					x=x+w;
					text=Convert.ToString(score[i]);
					draw();

				}

		}
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

}
