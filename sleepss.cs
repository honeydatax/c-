using System;

namespace logic{
	
	class logics{
		public void Dsleeps( int args){
			string dt=DateTime.Now.ToString();
			string dt2=DateTime.Now.ToString();
			int ii;
			int lens=0;
			char cc;
			if (args > 0 ){
				do{
					dt=DateTime.Now.ToString();
					if(dt!=dt2){
						dt2=dt;
						lens++;
					}
				}while (lens<args);
			}

			
		}

		static void Main(string[] args){
			logics logss = new logics();
			if (args[0]!=null) logss.Dsleeps(Convert.ToInt16(args[0]));
		}

		
	}
}






