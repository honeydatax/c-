using System;

namespace logic{
	
	class logics{
		public class maps{
			private int count=25;
			private int col=25;
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
	
		}

		static void Main(string[] args){
			double d=0.00f;
			double dd=0.00f;
			double ddd=0.00f;
			int i=0;
			int ii=0;
			int iii=0;
			maps mp = new maps(80,20);
			for (ii=2;ii<8;ii++){
				ddd=Math.PI*2.00f*Convert.ToDouble(ii)+5.00;
				iii=Convert.ToInt16(ddd);
				ddd=ddd/2;
				for (i=0;i<iii;i++){
					d=38.00f+Convert.ToDouble(ii)*Math.Cos(Convert.ToDouble(i)/(ddd)*Math.PI);
					dd=8.00f+Convert.ToDouble(ii)*Math.Sin(Convert.ToDouble(i)/(ddd)*Math.PI);
					mp.mapstar(Convert.ToInt16(d),Convert.ToInt16(dd),'-');
				}
			}
			mp.center(8,"circle");
			mp.Println();	
		}

		
	}
}






