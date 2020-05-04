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
			public int current=0;
			public node [] nodes=null;
			private stack stacks=null;
			private int length=0;
			private int SP=0;
			public int roots=0;
			public bool debugs=false;
			
			public class node{
				public string caption="";
				public string text="";
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
				current=roots;
				
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
			public void setText(int index,string text){
				nodes[index].text=text;
			}
			public string getText(int index){
				return nodes[index].text;
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
			public void lloops(){
				int i=0;
				bool exits=false;
				string lines="";
				Console.WriteLine("");
				while(!exits){
					Console.Write(nodes[current].caption.Trim()+">");
					lines=Console.ReadLine();
					lines=lines.ToUpper();
					lines=lines.Trim();
					if(lines.IndexOf("DIR")==0){
						dirs();
						lines="";
					}
					if(lines.IndexOf("EXIT")==0){
						exits=true;
						lines="";
					}
					if(lines.IndexOf("HELP")==0){
						help();
						lines="";
					}
					if(lines.IndexOf("TYPE")==0){
						string [] s=strs(lines);
						int ii=0;
						if(s.Length>1){
							ii=find(s[1]);
							if (ii>-1)Console.WriteLine(" {0}",nodes[ii].text);
						}
						lines="";
					}

					if(lines.IndexOf("CD ..")==0){
						int ii=0;
						if(nodes[current].father>-1)current=nodes[current].father;


						lines="";
					}

					if(lines.IndexOf("CD")==0){
						string [] s=strs(lines);
						int ii=0;
						if(s.Length>1){
							ii=find(s[1]);
							if (ii>-1){
								if(nodes[ii].sun>-1)current=ii;
							}
						}
						lines="";
					}


				}
			}
			public string [] strs(string s){
				return s.Split(' ');
			}
			public void help(){
				Console.WriteLine("type file");
				Console.WriteLine("help");
				Console.WriteLine("exit");
				Console.WriteLine("dir");				
				Console.WriteLine("cd ..");
				Console.WriteLine("cd file");
			}
			public int find(string s){
				int retss=-1;
				bool eexits=false;
				int cursor=current;
				cursor=nodes[cursor].sun;
				if(cursor<0) eexits=true;
				while(!eexits){
					if (cursor>-1){
						if(String.Compare(nodes[cursor].caption.Trim().ToUpper(),s.Trim().ToUpper())==0){
							retss=cursor;
							eexits=true;
						}
					}
					cursor=nodes[cursor].after;
					
					if (cursor<0)eexits=true;
				}
				return retss;
			} 
		
			public void dirs(){
				bool eexits=false;
				int cursor=current;
				cursor=nodes[cursor].sun;
				if(cursor<0) eexits=true;
				while(!eexits){
					if (cursor>-1)Console.WriteLine("{0}",nodes[cursor].caption);
					cursor=nodes[cursor].after;
					if (cursor<0)eexits=true;
				}
			} 
		}
		static void Main(string[] args){
			int node1=0;
			int x86=0;
			trees tree1 = new trees(1025,"CPUS");
			node1=tree1.roots;
			tree1.setText(node1,tree1.getCaption(node1));
			tree1.debugs=false;
			x86=tree1.add("x86");
			tree1.setText(x86,tree1.getCaption(x86));
			tree1.setfather(x86,tree1.roots);
			node1=tree1.add("8086");
			tree1.setText(node1,tree1.getCaption(node1));
			tree1.setfather(node1,x86);
			node1=tree1.add("80186");
			tree1.setText(node1,tree1.getCaption(node1));
			tree1.setfather(node1,x86);
			node1=tree1.add("80286");
			tree1.setText(node1,tree1.getCaption(node1));
			tree1.setfather(node1,x86);
			node1=tree1.add("80386");
			tree1.setText(node1,tree1.getCaption(node1));
			tree1.setfather(node1,x86);
			node1=tree1.add("80486");
			tree1.setText(node1,tree1.getCaption(node1));
			tree1.setfather(node1,x86);
			node1=tree1.add("arm");
			tree1.setText(node1,tree1.getCaption(node1));
			tree1.setfather(node1,tree1.roots);
			//tree1.report();
			tree1.help();
			tree1.lloops();
		}

		
	}
}






