using System;

namespace logic{
	
	class logics{
		public class Logics{
			public bool [] bits= new bool[10];
			private bool exits=false;
			public Logics(){
				int index=0;
				int i=0;
				for (i=0;i<10;i++)bits[i]=false;
				report();
				while(!exits){
					
					i=inputs();
					
					if (i==8){
						exits=true;
					}else{
						exange(i,!(bits[i]));
					}
					report();
				}
			}
			private int inputs(){
				bool exitss=false;
				string s="";
				char c=' ';
				int i=0;
				Console.WriteLine("0 to 7 doors  option 8 exit");
				while(!exitss){
					i=-1;
					s=Console.ReadLine();
					if (s.Length>0)c=s[0];
					if (c>='0' && c<='8')i=Convert.ToInt16(c-48);
					
					if (i!=-1) exitss=true;
				}
				return i;
			}
			public void exange(int index ,bool b){
				bits[index]=b;
				calc();
			}
			public void calc(){
				int i=0;
				bits[8]=bits[0];
				bits[9]=false;
				for (i=0;i<8;i++)bits[8]=bits[8] && bits[i];
				for (i=0;i<8;i++)bits[9]=bits[9] || bits[i];

			}
			public void report(){
				int i=0;
				for (i=0;i<8;i++)Console.Write(bits[i].ToString()[0]+" ");
				Console.WriteLine(" = " + bits[8].ToString()[0]);
				for (i=0;i<8;i++)Console.Write(bits[i].ToString()[0]+" ");
				Console.WriteLine(" = " + bits[9].ToString()[0]);
			}
	
		}
		
		static void Main(string[] args){
			Logics logs = new Logics();
		
				
		
		}

		
	}
}






