using System;

namespace logic{
	
	class logics{
		public class lineInput{
			public string value ="";
			public int x=0;
			public int y=0;
			public int length=0;
			public int max=79;
			
			public lineInput(){
			}
			public string input(){
				ConsoleKeyInfo key=new ConsoleKeyInfo();
				string s="";
				char last=' ';
				char c32=' ';
				char c13='\r';
				int b=32;
				int bb=32;
				bool exits=false;
				int i=0;
				x=Console.CursorLeft;
				y=Console.CursorTop;
				while(!exits){
					try{
						key=Console.ReadKey(true);
						b=Convert.ToInt16(key.Key);
						if(b<32){
							
							if(b==8 && length>0){
								
								s="";
								length--;
						
								for(i=0;i<length;i++)s=s+value[i];
								value=s;
								Console.CursorLeft=x;
								Console.CursorTop=y;
								Console.Write(value+"  ");
								Console.CursorLeft=x+length;
								Console.CursorTop=y;

								bb=0;
								b=1;
							}
							
						}
						

					}catch{
						b=0;
					}
					
					//b=;
					if (key.KeyChar=='\n')exits=true;
					
					if(b>31 && b <255){
						value=value+key.KeyChar;
						length++;
						Console.Write(key.KeyChar);
					}

					/*
					if (!Console.CapsLock && b>=65 && b<=65+24){
						b=b+32;
					}
					
					last=Convert.ToChar(Convert.ToByte(b));
					if(b<32 && b>0){
						Console.Write("!{0}",b);
					}
					*/
				}
				return value;	
			}
			
		}
		
		static void Main(string[] args){
			lineInput inputs = new lineInput();
			
			Console.Write("\n!{0}",inputs.input());
				

		}

		
	}
}






