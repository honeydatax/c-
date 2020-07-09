using System;
using System.IO;

namespace logic{
	
	class logics{
		public class Shells{
			private int max=32000;
			private int count=-1;
			private bool endss=false;
			public int terminal=78;
			public int [] gosubs= new int[2049];
			private int returns=0;
			private int returnss=0;
			private int countvar=0;
			private bool varson=false;
			private string ggotos="";
			private bool ggoto=false;
			public maps mp = new maps(80,20);
			public string [] history1=new string[2048];
			public string [] history2=new string[2048];
			public string [] history3=new string[2048];
			public int history1len=0;
			public int history2len=0;
			public int history3len=0;
			VarList vars1 = new VarList();
			public Shells(string files){

				Console.TreatControlCAsInput=true;
				int i=0;
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
				history1[0]="exit";
				history1len=1;
				history2[0]="exit";
				history2len=1;
				history3[0]="exit";
				history3len=1;

				
				while(!endss){
					ggotos="";
					ggoto=false;
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
					returns=count;
					try{
						runs(command,files);
					}catch{
						Console.WriteLine("ERROR : in Command");
					}
					if (returns!=count)count=returns;
					if (files!="" && ggoto){
						count=list.Length;
						for(i=0;i<list.Length;i++){
							if (list[i].IndexOf(ggotos)==0){
								count=i-1;
								i=list.Length+1;
							}
						}
						
					}
					if(Console.KeyAvailable){
							if(Convert.ToByte(Console.ReadKey(true).Key)==27)endss=true;
					}

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
					string back3="";
					string [] argss=null;
					string [] argss2=null;
					string [] argss3=null;
					string argvvv="";
					int i=0;
					int i1=0;
					int i2=0;					
					int i3=0;
					string svar="";
					int ivar=0;
					string svar2="";
					int ivar2=0;
					string svar3="";
					int ivar3=0;
					string svar4="";
					int ivar4=0;

					commands=command.Replace("  "," ");					
					back2=commands;
					back3=back2;
					commands=removespaces(commands);
					commands=commands.Trim();
					commands=commands.Replace("  "," ");					
					back=commands;
					commands=commands.ToUpper();
					
				if (commands.IndexOf(":")!=0 && commands.IndexOf("#")!=0){
					if (commands.IndexOf("FOR ")==0){
						
						argss=commands2(commands);
						argss3=commands2(back2);
						if (argss.Length>1){
							argvvv=argss[0];
							argvvv=removespaces(argvvv);
							argvvv=argvvv.Replace("  "," ");		
							argss2=args(argvvv);
							try{
							
								if (argss2.Length>4){
									svar=argss2[1];
									ivar=search(svar);
									if(ivar<0){
										addvar(argss2[1],"0");
										svar=argss2[1];
									}
									ivar=search(svar);
									
									
									svar2=argss2[2];
					ivar2=search(svar2);
					
					if(ivar2<0){
						addvar(svar2,"0");

					}
					ivar2=search(svar2);
					

									svar3=argss2[3];
					ivar3=search(svar3);
					
					if(ivar3<0){
						addvar(svar3,"0");

					}
					ivar3=search(svar3);
					
									svar4=argss2[4];
					ivar4=search(svar4);
					
					if(ivar4<0){
						addvar(svar4,"0");

					}
					ivar4=search(svar4);
					
									
									
									
																
									i1=Convert.ToInt16(vars1.value[ivar2]);
									i2=Convert.ToInt16(vars1.value[ivar3]);
									i3=Convert.ToInt16(vars1.value[ivar4]);
									if (i1<i2){
										
										for(i=i1;i<i2;i=i+i3){
											vars1.value[ivar]=Convert.ToString(i).Trim();
											commands=back3;
											commands=commands.Trim();
											commands=commands.Replace("  "," ");
											back2=commands;
											commands=removespaces(commands);
											commands=commands.Replace("  "," ");
											commands=commands.ToUpper();
											
											run(commands,files,back2);
											if(ggoto)i=i2+1;
										}
									}
								}
							}catch{
								center("error :for",terminal);
							}
								
						}
						commands="";
					}
					if (commands.IndexOf("TIME ")==0){
						string s="";
						string sss="";
						
						argss=commands2(commands);
						
						sss=argss[0];
						argss3=commands2(back);
						if (argss.Length>1){
							argss2=args(argss[0]);
									svar=argss2[1];
							try{
								TimeSpan t;
								DateTime dt1=DateTime.Now;


										
										run(commands,files,back);
											
								DateTime dt2=DateTime.Now;
								t=dt2-dt1;
								
								
				string [] ss=args(sss);
				if (ss.Length>1){
					i=search(ss[1]);
					if (i==-1){
						addvar(ss[1],Convert.ToString(t.Hours)+":"+Convert.ToString(t.Minutes)+":"+Convert.ToString(t.Seconds)+":"+Convert.ToString(t.Milliseconds));
					}else{
						vars1.value[i]=Convert.ToString(t.Hours)+":"+Convert.ToString(t.Minutes)+":"+Convert.ToString(t.Seconds)+":"+Convert.ToString(t.Milliseconds);
					}
				} 
				


								
							}catch{
								center("error :TIME",terminal);
							}
								
						}
						commands="";
					}

					if (commands.IndexOf("IF ")==0){
						
						argss=commands2(commands);
						argss3=commands2(back);
						if (argss.Length>1){
							argss2=args(argss[0]);
							try{
								bool j=true;
								string h="";
								if (argss2.Length>1){
									svar=argss2[1];
									
									ivar=search(svar);
					
									if(ivar<0){
										addvar(svar,"0");

									}
									ivar=search(svar);


									h=vars1.value[ivar];
									h=h.ToUpper();
									h=h.Trim();
									
									if (h[0]=='0' || h=="FALSE")j=false;
								}else{
									j=false;
								}	
								if (j){
										
										
										
										
								
										run(commands,files,back);
								}			
								
							}catch{
								center("error :if",terminal);
							}
								
						}
						commands="";
					}
					
				}
					if (commands!="")run(commands,files,back);
			}
			
			public void run(string command ,string files,string back){
				string ss="";
				string sss="";
				int i=0;
				string commands="";
				string [] ccommandss;
				string [] backs;
				ccommandss=commands2(command);
				backs=commands2(back);
				for(i=0;i<ccommandss.Length;i++){
					
					commands=ccommandss[i];
					back=backs[i];
					sss=back;
					back=removespaces(back);
					back=back.Trim();
					commands=commands.Trim();
					if (files!="" && varson) center(commands,terminal);	
					if (commands.IndexOf("EXIT")==0){
						commands="";
						endss=EXIT();
						i=ccommandss.Length+1;
					}
					if (commands.IndexOf("CAT ")==0 || commands.IndexOf("TYPE ")==0)commands=CAT(back);
					if (commands.IndexOf("SLEEP ")==0 || commands.IndexOf("DELAY ")==0 )commands=SLEEP(back);	
					if (commands.IndexOf("PRINTF ")==0)commands=WRITE(back);	
					if (commands.IndexOf("ECHO ")==0 || commands.IndexOf("PRINT ")==0)commands=WRITE(back);	
					if (commands.IndexOf("LOGIC ")==0 )commands=LOGIC(back);		
					if (commands.IndexOf("EXPR ")==0 )commands=EXPR(back);		
					if (commands.IndexOf("CAL ")==0 )commands=CAL(back);	
					if (commands.IndexOf("CLS")==0 || commands.IndexOf("CLEAR")==0)commands=CLEAR();
					if (commands.IndexOf("DIR ")==0 || commands.IndexOf("LS ")==0)commands=DIR(back);	
					if (commands.IndexOf("DATE ")==0 )commands=DATE(back);
					if (commands.IndexOf("COLOR ")==0 )commands=COLOR(back);
					if (commands.IndexOf("BACK ")==0 )commands=BACK(back);
					if (commands.IndexOf("VARS")==0 )commands=VARS();		
					if (commands.IndexOf("ON")==0 )commands=ON(true);		
					if (commands.IndexOf("OFF")==0 )commands=ON(false);		
					if (commands.IndexOf("HELP")==0 )commands=HELP();
					if (commands.IndexOf("BEEP")==0 )commands=BEEP();
					if (commands.IndexOf("GOTO ")==0 )commands=GOTO(back);
					if (commands.IndexOf("GOSUB ")==0 )commands=GOSUB(back);
					if (commands.IndexOf("RETURN")==0 )commands=RETURN();
					if (commands.IndexOf("MID ")==0 )commands=MID(back);
					if (commands.IndexOf("RIGTH ")==0 )commands=RIGTH(back);
					if (commands.IndexOf("LEFT ")==0 )commands=LEFT(back);
					if (commands.IndexOf("READ ")==0 )commands=READ(back);
					if (commands.IndexOf("SPLIT ")==0 )commands=SPLIT(back);
					if (commands.IndexOf("CONST ")==0 )commands=CONST(back);
					if (commands.IndexOf("BINARY ")==0 )commands=BINARY(back);
					if (commands.IndexOf("HEX ")==0 )commands=HEXS(back);
					if (commands.IndexOf("INDEX ")==0 )commands=INDEX(back);
					if (commands.IndexOf("REPLACE ")==0 )commands=REPLACE(back);
					if (commands.IndexOf("FIND ")==0 )commands=FIND(back);
					if (commands.IndexOf("CHR ")==0 )commands=CHR(back);
					if (commands.IndexOf("WRITE ")==0 )commands=WRITE(back);
					if (commands.IndexOf("LOAD ")==0 )commands=LOAD(back);
					if (commands.IndexOf("SPACE ")==0 )commands=SPACE(back);
					if (commands.IndexOf("STRING ")==0 )commands=STRING(back);
					if (commands.IndexOf("SOUND ")==0 )commands=SOUND(back);
					if (commands.IndexOf("LOCATE ")==0 )commands=LOCATE(back);
					if (commands.IndexOf("CONCAT ")==0 )commands=COMCAT(back);
					if (commands.IndexOf("APPEND ")==0 )commands=APPEND(back);
					if (commands.IndexOf("LEN ")==0 )commands=LEN(back);
					if (commands.IndexOf("GREP ")==0 )commands=GREP(back);
					if (commands.IndexOf("ARRAY ")==0 )commands=ARRAY(back);
					if (commands.IndexOf("COPY ")==0 || commands.IndexOf("CP")==0 )commands=COPY(back);
					if (commands.IndexOf("MORE ")==0)commands=MORE(back);
					if (commands.IndexOf("EDITOR ")==0)commands=EDITOR(back);
					if (commands.IndexOf("EDIT ")==0)commands=EDIT(back);
					if (commands.IndexOf("TRIM ")==0)commands=TRIM(back);
					if (commands.IndexOf("INKEY ")==0)commands=INKEY(back);
					if (commands.IndexOf("REFRESH")==0)commands=REFRESH();
					if (commands.IndexOf("PSTRING ")==0)commands=PSTRING(back);
					if (commands.IndexOf("VSTRING ")==0)commands=VSTRING(back);
					if (commands.IndexOf("PCENTER ")==0)commands=PCENTER(back);
					if (commands.IndexOf("VCENTER ")==0)commands=VCENTER(back);
					if (commands.IndexOf("CIRCLE ")==0)commands=CIRCLE(back);
					if (commands.IndexOf("FILLCIRCLE ")==0)commands=FILLCIRCLE(back);
					if (commands.IndexOf("FILLRECT ")==0)commands=FILLRECT(back);
					if (commands.IndexOf("RECT ")==0)commands=RECT(back);
					if (commands.IndexOf("GRID ")==0)commands=GRID(back);
					if (commands.IndexOf("HLINE ")==0)commands=HLINE(back);
					if (commands.IndexOf("VLINE ")==0)commands=VLINE(back);
					if (commands.IndexOf("BASH")==0 || commands.IndexOf("SH")==0 || commands.IndexOf("COMMAND")==0)commands=BASH(back);	
					if (commands.IndexOf("=")>-1 || commands.IndexOf("LET")==0 )commands=LET(back);							
					
					
					if(ggoto)i=ccommandss.Length+1;
				}
			}
		public string mid(string ss,int start,int size){
			return ss.Substring(start,size);
		}
		public string MID(string backs){
				int i1=0;
				int i2=0;
				arguments argss = new arguments(backs, ' ');
					try{
						if(argss.argumentss.numbers[2]){
							i1=argss.argumentss.i[2];
						}else{
							i1=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						if(argss.argumentss.numbers[3]){
							i2=argss.argumentss.i[3];
						}else{
							i2=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}

						vars1.setvar(argss.argumentss.txt[1].Trim(),(vars1.getvar(argss.argumentss.txt[1].Trim())).Substring(i1,i2));
					}catch{
						Console.WriteLine("error: MID!");	
					}
						
		
			return "";
		
		}

		public string RIGTH(string backs){
				int i1=0;
				int i2=0;
				int i3=0;
				
				arguments argss = new arguments(backs, ' ');
					try{
						if(argss.argumentss.numbers[2]){
							i1=argss.argumentss.i[2];
						}else{
							i1=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						i3=vars1.getvar(argss.argumentss.txt[1].Trim()).Length;
						i2=i3-i1;
						i1=i3-i2;
						vars1.setvar(argss.argumentss.txt[1].Trim(),(vars1.getvar(argss.argumentss.txt[1].Trim())).Substring(i2,i1));
					}catch{
						Console.WriteLine("error: RIGTH!");	
					}
						
		
			return "";
		
		}

		public string LEFT(string backs){
				int i1=0;
				arguments argss = new arguments(backs, ' ');
					try{
						if(argss.argumentss.numbers[2]){
							i1=argss.argumentss.i[2];
						}else{
							i1=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						vars1.setvar(argss.argumentss.txt[1].Trim(),(vars1.getvar(argss.argumentss.txt[1].Trim())).Substring(0,i1));
					}catch{
						Console.WriteLine("error: LEFT!");	
					}
						
		
			return "";
		
		}
		public string READ(string backs){
					arguments argss = new arguments(backs, ' ');
					try{
						lineInsert inputs = new lineInsert();
						vars1.setvar(argss.argumentss.txt[1].Trim(),inputs.input(history1,history1len));
					if(history1len<2047){
						history1[history1len]=vars1.getvar(argss.argumentss.txt[1].Trim());
						history1len++;
					}

					}catch{
						Console.WriteLine("error: read!");	
					}
			return "";
		}

		public string SPLIT(string backs){
					string s="";
					string [] ss=null;
					int i=0;
					arguments argss = new arguments(backs, ' ');
					try{
					s=vars1.getvar(argss.argumentss.txt[2].Trim());
					ss=vars1.getvar(argss.argumentss.txt[1].Trim()).Split(s[0]);
					for(i=0;i<ss.Length;i++){
						vars1.setvar(argss.argumentss.txt[1].Trim()+i.ToString(),ss[i]);
						
					}
					}catch{
						Console.WriteLine("error: split!");	
					}
						

				
				return "";

		
		}

		public string SOUND(string files){
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						Console.Beep(i,ii);
						
					}catch{
						Console.WriteLine("error: sound!");	
					}
						

				
				return "";

		}

		public string LOCATE(string files){
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						Console.SetCursorPosition(i,ii);
						
						
					}catch{
						Console.WriteLine("error: locate!");	
					}
				return "";
		}



		public string PSTRING(string files){
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						mp.pstring(i,ii,vars1.getvar(argss.argumentss.txt[3].Trim()));
						
						
						
					}catch{
						Console.WriteLine("error: PSTRING!");	
					}
				return "";

	
		}

		public string VSTRING(string files){
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						mp.vstring(i,ii,vars1.getvar(argss.argumentss.txt[3].Trim()));
						
						
						
					}catch{
						Console.WriteLine("error: vstring!");	
					}
				return "";
		
		}

