using System;

namespace logic{
	
	class logics{
		public string DDunix ( string args){
			int ii;
			int lens;
			char cc;
			string arg0=args.Trim();
			arg0=arg0.Replace("\\","/");
			int i=arg0.IndexOf(":");
			lens=arg0.Length;
			if (i > 0 ){
				i=arg0.IndexOf(":/");
				if (i > 0) {
					arg0=arg0.Replace(":","");
					arg0="/home/user1/"+arg0;
				}
				if (i < 1) {
					arg0=arg0.Replace(":","/");
					arg0="/home/user1/"+arg0;
				}
			}
			
			return arg0;
		}

		static void Main(string[] args){
			logics logss = new logics();
			if (args[0]!=null){
				Console.WriteLine("out: {0}.!",logss.DDunix(args[0]));
			}
		}

		
	}
}






