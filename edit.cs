using System;
using System.IO;

namespace logic{
	
	class logics{
		public class Edit{
			public string name="";
			public int pos=0;
			private lineNew list1 = new lineNew();			
			public Edit(string s){
				int i=0;
				bool exits=false;
				string ss="";
				name=s;
			list1.x=0;
			list1.w=78;
			list1.y=0;
			list1.h=20;
			list1.start=0;
				list1.clear();
				if(name=="")list1.add("",list1.length+1);
				if (name!="")name="new.lst";
				try{
					list1.load(name);
				}catch{
					list1.add("",list1.length+1);
				}
				
				
				pos=0;
				int chrs=0;
				while(!exits){
					
					lineInsert inputs = new lineInsert();
					list1.report();
					ss=list1.gets(pos);
					Console.CursorLeft=list1.y;
					Console.CursorTop=pos-list1.start;
					chrs=0;
					inputs.value=ss;
					returner rr=inputs.input(ss,chrs);
					ss=rr.rets;
					chrs=rr.keys;
					list1.change(ss,pos);
					if(chrs==8){
						exits=true;
						
					}

					if(chrs==1){
						pos=pos+1;
						list1.add("",pos);
					}
					if(chrs==2){
						pos=pos-1;
					}
					if(chrs==3){
						pos=pos+1;
						if(pos>list1.length)list1.add("",pos);
					}
					if(chrs==4){
						list1.start=list1.start-19;
						pos=pos-19;
					}
					if(chrs==5){
						list1.start=list1.start+19;
						pos=pos+19;
					}
					if(pos<0){
						pos=0;
						list1.start=0;
					}
					if(pos>list1.length){
						pos=list1.length;
						list1.add("",pos);
					}
					if(list1.start>list1.length)list1.start=list1.length;
					if(list1.start<0)list1.start=0;
					if(list1.start<pos-19)list1.start=pos-19;
					if(list1.start>list1.length)list1.start=list1.length-1;
					if(list1.start<0)list1.start=0;
				}
				try{
					list1.save(name);
				}catch{
					
				}

			}
		}


		public class returner{
			public string rets="";
			public int keys=0;
		} 


		public class lineNew{
			public int x=0;
			public int y=0;
			public int w=76;
			public int h=20;
			public int start;
			public int length=0;
			private int lengths=0;
			const int max=32002;
			public int maxs=max;
			public bool [] del= new bool[max];
			public int [] lint= new int[max];
			public string [] listss= new string[max];
			public lineNew(){
				int i=0;
				length=0;
				for(i=0;i<max;i++){
					listss[i]="";
					lint[i]=0;
					del[i]=false;
				}
			}
			public void change(string text,int index){
				if(index<length)listss[lint[index]]=text;
			}
			public void add (string text,int index){
				int i=0;
				int iii=index;
				int ii=-1;
				if(iii>length)iii=length;
				if(iii<0)iii=0;
				if (length>0 && length<max && lengths<max && iii<max){
					
					for(i=0;i<lengths;i++){
						if (del[i]){
							del[i]=false;
							ii=i;
							listss[i]=text;
							i=lengths+1;
						}
					}
					
					if (ii<0 && lengths<max){
						ii=lengths;
						listss[ii]=text;
						lengths++;
					}

				}

				if (ii>-1 && length>0 && length<max && lengths<max){
					if(iii!=length){
						for(i=length;i>index;i--){
							lint[i]=lint[i-1];
						}
					
					
					}
						
					lint[iii]=ii;
					if (length>0 && length<max-1)length++;
				}
				if (length==0){
					ii=lengths;
					listss[ii]=text;
					lengths++;
					lint[length]=ii;
					length++;
				}
			}
			public void remove(int index){
				int i=0;
				if(index<length)del[lint[index]]=true;
				if (index<length && index>-1){
					for(i=index;i<length;i++){
						lint[i]=lint[i+1];
					}
				
					if (length>0)length--;
				}

				
			}
			public string gets(int index){
				int i=0;
				string ss="";
				if (index<length && index<length && index>-1){
						ss=listss[lint[index]];
				
				}
				return ss;

				
			}

			public void load(string name){
				int i;
				string s="";
				string ss=null;
				string [] sss=null;
				try{
					ss=File.ReadAllText(name);
				}catch{
				}
				length=0;
				lengths=0;
				ss=ss.Replace("\r","");
				sss=ss.Split('\n');
				for(i=0;i<max;i++){
					del[i]=false;
					if(i<sss.Length){
						lint[i]=i;
						listss[i]=sss[i];
					}
				}
				length=sss.Length;
				lengths=sss.Length;
			}
			public void save(string name){
				int i;
				string s="";
				for(i=0;i<length;i++)s=s+listss[lint[i]]+"\r\n";
				try{
					File.WriteAllText(name,s);
				}catch{
				}
			}
			public void clear(){
				int i=0;
				length=0;
				lengths=0;
				for(i=0;i<max;i++){
					del[i]=false;
				}
			}
		public string mid(string ss,int start,int size){
			int i;
			string s="";
			int sizes=size+start;
			int starts=start;
			if (start>ss.Length)starts=ss.Length-1;
			if (starts<0)starts=0;
			if (sizes>ss.Length)sizes=ss.Length;
			for(i=start;i<sizes;i++)s=s+ss[i];
			return s;
		}

			public void report(){
				int i=0;
				string s="";
				int ii=h;
				if(start<0)start=0;
				if(length<h)ii=length;
				if(start+ii>length)start=length-h;
				if(start<0)start=0;
				if(length>h)ii=start+ii;
				
				for(i=start;i<ii;i++){
					Console.CursorTop=y+i-start;
					Console.CursorLeft=x;
					if(listss[lint[i]].Length<w){
						Console.Write(listss[lint[i]]);
					}else{
						s=mid(listss[lint[i]],0,w);
						Console.Write(s);
					}

				}
				Console.CursorTop=y+i-start;
				Console.CursorLeft=0;

			}
		}
		
		public class lineInsert{
			public int tkeys=0;
			public string value ="";
			public int x=0;
			public int y=0;
			public int length=0;
			public int max=79;
			int cursor=0;
			public int line=0;			
			public lineInsert(){
			}
			public returner input(string back, int keys){
				returner rr = new returner();
				ConsoleKeyInfo key=new ConsoleKeyInfo();
				string s="";
				char last=' ';
				char c32=' ';
				char c13='\r';
				int b=32;
				int bb=32;
				bool exits=false;
				int i=0;
				line=0;
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
						tkeys=2;
						exits=true;						
					}
					if(key.Key==ConsoleKey.DownArrow){
						clears();
						tkeys=3;
						exits=true;						
					}
					
					if(key.Key==ConsoleKey.PageDown){
						clears();
						tkeys=5;
						exits=true;						
					}
					if(key.Key==ConsoleKey.PageUp){
						clears();
						tkeys=4;
						exits=true;						
					}

					if(key.Key==ConsoleKey.Escape){
						clears();
						tkeys=8;
						exits=true;						
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

					if(key.Key==ConsoleKey.Enter){
						clears();
						tkeys=1;
						exits=true;						

					}
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
				//value=value.Replace("_","");
				//cursorinsert();
				value=value.Replace("_","");
				length=value.Length;
				rr.rets=value;
				rr.keys=tkeys;
				return rr;
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
				Console.Write(stringss(value.Length," ")+"  ");
			}


		}
		
		static void Main(string[] args){
			string s="new.lst";
			if (args.Length>0)s=args[0];
			Console.Clear();
			Edit edits=new Edit(s);
			
		}

		
	}
}