		public string CIRCLE(string files){
			int iii=0;
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						if(argss.argumentss.numbers[3]){
							iii=argss.argumentss.i[3];
						}else{
							iii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}
						mp.circle(i,ii,iii,vars1.getvar(argss.argumentss.txt[4].Trim())[0]);
					}catch{
						Console.WriteLine("error: CIRCLE!");	
					}
				return "";
		}

		public string HLINE(string files){

			int iii=0;
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						if(argss.argumentss.numbers[3]){
							iii=argss.argumentss.i[3];
						}else{
							iii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}
						mp.horline(i,ii,iii,vars1.getvar(argss.argumentss.txt[4].Trim())[0]);
					}catch{
						Console.WriteLine("error: HLINE!");	
					}
				return "";
		}

		public string VLINE(string files){
			int iii=0;
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						if(argss.argumentss.numbers[3]){
							iii=argss.argumentss.i[3];
						}else{
							iii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}
						mp.verline(i,ii,iii,vars1.getvar(argss.argumentss.txt[4].Trim())[0]);
					}catch{
						Console.WriteLine("error: VLINE!");	
					}
				return "";
		}


		public string FILLCIRCLE(string files){
			int iii=0;
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						if(argss.argumentss.numbers[3]){
							iii=argss.argumentss.i[3];
						}else{
							iii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}
						mp.fillcircle(i,ii,iii,vars1.getvar(argss.argumentss.txt[4].Trim())[0]);
					}catch{
						Console.WriteLine("error: fillcircle!");	
					}
				return "";
		}

		public string FILLRECT(string files){
			int iiii=0;
			int iii=0;
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						if(argss.argumentss.numbers[3]){
							iii=argss.argumentss.i[3];
						}else{
							iii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}
						if(argss.argumentss.numbers[4]){
							iiii=argss.argumentss.i[4];
						}else{
							iiii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[4].Trim()));
						}

						mp.rect(i,ii,iii,iiii,vars1.getvar(argss.argumentss.txt[5].Trim())[0]);
					}catch{
						Console.WriteLine("error: FILLRECT!");	
					}
				return "";
		}

		public string RECT(string files){
			int iiii=0;
			int iii=0;
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						if(argss.argumentss.numbers[3]){
							iii=argss.argumentss.i[3];
						}else{
							iii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}
						if(argss.argumentss.numbers[4]){
							iiii=argss.argumentss.i[4];
						}else{
							iiii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[4].Trim()));
						}

						mp.lrect(i,ii,iii,iiii,vars1.getvar(argss.argumentss.txt[5].Trim())[0]);
					}catch{
						Console.WriteLine("error: RECT!");	
					}
				return "";
		}

		public string GRID(string files){
			int iiiii=0;
			int iiii=0;
			int iii=0;
			int ii=0;
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						if(argss.argumentss.numbers[3]){
							iii=argss.argumentss.i[3];
						}else{
							iii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}
						if(argss.argumentss.numbers[4]){
							iiii=argss.argumentss.i[4];
						}else{
							iiii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[4].Trim()));
						}
						if(argss.argumentss.numbers[5]){
							iiiii=argss.argumentss.i[5];
						}else{
							iiiii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[5].Trim()));
						}
						mp.grid(i,ii,iii,iiii,iiiii,vars1.getvar(argss.argumentss.txt[6].Trim())[0]);
					}catch{
						Console.WriteLine("error: GRID!");	
					}
				return "";
		}




		public string PCENTER(string files){
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						mp.center(i,vars1.getvar(argss.argumentss.txt[2].Trim()));
						
						
					}catch{
						Console.WriteLine("error: PCENTER!");	
					}
				return "";
					
		}

		public string VCENTER(string files){
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							i=argss.argumentss.i[1];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
						mp.vcenter(i,vars1.getvar(argss.argumentss.txt[2].Trim()));
						
						
					}catch{
						Console.WriteLine("error: VCENTER!");	
					}
				return "";
		}



		public string GREP(string files){
			string [] ss=null;
			string s="";
			string sss="";
			string ssss="";
			int i=0;
					arguments argss = new arguments(files,' ');
					try{
						s=vars1.getvar(argss.argumentss.txt[1].Trim());
						sss=vars1.getvar(argss.argumentss.txt[2].Trim());
						s=s.Replace("\r","");
						ss=s.Split('\n');
						ssss="";
						for(i=0;i<ss.Length;i++){
							if(ss[i].IndexOf(sss)>-1)ssss=ssss+ss[i]+"\r\n";
						}
						vars1.setvar(argss.argumentss.txt[1].Trim(),ssss);
					}catch{
						Console.WriteLine("error: GREP!");	
					}
				return "";
		}

		public string ARRAY(string files){
			int i=0;
			string [] ss=null;
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[4]){
							i=argss.argumentss.i[4];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[4].Trim()));
						}
						ss=(vars1.getvar(argss.argumentss.txt[2].Trim())).Split((vars1.getvar(argss.argumentss.txt[3].Trim()))[0]);
						
						vars1.setvar(argss.argumentss.txt[1].Trim(),ss[i]);
					}catch{
						Console.WriteLine("error: ARRAY!");	
					}
				return "";
		}






		public string REPLACE(string files){
				arguments argss = new arguments(files, ' ');
					try{
						vars1.setvar(argss.argumentss.txt[1].Trim(),(vars1.getvar(argss.argumentss.txt[1].Trim())).Replace(vars1.getvar(argss.argumentss.txt[2].Trim()),vars1.getvar(argss.argumentss.txt[3].Trim())));
					}catch{
						Console.WriteLine("error: REPLACE!");	
					}
				return "";
		}

		public string FIND(string files){
				arguments argss = new arguments(files, ' ');
					try{
						vars1.setvar(argss.argumentss.txt[1].Trim(),(vars1.getvar(argss.argumentss.txt[2].Trim())).IndexOf(vars1.getvar(argss.argumentss.txt[3].Trim())).ToString());
					}catch{
						Console.WriteLine("error: find!");	
					}
				return "";
	
		}



		public string CHR(string files){
			char c=' ';
				arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[2]){
							c=Convert.ToChar(argss.argumentss.i[2]);
						}else{
							c=Convert.ToChar(Convert.ToByte(vars1.getvar(argss.argumentss.txt[2].Trim())));
						}
						vars1.setvar(argss.argumentss.txt[1].Trim(),c.ToString());
					}catch{
						Console.WriteLine("error: CHR!");	
					}
				return "";
		}



		public string WRITE(string backs){
					arguments argss = new arguments(backs, ' ');
					try{
						if(argss.argumentss.length>2){
						 File.WriteAllText(vars1.getvar(argss.argumentss.txt[1].Trim()),vars1.getvar(argss.argumentss.txt[2]));
					 }else{
						Console.Write(vars1.getvar(argss.argumentss.txt[1].Trim()));
					}
					}catch{
						Console.WriteLine("error: write!");	
					}
			return "";
		
		}

		public string LOAD(string files){
				arguments argss = new arguments(files, ' ');
					try{
						vars1.setvar(argss.argumentss.txt[1].Trim(),File.ReadAllText(vars1.getvar(argss.argumentss.txt[2].Trim())));
					}catch{
						Console.WriteLine("error: LOAD!");	
					}
			return "";
					
		}

		public string SPACE(string files){
					int i=0;
					int ii=0;
					string s="";
					arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[2]){
							ii=argss.argumentss.i[2];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
						}
						s="";
						for(i=0;i<ii;i++){
							s=s+" ";
						}
						vars1.setvar(argss.argumentss.txt[1].Trim(),s);
					}catch{
						Console.WriteLine("error: SPACE!");	
					}
				return "";
		}

		public string STRING(string files){
					int i=0;
					int ii=0;
					string s="";
					string ss="";
					arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[3]){
							ii=argss.argumentss.i[3];
						}else{
							ii=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}
						ss=vars1.getvar(argss.argumentss.txt[2].Trim());
						s="";
						for(i=0;i<ii;i++){
							s=s+ss;
						}
						vars1.setvar(argss.argumentss.txt[1].Trim(),s);
					}catch{
						Console.WriteLine("error: STRING!");	
					}
				return "";
		}

		public string LEN(string files){
				arguments argss = new arguments(files, ' ');
					try{
						vars1.setvar(argss.argumentss.txt[1].Trim(),Convert.ToString((vars1.getvar(argss.argumentss.txt[2])).Length));
					}catch{
						Console.WriteLine("error: LEN!");	
					}
				return "";
		}



		public string APPEND(string files){
			int i=0;
				arguments argss = new arguments(files, ' ');
					try{

						if(argss.argumentss.numbers[3]){
							i=argss.argumentss.i[3];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}
						vars1.setvar(argss.argumentss.txt[1].Trim(),(vars1.getvar(argss.argumentss.txt[1].Trim())).Insert(i,vars1.getvar(argss.argumentss.txt[2].Trim())));
					}catch{
						Console.WriteLine("error: APPEND");	
					}
				return "";
			

		}




		public string COMCAT(string files){
			int i=0;
			string s="";
				arguments argss = new arguments(files, ' ');
					try{
						s="";
						for(i=1;i<argss.argumentss.length;i++){
							s=s+vars1.getvar(argss.argumentss.txt[i].Trim());
						}
						vars1.setvar(argss.argumentss.txt[1].Trim(),s);
					}catch{
						Console.WriteLine("error: COMCAT!");	
					}
				return "";
		}


		public string COPY(string files){
			int i=0;
			string s="";
				arguments argss = new arguments(files, ' ');
					try{
						s="";
						for(i=1;i<argss.argumentss.length;i++){
							s=s+File.ReadAllText(vars1.getvar(argss.argumentss.txt[i].Trim()));
						}
						File.WriteAllText(vars1.getvar(argss.argumentss.txt[1].Trim()),s);
						
					}catch{
						Console.WriteLine("error: COPY!");	
					}
				return "";

		
		}






		public string INDEX(string files){
					int i=0;
					arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[3]){
							i=argss.argumentss.i[3];
						}else{
							i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
						}
						vars1.setvar(argss.argumentss.txt[1].Trim(),vars1.getvar(argss.argumentss.txt[2].Trim()+i.ToString()));
					}catch{
						Console.WriteLine("error: index!");	
					}
						

				
				return "";

		}




			public string RETURN(){
				if (returnss>0){
					returnss--;
					returns=gosubs[returnss];
				}
				return "";
			}
			public string GOSUB(string files){
				
				if (returnss<2047){
					gosubs[returnss]=returns;
					returnss++;
				}
				return GOTO(files);
				
			}
			public string GOTO(string files){
				arguments argss = new arguments(files, ' ');
					try{
						ggotos=":"+argss.argumentss.texts[1].Trim();
						if (ggotos.Length>1)ggoto=true;
					}catch{
						Console.WriteLine("error: goto!");	
					}
						
				return "";
				
			}
			public void addvar(string s1, string s2){
				string s="";
				vars1.setvar(s1,s2);
			}
			public int search(string s1){
				int rets=-1;
				int i=0;
				string s=s1.ToUpper(); 
				s=s.Trim();
				if (vars1.length>0){
					for(i=0;i<vars1.length;i++){
						if(string.Compare(vars1.name[i],s)==0){
							rets=i;
							i=vars1.length+1;
						}
					}
				} 
				return rets;
			}
			public string VARS(){
				vars1.list();
				return "";
			}

			public string getsvalue(int index){
				return vars1.value[index];
			}
			public string LET(string files){
					
					
					try{
						
						arguments argss = new arguments(files, '=');
						string s=argss.argumentss.txt[0].Trim();
						string ss=argss.argumentss.texts[1];
						
				if (s.IndexOf("LET")==0){
					s=s.Remove(0,3);
				}
				ss=ss.Replace("\\n","\n");
				ss=ss.Replace("\\t","\t");
				ss=ss.Replace("\\r","\r");
				ss=ss.Replace("\\b","\b");
				ss=ss.Replace("\\a","\a");
				
				
						vars1.setvar(s,ss);
					}catch{
						Console.WriteLine("error: let set vars!");	
					}
				return "";
			}
			
			public string CONST(string files){
				int i=0;
				arguments argss = new arguments(files, ' ');
					try{
						for(i=1;i<argss.argumentss.length;i++)vars1.setvar(argss.argumentss.txt[i].Trim(),argss.argumentss.txt[i].Trim());
					}catch{
						Console.WriteLine("error: const!");	
					}
				return "";
			}
			
			
			public string ON(bool b){
				varson=b;
				return "";
			}
			
			public string Commands(){
				
				string comm="";
				try{
				lineInsert inputs = new lineInsert();
				Console.Write(">>");
				comm=inputs.input(history2,history2len);
					if(history2len<2047){
						history2[history2len]=comm;
						history2len++;
					}
				}catch{
					
				}
				return comm;
			}
			public string removespaces(string s){
				bool b1=false;
				int i=0;
				string ss="";
				char charback=' ';
				bool b=false;
				string sss="";
				int ii=0;
				
				for (i=0;i<s.Length;i++){
					
					if (s[i]>=' ' && !b && s[i]!='$')ss=ss+s[i];
					b1=true;
					if ((s[i]>='A' && s[i]<='Z') || (s[i]>='a' && s[i]<='z')  || (s[i]>='0' && s[i]<='9'))b1=false;
					if (s[i]>' ' && b && !b1 && !(charback==' ' && s[i]==' ')){
						sss=sss+s[i];
						charback=s[i];
					}

					if (b) {
							if (b1 || i>=(s.Length-1)){
						

								
								sss=sss.Trim();
								ii=search(sss);

							
								if (ii>-1){
								
									sss=getsvalue(ii);
									ss=ss+sss+" ";
								}
								
								sss="";
								
								if (!(i>=s.Length-1))ss=ss+s[i];
								b=false;
							}

						}
					if (s[i]=='$')b=true;
				}
				return ss;
			}
			public string [] args(string argc){
				int i=0;
				int size=0;
				string [] ss =argc.Split(' ');
				string [] sss = new string[ss.Length];
				for (i=0;i<ss.Length;i++)sss[i]=ss[i].Trim();
				return sss ;
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
				int ivars=0;
				string svar="";
				string s=files.Trim();
				s=s.Replace("  "," ");
				
				argumentst argss = new argumentst(s, ' ');
					
						for(i=2;i<argss.argumentss.length;i++){
							svar=argss.argumentss.txt[i].Trim();
						if(svar!=""){
					
							if (svar[0]=='+')signals=0;
							if (svar[0]=='-')signals=1;
							if (svar[0]=='*')signals=2;
							if (svar[0]=='/')signals=3;
							if (svar[0]=='\\')signals=3;
							try{
								if (svar[0]!='+' && svar[0]!='-' && svar[0]!='*' && svar[0]!='\\' && svar[0]!='/' ){
									if(!(svar[0]>='0' && svar[0]<='9'))svar=vars1.getvar(svar);
									

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
					
				vars1.setvar(argss.argumentss.txt[1].Trim(),Convert.ToString(sums).Trim());
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
				arguments argss = new arguments(files, ' ');
				
				int ivars=0;
						for(i=2;i<argss.argumentss.length;i++){
							svar=argss.argumentss.txt[i].Trim();
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

								if (map==0 && signals==7){
									svar=argss.argumentss.txt[i].Trim();
									if(!(svar[0]>='0' && svar[0]<='9')){
										svar=vars1.getvar(argss.argumentss.txt[i].Trim());
									}
									s11=svar;
								}
								svar=argss.argumentss.txt[i].Trim();
								
								if (map==0 && signals!=7) i=argss.argumentss.length+1;
								if (map==1 && signals>=3 && signals<=6)lastsignal=signals; 
								if (map==1 && (signals<3 || signals>6)) i=argss.argumentss.length+1;
								if (map==2 && signals==7){
														
								if(bsignals>=3 && bsignals<=6){
									if(!(svar[0]>='0' && svar[0]<='9')){
										svar=vars1.getvar(svar);
									}

										if(bsignals==3)sums=LIKE(s11,svar);
										if(bsignals==4)sums=DIFERENT(s11,svar);
										if(bsignals==5)sums=BIG(s11,svar);
										if(bsignals==6)sums=LESS(s11,svar);
								}
										if(thesignal==1)sumslog=ORS(sumslog,sums); 
										if(thesignal==2)sumslog=ANDS(sumslog,sums); 
										
								}
								if (map==2 && signals!=7)i=argss.argumentss.length+1;
								if (map==3 && (signals<1 || signals>2))i=argss.argumentss.length+1;	
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
						vars1.setvar(argss.argumentss.txt[1].Trim(),Convert.ToString(i).Trim());
						
					

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
				Console.SetCursorPosition(0,0);
				Console.Clear();
				return "";
			}
			public string REFRESH(){
				return "";
			}

			public string DIR(string files){
					arguments argss = new arguments(files, ' ');
					try{
						vars1.setvar(argss.argumentss.txt[1].Trim(),string.Concat(Directory.GetFiles(".")));
					}catch{
						Console.WriteLine("error: dir!");	
					}
						
				return "";
			}
			public string CAT(string files){
					arguments argss = new arguments(files, ' ');
					try{
						vars1.setvar(argss.argumentss.txt[1].Trim(),File.ReadAllText(vars1.getvar(argss.argumentss.txt[2].Trim())));
					}catch{
						Console.WriteLine("error: cat!");	
					}
				return "";
			}

			public string BINARY(string files){
				int i=0;
					arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[2]){
							i=argss.argumentss.i[2];
						}else{
						    i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));	
						}
						Binary bin = new Binary(Convert.ToByte(i));
						vars1.setvar(argss.argumentss.txt[1].Trim(),bin.report());
					}catch{
						Console.WriteLine("error: binary!");	
					}
				return "";
			}

			
			public string HEXS(string files){
					int i=0;
					arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[2]){
							i=argss.argumentss.i[2];
						}else{
						    i=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));	
						}
						HEX hex = new HEX(Convert.ToByte(i));
						vars1.setvar(argss.argumentss.txt[1].Trim(),hex.print());
					}catch{
						Console.WriteLine("error: hex!");	
					}
				return "";
			}

			
			
			
			public string TRIM(string files){
				string ss="";
				string svar="";
				int ivar=0;
				string [] s=args(files);
				if(s.Length>1){
					svar=s[1];
					ivar=search(svar);
					
					if(ivar<0){
						addvar(s[1],"0");

					}
					ivar=search(svar);

					try{
						vars1.value[ivar]=vars1.value[ivar].Trim();
					}catch{
						Console.WriteLine("error: trim!");	
					}
						

				}
				return "";
			}

			public string INKEY(string files){
				string ss="";
				string svar="";
				bool bb=false;
				int ivar=0;
				string [] s=args(files);
				if(s.Length>1){
					svar=s[1];
					ivar=search(svar);
					
					if(ivar<0){
						addvar(s[1],"0");

					}
					ivar=search(svar);

					try{
						if(Console.KeyAvailable){
							vars1.value[ivar]=Convert.ToString(Convert.ToByte(Console.ReadKey(true).Key));
						}else{
							vars1.value[ivar]="0";
						}
					}catch{
						Console.WriteLine("error: trim!");	
					}
						

				}
				return "";
			}



			public string MORE(string files){
				string [] ss=null;
				string [] s=args(files);
				int i=0;
				int ii=0;
				string s1="";
				if(s.Length>1){
					try{
						ss=File.ReadAllLines(s[1]);
					    for(i=0;i<ss.Length;i++){
						Console.WriteLine("{0}",ss[i]);	
						ii++;
						if (ii>21){
							Console.Write("-----------");
							s1=Console.ReadLine();
							if (s1.Length>0)i=ss.Length+1;
							ii=0;
						}
					}

					}catch{
						Console.WriteLine("error: {0}!",s[1]);	
					}
					
				}
				return "";
			}
			public string EDIT(string files){
				arguments argss = new arguments(files, ' ');
					try{
						Console.Clear();
						Edit edits=new Edit(argss.argumentss.texts[1].Trim());
						Console.Clear();
						
					}catch{
						Console.WriteLine("error: edit!");	
					}
				return "";
			}


			public string EDITOR(string files){
				string sss="";
				string [] ss=null;
				string [] s=args(files);
				string ss1="";
				string sss2="";
				bool exits2=false;
				bool saves=true;
				bool ldel=false;
				int lline=-1;
				int i=0;
				int ii=0;
				int i1;
				
				string s1="";
				if(s.Length>1){
				  center("#editor: "+s[1],terminal);
				  while(!exits2){
					 lineInsert inputs = new lineInsert();
					 try{
						ss=File.ReadAllLines(s[1]);
						if (lline<0)lline=ss.Length+1;
						if (lline>ss.Length)lline=ss.Length+1;
					}catch{
						ss=new string[]{""};	
						center("#creating : "+s[1],terminal);
					}
					
					saves=true;
					
					sss=inputs.input(history3,history3len);
					if(history3len<2047){
						history3[history3len]=sss;
						history3len++;
					}

					ldel=false;
					sss=sss.Trim();
					if(sss.Length>0){
						if(sss[0]=='@'){
							if(sss.Length==1){
								exits2=true;
								saves=false;
							}else{
								if (sss.Length>1){
									if(sss[1]>='0' && sss[1]<='9'){
										sss2="";
										for(i1=1;i1<sss.Length;i1++){
											sss2=sss2+sss[i1];
										}
										
										sss2=sss2.Trim();
										lline=Convert.ToInt16(sss2);
										center("#cursor: "+lline.ToString(),terminal);
										saves=false;
									}
									if(sss[1]=='+'){
										saves=false;
										lline=sss.Length;
										
									}
									if(sss[1]=='-'){
										saves=false;
										lline=0;
									}
									if(sss[1]=='!'){
										
										saves=false;
										for(i=0;i<ss.Length;i++){
											
											Console.WriteLine("%-{0}",ss[i]);
										}
									}
									ldel=false;
									if(sss[1]=='#'){
										ldel=true;
										saves=true;
									}

								}
							}
						}

									


					} 
					
							
				
					
						ss1="";
						if(ldel && lline>=ss.Length)lline=ss.Length+1;
						if(lline<0)lline=0;
					    for(i=0;i<ss.Length;i++){
							if(i==lline && !ldel)ss1=ss1+sss+"\r\n"; 
							if(!(ldel && lline==i))ss1=ss1+ss[i]+"\r\n";
								
						}
						if(lline>ss.Length-1 && !ldel)ss1=ss1+sss+"\r\n"; 
						
						try{
							if(saves){
								lline=lline+1;
								File.WriteAllText(s[1],ss1);
							}
							
							

						}catch{
							center("Error: file protected:"+s[1],terminal);
						}

					
				  } 
				  center("#ending writing: "+s[1],terminal);
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
					arguments argss = new arguments(files, ' ');
					try{
						string ss="";
						if(argss.argumentss.length>1)ss=argss.argumentss.texts[1].Trim();
						Shells shells = new Shells(ss);
						shells.Dispose();
				shells=null;
				argss=null;
				center(" ",terminal);
				GC.Collect();

					}catch{
						Console.WriteLine("error: bash!");	
					}
				return "";
			}


			public string DATE(string files){
					arguments argss = new arguments(files, ' ');
					try{
						vars1.setvar(argss.argumentss.txt[1].Trim(),DateTime.Now.ToString());
					}catch{
						Console.WriteLine("error: date!");	
					}

				return "";

			}

			public string COLOR(string files){
					arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							Console.ForegroundColor=(ConsoleColor) argss.argumentss.i[1];
						}else{
							Console.ForegroundColor=(ConsoleColor) Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
					}catch{
						Console.WriteLine("error: color!");	
					}

				return "";

			}

			public string BACK(string files){
					arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
							Console.BackgroundColor=(ConsoleColor) argss.argumentss.i[1];
						}else{
							Console.BackgroundColor=(ConsoleColor) Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim()));
						}
					}catch{
						Console.WriteLine("error: back color!");	
					}

				return "";

					
				} 
				





			public string SLEEP(string files){
					arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[1]){
						sleeps(argss.argumentss.i[1]);
					}else{
							sleeps(Convert.ToInt16(vars1.getvar(argss.argumentss.txt[1].Trim())));
						}
					}catch{
						Console.WriteLine("error: sleep!");	
					}
				
				return "";
			}
			public string BEEP(){
				Console.Beep(415,1500);
				
				return "";
			}
			public string HELP(){
				center("help this help",terminal);
				center("for var from into steep ; echo var ; # for command",terminal);
				center("logic var $var1 = $var2 && $var3 ! $var4 ; # bool test",terminal);
				center("if $var ; echo var ; # check if a var is false or 0 afther a logic var test",terminal);
				center("time var ; sleep var ; # put the take time run in a var",terminal);
				center("sleep var ; # waits seconds",terminal);
				center("exit ; # exit command line or a bash file",terminal);
				center("cat file ; # list a file in the screen",terminal);
				center("command $file ; # call a command file bash .lst",terminal);
				center("printf var ; # put a message in a screen",terminal);
				center("echo var ; # put a message in a screen",terminal);
				center("expr var $var1 + $var2 - $var3 * $var4 / $var5 ; # mat expressions",terminal);
				center("cal var year moth",terminal);
				center("cls ; # clear screen",terminal);
				center("dir var; # list all files",terminal);
				center("dir ; # list all files",terminal);
				center("date var ; # put data time into a var",terminal);
				center("on ; # show the command in a bash file",terminal);
				center("off ; # dont show the command in a bash file",terminal);
				center("vars ; # list all var in the screen",terminal);
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
			string s="";
			int i1=0;
			int i2=0;
			arguments argss = new arguments(files, ' ');
					try{
						if(argss.argumentss.numbers[2]){
						i1=argss.argumentss.i[2];
					}else{
						i1=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[2].Trim()));
					}
						if(argss.argumentss.numbers[3]){
						i2=argss.argumentss.i[3];
					}else{
						i2=Convert.ToInt16(vars1.getvar(argss.argumentss.txt[3].Trim()));
					}
	
				s="";
			int [] Mday = new int[]{31,28,31,30,31,30,31,31,30,31,30,31};
			DateTime d = new DateTime();
			
			
			int month=i1;
			int year=i2;
			string space="";
			int i;
			int max=Mday[month-1];
			int wd=0;
			
		  
			d=Convert.ToDateTime(Convert.ToString(1)+"/"+i2.ToString()+"/"+i1.ToString()+" 12:0:0");
			if (month==2){
				i=year/4;
				i=i*4;
				if(year==i)max++;
			}
			
			s=s+Convert.ToString(year)+"\r\n";
			s=s+Convert.ToString(month)+"\r\n";
			s=s+"Su Mo Tu We Th Fr Sa"+"\r\n";
			wd=Convert.ToInt16(d.DayOfWeek);
			for(i=0;i<wd;i++){
				s=s+"   ";
			}
			for(i=0;i<max;i++){
				space="";
				if (i < 9)space=" ";
					s=s+space+Convert.ToString(i+1)+" ";
				wd++;
				if(wd>6){
					s=s+"\r\n";
					wd=0;
				}
			}
			s=s+"\r\n";
			vars1.setvar(argss.argumentss.txt[1].Trim(),s);
		  }catch{
			  Console.WriteLine("error on calender value");
		  }
		
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

		public class maps{
			public int count=25;
			public int col=80;

			

			public maps(int x, int y){
				int i;
				count=y;
				col=x;
			}
	
			public void  mapstar(int x,int y,string ssss){
				
				if (x>-1 && x<col && y>-1 && y<count){
					Console.SetCursorPosition(x,y);
					Console.Write(ssss);
				}
			}
			
			public void Println(){
				int i;
				int ii;
				string s="";
			}
			
			public void pstring(int x,int y,string s){
				int i=0;
				int ii=x;
				int iii=s.Length;
				string ss="";
				if (ii+iii>col)iii=iii+x-col;
					for(i=0;i<iii;i++)ss=ss+s[i];
					mapstar(x,y,ss);
				
			}
			public void vstring(int x,int y,string s){
				int i=0;
				int ii=y;
				int iii=s.Length;
				if (ii+iii>count)iii=iii+y-count;
				for(i=0;i<iii;i++){
					mapstar(x,i+y,s[i].ToString());
				}
					
				
			}
			public void vcenter(int x,string s){
				int y=count/2;
				y=y-s.Length/2;
				if (y<0)y=0;
				vstring(x,y,s);
			}
			public void center(int y,string s){
				int x=col/2;
				x=x-s.Length/2;
				if (x<0)x=0;
				pstring(x,y,s);
			}
			public void circle(int x,int y,int r,char s){
				double d=0.00f;
				double dd=0.00f;
				double ddd=0.00f;
				double xx=Convert.ToDouble(x);
				double yy=Convert.ToDouble(y);
				double rr=Convert.ToDouble(r);
				int i=0;
				int ii=0;
				int iii=0;
				
				ddd=Math.PI*Math.PI*rr+5.00f;
				iii=Convert.ToInt16(ddd);
				ddd=ddd/2;
				for (i=0;i<iii;i++){
					d=xx+rr*Math.Cos(Convert.ToDouble(i)/(ddd)*Math.PI);
					dd=yy+rr*Math.Sin(Convert.ToDouble(i)/(ddd)*Math.PI);
					mapstar(Convert.ToInt16(d),Convert.ToInt16(dd),s.ToString());
				}

			}
			public void horline(int x, int y, int w , char c){
				int i=x;
				int ii=x;
				int iii=w;
				string ss="";
				if (ii+iii>col)iii=iii+x-col;

				string ssss="";
				for (i=0;i<iii;i++){
					ssss=ssss+c;
				}
				mapstar(x,y,ssss);
			}
			public void fillcircle(int x,int y,int r,char s){
				int [] half=new int[2000];
				double d=0.00f;
				double dd=0.00f;
				double ddd=0.00f;
				double d1=0.00f;
				double ddd1=0.00f;
				double rr=Convert.ToDouble(r);
				string ss="";

				int i=0;
				ddd1=rr*2.00f;
				ddd=ddd1*2.00f;
				
				
				for (i=0;i<r*2;i++){
					half[i]=Convert.ToInt16(rr*Math.Sin(Convert.ToDouble(i)/ddd1*Math.PI));
					horline(x-half[i],i+(y-r),half[i]*2,s);
				}
				
			}
			public void verline(int x, int y, int h , char c){
				int i=x;
				int ii=y;
				int iii=h;
				if (ii+iii>count)iii=iii+y-count;
				string ssss="";
				for (i=y;i<y+iii;i++){
					mapstar(x,i,c.ToString());
				}
				
			}
			public void grid(int x, int y, int w ,int h,int steep ,char c){
				int i=0;
				for(i=y;i<y+h;i=i+steep)horline(x,i,w,c);
				for(i=x;i<x+w;i=i+steep)verline(i,y,h,c);
			}	
			public void lrect(int x, int y, int w ,int h, char c){
				horline(x,y,w,c);
				horline(x,y+h,w,c);
				verline(x,y,h+1,c);
				verline(x+w,y,h+1,c);

			}

			public void rect(int x, int y, int w ,int h, char c){
					int i=0;
					for (i=y;i<y+h;i++){
						horline(x,i,w,c);
					}
				
			}
	
		}

		public class Binary{
			public byte value =0;
			public bool [] bits = new bool[8];
			public Binary(byte b){
				int i=0;
				value=b;
				reset();
				solve(value);
			}
			public void reset(){
				int i=0;
				for(i=0;i<8;i++)bits[i]=false;
			}
			public byte back(){
				int i=0;
				byte bb=1;
				byte bbb=2;
				value=0;
				for(i=0;i<8;i++){
					if(bits[i])value=Convert.ToByte(value | bb);
					bb=Convert.ToByte((bb*bbb) & 255);
					
				}
				
				
				return value;
			}
			public void solve(byte b){
				int i=0;
				byte bb=1;
				byte bbb=2;
				value=b;
				for(i=0;i<8;i++){
					bits[i]=(value & bb)!=0;
					bb=Convert.ToByte((bb*bbb) & 255);
					
				}
				
				
				
			}
			public string report(){
				int i=0;
				string s="";
				for(i=7;i>-1;i--){
					if(bits[i]){
						s=s+"1";
					}else{
						s=s+"0";
					}
				}
				return s;
			}
		}
		

		public class HEX{
			public byte value=0;
			public byte low=0;
			public byte high=0;
			public string s="";
			public HEX(byte b){
				value=b;
				solve(value);
			}
			public void solve(byte b){
				value=b;
				high=highs(b);
				low=lows(b);
				s=""+values(high);
				s=s+values(low);
				
			}
			public byte back(){
				byte b=0;
				low=Convert.ToByte(low & 15);
				high=Convert.ToByte(high & 15);
				b=Convert.ToByte(high*16);
				b=Convert.ToByte(b | low);
				
				value=b;
				s=""+values(high);
				s=s+values(low);
				
				return b;
			}
			public byte highs(byte b){
				byte bb=16;
				bb=Convert.ToByte(b/bb);
				return bb;
			}
			public byte lows(byte b){
				return Convert.ToByte(b & 15);
			}
			public char values(byte b){
				byte bb=Convert.ToByte(b & 15);
				string s="0123456789ABCDEF";
				return s[bb];
			}
			public string print(){

				return s;
			}

		}

		public class lineInsert{
			public string value ="";
			public int x=0;
			public int y=0;
			public int length=0;
			public int max=79;
			int cursor=0;
			public int line=0;			
			public lineInsert(){
			}
			public string input(string [] back, int len){
				ConsoleKeyInfo key=new ConsoleKeyInfo();
				string s="";
				char last=' ';
				char c32=' ';
				char c13='\r';
				int b=32;
				int bb=32;
				bool exits=false;
				int i=0;
				line=len-1;
				x=Console.CursorLeft;
				y=Console.CursorTop;
				value=value.Replace("_","");				
				cursor=value.Length;
				cursorinsert();
				while(!exits){
					try{
						key=Console.ReadKey(true);
						b=Convert.ToInt16(key.Key);
					}catch{
						b=0;
					}
					
					if(key.Key==ConsoleKey.UpArrow){
						clears();
							line--;
							refresh(back,len);
						
					}
					if(key.Key==ConsoleKey.DownArrow){
						clears();
							line++;
							refresh(back,len);
					}
					
					if(key.Key==ConsoleKey.PageDown){
						clears();
							line=len;
							refresh(back,len);
					}
					if(key.Key==ConsoleKey.PageUp){
							clears();
							line=0;
							refresh(back,len);
					}

					
					if(key.Key==ConsoleKey.LeftArrow ){

								value=value.Replace("_","");
								cursor--;
								cursorinsert();
								bb=0;
								b=1;

					}
					if(key.Key==ConsoleKey.RightArrow ){

								value=value.Replace("_","");
								cursor++;
								cursorinsert();
								bb=0;
								b=1;

					}


					if(key.Key==ConsoleKey.End ){

								value=value.Replace("_","");
								cursor=value.Length;
								cursorinsert();
								bb=0;
								b=1;

					}
					if(key.Key==ConsoleKey.Home ){

								value=value.Replace("_","");
								cursor=0;
								cursorinsert();
								bb=0;
								b=1;

					}

					if(key.Key==ConsoleKey.Enter)exits=true;
					if((key.Key==ConsoleKey.Delete || key.Key==ConsoleKey.Backspace) && length>0){
					
								s="";
								
								value=value.Replace("_","");
								cursor--;
								
								if(cursor>-1){
									char c=value[cursor];
									value=value.Insert(cursor,"_");
									value=value.Replace("_"+c,"");
								}
								value=value.Replace("_","");
								cursorinsert();
								bb=0;
								b=1;
								 
					
					}
					
					if(key.KeyChar>=' ' && length<max){
					
						if(key.KeyChar!='_') value=value.Replace("_",key.KeyChar.ToString());
						value=value.Replace("_","");
						cursor++;
						cursorinsert();
					}
					
				
				}
				value=value.Replace("_","");
				cursorinsert();
				value=value.Replace("_","");
				length=value.Length;
				Console.WriteLine("");
				return value;
			}
			
			
			public void cursorinsert(){
				string ss="";
				int ii=0;
				length=value.Length;
				if(cursor>length)cursor=length;
				if(cursor<0)cursor=0;
				
				for(ii=0;ii<value.Length+1;ii++){
					if(cursor==ii)ss=ss+"_";
					if(ii<value.Length)ss=ss+value[ii];
				}
				
				value=ss;
				Console.CursorLeft=x;
				Console.CursorTop=y;
				Console.Write(value+"  ");
				Console.CursorLeft=x+cursor;
				Console.CursorTop=y;
				

				
			}
			public void refresh(string [] back,int len){
				if(len>0){
					if(line>len-1)line=len-1;
					if(line<0)line=0;
					value=back[line];
					value=value.Replace("_","");
					length=value.Length;
					cursor=length;
					cursorinsert();
				}
			}
			public string stringss(int ii,string ss){
				int i=0;
				string s="";
				for(i=0;i<ii;i++){
					s=s+ss;
				}
				return s;
			}
			public void clears(){
				Console.CursorLeft=x;
				Console.CursorTop=y;
				Console.Write(stringss(value.Length," "));
			}


		}

		public class VarList{
			public const int max=1025;
			public int length=0;
			public string [] name= new string[max];
			public string [] value= new string[max];
			public VarList (){
				int i=0;
				for(i=0;i<max;i++){
					name[i]="";
					value[i]="";
				}
				
				
			}
			public void setvar(string s,string ss){
				int i=0;
				int ii=-1;
				string s1=s.Trim();
				for(i=0;i<length;i++){
					if(string.Compare(name[i],s1)==0){
						value[i]=ss;
						ii=i;
						i=length+1;
					}
				}
				if(length<max-2 && ii==-1){
					name[length]=s;
					value[length]=ss;
					length++;
				}
			}
			public string getvar(string s){
				string ss="";
				int i=0;
				string s1=s.Trim();
				for(i=0;i<length;i++){
					if(string.Compare(name[i],s1)==0){
						ss=value[i];
						i=length+1;
					}
				}
				return ss;
			}
			public void list(){
				int i;
				for(i=0;i<length;i++){
					Console.WriteLine("{0},{1}={2}",i,value[i],value[i]);
				}
			}
			
		}


			public class arguments{
				public returnArg argumentss=new returnArg();
				public arguments(string args , char separetor){
					int i=0;
					char c=' ';
					argumentss.s=args;
					argumentss.ss=argumentss.s.Trim().ToUpper();
					argumentss.txt=argumentss.ss.Split(separetor);
					argumentss.texts=args.Split(separetor);
					argumentss.length=argumentss.texts.Length;
					
					argumentss.number= new double[argumentss.length];
					argumentss.numbers= new bool[argumentss.length];
					argumentss.i= new int[argumentss.length];
					
					for(i=0;i<argumentss.length;i++){
						if(argumentss.texts[i].Length>0){
							c=argumentss.texts[i][0];
							if((c>='0' && c<='9') || c=='+' || c=='-'){
								argumentss.number[i]=Convert.ToDouble(argumentss.texts[i].Trim());
								argumentss.i[i]=(int) argumentss.number[i];
								argumentss.numbers[i]=true;
							}else{
								argumentss.i[i]=0;
								argumentss.number[i]=0.00f;
								argumentss.numbers[i]=false;
							}
						}else{
							argumentss.i[i]=0;
							argumentss.number[i]=0.00f;
							argumentss.numbers[i]=false;
						}
					}
					
				}
				public void report(){
					int i=0;
					Console.WriteLine("{0}",argumentss.s);
					for(i=0;i<argumentss.length;i++)Console.WriteLine("{0},{1},{2},{3},{4},{5}",i,argumentss.texts[i],argumentss.txt[i],argumentss.number[i],argumentss.i[i],argumentss.numbers[i]);
				}
				
			}
			public class returnArg{
				public string [] texts;
				public string [] txt;
				public int [] i;
				public double [] number;
				public bool [] numbers;
				public int length=0;
				public string s="";
				public string ss="";
				
			}
			public class argumentst{
				public returnArg argumentss=new returnArg();
				public argumentst(string args , char separetor){
					int i=0;
					char c=' ';
					argumentss.s=args;
					argumentss.ss=argumentss.s.Trim().ToUpper();
					argumentss.txt=argumentss.ss.Split(separetor);
					argumentss.texts=args.Split(separetor);
					argumentss.length=argumentss.texts.Length;
					
					argumentss.number= new double[argumentss.length];
					argumentss.numbers= new bool[argumentss.length];
					argumentss.i= new int[argumentss.length];
					
					for(i=0;i<argumentss.length;i++){
						if(argumentss.texts[i].Length>0){
							c=argumentss.texts[i][0];
							if(c>='0' && c<='9') {
								argumentss.number[i]=Convert.ToDouble(argumentss.texts[i].Trim());
								argumentss.i[i]=(int) argumentss.number[i];
								argumentss.numbers[i]=true;
							}else{
								argumentss.i[i]=0;
								argumentss.number[i]=0.00f;
								argumentss.numbers[i]=false;
							}
						}else{
							argumentss.i[i]=0;
							argumentss.number[i]=0.00f;
							argumentss.numbers[i]=false;
						}
					}
					
				}
				public void report(){
					int i=0;
					Console.WriteLine("{0}",argumentss.s);
					for(i=0;i<argumentss.length;i++)Console.WriteLine("{0},{1},{2},{3},{4},{5}",i,argumentss.texts[i],argumentss.txt[i],argumentss.number[i],argumentss.i[i],argumentss.numbers[i]);
				}
				
			}

		public class Edit{
			public string name="";
			public int pos=0;
			private lineNew list1 = new lineNew();			
			public Edit(string s){
				int i=0;
				bool exits=false;
				string ss="";
				name=s;
			list1.x=0;
			list1.w=78;
			list1.y=0;
			list1.h=20;
			list1.start=0;
				list1.clear();
				if(name=="")list1.add("",list1.length+1);
				if (name=="")name="new.lst";
				try{
					list1.load(name);
				}catch{
					list1.add("",list1.length+1);
				}
				
				
				pos=0;
				int chrs=0;
				while(!exits){
					
					lineInserts inputs = new lineInserts();
					Console.Clear();
					list1.report();
					ss=list1.gets(pos);
					Console.CursorLeft=list1.y;
					Console.CursorTop=pos-list1.start;
					chrs=0;
					inputs.value=ss;
					returner rr=inputs.input(ss,chrs);
					ss=rr.rets;
					chrs=rr.keys;
					if(pos>=list1.length){
						list1.add(ss,pos);
					}else{
						list1.change(ss,pos);
					}
					if(chrs==8){
						exits=true;
						
					}

					if(chrs==1){
						pos=pos+1;
						list1.add("",pos);
					}
					if(chrs==2){
						pos=pos-1;
					}
					if(chrs==3){
						pos=pos+1;
						if(pos>list1.length)list1.add("",pos);
					}
					if(chrs==4){
						list1.start=list1.start-19;
						pos=pos-19;
					}
					if(chrs==5){
						list1.start=list1.start+19;
						pos=pos+19;
					}
					if(pos<0){
						pos=0;
						list1.start=0;
					}
					if(pos>list1.length){
						pos=list1.length;
						list1.add("",pos);
					}
					if(list1.start>list1.length)list1.start=list1.length-1;
					if(list1.start<0)list1.start=0;
					if(list1.start<pos-19)list1.start=pos-19;
					if(list1.start>list1.length)list1.start=list1.length-1;
					if(list1.start>pos)list1.start=pos;
					if(list1.start<0)list1.start=0;
				}
				try{
					list1.save(name);
				}catch{
					
				}

			}
		}


		public class returner{
			public string rets="";
			public int keys=0;
		} 


		public class lineNew{
			public int x=0;
			public int y=0;
			public int w=76;
			public int h=20;
			public int start;
			public int length=0;
			private int lengths=0;
			const int max=32002;
			public int maxs=max;
			public bool [] del= new bool[max];
			public int [] lint= new int[max];
			public string [] listss= new string[max];
			public lineNew(){
				int i=0;
				length=0;
				for(i=0;i<max;i++){
					listss[i]="";
					lint[i]=0;
					del[i]=false;
				}
			}
			public void change(string text,int index){
				if(index<length)listss[lint[index]]=text;
			}
			public void add (string text,int index){
				int i=0;
				int iii=index;
				int ii=-1;
				if(iii>length)iii=length;
				if(iii<0)iii=0;
				if (length>0 && length<max && lengths<max && iii<max){
					
					for(i=0;i<lengths;i++){
						if (del[i]){
							del[i]=false;
							ii=i;
							listss[i]=text;
							i=lengths+1;
						}
					}
					
					if (ii<0 && lengths<max){
						ii=lengths;
						listss[ii]=text;
						lengths++;
					}

				}

				if (ii>-1 && length>0 && length<max && lengths<max){
					if(iii!=length){
						for(i=length;i>index;i--){
							lint[i]=lint[i-1];
						}
					
					
					}
						
					lint[iii]=ii;
					if (length>0 && length<max-1)length++;
				}
				if (length==0){
					ii=lengths;
					listss[ii]=text;
					lengths++;
					lint[length]=ii;
					length++;
				}
			}
			public void remove(int index){
				int i=0;
				if(index<length)del[lint[index]]=true;
				if (index<length && index>-1){
					for(i=index;i<length;i++){
						lint[i]=lint[i+1];
					}
				
					if (length>0)length--;
				}

				
			}
			public string gets(int index){
				int i=0;
				string ss="";
				if (index<length && index<length && index>-1){
						ss=listss[lint[index]];
				
				}
				return ss;

				
			}

			public void load(string name){
				int i;
				string s="";
				string ss=null;
				string [] sss=null;
				try{
					ss=File.ReadAllText(name);
				}catch{
				}
				length=0;
				lengths=0;
				ss=ss.Replace("\r","");
				sss=ss.Split('\n');
				for(i=0;i<max;i++){
					del[i]=false;
					if(i<sss.Length){
						lint[i]=i;
						listss[i]=sss[i];
					}
				}
				length=sss.Length;
				lengths=sss.Length;
			}
			public void save(string name){
				int i;
				string s="";
				for(i=0;i<length;i++)s=s+listss[lint[i]]+"\r\n";
				try{
					File.WriteAllText(name,s);
				}catch{
				}
			}
			public void clear(){
				int i=0;
				length=0;
				lengths=0;
				for(i=0;i<max;i++){
					del[i]=false;
				}
			}
		public string mid(string ss,int start,int size){
			int i;
			string s="";
			int sizes=size+start;
			int starts=start;
			if (start>ss.Length)starts=ss.Length-1;
			if (starts<0)starts=0;
			if (sizes>ss.Length)sizes=ss.Length;
			for(i=start;i<sizes;i++)s=s+ss[i];
			return s;
		}

			public void report(){
				int i=0;
				string s="";
				int ii=h;
				if(start<0)start=0;
				if(length<h)ii=length;
				if(start+ii>length)start=length-h;
				if(start<0)start=0;
				if(length>h)ii=start+ii;
				
				for(i=start;i<ii;i++){
					Console.CursorTop=y+i-start;
					Console.CursorLeft=x;
					if(listss[lint[i]].Length<w){
						Console.Write(listss[lint[i]]);
					}else{
						s=mid(listss[lint[i]],0,w);
						Console.Write(s);
					}

				}
				Console.CursorTop=y+i-start;
				Console.CursorLeft=0;

			}
		}
		
		public class lineInserts{
			public int tkeys=0;
			public string value ="";
			public int x=0;
			public int y=0;
			public int length=0;
			public int max=79;
			int cursor=0;
			public int line=0;			
			public lineInserts(){
			}
			public returner input(string back, int keys){
				returner rr = new returner();
				ConsoleKeyInfo key=new ConsoleKeyInfo();
				string s="";
				char last=' ';
				char c32=' ';
				char c13='\r';
				int b=32;
				int bb=32;
				bool exits=false;
				int i=0;
				line=0;
				x=Console.CursorLeft;
				y=Console.CursorTop;
				value=value.Replace("_","");				
				cursor=value.Length;
				cursorinsert();
				while(!exits){
					try{
						key=Console.ReadKey(true);
						b=Convert.ToInt16(key.Key);
					}catch{
						b=0;
					}
					
					if(key.Key==ConsoleKey.UpArrow){
						clears();
						tkeys=2;
						exits=true;						
					}
					if(key.Key==ConsoleKey.DownArrow){
						clears();
						tkeys=3;
						exits=true;						
					}
					
					if(key.Key==ConsoleKey.PageDown){
						clears();
						tkeys=5;
						exits=true;						
					}
					if(key.Key==ConsoleKey.PageUp){
						clears();
						tkeys=4;
						exits=true;						
					}

					if(key.Key==ConsoleKey.Escape){
						clears();
						tkeys=8;
						exits=true;						
					}



					
					if(key.Key==ConsoleKey.LeftArrow ){

								value=value.Replace("_","");
								cursor--;
								cursorinsert();
								bb=0;
								b=1;

					}
					if(key.Key==ConsoleKey.RightArrow ){

								value=value.Replace("_","");
								cursor++;
								cursorinsert();
								bb=0;
								b=1;

					}


					if(key.Key==ConsoleKey.End ){

								value=value.Replace("_","");
								cursor=value.Length;
								cursorinsert();
								bb=0;
								b=1;

					}
					if(key.Key==ConsoleKey.Home ){

								value=value.Replace("_","");
								cursor=0;
								cursorinsert();
								bb=0;
								b=1;

					}

					if(key.Key==ConsoleKey.Enter){
						clears();
						tkeys=1;
						exits=true;						

					}
					if((key.Key==ConsoleKey.Delete || key.Key==ConsoleKey.Backspace) && length>0){
					
								s="";
								
								value=value.Replace("_","");
								cursor--;
								
								if(cursor>-1){
									char c=value[cursor];
									value=value.Insert(cursor,"_");
									value=value.Replace("_"+c,"");
								}
								value=value.Replace("_","");
								cursorinsert();
								bb=0;
								b=1;
								 
					
					}
					
					if(key.KeyChar>=' ' && length<max){
					
						if(key.KeyChar!='_') value=value.Replace("_",key.KeyChar.ToString());
						value=value.Replace("_","");
						cursor++;
						cursorinsert();
					}
					
				
				}
				//value=value.Replace("_","");
				//cursorinsert();
				value=value.Replace("_","");
				length=value.Length;
				rr.rets=value;
				rr.keys=tkeys;
				return rr;
			}
			
			
			public void cursorinsert(){
				string ss="";
				int ii=0;
				length=value.Length;
				if(cursor>length)cursor=length;
				if(cursor<0)cursor=0;
				
				for(ii=0;ii<value.Length+1;ii++){
					if(cursor==ii)ss=ss+"_";
					if(ii<value.Length)ss=ss+value[ii];
				}
				
				value=ss;
				Console.CursorLeft=x;
				Console.CursorTop=y;
				Console.Write(value+"  ");
				Console.CursorLeft=x+cursor;
				Console.CursorTop=y;
				

				
			}
			public void refresh(string [] back,int len){
				if(len>0){
					if(line>len-1)line=len-1;
					if(line<0)line=0;
					value=back[line];
					value=value.Replace("_","");
					length=value.Length;
					cursor=length;
					cursorinsert();
				}
			}

			public string stringss(int ii,string ss){
				int i=0;
				string s="";
				for(i=0;i<ii;i++){
					s=s+ss;
				}
				return s;
			}
			public void clears(){
				Console.CursorLeft=x;
				Console.CursorTop=y;
				Console.Write(stringss(value.Length," ")+"  ");
			}


		}



		static void Main(string[] args){
			string s="";
			if(args.Length>0)s=args[0];
			Shells shells = new Shells(s);

				

		}

		
	}
}
}





