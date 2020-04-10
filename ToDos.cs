using System;

namespace logic{
	
	class logics{
		public string DDdos ( string args){
			int ii;
			int lens;
			char cc;
			string arg0=args.Trim();
			arg0=arg0.Replace("/","\\");
			int i=arg0.IndexOf("\\home");
			lens=arg0.Length;
			if (i > -1 ){
					arg0="C:\\USERS\\USER1"+arg0;
			}
			
			return arg0;
		}

		static void Main(string[] args){
			logics logss = new logics();
			if (args[0]!=null){
				Console.WriteLine("out: {0}.!",logss.DDdos(args[0]));
			}
		}

		
	}
}






