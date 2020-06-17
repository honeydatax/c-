using System;

namespace logic{
	
	class logics{
		public class HEX{
			public byte value=0;
			public byte low=0;
			public byte high=0;
			public string s="";
			public HEX(byte b){
				value=b;
				solve(value);
			}
			public void solve(byte b){
				value=b;
				high=highs(b);
				low=lows(b);
				s=""+values(high);
				s=s+values(low);
				print();
			}
			public byte back(){
				byte b=0;
				low=Convert.ToByte(low & 15);
				high=Convert.ToByte(high & 15);
				b=Convert.ToByte(high*16);
				b=Convert.ToByte(b | low);
				
				value=b;
				s=""+values(high);
				s=s+values(low);
				print();
				return b;
			}
			public byte highs(byte b){
				byte bb=16;
				bb=Convert.ToByte(b/bb);
				return bb;
			}
			public byte lows(byte b){
				return Convert.ToByte(b & 15);
			}
			public char values(byte b){
				byte bb=Convert.ToByte(b & 15);
				string s="0123456789ABCDEF";
				return s[bb];
			}
			public void print(){
				Console.Write(value.ToString()+"=");
				Console.WriteLine(s);
			}

		}

		static void Main(string[] args){
			HEX hex = new HEX(0);
			byte i=0;
			for (i=0;i<16;i++){
				hex.low=i;
				hex.back();
			}
			for (i=0;i<16;i++){
				hex.high=i;
				hex.back();
			}
				

		}

		
	}
}






