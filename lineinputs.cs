using System;

namespace logic{
	
	class logics{
		public class lineInput{
			public string value ="";
			public int x=0;
			public int y=0;
			public int length=0;
			public int max=79;
			public int line=0;
			
			public lineInput(){
			}
			public string input(string [] back){
				ConsoleKeyInfo key=new ConsoleKeyInfo();
				string s="";
				char last=' ';
				char c32=' ';
				char c13='\r';
				int b=32;
				int bb=32;
				bool exits=false;
				int i=0;
				line=back.Length-1;
				x=Console.CursorLeft;
				y=Console.CursorTop;
				while(!exits){
					try{
						key=Console.ReadKey(true);
						b=Convert.ToInt16(key.Key);
					}catch{
						b=0;
					}
					if(key.Key==ConsoleKey.UpArrow || key.Key==ConsoleKey.PageUp || key.Key==ConsoleKey.LeftArrow ){
							line--;
							refresh(back);
						
					}
					if(key.Key==ConsoleKey.DownArrow || key.Key==ConsoleKey.RightArrow ){
							line++;
							refresh(back);
					}

					if(key.Key==ConsoleKey.PageDown || key.Key==ConsoleKey.End){
							line=back.Length-1;
							refresh(back);
					}
					if(key.Key==ConsoleKey.PageUp || key.Key==ConsoleKey.Home){
							line=0;
							refresh(back);
					}
					if(key.Key==ConsoleKey.Enter)exits=true;
					if((key.Key==ConsoleKey.Delete || key.Key==ConsoleKey.Backspace) && length>0){
								
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
					
					if(key.KeyChar>=' ' && length<max){
						value=value+key.KeyChar;
						length++;
						Console.Write(key.KeyChar);
					}

				}
				return value;	
			}
			public void refresh(string [] back){
				if(back.Length>0){
					if(line>back.Length-1)line=back.Length-1;
					if(line<0)line=0;
					value=back[line];
					length=back[line].Length;
					Console.CursorLeft=x;
					Console.CursorTop=y;
					Console.Write(value+"  ");
					Console.CursorLeft=x+length;
					Console.CursorTop=y;
				}
			}
			
		}
		
		static void Main(string[] args){
			lineInput inputs = new lineInput();
			string [] s = new string[12];
			int i=0;
			for(i=0;i<s.Length;i++)s[i]="line "+ i.ToString();  
			
			Console.Write("\n!{0}",inputs.input(s));
				

		}

		
	}
}






