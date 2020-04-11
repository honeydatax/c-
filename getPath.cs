using System;

namespace logic{
	
	class logics{
		public string getPath ( string args){
			int ii;
			int lens;
			int iii;
			char cc;
			string s=".\\";
			string arg0=args.Trim();
			arg0=arg0.ToUpper();
			int i=arg0.LastIndexOf("\\");
			if (i<0)i=arg0.LastIndexOf("/");
			if (i<0)i=arg0.IndexOf(":");
			lens=arg0.Length;
			iii=arg0.LastIndexOf(".");
			if (iii<0) i=lens;
			if (i > -1 ){
				char [] c=arg0.ToCharArray();
				s="";
				for (ii=0;ii<i;ii++){
					s=s+c[ii].ToString();
				}

			}
			return s;
		}

		static void Main(string[] args){
			logics logss = new logics();
			if (args[0]!=null){
				Console.WriteLine("out: {0}.!",logss.getPath(args[0]));
			}
		}

		
	}
}






