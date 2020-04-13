using System;

namespace logic{
	
	class logics{
		public class lotos{
			private int count=10;
			public int [] n1= new int[10];
			private int [] n2= new int[10];			
			public void refresh(){
				int i;
				Random rnds;
				rnds=new Random();
				for(i=0;i<count;i++)n2[i]=rnds.Next(49)+1;
				order();
				//copy();
				Print();
			}
			private void order(){
				int b;
				int i;
				int f;
				int g;
				int h;
				n1[0]=n2[0];
				for(b=1;b<count;b++){
					f=n2[b];
					for(i=0;i<b;i++){
						if (f<n1[i]){
							g=n1[i];
							n1[i]=f;
							f=g;
						}
					}
					n1[i]=f;
				}
				
			}
			private void copy(){
				int i;
				for(i=0;i<count;i++)n1[i]=n2[i];
			}
			private void Print(){
				int i;
				for(i=0;i<count;i++)Console.WriteLine("{0}",n1[i]);
			}
		}

		static void Main(string[] args){
			lotos lo = new lotos();
			lo.refresh();

		}

		
	}
}






