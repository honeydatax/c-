using System;

namespace logic{
	
	class logics{
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
		static void Main(string[] args){
			arguments argss = new arguments("hello world hi there -12.8", ' ');
			argss.report();
			
			
		}

		
	}
}






