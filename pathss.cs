using System;

namespace logic{
	
	class logics{
		public string DDPath ( string args,string args1,string args2){
			int ii;
			int lens;
			char cc;
			string arg0=args.Trim();
			int i=arg0.IndexOf(":");
			lens=arg0.Length;
			if (i > 0 ){
				arg0=arg0.Replace(args1,args2);
			}
			
			return arg0;
		}

		static void Main(string[] args){
			logics logss = new logics();
			if (args[2]!=null){
				Console.WriteLine("out: {0}.!",logss.DDPath(args[0],args[1],args[2]));
			}
		}

		
	}
}






