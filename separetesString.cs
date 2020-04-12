using System;

namespace logic{
	
	class logics{
		public string [] Dseparates( string args,string arg2,string [] arg3){
			int ii;
			int lens;
			char cc;
			string arg0=args.Trim();
			lens=arg2.Length;
			if (lens > 0 ){
				char [] c=arg2.ToCharArray();
				for (ii=0;ii<lens;ii++)	arg0=arg0.Replace(c[ii].ToString(),c[0].ToString());
				arg3=arg0.Split(c[0]);
			}
			return arg3;
			
		}

		static void Main(string[] args){
			logics logss = new logics();
			string dt=DateTime.Now.ToString();
			string [] s=null;
			int i;
			s=logss.Dseparates(dt," \\/-|:,.",s);
			for(i=0;i<s.Length;i++) Console.WriteLine("{0}: {1}",i,s[i]);
			
		}

		
	}
}






