using System;

namespace logic{
	
	class logics{
		public class Binary{
			byte value =0;
			bool [] bits = new bool[8];
			public Binary(byte b){
				int i=0;
				value=b;
				for(i=0;i<8;i++)bits[i]=false;
				solve(value);
			}
			public void solve(byte b){
				int i=0;
				byte bb=1;
				byte bbb=2;
				value=b;
				for(i=0;i<8;i++){
					bits[i]=(value & bb)!=0;
					bb=Convert.ToByte((bb*bbb) & 255);
					
				}
				
				report();
				
			}
			public void report(){
				int i=0;
				Console.Write(value.ToString()+"=");
				for(i=7;i>-1;i--){
					if(bits[i]){
						Console.Write("1");
					}else{
						Console.Write("0");
					}
				}
				Console.WriteLine("");
			}
		}
		
		static void Main(string[] args){
			Binary bin = new Binary(0);
			byte i=0;
			for (i=1;i<255;i++){
				bin.solve(i);
			}
		
				
		
		}

		
	}
}






