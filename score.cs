using System;

namespace logic{
	
	class logics{
		public class score{
			const int count=10;
			public int len=0;
			public sscores [] n1= new sscores[count];
			private sscores [] n2= new sscores[count];
			public class sscores{
				public string name="";
				public int n1=0;
			}				
			public score(){
				int i;
				for(i=0;i<count;i++){
					n1[i]=new sscores();
					n2[i]=new sscores();
				}
				
				
				
			}
			public void add(string name ,int scores){
				if (len<count){
					n2[len].n1=scores;
					n2[len].name=name;
					len++;
				}
				order();
			}
			private void order(){
				int b;
				int i;
				int fn1;
				string f;
				string g;
				int gn1;
				string h;
				int hn1;
				n1[0].n1=n2[0].n1;
				n1[0].name=n2[0].name;
				for(b=1;b<len;b++){
					f=n2[b].name;
					fn1=n2[b].n1;
					for(i=0;i<b;i++){
						if (fn1<n1[i].n1){
							gn1=n1[i].n1;
							g=n1[i].name;
							n1[i].name=f;
							n1[i].n1=fn1;
							fn1=gn1;
							f=g;
						}
					}
					n1[i].name=f;
					n1[i].n1=fn1;
				}
				copy();
				
			}
			private void copy(){
				int i;
				for(i=0;i<len;i++)n2[i]=n1[i];
			}
			public void Print(){
				int i;
				for(i=0;i<len;i++)Console.WriteLine("{0}={1}",n2[i].name,n2[i].n1);
			}
		}

		static void Main(string[] args){
			score lo = new score();
			string [] names= new string[]{"job","jon","bob","lex","steve","max","maxine","robert","tim","peter","lene"};
			int i;
			Random rnds;
			rnds=new Random();
			for(i=0;i<10;i++)lo.add(names[i],rnds.Next(30000));
			lo.Print();
		}

		
	}
}






