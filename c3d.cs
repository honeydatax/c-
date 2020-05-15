using System;

namespace logic{
	class logics{
		public class c3ds{
			public string title="";
			public Zs [] z=null;
			public c3ds(int zs,int ys,int xs,string titles){
				int i=0;
				title=titles;
				z=new Zs[zs];

				for(i=0;i<zs;i++)z[i]=new Zs(ys,xs);
			}
			public void sets(int zs,int ys,int xs,int values){
				z[zs].y[ys].x[xs].value=values;
			}
			public int gets(int zs,int ys,int xs){
				return z[zs].y[ys].x[xs].value;
			}
			public void print(int zs,int ys,int xs){
				Console.Write("[");
				Console.Write(zs);
				Console.Write(",");
				Console.Write(ys);
				Console.Write(",");
				Console.Write(zs);
				Console.Write("]=");
				Console.WriteLine("{0}",gets(zs,ys,xs));
			}
			public void report(){
				int zz=0;
				int yy=0;
				int xx=0;
				Console.WriteLine("{0}",title);
				for(zz=0;zz<z.Length;zz++){
					for(yy=0;yy<z[zz].y.Length;yy++){
						for(xx=0;xx<z[zz].y[yy].x.Length;xx++){
								print(zz,yy,xx);
								
						}
					}
				}
			}
		}
		public class Zs{
			public Ys [] y =null;
			public Zs(int ys,int xs){
				int i=0;
				y=new Ys[ys];
				for(i=0;i<ys;i++)y[i]=new Ys(xs);
			}
		}
		public class Ys{
			public Xs [] x =null;
			public Ys(int xs){
				int i=0;
				x=new Xs[xs];
				for(i=0;i<xs;i++)x[i]=new Xs();
			}
		}
		public class Xs{
			public int value=0;
		} 





		static void Main(string[] args){
			int zz=0;
			int yy=0;
			int xx=0;
			int count=0;
			c3ds c3d = new c3ds(4,4,4,"3d structure");
			
				//Console.WriteLine("");
				for(zz=0;zz<c3d.z.Length;zz++){
					for(yy=0;yy<c3d.z[zz].y.Length;yy++){
						for(xx=0;xx<c3d.z[zz].y[yy].x.Length;xx++){
								c3d.z[zz].y[yy].x[xx].value=count;
								count++;
						}
					}
				}
				c3d.report();
				
		}

	}

}






