using System;

namespace logic{
	
	class logics{
		public class lists{
			public int length=0;
			const int max=1025;
			private bool crescent=false;
			public string [] listss= new string[max];
			public lists(bool orders){
				length=0;
				crescent=orders;
			}
			public void add (string text){
				int i=0;
				string s1=text;
				string s2=text;
				if (length!=0 && length<=max){
					for(i=0;i<length;i++){
					if (String.Compare(s1,listss[i])>0 && !crescent){
						s2=listss[i];
						listss[i]=s1;
						s1=s2;
					}
					
					if (String.Compare(s1,listss[i])<0 && crescent){
						s2=listss[i];
						listss[i]=s1;
						s1=s2;
					}
					 
					}
					listss[length]=s1;
					length++;					
					
				}
				if (length<1){
					listss[0]=s1;
					length++;
				}

			}
			public void remove(int index){
				int i=0;
				if (index<=length && index>-1){
					for(i=index;i<length;i++){
						listss[i]=listss[i+1];
					}
					if (length>0)length--;
				}
			}
			public void report(){
				int i=0;
				Console.WriteLine("list--------------");
				for(i=0;i<length;i++)Console.WriteLine(" {0} ",listss[i]);
			}
		}
		static void Main(string[] args){
			lists list1 = new lists(false);
			lists list2 = new lists(true);
			int i=0;
			list1.add("CCC");
			list1.add("AAA");
			list1.add("MMM");
			list1.add("ZZZ");
			list1.add("XXX");
			list1.add("VVV");
			list1.add("BBB");
			list2.add("CCC");
			list2.add("AAA");
			list2.add("MMM");
			list2.add("ZZZ");
			list2.add("XXX");
			list2.add("VVV");
			list2.add("BBB");
			list1.report();
			list2.report();
				

		}

		
	}
}






