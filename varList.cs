using System;

namespace logic{
	
	class logics{
		public class VarList{
			public const int max=1025;
			public int length=0;
			public string [] name= new string[max];
			public string [] value= new string[max];
			public VarList (){
				int i=0;
				for(i=0;i<max;i++){
					name[i]="";
					value[i]="";
				}
				
				
			}
			public void setvar(string s,string ss){
				int i=0;
				int ii=-1;
				string s1=s.Trim();
				for(i=0;i<length;i++){
					if(string.Compare(name[i],s1)==0){
						value[i]=ss;
						ii=i;
						i=length+1;
					}
				}
				if(length<max-2 && ii==-1){
					name[length]=s;
					value[length]=ss;
					length++;
				}
			}
			public string getvar(string s){
				string ss="";
				int i=0;
				string s1=s.Trim();
				for(i=0;i<length;i++){
					if(string.Compare(name[i],s1)==0){
						ss=value[i];
						i=length+1;
					}
				}
				return ss;
			}
			public void list(){
				int i;
				for(i=0;i<length;i++){
					Console.WriteLine("{0},{1}={2}",i,name[i],value[i]);
				}
			}
			
		}

		static void Main(string[] args){
			VarList vars = new VarList();
			vars.setvar("a1","0");
			vars.setvar("b1","hello");
			vars.setvar("c1","hi");
			
			vars.list();
			vars.setvar("b1","hel");
			vars.list();
			Console.WriteLine("b1={0}",vars.getvar("b1"));				

		}

		
	}
}






