using System;

namespace logic{
	class logics{
		public class HHTMS{
			public int length=0;
			public string title="";
			public string text="";
			public hhtml [] html =null;
			public string [] tags=null;
			public HHTMS(string texts, int max){
				int i=0;
				//					0    ,    1    ,  2    ,   3  , 4
				tags=new string[]{"title","//title","body","//body","h1","h2","h3","h4","h5","h6","a","hr","br","p"};
				text=texts;
				html=new hhtml[max];
				for(i=0;i<max;i++)html[i]=new hhtml(); 
			}
			public class hhtml{
				public string caption;
				public int code;
			}
			public void parse(){
				int i=0;
				int ii=0;
				int size=0;
				string sss="";	
				string ssss="";				
				bool ignore=false;
				bool gettitle=false;
				bool getbody=false;
				bool func=false;
				length=0;
				string [] s = text.Split('<');
				for(i=0;i<s.Length;i++){
					
					string [] ss = s[i].Split('>');
					
						
						size=ss.Length;
						if (size>0){
							ignore=false;
							sss="/";
							ssss="";
							if (size>1)ssss=ss[1].Trim();
							sss=ss[0].Trim();
							sss=ss[0].ToLower();
							if (sss=="")sss="/";
							if(sss[0]=='/')ignore=true;
							func=true;
							if (ssss=="")func=false;
							
							//***********title;
							if(!ignore && string.Compare(tags[0],sss)==0){
								if (size>1)title=ss[1];
								sss="/";
								ignore=true;
							}
							//***********body;
							if (sss[0]!='/' && size==1){
								sss="/";
								ignore=true;
								getbody=true;
								
							}

							if(!ignore && string.Compare(tags[2],sss)==0){
								if(size>1)addhtml(ssss,0);
								sss="/";
								ignore=true;
								getbody=true;
							}

							//***********bodyend ;
							if(ignore && string.Compare(tags[3],sss)==0){
								
								sss="/";
								ignore=true;
								getbody=false;
							}
							
							if(!ignore && getbody ){
							
								for (ii=4;ii<tags.Length;ii++){
									
									if (string.Compare(tags[ii],sss)==0 && func) addhtml(ssss,ii);
								}
							}
							
						}
						
				}
				
			}
			public void printHTML(int index){
				if (index<html.Length){
					Console.Write(html[index].code);
					Console.Write(",");
					Console.WriteLine(html[index].caption);
				}
				
			}
			public void printHtml(){
				int i=0;
				Console.WriteLine("title:{0}",title);
				for(i=0;i<length;i++)printHTML(i);
			}
			public void addhtml(string captions,int codes){
				if (length<html.Length-1){
					html[length].code= codes;
					html[length].caption= captions;
					length++;
				}
			} 
			public void printText(){
				Console.WriteLine(text);
			}
		}


		static void Main(string[] args){
			HHTMS html1= new HHTMS("",1024);
			html1.text="<html><head><title>";
			html1.text=html1.text+"hello</title></head><body>";
			html1.text=html1.text+"hello";
			html1.text=html1.text+"<H1>hello</H1>";
			html1.text=html1.text+"<H2>hello</H2>";
			html1.text=html1.text+"<H3>hello</H3>";
			html1.text=html1.text+"<H4>hello</H4>";
			html1.text=html1.text+"<H5>hello</H5>";
			html1.text=html1.text+"<H6>hello</H6>";
			html1.text=html1.text+"<a>hello</a>";
			html1.text=html1.text+"<p>hello</p>";
			html1.text=html1.text+"<br>.</br>";
			html1.text=html1.text+"<br>.</br>";
			html1.text=html1.text+"</body><html>";
			html1.parse();
			html1.printHtml();	
				
		}

	}

}






