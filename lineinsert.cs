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
			public string input(string [] back, int len){
				ConsoleKeyInfo key=new ConsoleKeyInfo();
				string s="";
				char last=' ';
				char c32=' ';
				char c13='\r';
				int b=32;
				int bb=32;
				bool exits=false;
				int i=0;
				line=len-1;
				x=Console.CursorLeft;
				y=Console.CursorTop;
				value=value.Replace("_","");				
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
						clears();
							line--;
							refresh(back,len);
						
					}
					if(key.Key==ConsoleKey.DownArrow){
							clears();
							line++;
							refresh(back,len);
					}
					
					if(key.Key==ConsoleKey.PageDown){
						clears();
							line=len;
							refresh(back,len);
					}
					if(key.Key==ConsoleKey.PageUp){
						clears();
							line=0;
							refresh(back,len);
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
								
								value=value.Replace("_","");
								cursor--;
								
								if(cursor>-1){
									char c=value[cursor];
									value=value.Insert(cursor,"_");
									value=value.Replace("_"+c,"");
								}
								value=value.Replace("_","");
								cursorinsert();
								bb=0;
								b=1;
								 
					
					}
					
					if(key.KeyChar>=' ' && length<max){
					
						if(key.KeyChar!='_') value=value.Replace("_",key.KeyChar.ToString());
						value=value.Replace("_","");
						cursor++;
						cursorinsert();
					}
					
				
				}
				value=value.Replace("_","");
				cursorinsert();
				value=value.Replace("_","");
				length=value.Length;
				Console.WriteLine("");
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
			public void refresh(string [] back,int len){
				if(len>0){
					if(line>len-1)line=len-1;
					if(line<0)line=0;
					value=back[line];
					value=value.Replace("_","");
					length=value.Length;
					cursor=length;
					cursorinsert();
				}
			}

			public string stringss(int ii,string ss){
				int i=0;
				string s="";
				for(i=0;i<ii;i++){
					s=s+ss;
				}
				return s;
			}
			public void clears(){
				Console.CursorLeft=x;
				Console.CursorTop=y;
				Console.Write(stringss(value.Length," "));
			}


		}


	
		static void Main(string[] args){
			lineInsert inputs = new lineInsert();
			string [] s = new string[12];
			int i=0;
			for(i=0;i<s.Length;i++)s[i]="line "+ i.ToString();  
			
			Console.Write("\n!{0}",inputs.input(s,12));
				

		}

		
	}
}






