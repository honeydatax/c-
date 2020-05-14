using System;

namespace logic{
	class logics{
		public class tables{
			public int size=0;
			public string title="";
			public rows [] rrows = null;
			public tables(int row,int col,int sizes,string titles){
				int i=0;
				rrows = new rows[row];
				size=sizes;
				for(i=0;i<row;i++) rrows[i]=new rows(col);
				title=titles;
			}
			public void report(){
			int i=0;
			int ii=0;
			Console.WriteLine("{0}",title);
				for(i=0;i<rrows.Length;i++){
					
					Console.Write("|");
						for(ii=0;ii<rrows[0].cols.Length;ii++){
							print(rrows[i].cols[ii]);
							Console.Write("|");
						}
						Console.WriteLine("");
				}
			}
			private void print(string s){
				int i=0;
				string ss=s;
				for(i=0;i<size;i++)ss=ss+" ";
				for(i=0;i<size;i++)Console.Write(ss[i]);
			}
		}
		public class rows{
			public string [] cols=null;
			public rows(int col){
				int i=0;
				cols=new string[col];
				for(i=0;i<col;i++)cols[i]="";
			}
		}


		static void Main(string[] args){
			int i=0;
			int ii=0;
			int iii=0;
			char c =' ';
				tables table1 = new tables(26,3,8,"table1:");
				for(i=0;i<table1.rrows.Length;i++){
					c=Convert.ToChar(i+65);
						for(ii=0;ii<table1.rrows[0].cols.Length;ii++)table1.rrows[i].cols[ii]=" "+c+","+Convert.ToString(ii);
				}
				table1.report();
		}

	}

}






