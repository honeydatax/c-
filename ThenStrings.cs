using System;

namespace logic{
	
	class logics{
		public class theString{
			public string SString(string s, int size){
				string ss="";
				int i;
				for(i=0;i<size;i++)ss=ss+s;
				return ss;
			}
			public string SSpaces(int size){
				return SString(" ",size);
			}
			public void center(string s,int size){
				int sizes=size/2-s.Length/2;
				string ss=SSpaces(sizes);
				ss=ss+s;
				Console.WriteLine("{0}",ss);
				
			}
		}
		static void Main(string[] args){
			theString s = new theString();
			string ss="";
			int i;
			for(i=0;i<17;i++){
				ss=ss+"**";
				s.center(ss,79);
			}

		}

		
	}
}






