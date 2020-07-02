using System;

namespace logic{
	class logics{
		public class g3d{
		public int x=0;
		public int y=0;
		public int w=600;
		public int h=300;
		public int per=25;
		public int xx=4;
		public int yy=4;
		public int zz=4;
		public int dims=8;
		public int depres=25;
		public g3d(){
			calc();
		}
		public void calc(){
			int i=0;
			int x1=0;
			int y1=0;
			int z1=0;
			int zw1=0;
			int zh1=0;
			int zw2=0;
			int zh2=0;
			int zw3=0;
			int zh3=0;
			if (xx<0)xx=0;
			if (xx>dims-1)xx=dims-1;
			if (yy<0)yy=0;
			if (yy>dims-1)yy=dims-1;
			if (zz<0)zz=0;
			if (zz>dims-1)zz=dims-1;
			z1=((dims-1)-zz)*depres;
			x1=xx;
			y1=yy;
			zw1=w-z1;
			zh1=h-z1;
			zw2=zw1/dims;
			zh2=zh1/dims;
			zw3=w-z1;
			zh3=h-z1;
			zw3=zw3/dims;
			zh3=zh3/dims;
			xx=w/2+(zw2*(x1-(dims/2)))+x;
			yy=h/2+(zh2*(y1-(dims/2)))+y;
			x1=100*zw3/zw2;
			per=x1;
		}
		public void report(){
			int xi=0;
			int yi=0;
			int zi=0;
			int xxx=0;
			int yyy=0;
			int zzz=0;
			xx=xxx;
			yy=yyy;
			zz=zzz;
			for(zi=0;zi<dims;zi++){
			for(yi=0;yi<dims;yi++){
			for(xi=0;xi<dims;xi++){
			xx=xi;
			yy=yi;
			zz=zi;
				calc();
				Console.WriteLine("{0},{1},{2}={3},{4}",xi,yi,zi,xx,yy);
			}
			}
			}
		}
		
	}

		static void Main(string[] args){
			g3d d3ds= new g3d();
			d3ds.report();
		}

}	
	
}






