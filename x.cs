using System;

namespace logic{
	
	class logics{
		public class X{
			public int xx=0;
			public X(){
				print();
			}
			private void print(){
				string s="";
				if (xx>0)s=spaces(xx);
				s=s+"X";
				Console.WriteLine("{0}",s);
			}
			public void front(){
				if(xx<78) xx++;
				print();
			}
			public void back(){
				if(xx>0) xx--;
				print();
			}

			public string spaces(int x){
				int i;
				string s="";
				for(i=0;i<x;i++)s=s+" ";
				return s;
				
			}
		}
	
		static void Main(string[] args){
			X xx = new X();
			int i;
			for (i=0;i<16;i++){
				if(i<8){
					xx.front();
				}else{
					xx.back();
				}
			}
		}

		
	}
}






