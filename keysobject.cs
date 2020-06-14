using System;

namespace logic{
	
	class logics{
		public class KEYS{
			public const int max=1025;
			public string [] keys=new string[max];
			public string [] values=new string[max];
			public int length=0;
			public KEYS(){
				
			}
			public void add(string s, string ss){
				if(length<max){
					keys[length]=s.Trim();
					values[length]=ss;
					length++;
				}
			}
			public void print(string s){
				int i=0;
				int ii=s.Length;
				string ss=s.Trim();
				Console.WriteLine("{0}:",s);
				for(i=0;i<length;i++){
					if(keys[i].IndexOf(ss)==0 && keys[i].Length==ii)Console.WriteLine("			:{0}",values[i]);
				}
			}
		}
		
		
		static void Main(string[] args){
			KEYS keys = new KEYS();
			keys.add("NAME","keys");
			keys.add("VERSION","1.00.2");
			keys.add("HELP","programs tests in keys");
			keys.print("NAME");
			keys.print("VERSION");
			keys.print("HELP");
		}

		
	}
}






