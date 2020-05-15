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
		public class garea{
			public string [] caption=null;
			public string text="";
			private string [] texts=null;
			public int cursor=0;
			public int x=0;
			public int y=0;
			public int w=0;
			public int h=8;
			public int size=8;
			public int length=0;
			public int focused=0;
			private int rstart=0;
			private int rend=0;
			private int rsize=0;
			private int nline=0;
			public bool [] focus=null;
			private glabelline label1 = new glabelline();
			public garea(int size){
				int i=0;
				length=size;
				cursor=0;
				
				caption=new string[size];
				focus=new bool[size];
				cursor=0;
				
				for (i=0;i<size;i++)caption[i]="";
				for (i=0;i<length;i++)focus[i]=false;
				focus[0]=true;
			}
			public void drawtext(Graphics canvas){
				string ss="";
				int i=0;
				texts=null;
				texts=text.Split('\n');
				for(i=0;i<length;i++){
					caption[i]="";
					if(focus[i] && i<texts.Length){
						focused=i;
						if(cursor>texts[i+nline].Length)cursor=texts[i+nline].Length;
						showcaptionfocus();
						i=length+1;
					}
				}
				for(i=0;i<length;i++){
					ss="";
					if (i<texts.Length && i!=focused)showcaption(i);
					if (i<texts.Length)ss=caption[i];
					label1.drawLabel(x,y+(i*(size+8)),w,size+8,size,ss,canvas);
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
				int iiii=0;
					
					for (i=0;i<length;i++){
						if(focus[i]){
							if(e.KeyCode==Keys.Left)backs(i);
							if(e.KeyCode==Keys.Right)rigth(i);
							if(e.KeyCode==Keys.Home)cursor=0;
							if(e.KeyCode==Keys.End)cursor=texts[i+nline].Length;
							if(e.KeyCode==Keys.Enter){
								insert('\n',focused);	
							}
							 if (e.KeyCode==Keys.PageUp){
									  nline=nline-length;
									  if(nline<0)nline=0;
							 }
							if(e.KeyCode==Keys.PageDown && texts.Length>length){
								
								if(texts.Length<nline)nline=texts.Length;
								if (nline<texts.Length-length-1)nline=nline+length;
								if(nline>=texts.Length-length-1)nline=texts.Length-length-1;
							}

							 ii=i;
							if(e.KeyCode==Keys.Up && nline>-1){
							  
								for(iiii=0;iiii<length;iiii++){
								  if(iiii==0 && focus[iiii]==true){
									  nline--;
									  if(nline<0)nline=0;
								   }else{
									if (focus[iiii]==true){
										focus[iiii]=false;
										iiii=iiii-1;
										if (iiii<0)iiii=0;
										focus[iiii]=true;
										ii=iiii;
										if (cursor>texts[iiii+nline].Length)cursor=texts[iiii+nline].Length;
										iiii=length+1;
									}
								   }
								  }
							}
							

							if(e.KeyCode==Keys.Down && focused+1<texts.Length){
								int llength=length;
								
								
								for(iiii=0;iiii<length;iiii++){
								  if(iiii==length-1 && focus[iiii]==true){
									  if (nline<texts.Length-length-1)nline++;
									  
									  if(nline>=texts.Length-length-1)nline=texts.Length-length-1;
								   }else{
								   

									if (focus[iiii]==true){
										focus[iiii]=false;
										iiii=iiii+1;
										if (iiii>=length)iiii=length-1;
										focus[iiii]=true;
										ii=iiii;
										if (cursor>texts[iiii+nline].Length)cursor=texts[iiii+nline].Length;
										iiii=length+1;
									}
								  }
								}

							}
							
							i=length+1;
						}
					}

				return ii;
			}

			public void showcaption(int index){
				int i=0;
				int start=rend-rsize;
				int end=rstart+rsize;
				if (texts[index+nline].Length<end)end=texts[index+nline].Length;
				
				if (start>texts[index+nline].Length)start=end;
				if (start<0)start=0;
				caption[index]="";
				
			  if (start!=end && start>-1 && end>-1){
				for(i=start;i<end;i++){
				
					caption[index]=caption[index]+texts[index+nline][i];
				}
				
			  }
			}
			public void showcaptionfocus(){
				int index=focused;
				int i=0;
				int start=0;
				int end=texts[index+nline].Length;
				int len = w/size-1;
				int half=len / 2;
				if (len<-1)len = 1;
				rsize=len;
				if (texts[index+nline].Length>len){
					if(cursor+half>texts[index+nline].Length){
						end=texts[index+nline].Length;
						start=end-len;
					}else{
						end=cursor+half;
						start=end-len;
					}
					if(start<0){
						start=0;
						end=start+len;
					}
					if(end>texts[index+nline].Length){
						end=texts[index+nline].Length;
					}
				}
				caption[index]="";
				rstart=start;
				rend=end;
			  
				for(i=start;i<end;i++){
					if (cursor==i)caption[index]=caption[index]+"|";
					caption[index]=caption[index]+texts[index+nline][i];
				}
				if (cursor>=end)caption[index]=caption[index]+"|";
			  
			}

			public void insert(char c,int index){
				string ss="";
				int i=0;
				if (cursor>texts[index+nline].Length) cursor=texts[index+nline].Length;
				
				for (i=0;i<texts[index+nline].Length;i++){
					if(cursor==i)ss=ss+c;
					ss=ss+texts[index+nline][i];
				}
				if (cursor>=texts[index+nline].Length)ss=ss+c;
					texts[index+nline]=ss;
					cursor++;
				text="";
				for(i=0;i<texts.Length;i++)text=text+texts[i]+"\n";
			}
		public void backs(int index){
			cursor--;
			if (cursor<0)cursor=0;
		}
		public void rigth(int index){
			cursor++;
			if (cursor>texts[index+nline].Length)cursor=texts[index+nline].Length;
		}
		
		public void delets(int index){
				string ss="";
				int i=0;
				
				if (cursor>texts[index+nline].Length) cursor=texts[index+nline].Length;			
				for (i=0;i<texts[index+nline].Length;i++){
					if (cursor-1!=i && cursor!=0)ss=ss+texts[index+nline][i];
				}
			texts[index+nline]=ss;
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

		public class glabelline{
			public void drawLabel(int x,int y,int w,int h,int size,string s,Graphics canvas){
			float xn;
			float yn;
			string sss=s;
			Font ff;
			StringFormat ss;
			ss=new StringFormat();

			ff = new Font("Mono",size);
			xn=(float) x+2;
			yn=(float) y+1;
			canvas.FillRectangle(Brushes.Black,x,y,w,h);
			canvas.DrawString(sss,ff,Brushes.White,xn,yn,ss);			
			}
		}

		
   public class Form1 : Form
		 
    {
		public int selected=-1;
		public garea area1 = new garea(12);
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
			string ss="abcdef";
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
			area1.x=0;
			area1.y=0;
			area1.w=200;
			area1.h=30;
			area1.size=12;
			for(i=0;i<64;i++){
				area1.text=area1.text+" Line :" +Convert.ToString(i) +"  ->"+ss+"\n";
				if(ss.Length<80)ss=ss+ss;
			}
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
			selected=area1.check(e);
			if(selected>-1){
				this.Refresh();
			}
		}
		void Keyit(object sender,KeyEventArgs e){
			selected=area1.keys(e);
			if(selected>-1){
				this.Refresh();
			}
		}

        void draw(){
			string s="";
			area1.drawtext(canvas);
			if (selected>-1)s=area1.caption[selected];
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
