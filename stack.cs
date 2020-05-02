using System;

namespace logic{
	
	class logics{
		public class stack{
			public int length=0;
			public int SP=0;
			public bool reported=false;
			public int [] stacks=null;
			public stack(int size){
				stacks=new int[size];
				length=size;
			}
			public void push(int value){
				if (SP<length){
					stacks[SP]=value;
					SP++;
					if (reported)Console.Write(" push:{0} ",value);
				}
			}
			public int pop(){
				int rets=-1;
				if (SP>0){
					SP--;
					rets=stacks[SP];
					if (reported)Console.Write(" pop:{0} ",rets);
				}
				return rets;
			}
			public void reporter(){
				int i=0;
				Console.WriteLine("");
				Console.WriteLine(" STACK:");
				for (i=0;i<SP;i++){
					Console.Write(" {0} ",stacks[i]);
				}
				Console.WriteLine("");
			}

			public void dec(){
				int i=0;
				Console.WriteLine("");
				Console.WriteLine(" STACKBack:");
				for (i=SP;i>-1;i--){
					Console.Write(" {0} ",stacks[i]);
				}
				Console.WriteLine("");
			}
			
		}
		static void Main(string[] args){
			stack logs = new stack(1025);
			int i=0;
			int ii=0;
			logs.reported=true;
			for(i=0;i<20;i++)logs.push(i);
			logs.reported=false;
			logs.reporter();
			logs.dec();
			ii=logs.SP;
			for(i=0;i<ii;i++)Console.Write(" PoP:{0} ",logs.pop());
			Console.WriteLine("");
		}

		
	}
}






