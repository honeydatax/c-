using System;

namespace logic{
	
	class logics{
		public class lists{
			public int length=0;
			const int max=1025;
			public string [] listss= new string[max];
			public lists(){
				length=0;
			}
			public void add (string text){
				if (length<max){
					listss[length]=text;
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
			lists list1 = new lists();
			int i=0;
			list1.add("arm");
			list1.add("pc");
			list1.add("x86");
			list1.add("80186");
			list1.add("80286");
			list1.add("80386");
			list1.add("80486");
			list1.report();
			list1.remove(1);
			list1.report();
				

		}

		
	}
}






