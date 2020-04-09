using System;

namespace logic{
	
	class logics{
		public string DDrivers ( string args){
			int ii;
			int lens;
			char cc;
			string arg0=args.Trim();
			int i=arg0.IndexOf(":");
			lens=arg0.Length;
			if (i > 0 ){
				char [] c=arg0.ToCharArray();
				cc=c[0];
				ii=Convert.ToInt16(cc);
				if (c[0]>='0' && c[0]<='9') {
					ii=ii+17;
					cc=Convert.ToChar(ii);
				}
				arg0=cc.ToString();
				for (ii=1;ii<lens;ii++)	arg0=arg0+c[ii].ToString();
			}
			
			return arg0;
		}

		static void Main(string[] args){
			logics logss = new logics();
			if (args[0]!=null){
				Console.WriteLine("out: {0}.!",logss.DDrivers(args[0]));
			}
		}

		
	}
}






