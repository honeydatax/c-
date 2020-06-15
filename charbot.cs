using System;

namespace logic{
	
	class logics{
		public class chatboot{
			public int length=0;
			public KEYS keys = new KEYS();
			public const int maxword=1024;
			public const int maxclient=1024;
			public sublist [] sublist1=new sublist [maxclient];
			public string [] words=new string[maxclient];
			public chatboot(){
				int i=0;
							
				for(i=0;i<maxword;i++)words[i]="";
				for(i=0;i<maxclient;i++)sublist1[i]=new sublist();
			}
			public void bot(){
				int i=0;
				int ii=0;
				string tnames="";
				string lnames="";
				if (keys.length>1){
					Console.WriteLine("{0}",keys.keys[0]);
					Console.WriteLine("{0}",keys.values[0]);
					tnames=Console.ReadLine();
					Console.WriteLine("{0}",keys.keys[1]);
					Console.WriteLine("{0}",keys.values[1]);
					lnames=Console.ReadLine();
					i=find(tnames,lnames);
					Console.WriteLine("{0}",i);
					if (i>-1 && keys.length>2){
						for(ii=2;ii<keys.length;ii++){
							Console.WriteLine("{0}",keys.keys[ii]);
							Console.WriteLine("{0}",keys.values[ii]);
							sublist1[i].values[ii]=Console.ReadLine().Trim().ToUpper();
							if(sublist1[i].values[ii]=="")sublist1[i].values[ii]=" "; 
						}
						for(ii=0;ii<keys.length;ii++){
							Console.WriteLine("{0}",keys.keys[ii]);
							Console.WriteLine("{0}",sublist1[i].values[ii]);
							
						}

						
					}
				}
				
				
				
			}
			public int find(string s, string ss){
				int iii=-1;
				int ii=-1;
				int i=0;
				string s1="";
				string s2="";
				s1=s.ToUpper();
				s2=ss.ToUpper();
				s1=s1.Trim();
				s2=s2.Trim();
				if (length<maxclient){
					for(i=0;i<length;i++){
						if (sublist1[i].values[0].IndexOf(s1)==0 && sublist1[i].values[0].Length==s1.Length && sublist1[i].values[1].IndexOf(s2)==0 && sublist1[i].values[1].Length==s2.Length){
							ii=i;
							i=length+1;
						}
						
						
					}
					
				}
				if(ii!=-1){
					Console.WriteLine("client exists. error");
				}else{
					
					if(length<maxclient){
						sublist1[length].values[0]=s1;
						sublist1[length].values[1]=s2;
						i=length;
						length++;

					}

				}
				return i;
			}
		}
		public class sublist{
			public const int max=1024;
			public string [] values=new string[max];
			public sublist(){
				int i=0;
				for(i=0;i<max;i++)values[i]="";
			}
			
		}
		public class KEYS{
			public const int max=1025;
			public string [] keys=new string[max];
			public string [] values=new string[max];
			public int length=0;
			public KEYS(){
				int i=0;
				for(i=0;i<max;i++)keys[i]="";
				for(i=0;i<max;i++)values[i]="";
			
			}
			public void add(string s, string ss){
				string s1=s;
				if(length<max){
					s1=s.ToUpper();
					keys[length]=s.Trim();
					values[length]=ss;
					length++;
				}
			}
			public void print(bool s){
				int i=0;
				int ii=0;
				
					if(s)ii=length-1;
					for(i=0;i<length;i++){
						if(s){
							ii=length-1-i;
						}else{
							ii=i;
						}
						
						Console.WriteLine("{0}:",keys[ii]);
						Console.WriteLine("			:{0}",values[ii]);
					}
				
				
			}
			public void separete(){
				Console.WriteLine("----------------");
			}
		}
		
		
		static void Main(string[] args){
			chatboot bot1 = new chatboot();
			
			bot1.keys.add("NAME","wats is you name?: ");
			bot1.keys.add("LAST NAME","wats is you last name?: ");
			bot1.keys.add("AGE","wats is you age?: ");
			bot1.bot();
			
			
			
		}

		
	}
}






