using System;

namespace logic{
	
	class logics{
		public class maps{
			public int count=25;
			public int col=80;

			

			public maps(int x, int y){
				int i;
				count=y;
				col=x;
			}
	
			public void  mapstar(int x,int y,string ssss){
				
				if (x>-1 && x<col && y>-1 && y<count){
					Console.SetCursorPosition(x,y);
					Console.Write(ssss);
				}
			}
			
			public void Println(){
				int i;
				int ii;
				string s="";
			}
			
			public void pstring(int x,int y,string s){
				int i=0;
				int ii=x;
				int iii=s.Length;
				if (ii+iii>col)iii=iii+x-col;
				
					mapstar(x,y,s);
				
			}
			public void vstring(int x,int y,string s){
				int i=0;
				int ii=y;
				int iii=s.Length;
				string ssss="";
				if (ii+iii>count)iii=iii+y-count;
				for(i=0;i<iii;i++){
					ssss=s[i]+"\r\n";
				}
					mapstar(x,y,ssss);
				
			}
			public void vcenter(int x,string s){
				int y=count/2;
				y=y-s.Length/2;
				if (y<0)y=0;
				vstring(x,y,s);
			}
			public void center(int y,string s){
				int x=col/2;
				x=x-s.Length/2;
				if (x<0)x=0;
				pstring(x,y,s);
			}
			public void circle(int x,int y,int r,char s){
				double d=0.00f;
				double dd=0.00f;
				double ddd=0.00f;
				double xx=Convert.ToDouble(x);
				double yy=Convert.ToDouble(y);
				double rr=Convert.ToDouble(r);
				int i=0;
				int ii=0;
				int iii=0;
				
				ddd=Math.PI*Math.PI*rr+5.00f;
				iii=Convert.ToInt16(ddd);
				ddd=ddd/2;
				for (i=0;i<iii;i++){
					d=xx+rr*Math.Cos(Convert.ToDouble(i)/(ddd)*Math.PI);
					dd=yy+rr*Math.Sin(Convert.ToDouble(i)/(ddd)*Math.PI);
					mapstar(Convert.ToInt16(d),Convert.ToInt16(dd),s.ToString());
				}

			}
			public void horline(int x, int y, int w , char c){
				int i=x;
				int ii=w;
				string ssss="";
				for (i=x;i<x+w;i++){
					ssss=ssss+c;
				}
				mapstar(x,y,ssss);
			}
			public void fillcircle(int x,int y,int r,char s){
				int [] half=new int[2000];
				double d=0.00f;
				double dd=0.00f;
				double ddd=0.00f;
				double d1=0.00f;
				double ddd1=0.00f;
				double rr=Convert.ToDouble(r);
				string ss="";

				int i=0;
				ddd1=rr*2.00f;
				ddd=ddd1*2.00f;
				
				
				for (i=0;i<r*2;i++){
					half[i]=Convert.ToInt16(rr*Math.Cos(Convert.ToDouble(i)/ddd1*Math.PI));
					horline(x-half[i],i+(y-r),half[i]*2,s);
				}
				
			}
			public void verline(int x, int y, int h , char c){
				int i=x;
				int ii=h;
				string ssss="";
				for (i=y;i<y+h;i++){
					ssss=ssss+c+"\r\n";
				}
				mapstar(x,y,ssss);
			}
			public void grid(int x, int y, int w ,int h,int steep ,char c){
				int i=0;
				for(i=y;i<y+h;i=i+steep)horline(x,i,w,c);
				for(i=x;i<x+w;i=i+steep)verline(i,y,h,c);
			}	
			public void lrect(int x, int y, int w ,int h, char c){
				horline(x,y,w,c);
				horline(x,y+h,w,c);
				verline(x,y,h+1,c);
				verline(x+w,y,h+1,c);

			}

			public void rect(int x, int y, int w ,int h, char c){
					int i=0;
					for (i=y;i<y+h;i++){
						horline(x,i,w,c);
					}
				
			}
	
		}

		static void Main(string[] args){
			
			int ii=0;
			Console.Clear();
			maps mp = new maps(80,20);
			mp.grid(0,0,mp.col,mp.count,5,'.');
			mp.lrect(1,1,10,10,',');
			mp.rect(30,5,20,10,':');
			mp.fillcircle((mp.col/2),(mp.count)/2,8,'-');
			mp.vstring(10,2,"vertical");
			mp.pstring(1,1,"lrect");
			mp.vcenter(8,"vcenter");
			mp.center(8,"circle");
			mp.Println();	
		}

		
	}
}






