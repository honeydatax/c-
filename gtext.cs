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
		public class gtext{
			public string [] caption=null;
			public string [] text=null;
			public int [] cursor=null;
			public int x=0;
			public int y=0;
			public int w=0;
			public int h=0;
			public int size=0;
			public int length=0;
			public bool [] focus=null;
			private glabel label1 = new glabel();
			public gtext(int size){
				int i=0;
				length=size;
				cursor=new int[size];
				text=new string[size];
				caption=new string[size];
				focus=new bool[size];
				for (i=0;i<size;i++)cursor[i]=0;
				for (i=0;i<size;i++)text[i]="";
				for (i=0;i<size;i++)caption[i]="";
				for (i=0;i<length;i++)focus[i]=false;
				focus[0]=true;
			}
			public void drawtext(Graphics canvas){
				int i=0;
				for(i=0;i<length;i++){
					showcaption(i);
					label1.drawLabel(x,y+(i*h),w,h,size,caption[i],canvas);
				}
			}
			public int check(KeyPressEventArgs e){
				int i=0;
				int ii=-1;
			    if(e.KeyChar>0){
					for (i=0;i<length;i++){
						if(focus[i]){
							if(e.KeyChar>=' ')insert(e.KeyChar,i);
							if(Convert.ToInt16(e.KeyChar)==8)delets(i);
							
							
							ii=i;
							i=length+1;
						}
					}
				}
				return ii;
			}
			public int keys(KeyEventArgs e){
				int i=0;
				int ii=-1;
				int iii=0;
					for (i=0;i<length;i++){
						if(focus[i]){
							if(e.KeyCode==Keys.Left)backs(i);
							if(e.KeyCode==Keys.Right)rigth(i);
							if(e.KeyCode==Keys.Home)cursor[i]=0;
							if(e.KeyCode==Keys.End)cursor[i]=text[i].Length;
							if(e.KeyCode==Keys.Up || e.KeyCode==Keys.PageUp){
								for(iii=0;iii<length;iii++){
									if (focus[iii]==true){
										focus[iii]=false;
										iii=iii-1;
										if (iii<0)iii=0;
										focus[iii]=true;
									}
								}
							}
							if(e.KeyCode==Keys.Down || e.KeyCode==Keys.PageDown){
								for(iii=0;iii<length;iii++){
									if (focus[iii]==true){
										focus[iii]=false;
										iii=iii+1;
										if (iii>=length)iii=length-1;
										focus[iii]=true;
									}
								}

							}
							if(e.KeyCode==Keys.Enter){
								for(iii=0;iii<length;iii++){
									if (focus[iii]==true){
										focus[iii]=false;
										iii=iii+1;
										if (iii>=length)iii=0;
										focus[iii]=true;
									}
								}

							}

							ii=i;
							i=length+1;
						}
					}

				return ii;
			}

			public void showcaption(int index){
				int i=0;
				int start=0;
				int end=text[index].Length;
				int len = w/size-1;
				int half=len / 2;
				if (len<-1)len = 1;
				if (text[index].Length>len){
					if(cursor[index]+half>text[index].Length){
						end=text[index].Length;
						start=end-len;
					}else{
						end=cursor[index]+half;
						start=end-len;
					}
					if(start<0){
						start=0;
						end=start+len;
					}
					if(end>text[index].Length){
						end=text[index].Length;
					}
				}
				caption[index]="";
				for(i=start;i<end;i++){
					if (cursor[index]==i)caption[index]=caption[index]+"|";
					caption[index]=caption[index]+text[index][i];
				}
				if (cursor[index]>=end)caption[index]=caption[index]+"|";
			}
			public void insert(char c,int index){
				string ss="";
				int i=0;
				if (cursor[index]>text[index].Length) cursor[index]=text[index].Length;
				
				for (i=0;i<text[index].Length;i++){
					if(cursor[index]==i)ss=ss+c;
					ss=ss+text[index][i];
				}
				if (cursor[index]>=text[index].Length)ss=ss+c;
					text[index]=ss;
					cursor[index]++;
			}
		public void backs(int index){
			cursor[index]--;
			if (cursor[index]<0)cursor[index]=0;
		}
		public void rigth(int index){
			cursor[index]++;
			if (cursor[index]>text[index].Length)cursor[index]=text[index].Length;
		}
		
		public void delets(int index){
				string ss="";
				int i=0;
				
				if (cursor[index]>text[index].Length) cursor[index]=text[index].Length;			
				for (i=0;i<text[index].Length;i++){
					if (cursor[index]-1!=i && cursor[index]!=0)ss=ss+text[index][i];
				}
			text[index]=ss;
		}
}
		public class glabel{
			public void drawLabel(int x,int y,int w,int h,int size,string s,Graphics canvas){
			float xn;
			float yn;
			string sss=s;
			Font ff;
			StringFormat ss;
			ss=new StringFormat();

			ff = new Font("Mono",size);
			xn=(float) x+8;
			yn=(float) y+8;


			canvas.FillRectangle(Brushes.Black,x,y,w,h);
			canvas.DrawRectangle(Pens.White,x+6,y+6,w-12,h-12);
			canvas.DrawString(sss,ff,Brushes.White,xn,yn,ss);			
			}
		}
		
   public class Form1 : Form
		 
    {
		public int selected=-1;
		public gtext text1 = new gtext(8);
		private glabel bar1 = new glabel();
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
			int i=0;
			this.Width=640;
			this.Height=350;
			this.Top=0;
			this.Left=0;
			x=0;
			y=0;
			w=(int) this.Width;
			h=(int) this.Height-20;
			this.Paint += new PaintEventHandler(OnPaints);
			text1.x=000;
			text1.y=0;
			text1.w=200;
			text1.h=30;
			text1.size=12;
			for(i=0;i<text1.length;i++)text1.caption[i]=" ";
			this.MouseDown += new MouseEventHandler(OnMouseDowns);
			this.KeyPress += new KeyPressEventHandler(KeyPresss);
			this.KeyDown += new KeyEventHandler(Keyit);
			this.CenterToScreen();
        }
        void OnMousemoves(object sender,MouseEventArgs e){
		}
        void OnMouseDowns(object sender,MouseEventArgs e){
		}
		void KeyPresss(object sender,KeyPressEventArgs e){
			selected=text1.check(e);
			if(selected>-1){
				this.Refresh();
			}
		}
		void Keyit(object sender,KeyEventArgs e){
			selected=text1.keys(e);
			if(selected>-1){
				this.Refresh();
			}
		}

        void draw(){
			string s="";
			text1.drawtext(canvas);
			if (selected>-1)s=text1.text[selected];
			bar1.drawLabel(0,250,630,40,12,s,canvas);
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
