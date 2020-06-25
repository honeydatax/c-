using System;
using System.IO;

namespace logic{
	
	class logics{
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
				if(index<length)listss[index]=text;
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
				if(length<h)ii=length;
				if(start+ii>length)start=length-h;
				if(start<-1)start=0;
				for(i=start;i<ii;i++){
					Console.CursorTop=y+i;
					Console.CursorLeft=x;
					if(listss[lint[i]].Length<w){
						Console.Write(listss[lint[i]]);
					}else{
						s=mid(listss[lint[i]],0,w);
						Console.Write(s);
					}

				}
				Console.CursorTop=y+i;
				Console.CursorLeft=0;

			}
		}
		static void Main(string[] args){
			lineNew list1 = new lineNew();
			int i=0;
			int count=0;
			Console.Clear();
			list1.x=10;
			list1.w=50;
			list1.y=10;
			list1.h=8;
			for(i=0;i<31;i++)list1.add("LINE :" +i.ToString(),list1.length+1);
			list1.report();

		}

		
	}
}






