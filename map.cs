using System;

namespace logic{
	
	class logics{
		public class maps{
			private int count=25;
			private char [] screen= new char[79*20];
			public star [] stars=new star[25];
			private Random rnds=new Random();


			public class star{
				public int x=0;
				public int y=0;
			}
			
			public maps(){
				int i;
				for (i=0;i<count;i++) setStar(i);
				for (i=0;i<(79*20);i++) screen[i]=' ';
			}
	
			public void debug(){
				Print();
			}
			private void setStar(int index){
				stars[index]=new star();
				stars[index].x=rnds.Next(78);
				stars[index].y=rnds.Next(20);
			}
			private void  mapstar(int index){
				screen[stars[index].y*79+stars[index].x]='*';
			}
			
			public void Println(){
				int i;
				int ii;
				string s="";
				for (i=0;i<count;i++)mapstar(i);
				for (ii=0;ii<20;ii++){
					s="";
					for (i=0;i<79;i++)s=s+screen[ii*79+i].ToString();
					Console.WriteLine("{0}",s);
				}

			}
			
			private void Print(){
				int i;
				for (i=0;i<count;i++) Console.WriteLine("x:{0},y:{1}",stars[i].x,stars[i].y);
			}
			
		}

		static void Main(string[] args){
			maps mp = new maps();
			if (args.Length>0){
				mp.debug();	
			}else{
				mp.Println();	
			}
			
		}

		
	}
}






