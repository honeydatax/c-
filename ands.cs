using System;

namespace logic{
	
	class logics{
		public class ANDS{
			public bool A=false;
			public bool B=false;
			public bool value=false;
			public bool quits=false;
			public ANDS(){
				char c=' ';
				string s="";
				Console.WriteLine("AND start:");
				while(!quits){
					Console.WriteLine("door A value?:");
					c=' ';
					c=inpust();
					
					if (c=='t' || c=='f') setA(Trues(c));
					Console.WriteLine("door B value?:");
					if (c!='q')c=inpust();
					if (c=='t' || c=='f') setB(Trues(c));
					report();
				}
			}
			public char inpust(){
				bool quitss=false;
				string s="";
				char c=' ';
				while(!quitss){
					Console.WriteLine("door 't'rue or 'f'alse?:");
					s=Console.ReadLine();
					c=' ';
					if (s.Length>0)c=s[0];
					if (c=='Q' || c=='q'){
						 quitss=qquit();
						 c='q';
					}
					if (c=='F' || c=='f'){
						 c='f';
						 quitss=true;
					}
					
					if (c=='T' || c=='t'){ 
						c='t';
						quitss=true;
					}
					
				}
				
				return c;
			}
			public bool Trues(char c){
				bool cc=true;
				if (c=='f')cc=false;
				return cc;
			}
			public void calc(){
				value=getA() && getB();
			}
			public bool qquit(){
				quits=true;
				return quits;
			}
			public bool getValue(){
				calc();
				return value;
			}
			public bool getA(){
				return A;
			}
			public bool getB(){
				return B;
			}

			public void setA(bool b){
				A=b;
			}
			public void setB(bool b){
				B=b;
			}
			public void report(){
				Console.WriteLine("{0} & {1} = {2}",getA(),getB(),getValue());
				Console.WriteLine("-------------------------------");
			}
		}
		static void Main(string[] args){
			ANDS Ands = new ANDS();
		}

		
	}
}






