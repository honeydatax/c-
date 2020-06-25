using System;

namespace logic{
	
	class logics{
		public class lineInsert{
			public string value ="";
			public int x=0;
			public int y=0;
			public int length=0;
			public int max=79;
			int cursor=0;
			public int line=0;			
			public lineInsert(){
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
				
				cursor=value.Length;
				cursorinsert();
				while(!exits){
					try{
						key=Console.ReadKey(true);
						b=Convert.ToInt16(key.Key);
					}catch{
						b=0;
					}
					
					if(key.Key==ConsoleKey.UpArrow){
							line--;
							if(line<0)line=0;
							cursor=back[line].Length;
							refresh(back);
						
					}
					if(key.Key==ConsoleKey.DownArrow){
							line++;
							if(line>back.Length-1)line=back.Length-1;
							cursor=back[line].Length;
							refresh(back);
					}
					
					if(key.Key==ConsoleKey.PageDown){
							line=back.Length-1;
							refresh(back);
					}
					if(key.Key==ConsoleKey.PageUp){
							line=0;
							refresh(back);
					}

					
					if(key.Key==ConsoleKey.LeftArrow ){

								value=value.Replace("_","");
								cursor--;
								cursorinsert();
								bb=0;
								b=1;

					}
					if(key.Key==ConsoleKey.RightArrow ){

								value=value.Replace("_","");
								cursor++;
								cursorinsert();
								bb=0;
								b=1;

					}


					if(key.Key==ConsoleKey.End ){

								value=value.Replace("_","");
								cursor=value.Length;
								cursorinsert();
								bb=0;
								b=1;

					}
					if(key.Key==ConsoleKey.Home ){

								value=value.Replace("_","");
								cursor=0;
								cursorinsert();
								bb=0;
								b=1;

					}

					if(key.Key==ConsoleKey.Enter)exits=true;
					if((key.Key==ConsoleKey.Delete || key.Key==ConsoleKey.Backspace) && length>0){
					
								s="";
								
								value.Replace("_","");
								cursor--;
								for(i=0;i<length;i++){
									if(!(i==cursor))s=s+value[i];
								}
								value=s;
								
								cursorinsert();
								bb=0;
								b=1;
								 
					
					}
					
					if(key.KeyChar>=' ' && length<max){
					
						value=value.Replace("_",key.KeyChar.ToString());
						
						cursor++;
						cursorinsert();
					}
					
				
				}
				value=value.Replace("_","");
				cursorinsert();
				value=value.Replace("_","");
				length=value.Length;
				return value;
			}
			
			
			public void cursorinsert(){
				string ss="";
				int ii=0;
				length=value.Length;
				if(cursor>length)cursor=length;
				if(cursor<0)cursor=0;
				
				for(ii=0;ii<value.Length+1;ii++){
					if(cursor==ii)ss=ss+"_";
					if(ii<value.Length)ss=ss+value[ii];
				}
				
				value=ss;
				Console.CursorLeft=x;
				Console.CursorTop=y;
				Console.Write(value+"  ");
				Console.CursorLeft=x+cursor;
				Console.CursorTop=y;
				

				
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
			lineInsert inputs = new lineInsert();
			string [] s = new string[12];
			int i=0;
			for(i=0;i<s.Length;i++)s[i]="line "+ i.ToString();  
			
			Console.Write("\n!{0}",inputs.input(s));
				

		}

		
	}
}






