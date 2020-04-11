using System;

namespace logic{
	
	class logics{
		public string DosDrivers ( string args){
			int ii;
			int lens;
			char cc;
			string s="";
			string arg0=args.Trim();
			arg0=arg0.ToUpper();
			arg0=arg0.Replace("/","\\");
			int i=arg0.IndexOf(":");
			lens=arg0.Length;
			if (i > 0 ){
				char [] c=arg0.ToCharArray();
				for (ii=0;ii<i;ii++){	
					if (ii<i)s=s+c[ii].ToString();
				}
			


				cc=c[0];

				if (c[0]>='0' && c[0]<='9') {
					ii=Convert.ToInt16(s);
					ii=ii+65;
					cc=Convert.ToChar(ii);
				}
				arg0=cc.ToString();
				for (ii=0;ii<lens;ii++){
					if (ii>=i)arg0=arg0+c[ii].ToString();
				}
			}
			return arg0;
		}

		static void Main(string[] args){
			logics logss = new logics();
			if (args[0]!=null){
				Console.WriteLine("out: {0}.!",logss.DosDrivers(args[0]));
			}
		}

		
	}
}






