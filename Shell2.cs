using System;
using System.IO;

namespace logic{
	
	class logics{
		public class Shells{
			private int max=32000;
			private int count=-1;
			private bool endss=false;
			public int terminal=78;
			public string [] vars= new string[251];
			public string [] value= new string[251];
			private int countvar=0;
			private bool varson=false;
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
			public void Dispose(){
				center("dispose shell",terminal);
				GC.SuppressFinalize(this);
				
			}
			public void runs(string command ,string files){
					string back="";
					string back2="";
					string commands="";
					string [] argss=null;
					string [] argss2=null;
					string [] argss3=null;
					int i=0;
					int i1=0;
					int i2=0;					
					int i3=0;
					string svar="";
					int ivar=0;
					commands=command.Trim();
					back2=commands;
					commands=removespaces(commands);
					commands=commands.Replace("  "," ");					
					back=commands;
					commands=commands.ToUpper();
			
					if (commands.IndexOf("FOR")==0){
						
						argss=commands2(commands);
						argss3=commands2(back2);
						if (argss.Length>1){
							argss2=args(argss[0]);
							try{
							
								if (argss2.Length>4){
									svar=argss2[1];
									ivar=search(svar);
									if(ivar<0){
										addvar(argss2[1],"0");
										svar=argss2[1];
									}
									ivar=search(svar);
									i1=Convert.ToInt16(argss2[2]);
									i2=Convert.ToInt16(argss2[3]);
									i3=Convert.ToInt16(argss2[4]);
									if (i1<i2){
										
										for(i=i1;i<i2;i=i+i3){
											value[ivar]=Convert.ToString(i).Trim();
											commands=argss3[1];
											commands=commands.Trim();
											commands=commands.ToUpper();
											commands=removespaces(commands);
											back2=argss3[1];
											back2=back2.Trim();
											back2=removespaces(back2);
											commands=commands.Replace("  "," ");
											back2=back2.Replace("  "," ");
											run(commands,files,back2);
											
										}
									}
								}
							}catch{
								center("error :for",terminal);
							}
								
						}
						commands="";
					}
					if (commands.IndexOf("TIME")==0){
						
						argss=commands2(commands);
						argss3=commands2(back);
						if (argss.Length>1){
							argss2=args(argss[0]);
							try{
								TimeSpan t;
								DateTime dt1=DateTime.Now;

										commands=argss[1];
										back=argss3[1];
										back=back.Trim();
										run(commands,files,back);
											
								DateTime dt2=DateTime.Now;
								t=dt2-dt1;
								center("Time :"+Convert.ToString(t.Hours)+":"+Convert.ToString(t.Minutes)+":"+Convert.ToString(t.Seconds)+":"+Convert.ToString(t.Milliseconds),terminal);


								
							}catch{
								center("error :TIME",terminal);
							}
								
						}
						commands="";
					}

					if (commands.IndexOf("IF")==0){
						
						argss=commands2(commands);
						argss3=commands2(back);
						if (argss.Length>1){
							argss2=args(argss[0]);
							try{
								bool j=true;
								string h="";
								if (argss2.Length>1){
									h=argss2[1];
									h=h.Trim();
									
									if (h[0]=='0' || h=="FALSE")j=false;
								}else{
									j=false;
								}	
								if (j){
										commands=argss[1];
										
										back=argss3[1];
										back=back.Trim();
								
										run(commands,files,back);
								}			
								
							}catch{
								center("error :if",terminal);
							}
								
						}
						commands="";
					}
					

					if (commands!="")run(commands,files,back);
			}
			
