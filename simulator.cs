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
	public class painel{
		public int x=0;
		public int y=0;
		public int size=0;
		public bool ands=false;
		public bool [] bits= new bool[10];
		private drawLed led=new drawLed();		
		public painel(int xx,int yy, int sizes){
			int i=0;
			x=xx;
			y=yy;
			size=sizes;
			for (i=0;i<10;i++)bits[i]=false;
			calc();
		}
		public void drawPainel(Graphics canvas){
			int i=0;
			for(i=0;i<9;i++){
				led.drawLeds(x+(i*size),y,bits[i],size,canvas);
			}
		}
		public bool check(MouseEventArgs e){
				bool b=false;
				int i=0;
				int ii=-1;
				int xx=0;
				int yy=0;
			    if (e.Button>0){
					for(i=0;i<8;i++){
						if (e.X>(x+(i*size)) && e.Y >y && e.X<(x+((i+1)*size)) && e.Y<(y+size)){
					
							ii=i;
							b=true;
							i=9;
							trogle(ii);
						}
					}
					
				}
			return b;
		}
			public void exange(int index ,bool b){
				bits[index]=b;
				calc();
			}
			public void calc(){
				int i=0;
				if (ands){
					bits[8]=bits[0];
					for (i=0;i<8;i++)bits[8]=bits[8] && bits[i];
				}else{
					bits[8]=false;
					for (i=0;i<8;i++)bits[8]=bits[8] || bits[i];
				}
				

			}
			public void trogle(int index ){
				bits[index]=!bits[index];
				calc();
			}

	}
	public class drawLed{
		public void drawLeds(int x,int y, bool on,int size,Graphics canvas){
			if (on){
				canvas.FillEllipse(Brushes.White,new Rectangle(x,y,size,size));
				canvas.DrawEllipse(Pens.Black,new Rectangle(x,y,size,size));
			}else{
				canvas.FillEllipse(Brushes.Black,new Rectangle(x,y,size,size));
				canvas.DrawEllipse(Pens.White,new Rectangle(x,y,size,size));
			}
		}
	}
   public class Form1 : Form
		
		 
    {
		public painel led1=new painel(10,100,20);		
		public painel led2=new painel(10,150,20);		
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
			y=0;
			led1.ands=true;
			led2.ands=false;
			w=(int) this.Width;
			h=(int) this.Height-20;
			this.Paint += new PaintEventHandler(OnPaints);
			
			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){
			if(led1.check(e) || led2.check(e)) this.Refresh();     
		}
        void draw(){
			led1.drawPainel(canvas);
			led2.drawPainel(canvas);
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
