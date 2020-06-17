using System;

namespace logic{
	
	class logics{
		public class Binary{
			public byte value =0;
			public bool [] bits = new bool[8];
			public Binary(byte b){
				int i=0;
				value=b;
				reset();
				solve(value);
			}
			public void reset(){
				int i=0;
				for(i=0;i<8;i++)bits[i]=false;
			}
			public byte back(){
				int i=0;
				byte bb=1;
				byte bbb=2;
				value=0;
				for(i=0;i<8;i++){
					if(bits[i])value=Convert.ToByte(value | bb);
					bb=Convert.ToByte((bb*bbb) & 255);
					
				}
				
				report();
				return value;
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
			bin.reset();
			for (i=0;i<8;i++){
				bin.bits[i]=true;
				bin.back();
			}
			for (i=0;i<8;i++){
				bin.bits[i]=false;
				bin.back();
			}
		
				
		
		}

		
	}
}






