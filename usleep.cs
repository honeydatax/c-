using System;

namespace logic{
	
	class logics{
		public void USleep(int args){
			string dt=DateTime.Now.ToString();
			string dt2=DateTime.Now.ToString();
			int ii;
			int contss=3200;
			long lens=(long)args;
			long lens2=0;
			int cccc=0;
			lens=lens*contss/1000;
			char cc;
				do{					
					dt=DateTime.Now.ToString();
						lens2++;
						cccc++;
				}while (lens>lens2);
			

			
		}

		static void Main(string[] args){
			logics logss = new logics();
			if(args[0]!=null)logss.USleep(Convert.ToInt32(args[0]));
		}

		
	}
}