			public void run(string command ,string files,string back){
					string commands="";
					commands=command.Trim();
					if (files!="" && varson) center(commands,terminal);	
					if (commands.IndexOf("EXIT")>-1){
						commands="";
						endss=EXIT();
					}
					if (commands.IndexOf("CAT")==0 || commands.IndexOf("TYPE")==0)commands=CAT(back);
					if (commands.IndexOf("BASH")==0 || commands.IndexOf("SH")==0 || commands.IndexOf("COMMAND")==0)commands=BASH(back);	
					if (commands.IndexOf("SLEEP")==0 || commands.IndexOf("DELAY")==0 )commands=SLEEP(back);	
					if (commands.IndexOf("PRINTF")==0)commands=PRINTF(back);	
					if (commands.IndexOf("ECHO")==0 || commands.IndexOf("PRINT")==0)commands=PRINT(back);	
					if (commands.IndexOf("LOGIC")==0 )commands=LOGIC(back);		
					if (commands.IndexOf("EXPR")==0 )commands=EXPR(back);		
					if (commands.IndexOf("CAL")==0 )commands=CAL(back);	
					if (commands.IndexOf("CLS")==0 || commands.IndexOf("CLEAR")==0)commands=CLEAR();
					if (commands.IndexOf("DIR")==0 || commands.IndexOf("LS")==0)commands=DIR();	
					if (commands.IndexOf("DATE")==0 )commands=DATE();
					if (commands.IndexOf("VARS")==0 )commands=VARS();		
					if (commands.IndexOf("ON")==0 )commands=ON(true);		
					if (commands.IndexOf("OFF")==0 )commands=ON(false);		
					if (commands.IndexOf("=")>-1 || commands.IndexOf("LET")==0 )commands=LET(back);							
			}
			public void addvar(string s1, string s2){
				string s="";
				if (countvar<250){
					s=s1.ToUpper();
					vars[countvar]=s;
					value[countvar]=s2;
					countvar++;
				}
			}
			public int search(string s1){
				int rets=-1;
				int i=0;
				string s=s1.ToUpper(); 
				if (countvar>0){
					for(i=0;i<countvar;i++){
						if(vars[i]==s){
							rets=i;
							i=countvar+1;
						}
					}
				} 
				return rets;
			}
			public string VARS(){
				int rets=0;
				int i=0;
				center("vars list",terminal);
				if (countvar>0){
					for(i=0;i<countvar;i++){
						center(vars[i]+"="+value[i],terminal);
					}
				} 
				return "";
			}

			public string getsvalue(int index){
				return value[index];
			}
			public string LET(string files){
				string s="";
				string sss="";
				int i=0;
				s=files.Trim();
				sss=s.ToUpper();
				if (sss.IndexOf("LET")==0){
					s=s.Remove(0,3);
				}
				string [] ss=vvalue(s);
				if (ss.Length>1){
					i=search(ss[0]);
					if (i==-1){
						addvar(ss[0],ss[1]);
					}else{
						value[i]=ss[1];
					}
				} 
				return "";
			}
			public string ON(bool b){
				varson=b;
				return "";
			}
			
			public string Commands(){
				string comm="";
				Console.Write(">>");
				comm=Console.ReadLine();
				return comm;
			}
			public string removespaces(string s){
				int i=0;
				string ss="";
				bool b=false;
				string sss="";
				int ii=0;
				for (i=0;i<s.Length;i++){
					if (s[i]>' ' && b){
						sss=sss+s[i];
					}
					if (s[i]=='$'){
						b=true;
					}
					if (s[i]>=' ' && !b)ss=ss+s[i];
					if (s[i]==' ' || i>=(s.Length-1)){
						if (b){
							ii=search(sss);
							if (ii>-1)sss=getsvalue(ii);
							ss=ss+sss+" ";
						}
						b=false;
						sss="";
					}
				}
				return ss;
			}
			public string [] args(string argc){
				return argc.Split(' ');
			}
			public string [] commands2(string argc){
				return argc.Split(';');
			}

