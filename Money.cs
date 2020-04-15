using System;

namespace logic{
	
	class logics{
		public class MONEY{
			public MOVES [] moves;
			public int len=0; 
			public int max=0; 
			public MONEY(int count){
				int i;
				int counts;
				counts=count;
				if (counts>1000)counts=1000;
				max=counts;
				moves=new MOVES[counts];
				for(i=0;i<max;i++){
					moves[i]=new MOVES();
				}
			}
			
			public class MOVES{
				public string des="";
				public int value=0;
				
			}
			
			public void add(string s,int values){
				if (len<max){
					moves[len].des=s;
					moves[len].value=values;
					len++;
				}
			}

			public string spaces(string s,int values){
				string ss=s.Trim();
				while((ss.Length<values && values < 80)){	
					ss=ss+" ";
					
				}
				return ss;
			}

			public string zero(string s,int values){
				string ss=s.Trim();
				while((ss.Length<values && values < 50)){	
					ss="0"+ss;
					
				}
				return ss;
			}
			public void Report(){
				int i;
				int sum=0;
				string s1="";
				string s2="";
				string s3="";
				for(i=0;i<len;i++){
					sum=sum+moves[i].value;
					s1=spaces(moves[i].des,20);
					s2=spaces(Convert.ToString(moves[i].value),20);
					s3=spaces(Convert.ToString(sum),20);
					Console.WriteLine("{0}{1}{2}",s1,s2,s3);
				}
			}
			
		}

		static void Main(string[] args){
			MONEY money = new MONEY(50);
			string s="";
			int i=0;
			int max=17;
			Random rnds;
			rnds=new Random();
			for (i=0;i<max;i++){
				s="MOV "+money.zero(Convert.ToString(i),8);
				money.add(s,rnds.Next(2000)-1000);
			}
			money.Report();
				

		}

		
	}
}






