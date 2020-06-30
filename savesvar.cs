using System;
using System.IO;

namespace logic{
		
	class logics{
			public class configFile{
				public VarList vars = new VarList();
				public configFile(){
					
				}

				public void clear(){
					vars.length=0;
				}
				public void save(string file){
					int i=0;
					string s="";
					for(i=0;i<vars.length;i++){
						s=s+vars.name[i]+"="+vars.value[i]+"\r\n";
					}
					File.WriteAllText(file,s);
				}
				public void load(string file){
					int i=0;
					vars.length=0;
				  try{
					string [] ss = File.ReadAllLines(file);
					for(i=0;i<ss.Length;i++){
						
							arguments argss = new arguments(ss[i],'=');
							vars.setvar((argss.argumentss.txt[0].Trim()).ToUpper(),argss.argumentss.texts[1]);
						
					}
				   }catch{
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
					Console.WriteLine("{0},{1}={2}",i,name[i],value[i]);
				}
			}
			
		}

		static void Main(string[] args){
			configFile cnf = new configFile();
			
			cnf.vars.setvar("a","hello world");
			cnf.vars.setvar("b","10");
			cnf.vars.setvar("c","20");
			cnf.vars.setvar("config","config.txt");
			cnf.save(cnf.vars.getvar("config"));
			cnf.clear();
			cnf.load("config.txt");
			cnf.vars.list();
			
			
		}

		
	}
}






