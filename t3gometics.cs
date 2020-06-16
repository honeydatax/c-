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
			double d=0.00f;
			double dd=0.00f;
			char c =' ';
				tables table1 = new tables(12,5,8,"table1:");
				
				for(i=0;i<table1.rrows.Length;i++){
					

					table1.rrows[i].cols[0]=Convert.ToString(i);
					d=Convert.ToDouble(i)*(360.00f/table1.rrows.Length);
					table1.rrows[i].cols[1]=d.ToString("F1");
					d=Math.Cos(Convert.ToDouble(i)/((table1.rrows.Length)/2.00f)*Math.PI);
					table1.rrows[i].cols[2]=d.ToString("F6");
					d=Math.Sin(Convert.ToDouble(i)/((table1.rrows.Length)/2.00f)*Math.PI);
					table1.rrows[i].cols[3]=d.ToString("F6");
					d=Math.Tan(Convert.ToDouble(i)/((table1.rrows.Length)/2.00f)*Math.PI);
					table1.rrows[i].cols[4]=d.ToString("F6");

				}
				table1.report();
		}

	}

}






