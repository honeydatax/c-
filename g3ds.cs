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
	public class g3d{
		public int x=0;
		public int y=0;
		public int w=600;
		public int h=300;
		public int per=25;
		public int xx=4;
		public int yy=4;
		public int zz=4;
		public int dims=8;
		public int depres=25;
		public g3d(){
			calc();
		}
		public void calc(){
			int i=0;
			int x1=0;
			int y1=0;
			int z1=0;
			int zw1=0;
			int zh1=0;
			int zw2=0;
			int zh2=0;
			int zw3=0;
			int zh3=0;
			if (xx<0)xx=0;
			if (xx>dims-1)xx=dims-1;
			if (yy<0)yy=0;
			if (yy>dims-1)yy=dims-1;
			if (zz<0)zz=0;
			if (zz>dims-1)zz=dims-1;
			z1=((dims-1)-zz)*depres;
			x1=xx;
			y1=yy;
			zw1=w-z1;
			zh1=h-z1;
			zw2=zw1/dims;
			zh2=zh1/dims;
			zw3=w-z1;
			zh3=h-z1;
			zw3=zw3/dims;
			zh3=zh3/dims;
			xx=w/2+(zw2*(x1-(dims/2)))+x;
			yy=h/2+(zh2*(y1-(dims/2)))+y;
			x1=100*zw3/zw2;
			per=x1;
		}
		public void grid(Graphics canvas,Pen p){
			int i=0;
			int x1=0;
			int y1=0;
			int z1=0;
			int zw1=0;
			int zh1=0;
			int zw2=0;
			int zh2=0;
			int zw3=0;
			int zh3=0;
			int ixx=0;
			int iyy=0;
			if (xx<0)xx=0;
			if (xx>dims-1)xx=dims-1;
			if (yy<0)yy=0;
			if (yy>dims-1)yy=dims-1;
			if (zz<0)zz=0;
			if (zz>dims-1)zz=dims-1;
			z1=((dims-1)-zz)*depres;
			x1=0;
			y1=0;
			zw1=w-z1;
			zh1=h-z1;
			zw2=zw1/dims;
			zh2=zh1/dims;
			zw3=w-z1;
			zh3=h-z1;
			zw3=zw3/dims;
			zh3=zh3/dims;
			xx=w/2+(zw2*(x1-(dims/2)))+x;
			yy=h/2+(zh2*(y1-(dims/2)))+y;
			x1=100*zw3/zw2;
			per=x1;
			canvas.DrawRectangle(p,xx,yy,zw1,zh1);
			
			for(ixx=xx;ixx<xx+zw1+1;ixx=ixx+zw2){
				canvas.DrawLine(p,ixx,yy,ixx,yy+zh1);
			}
			for(iyy=yy;iyy<yy+zh1+1;iyy=iyy+zh2){
				canvas.DrawLine(p,xx,iyy,xx+zw1,iyy);
			}
			
		}


		
	}
   public class Form1 : Form
		
		 
    {	
		public g3d d3ds= new g3d();
		public Graphics canvas;
		public Bitmap bitmap;
		public int steps;
		public int x;
		public int y;
		public int w;
		public int h;
		public int min;
		public int xxx=4;
		public int yyy=4;
		public int zzz=4;
		public int outx=0;
		public int outy=0;
		public int indis=50;		
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
			this.Text="cursor keys";
			this.KeyDown += new KeyEventHandler(Keyit);
			zzz=7;
			d3ds.xx=xxx;
			d3ds.yy=yyy;
			d3ds.zz=zzz;
			d3ds.calc();
			this.Refresh();
			
        }
        void Keyit(object sender,KeyEventArgs e){
			
			if(e.KeyCode==Keys.Down)yyy++;
			if(e.KeyCode==Keys.Up)yyy--;
			if(e.KeyCode==Keys.Left)xxx--;
			if(e.KeyCode==Keys.Right)xxx++;
			if(xxx<0){
				xxx=d3ds.dims-1;
				zzz++;
			}
			if(xxx>d3ds.dims-1){
				xxx=0;
				zzz--;
			}
			if(yyy<0){
				yyy=d3ds.dims-1;
				zzz++;
			}
			if(yyy>d3ds.dims-1){
				yyy=0;
				zzz--;
			}
			if(zzz<0){
				zzz=d3ds.dims-1;
			}
			if(zzz>d3ds.dims-1){
				zzz=0;
			}
			d3ds.xx=xxx;
			d3ds.yy=yyy;
			d3ds.zz=zzz;
			this.Text="X:"+xxx.ToString()+" Y:"+yyy.ToString()+" Z:"+zzz.ToString();
			    
			this.Refresh();

		}
        void draw(){
			d3ds.xx=xxx;
			d3ds.yy=yyy;
			d3ds.zz=zzz;
			d3ds.calc();
			canvas.FillEllipse(Brushes.Black,d3ds.xx,d3ds.yy,70*d3ds.per/100,70*d3ds.per/100);
			d3ds.zz=zzz;
			d3ds.grid(canvas,Pens.Black);
			
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
