using System;

namespace logic{
	
	class logics{
		public class stack{
			public int length=0;
			public int SP=0;
			public bool reported=false;
			public int [] stacks=null;
			public stack(int size){
				stacks=new int[size];
				length=size;
			}
			public void push(int value){
				if (SP<length){
					stacks[SP]=value;
					SP++;
					if (reported)Console.Write(" push:{0} ",value);
				}
			}
			public int pop(){
				int rets=-1;
				if (SP>0){
					SP--;
					rets=stacks[SP];
					if (reported)Console.Write(" pop:{0} ",rets);
				}
				return rets;
			}
			
		}
		public class trees{
			public node [] nodes=null;
			private stack stacks=null;
			private int length=0;
			private int SP=0;
			public int roots=0;
			public bool debugs=false;
			
			public class node{
				public string caption="";
				public int back=-1;
				public int after=-1;
				public int father=-1;
				public int sun=-1;
			} 
			public trees(int size,string root){
				length=size;
				nodes=new node[size];
				stacks=new stack(size);
				roots=add(root);
				
			}
			public int add(string caption){
				int i=0;
				if (SP<length){
					nodes[SP]=new node();
					nodes[SP].caption=caption;
					i=SP;
					SP++;
				}
				return i;
			}
			public void setCaption(int index,string caption){
				nodes[index].caption=caption;
			}
			public string getCaption(int index){
				return nodes[index].caption;
			}
			public void setBack(int index,int back){
				nodes[index].back=back;
			}
			public int getback(int index){
				return nodes[index].back;
			}
			public void setAfter(int index,int after){
				nodes[index].after=after;
			}
			public int getafter(int index){
				return nodes[index].after;
			}
			public void setSun(int index,int sun){
				nodes[index].sun=sun;
			}
			public int getSun(int index){
				return nodes[index].sun;
			}
			public int getfather(int index){
				return nodes[index].father;
			}
			public void setfather(int index,int father){
				bool exits=false;
				int next=0;
				int pointer=0;
				if (father<SP){
					nodes[index].father=father;
					if (nodes[father].sun<0){
						nodes[father].sun=index;
					}else{
						pointer=nodes[father].sun;
						while(!exits){
							if(nodes[pointer].after<0){
								exits=true;
								nodes[pointer].after=index;
								nodes[index].back=pointer;
							}
							pointer=nodes[pointer].after;	
						}
					}
				}	
			}

			
			public void report(){
				bool todos=false;
				bool exits=false;
				int pointer=roots;
				stacks.SP=0;
				Console.WriteLine("tree--------");
				while(!exits){
					todos=false;
					if (pointer>-1){
						print(pointer);
					if (nodes[pointer].sun>-1){
						stacks.push(nodes[pointer].after);
						pointer=nodes[pointer].sun;
						todos=true;
					}else{
						if (pointer>-1){
							pointer=nodes[pointer].after;
						}
					}
					}
					if (pointer<0 && stacks.SP<1){
						exits=true;
					}else{
						if (!todos && pointer<0){
							if(stacks.SP>0){
								pointer=stacks.pop();
							}else{
								pointer=-1;
							}

						}
					}
					if (pointer<0 && stacks.SP<1)exits=true;
					
				}
				
			}
			private void print(int index){
				int i=0;
				if (stacks.SP>0)for (i=0;i<stacks.SP;i++)Console.Write("	");
				Console.Write("{0} ",nodes[index].caption);
				if (debugs){
					Console.Write(", {0},",nodes[index].back);
					Console.Write(" {0},",nodes[index].after);
					Console.Write(" {0},",nodes[index].father);
					Console.Write(" {0}",nodes[index].sun);
				}
				Console.WriteLine("");
			}
		}
		static void Main(string[] args){
			int node1=0;
			int x86=0;
			trees tree1 = new trees(1025,"CPS");
			tree1.debugs=false;
			node1=tree1.add("arm");
			tree1.setfather(node1,tree1.roots);
			x86=tree1.add("x86");
			tree1.setfather(x86,tree1.roots);
			node1=tree1.add("8086");
			tree1.setfather(node1,x86);
			node1=tree1.add("80186");
			tree1.setfather(node1,x86);
			node1=tree1.add("80286");
			tree1.setfather(node1,x86);
			node1=tree1.add("80386");
			tree1.setfather(node1,x86);
			node1=tree1.add("80486");
			tree1.setfather(node1,x86);
			tree1.report();
		}

		
	}
}






