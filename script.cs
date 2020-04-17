using System;
using System.IO;

namespace logic{
	
	class logics{
		public class Shells{
			private int max=32000;
			private int count=-1;
			private bool endss=false;
			public int terminal=78;
			public Shells(string files){
				string command="";
				string back="";
				center("new command",terminal);	
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
					runs(command,files);
				}
			}
			~Shells(){
				center("exit this shell",terminal);
			}
			public void runs(string command ,string files){
					string back="";
					string commands="";
					string [] argss=null;
					string [] argss2=null;
					string [] argss3=null;
					int i=0;
					int i1=0;
					int i2=0;					
					int i3=0;
					commands=command.Trim();
					back=commands;
					commands=commands.ToUpper();
					
					if (commands.IndexOf("FOR")>-1){
						
						argss=commands2(commands);
						argss3=commands2(back);
						if (argss.Length>1){
							argss2=args(argss[0]);
							try{
							
								if (argss2.Length>3){
									i1=Convert.ToInt16(argss2[1]);
									i2=Convert.ToInt16(argss2[2]);
									i3=Convert.ToInt16(argss2[3]);
									if (i1<i2){
										commands=argss[1];
										back=argss3[1];
										for(i=i1;i<i2;i=i+i3){
											run(commands,files,back);
										}
									}
								}
							}catch{
								center("error :for",terminal);
							}
								
						}
						commands="";
					}
					if (commands!="")run(commands,files,back);
			}
			
			public void run(string command ,string files,string back){
					string commands="";
					commands=command;
					if (files!="") center(commands,terminal);	
					if (commands.IndexOf("EXIT")>-1){
						commands="";
						endss=EXIT();
					}
					if (commands.IndexOf("CAT")>-1 || commands.IndexOf("TYPE")>-1)commands=CAT(back);
					if (commands.IndexOf("BASH")>-1 || commands.IndexOf("SH")>-1 || commands.IndexOf("COMMAND")>-1)commands=BASH(back);	
					if (commands.IndexOf("SLEEP")>-1 || commands.IndexOf("DELAY")>-1 )commands=SLEEP(back);	
					if (commands.IndexOf("ECHO")>-1 || commands.IndexOf("PRINTF")>-1 || commands.IndexOf("PRINT")>-1)commands=PRINT(back);	
					if (commands.IndexOf("CLS")>-1 || commands.IndexOf("CLEAR")>-1)commands=CLEAR();
					if (commands.IndexOf("DIR")>-1 || commands.IndexOf("LS")>-1)commands=DIR();	
					if (commands.IndexOf("CAL")>-1 )commands=CAL(back);	
					if (commands.IndexOf("DATE")>-1 )commands=DATE();	
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
			public string [] commands2(string argc){
				return argc.Split(';');
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
					for(i=0;i<files.Length;i++)center(files[i],terminal);	
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
			
			public string PRINT(string  files){
				string s="";
				int i=0;
				string [] ffiles=args(files);
				if (ffiles.Length>1){
					for(i=1;i<ffiles.Length;i++){
						s=s+ffiles[i]+" ";
					}
				}
				center(s,terminal);	
				return "";
			}
			public string BASH(string  files){
				string s="";
				string [] ffiles=args(files);
				center(files,terminal);	
				if (ffiles.Length>1)s=ffiles[1];
				Shells shells = new Shells(s);
				shells=null;
				ffiles=null;
				center(" ",terminal);
				GC.Collect();
				
				return "";
			}
			public string DATE(){
				center(DateTime.Now.ToString(),terminal);
				return "";
			}

			public string SLEEP(string files){
				int i;
				string ss="";
				string [] s=args(files);
				if(s.Length>1){
					try{
						i=Convert.ToInt16(s[1]);
						sleeps(i);
					}catch{
						center("error : not a valid number",terminal);	
					}
						

				}
				return "";
			}

			public void sleeps( int args){
			DateTime dt=DateTime.Now;
			DateTime dt2=DateTime.Now;
			int ii;
			int lens=0;
			char cc;
			if (args > 0 ){
				do{
					dt=DateTime.Now;
					if(dt.Second!=dt2.Second){
						dt2=dt;
						lens++;
					}
				}while (lens<args);
			}

			
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

			public string SString(string s, int size){
				string ss="";
				int i;
				for(i=0;i<size;i++)ss=ss+s;
				return ss;
			}
			public string SSpaces(int size){
				return SString(" ",size);
			}
			public void center(string s,int size){
				int sizes=size/2-s.Length/2;
				string ss=SSpaces(sizes);
				ss=ss+s;
				Console.WriteLine("{0}",ss);
				
			}


		static void Main(string[] args){
			string s="";
			if(args.Length>0)s=args[0];
			Shells shells = new Shells(s);

				

		}

		
	}
}
}





