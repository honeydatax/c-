using System;

namespace logic{
	
	class logics{
		public class Jk{
			public bool value=false;
			public bool quits=false;
			public Jk(){
				char c=' ';
				string s="";
				Console.WriteLine("JK start:");
				report();
				while(!quits){
					Console.WriteLine("'q'uit , 'r'eset , 's'et , 't'rogle?:");
					s=Console.ReadLine();
					c=' ';
					if (s.Length>0)c=s[0];
					if (c=='Q' || c=='q') qquit();
					if (c=='R' || c=='r') resets();
					if (c=='S' || c=='s') sets();
					if (c=='T' || c=='t') Trogle();
					report();
				}
			}
			public void sets(){
				value=true;
			}
			public void resets(){
				value=false;
			}
			public void Trogle(){
				value=!(value);
			}
			public void qquit(){
				quits=true;
			}
			public bool getValue(){
				return value;
			}
			public void report(){
				Console.WriteLine("JK:{0}",value);
			}
		}
		static void Main(string[] args){
			Jk JK = new logic.logics.Jk();
		}

		
	}
}






