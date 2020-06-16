using System;

namespace logic{
	
	class logics{
		public class maps{
			public int count=25;
			public int col=25;
			private char [] screen= null;
			

			public maps(int x, int y){
				int i;
				count=y;
				col=x;
				screen= new char[col*count];
				for (i=0;i<(col*count);i++) screen[i]=' ';
			}
	
			public void  mapstar(int x,int y,char c){
				if (x>-1 && x<col && y>-1 && y<count)screen[y*col+x]=c;
			}
			
			public void Println(){
				int i;
				int ii;
				string s="";
				for (ii=0;ii<count;ii++){
					s="";
					for (i=0;i<col;i++)s=s+screen[ii*col+i].ToString();
					Console.WriteLine("{0}",s);
				}

			}
			
			public void pstring(int x,int y,string s){
				int i=0;
				int ii=x;
				int iii=s.Length;
				if (ii+iii>col)iii=iii+x-col;
				for(i=0;i<iii;i++){
					mapstar(i+x,y,s[i]);
				}
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
				
				ddd=Math.PI*2.00f*rr+5.00;
				iii=Convert.ToInt16(ddd);
				ddd=ddd/2;
				for (i=0;i<iii;i++){
					d=xx+rr*Math.Cos(Convert.ToDouble(i)/(ddd)*Math.PI);
					dd=yy+rr*Math.Sin(Convert.ToDouble(i)/(ddd)*Math.PI);
					mapstar(Convert.ToInt16(d),Convert.ToInt16(dd),s);
				}

			}
			public void horline(int x, int y, int w , char c){
				int i=x;
				int ii=w;
				for (i=x;i<x+w;i++){
					mapstar(i,y,c);
				}
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
			
			maps mp = new maps(80,20);
			mp.rect(30,5,20,10,':');
			for (ii=0;ii<8;ii++){
				mp.circle((mp.col/2),(mp.count)/2,ii,'-');
			}
			mp.center(8,"circle");
			mp.Println();	
		}

		
	}
}






