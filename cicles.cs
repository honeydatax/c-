using System;

namespace logic{
	
	class logics{
		public int Dcicles( ){
			string dt=DateTime.Now.ToString();
			string dt2=DateTime.Now.ToString();
			int ii;
			int lens=0;
			int lens2=0;
			char cc;
				do{
					dt=DateTime.Now.ToString();
				}while (dt==dt2);
				dt2=dt;
				lens=0;
				do{
					dt=DateTime.Now.ToString();
						lens++;
						lens2++;
				}while (dt==dt2);
			

			return lens;
		}

		static void Main(string[] args){
			logics logss = new logics();
			Console.WriteLine("{0}:cicles in a second",logss.Dcicles());
		}

		
	}
}






