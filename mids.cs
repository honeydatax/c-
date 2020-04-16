using System;

namespace logic{
	
	class logics{
		public string mid(string ss,int start,int size){
			int i;
			string s="";
			int sizes=size+start;
			int starts=start;
			if (start>ss.Length)starts=ss.Length-1;
			if (starts<0)starts=0;
			if (sizes>ss.Length)sizes=ss.Length;
			for(i=start;i<sizes;i++)s=s+ss[i];
			return s;
		}
		static void Main(string[] args){
			logics logss = new logics();
			string s="hello world hi there.";
			Console.WriteLine("{0}",s);
			Console.WriteLine("{0}",logss.mid(s,3,10));
			Console.WriteLine("{0}",logss.mid(s,3,100));
			Console.WriteLine("{0}",logss.mid(s,0,8));
			
		}

		
	}
}






