using System;
using System.IO;

namespace logic{
	
	class logics{
		public class Shells{
			private string command="";
			private string back="";
			private int max=32000;
			private int count=-1;
			private bool endss=false;
			public Shells(string files){
				Console.WriteLine("new command");	
				string [] list=null;
				if(files!=""){
					try{
						list=File.ReadAllLines(files);
					}catch{
						endss=true;
					}
				}
				while(!endss){
					if(files==""){
						command=Commands();
						
					}else{
						count++;
						if (count>=list.Length){
							endss=true;
							command="";
						}else{
							command=list[count];
						}
					}
					command=command.Trim();
					back=command;
					command=command.ToUpper();
					if (files!="") Console.WriteLine("{0}",command);	
					if (command.IndexOf("EXIT")>-1){
						command="";
						endss=EXIT();
					}
					if (command.IndexOf("CAT")>-1 || command.IndexOf("TYPE")>-1)command=CAT(back);
					if (command.IndexOf("BASH")>-1 || command.IndexOf("SH")>-1)command=BASH(back);	
					if (command.IndexOf("CLS")>-1 || command.IndexOf("CLEAR")>-1)command=CLEAR();
					if (command.IndexOf("DIR")>-1 || command.IndexOf("LS")>-1)command=DIR();	
					if (command.IndexOf("CAL")>-1 )command=CAL(back);	
					if (command.IndexOf("COMMAND")>-1 )command=COMMAND();	
				}
			}
			public string Commands(){
				string comm="";
				Console.Write(">>");
				comm=Console.ReadLine();
				return comm;
			}
			public string [] args(string argc){
				return argc.Split(' ');
			}
			public bool EXIT(){
				return true;
			}
			public string CLEAR(){
				Console.Clear();
				return "";
			}
			public string DIR(){
					
				string s=".";
				try{
					int i=0;
					int t=0;
					
					string [] files = Directory.GetFiles(s);
					for(i=0;i<files.Length;i++)Console.WriteLine("{0}!",files[i]);	
						t=files.Length;
						Console.WriteLine(" {0} files!",t);	
					}catch{
						Console.WriteLine("error: {0}!",s);	
					}
				return "";
			}
			public string CAT(string files){
				string ss="";
				string [] s=args(files);
				if(s.Length>1){
					try{
						ss=File.ReadAllText(s[1]);
					}catch{
						Console.WriteLine("error: {0}!",s[1]);	
					}
						Console.WriteLine("{0}!",ss);	

				}
				return "";
			}
			
			public string COMMAND(){
				Shells shells = new Shells("");
				return "";
			}
			public string BASH(string  files){
				string [] ffiles=args(files);
				Console.WriteLine("shell {0}!",files);	
				if (ffiles.Length>1){
					Shells shells = new Shells(ffiles[1]);
				}
				return "";
			}
		public string CAL(string files){
			try{
			int [] Mday = new int[]{31,28,31,30,31,30,31,31,30,31,30,31};
			DateTime d = new DateTime();
			string [] ffiles=args(files);
			int month=Convert.ToInt16(ffiles[2]);
			int year=Convert.ToInt16(ffiles[1]);
			string space="";
			int i;
			int max=Mday[month-1];
			int wd=0;
			
		  
			d=Convert.ToDateTime(Convert.ToString(1)+"/"+ffiles[2]+"/"+ffiles[1]+" 12:0:0");
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
		  }catch{
			  Console.WriteLine("");
		  }
		
			
			
			Console.WriteLine("");
			return "";
			
		}

		

		static void Main(string[] args){
			Shells shells = new Shells("");

				

		}

		
	}
}
}





