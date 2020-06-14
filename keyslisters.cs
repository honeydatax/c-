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
			public void print(bool s){
				int i=0;
				int ii=0;
				
					if(s)ii=length-1;
					for(i=0;i<length;i++){
						if(s){
							ii=length-1-i;
						}else{
							ii=i;
						}
						
						Console.WriteLine("{0}:",keys[ii]);
						Console.WriteLine("			:{0}",values[ii]);
					}
				
				
			}
			public void separete(){
				Console.WriteLine("----------------");
			}
		}
		
		
		static void Main(string[] args){
			KEYS keys = new KEYS();
			keys.add("NAME","keys");
			keys.add("VERSION","1.00.2");
			keys.add("HELP","programs tests in keys");
			keys.print(true);
			keys.separete();
			keys.print(false);
			
		}

		
	}
}






