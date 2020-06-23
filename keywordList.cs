using System;

namespace logic{
	
	class logics{
		public class KEYWORDS{
			string [] keys=null;
			public KEYWORDS(string [] s){
				keys=s;
			}
			public int finds(string s){
				int i=0;
				int ii=-1;
				string ss=s.Trim();
				for(i=0;i<keys.Length;i++){
					if(string.Compare(keys[i],ss)==0){
						ii=i;
						i=keys.Length+1;
					}
				}
				return ii;
			}
			public void list(){
				int i=0;
				for(i=0;i<keys.Length;i++){
					Console.WriteLine("{0},{1}",i,keys[i]);
				}
			}
			
		}

		static void Main(string[] args){
			int i=0;
			string [] s={"HELLO","HI",
							"THERE"};
			KEYWORDS keyss = new KEYWORDS(s);
			keyss.list();
			for(i=s.Length-1;i>-1;i--)Console.WriteLine("{0},{1}",s[i],keyss.finds(s[i]));
			
			

		}

		
	}
}






