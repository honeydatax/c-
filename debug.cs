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
		public System.Timers.Timer T ;
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
			name[0]="debug:";
			name[1]="a=a+1";
			name[2]="b=b+2";
			name[3]="c=c+3";
			name[4]="d=d+4";
			name[5]="e=e*2";
			name[6]="f=f+f";
			name[7]="f=f+5";
			name[8]="f=f+8";
			score[0]=0;
			score[1]=1;
			score[2]=1;
			score[3]=1;
			score[4]=1;
			score[5]=1;
			score[6]=1;
			score[7]=1;
			score[8]=1;
			
			Paint += new PaintEventHandler(OnPaints);
			this.CenterToScreen();
			T= new System.Timers.Timer(400);
			T.Elapsed += new System.Timers.ElapsedEventHandler(ttimer);
			T.AutoReset=true;
			T.Enabled=true;

        }
        void ttimer(object sender, System.EventArgs e){
			T.Enabled=false;
			this.Refresh();
			score[1]=score[1]+1;
			score[2]=score[2]+2;
			score[3]=score[3]+3;
			score[4]=score[4]+4;
			score[7]=score[7]+5;
			score[8]=score[8]+8;
			score[5]=score[5]*2;
			score[6]=score[6]+score[6];

     
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
				for(i=0;i<9;i++){
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
