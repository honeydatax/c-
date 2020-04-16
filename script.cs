using System;
using System.IO;
namespace logic{
	
	class logics{
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
			int n;
			string s3="";
			if (args.Length>0) s3=args[0];
			string [] list=File.ReadAllLines(s3);
			bool b=true;
				Console.WriteLine("hello world");
				for(i=0;i<list.Length;i++){
					s1=list[i];
					s1=s1.Trim();
					s=s1.ToUpper();
					Console.WriteLine("out: {0}!",s);
					if (s.IndexOf("EXIT")==0) b=false; 
					if (s.IndexOf("CLS")==0) Console.Clear(); 
					if (s.IndexOf("CLEAR")==0) Console.Clear(); 
					if (s.IndexOf("CAT")==0 || s.IndexOf("TYPE")==0){
						s=logss.arg2(s1);
						try{
							s=File.ReadAllText(s);
						}catch{
							Console.WriteLine("error: {0}!",s);	
						}
						Console.WriteLine("out: {0}!",s);	
					} 
					if (s.IndexOf("DIR")==0 || s.IndexOf("LS")==0){
						
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

					} 

					
				}

		}

		
	}
}






