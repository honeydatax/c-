using System;

namespace logic{
	
	class logics{

		public void calenders(int year,int month){
			int [] Mday = new int[]{31,28,31,30,31,30,31,31,30,31,30,31};
			DateTime d = new DateTime();
			string space="";
			int i;
			int max=Mday[month-1];
			int wd=0;
			d=Convert.ToDateTime(Convert.ToString(1)+"/"+Convert.ToString(month)+"/"+Convert.ToString(year)+" 12:0:0");
			if (month==2){
				i=year/4;
				i=i*4;
				if(year==i)max++;
			}
			Console.WriteLine("");
			Console.WriteLine(" {0}",Convert.ToString(year));
			Console.WriteLine(" {0}",Convert.ToString(month));
			Console.WriteLine("Su Mo Tu We Th Fr Sa");
			wd=Convert.ToInt16(d.DayOfWeek);
			for(i=0;i<wd;i++){
				Console.Write("   ");
			}
			for(i=0;i<max;i++){
				space="";
				if (i < 9)space=" ";
				Console.Write("{0}{1} ",space,Convert.ToString(i+1));
				wd++;
				if(wd>6){
					Console.WriteLine("");
					wd=0;
				}
			}
			
			
			
			Console.WriteLine("");
			
		}
		static void Main(string[] args){
			logics logss = new logics();
			if (args.Length>1){
				logss.calenders(Convert.ToInt16(args[0]),Convert.ToInt16(args[1]));
			}
			
		}

		
	}
}