			public string [] vvalue(string argc){
				return argc.Split('=');
			}
			public string EXPR(string files){
				int signals=0;
				int sums=0;
				int ii=0;
				int ivar=-1;
				int i=0;
				string svar="";
				string [] ffile=args(files);
					if (ffile.Length>2){
						ivar=search(ffile[1]);
						if (ivar<0)addvar(ffile[1],"0");
						ivar=search(ffile[1]);
						for(i=2;i<ffile.Length;i++){
							svar=ffile[i];
							svar=svar.Trim();
							if (svar[0]=='+')signals=0;
							if (svar[0]=='-')signals=1;
							if (svar[0]=='*')signals=2;
							if (svar[0]=='/')signals=3;
							if (svar[0]=='\\')signals=3;
							try{
								if (svar[0]>='0' && svar[0]<='9'){
									ii=Convert.ToInt16(svar);
									if(signals==0)sums=ADDS(sums,ii);
									if(signals==1)sums=SUBS(sums,ii);
									if(signals==2)sums=MULS(sums,ii);
									if(signals==3)sums=DIVS(sums,ii);
								}
							}catch{
								center("ERROR expr",terminal);
							}
							
						}
					}
				if (ivar>-1)value[ivar]=Convert.ToString(sums).Trim();
				return "";
			}
			public string LOGIC(string files){
				int map=0;
				string sd="";
				int signals=0;
				int bsignals=0;
				int lastsignal=0;
				int thesignal=1;
				string s11="";
				bool sums=false;
				bool sumslog=false;
				int ii=0;
				int ivar=-1;
				int i=0;
				string svar="";
				sd=files.Replace("  "," ");
				string [] ffile=args(sd);
					if (ffile.Length>2){
						ivar=search(ffile[1]);
						if (ivar<0)addvar(ffile[1],"0");
						ivar=search(ffile[1]);
						for(i=2;i<ffile.Length;i++){
							svar=ffile[i];
							svar=svar.Trim();
							bsignals=signals;
							signals=7;
							if (svar!=""){
							try{
								if (svar[0]=='|')signals=1;
								if (svar[0]=='&')signals=2;
								if (svar[0]=='=')signals=3;
								if (svar[0]=='!')signals=4;
								if (svar[0]=='>')signals=5;
								if (svar[0]=='<')signals=6;
																
								if (map==0 && signals==7) s11=svar.Trim();
								if (map==0 && signals!=7) i=ffile[i].Length+1;
								if (map==1 && signals>=3 && signals<=6)lastsignal=signals; 
								if (map==1 && (signals<3 || signals>6)) i=ffile[i].Length+1;
								if (map==2 && signals==7){
										if(bsignals==3)sums=LIKE(s11,svar);
										if(bsignals==4)sums=DIFERENT(s11,svar);
										if(bsignals==5)sums=BIG(s11,svar);
										if(bsignals==6)sums=LESS(s11,svar);
																				
										if(thesignal==1)sumslog=ORS(sumslog,sums); 
										if(thesignal==2)sumslog=ANDS(sumslog,sums); 
										
								}
								if (map==2 && signals!=7)i=ffile[i].Length+1;
								if (map==3 && (signals<1 || signals>2))i=ffile[i].Length+1;	
								if (map==3 && signals>=1 && signals<=2){
									thesignal=signals;
									map=-1;
									
								}
								map++;
							}catch{
								center("ERROR LOGIC",terminal);
							}
						}
						}
						i=0;
						if (sumslog) i=1;
						value[ivar]=Convert.ToString(i).Trim();
					}

				return "";
			}

			public bool ANDS(bool i1,bool i2){
				return i1 && i2;
			}

			public bool ORS(bool i1,bool i2){
				return i1 || i2;
			}

			public bool LIKE(string i1,string i2){
				return i1 == i2;
			}

			public bool DIFERENT(string i1,string i2){
				
				return i1 != i2;
			}

			public bool BIG(string i1,string i2){
				int ii1=0;
				int ii2=0;
				
				try{
					ii1=Convert.ToInt16(i1);
					ii2=Convert.ToInt16(i2);
				}catch{
					center("ERROR LOGIC",terminal);
				}
				return (ii1 > ii2);
			}
			public bool LESS(string i1,string i2){
				int ii1=0;
				int ii2=0;
				
				try{
					ii1=Convert.ToInt16(i1);
					ii2=Convert.ToInt16(i2);
				}catch{
					center("ERROR LOGIC",terminal);
				}
				return (ii1 < ii2);
			}
			public int ADDS(int i1,int i2){
				return i1+i2;
			}

			public int SUBS(int i1,int i2){
				return i1-i2;
			}
			public int DIVS(int i1,int i2){
				return i1/i2;
			}
			public int MULS(int i1,int i2){
				return i1*i2;
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
			public string PRINTF(string  files){
				string s="";
				int i=0;
				string ss=files.Replace("\\n","\n");
				ss=ss.Replace("\\t","\t");
				ss=ss.Replace("\\r","\r");
				ss=ss.Replace("\\b","\b");
				ss=ss.Replace("\\a","\a");
				string [] ffiles=args(ss);
				if (ffiles.Length>1){
					for(i=1;i<ffiles.Length;i++){
						s=s+ffiles[i]+" ";
					}
				}
				Console.Write(s);	
				return "";
			}

			public string BASH(string  files){
				string s="";
				string [] ffiles=args(files);
				center(files,terminal);	
				if (ffiles.Length>1)s=ffiles[1];
				Shells shells = new Shells(s);
				shells.Dispose();
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





