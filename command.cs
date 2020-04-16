using System;
using System.IO;
namespace logic{
	
	class logics{
		public void MMain(string args){
			logics logss = new logics();
			string s;
			string s1;
			int i;
			int index;
			int n;
			string s3="";
			if (args.Length>0) s3=args;
			string [] list;
			try{
				list=File.ReadAllLines(s3);
			}catch{
				list=new string[1];
			}
			bool b=true;
				Console.WriteLine("bash");
				for(i=0;i<list.Length;i++){
					s1=list[i];
					s1=s1.Trim();
					s=s1.ToUpper();
					Console.WriteLine("out: {0}!",s);
					if (s.IndexOf("EXIT")>-1){
						 i=list.Length+1; 
						 s="";
					 }
					if (s.IndexOf("CLS")>-1){
						Console.Clear(); 
						s="";
					}
					if (s.IndexOf("CLEAR")>-1){
						 Console.Clear(); 
						 s="";
					 }
					if (s.IndexOf("DIR")>-1 || s.IndexOf("LS")>-1){
						
						try{
							int t;
							s=".";
							string [] files = Directory.GetFiles(s);
							for(i=0;i<files.Length;i++)Console.WriteLine("{0}!",files[i]);	
							t=files.Length;
							Console.WriteLine(" {0} files!",t);	
						}catch{
							Console.WriteLine("error: {0}!",s);	
						}
						s="";
					}
					if (s.IndexOf("CAT")>-1 || s.IndexOf("TYPE")>-1){
						s=logss.arg2(s1);
						try{
							s=File.ReadAllText(s);
						}catch{
							Console.WriteLine("error: {0}!",s);	
						}
						Console.WriteLine("out: {0}!",s);	
						s="";
					} 

					
				}

		}
		public string arg2(string s){
			string s1="";
			int i;
			int index=s.IndexOf(" ");
			if (index>0){
				for(i=index;i<s.Length;i++){
					s1=s1+s[i].ToString();
				}
				s1=s1.Trim();
			}
			return s1;
		}
		static void Main(string[] args){
			logics logss = new logics();
			string s;
			string s1;
			int i;
			int index;
			bool b=true;
				Console.WriteLine("hello world");
				while(b){
					Console.Write(">");
					s1=Console.ReadLine();
					s1=s1.Trim();
					s=s1.ToUpper();
					Console.WriteLine("out: {0}!",s);
					if (s.IndexOf("EXIT")>-1){
						 b=false; 
						 s="";
					 }
					if (s.IndexOf("CLS")>-1){
						Console.Clear(); 
						s="";
					}
					if (s.IndexOf("CLEAR")>-1){
						 Console.Clear(); 
						 s="";
					 }
					if (s.IndexOf("DIR")>-1 || s.IndexOf("LS")>-1){
						
						try{
							int t;
							s=".";
							string [] files = Directory.GetFiles(s);
							for(i=0;i<files.Length;i++)Console.WriteLine("{0}!",files[i]);	
							t=files.Length;
							Console.WriteLine(" {0} files!",t);	
						}catch{
							Console.WriteLine("error: {0}!",s);	
						}
						s="";
					}
					if (s.IndexOf("CAT")>-1 || s.IndexOf("TYPE")>-1){
						s=logss.arg2(s1);
						try{
							s=File.ReadAllText(s);
						}catch{
							Console.WriteLine("error: {0}!",s);	
						}
						Console.WriteLine("out: {0}!",s);	
						s="";
					} 
 					if (s.IndexOf("BASH")>-1 || s.IndexOf("SH")>-1){
						s=logss.arg2(s1);
						logss.MMain(s);
						s="";
					} 


					
				}

		}

		
	}
}






