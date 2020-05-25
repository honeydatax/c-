using System;

namespace logic{
	public class MULS{
		private ADDS add =new ADDS();
		public string [] item= new string[8000];
		public string ss0="";
		public string ss1="";
		public string  number1="0";
		public string  number2="0";
		public string  number="0";
		public int pos=0;
		public int pos1=0;
		public MULS(){
			int i=0;
			for(i=0;i<8000;i++)item[i]="";
		}
		public string math(string s1,string s2,bool b){
			int i=0;
			int point1s=0; 
			int point2s=0;
			int point3s=0;
			string number3="";
			string ssss="";
			int st=0;
			pos=0;
			if(b){
				Console.WriteLine(" {0}",s1);
				Console.WriteLine(" {0}",s2);
				Console.WriteLine(" *");
				Console.WriteLine("------------------------------");
			}
			number1=s1;
			number2=s2;
			number1=number1.Replace(",","");
			number2=number2.Replace(",","");
			number1=number1.Trim();
			number2=number2.Trim();

			st=number1.IndexOf(".");
			
			if(st<0)st=number1.Length;
			point1s=number1.Length-st-1;
			if(point2s<0)point2s=0;
			st=number2.IndexOf(".");
			if(st<0)st=number2.Length;
			
			point2s=number2.Length-st-1;
			if(point2s<0)point2s=0;
			point1s=point2s+point1s;
			number1=number1.Replace(".","");
			number2=number2.Replace(".","");
			if (number2.Length>number1.Length){
				number3=number1;
				number1=number2;
				number2=number3;
			}
			
			number2=sinvert(number2);
			number1=sinvert(number1);
			pos=number1.Length;
			for (i=0;i<number2.Length;i++){
				ssss=mulsn(number1,number2[i],b,i);
				
				item[i]=ssss;

			}
			number="0.0";
			for (i=0;i<number2.Length;i++){
				if (b){
					Console.WriteLine("{0}",item[i]);
				}
				
				number=add.sumss(number,item[i]+".0");
			}
			
			
			number1=number.Replace(",","");
			number1=number1.Replace(".0","");
			number1=number1.Replace(".","");
			number="";
			point3s=point1s;
			point1s=number1.Length-point1s-1;
			
			if (point1s<0){
				pos1=-point1s;
				for(i=0;i<pos1;i++)number1="0"+number1;
				//point1s=0;
			}
			
			point1s=number1.Length-point3s-1;
			
			ss1="";
			ss0="";
			for (i=0;i<number1.Length;i++){
				if(i<=point1s){
					ss0=ss0+number1[i];
				}else{
					ss1=ss1+number1[i];
				}
					
				
			}
			ss0=sinvert(ss0);
			ss0=separetes(ss0);
			ss0=sinvert(ss0);
			ss1=separetes(ss1);
			number=ss0+"."+ss1;
			if (b){
				Console.WriteLine("------------------------------");
				Console.WriteLine(" {0}",number);
			}
			return number;
		}
		public string zero(int index){
			int i=0;
			string s="";
			if (index>0)for(i=0;i<index;i++)s=s+"0";
			return s;
		}
		public string mulsn(string s,char c,bool prints,int index){
			int i=0;
			int z=0;
			int m=0;
			string ss="";
			string sss=s;
			char cc=' ';
			int steep=0;
			int x=0;
			int y=Convert.ToInt16(c-'0');
		
			for(i=0;i<s.Length;i++){
				x=Convert.ToInt16(sss[i]-'0');
				x=x*y+steep;
				z=x/10;
				m=x-(z*10);
				
				steep=z;
				cc=Convert.ToString(m)[0];
				ss=ss+cc;
			}
			
			ss=sinvert(ss);
			
			if (steep!=0){
				ss=Convert.ToString(steep)+ss;
			}
		
			
			ss=ss+zero(index);
				return ss;
		}
		public string sinvert(string s1){
			string s2="";
			int i=0;
			for(i=s1.Length-1;i>-1;i--){
				s2=s2+s1[i];
			}
			return s2;
		}		
		private string separetes(string s1){
			string s2="";
			int counter=0;
			int i=0;
			for(i=0;i<s1.Length;i++){
				s2=s2+s1[i];
				counter++;
				if (counter>2){
					if (!(i+1>=s1.Length))s2=s2+",";
					counter=0;
				}
			}
			return s2;
		}

	}
	public class ADDS{
		private string number1n;
		private string number2n;
		public string number;
		private string number1;
		private string number2;
		private string imaginary1;
		private string imaginary2;
		private string number1out;
		private string number2out;
		private string imaginary1out;
		private string imaginary2out;
		bool errors=false;
		public ADDS(){
			
		}
		public string sumss(string s1, string s2){
			string [] ss1 =s1.Split('.');
			string [] ss2 =s2.Split('.');
			bool img=false;
			int n1=0;
			int n2=0;
			int n3=0;
			int n4=0;
			errors=false;
			
			if (ss1.Length<1){
				number1="0";
				imaginary1="0";
			}
			
			if (ss1.Length==1){
				number1=ss1[0];
				imaginary1="0";
			}
			if (ss1.Length==2){
				number1=ss1[0];
				imaginary1=ss1[1];
			}

			if (ss2.Length<1){
				number2="0";
				imaginary2="0";
			}
			if (ss2.Length==1){
				number2=ss2[0];
				imaginary2="0";
			}
			if (ss2.Length==2){
				number2=ss2[0];
				imaginary2=ss2[1];
			}
			number1=number1.Replace(",","");
			imaginary1=imaginary1.Replace(",","");
			number2=number2.Replace(",","");
			imaginary2=imaginary2.Replace(",","");

			number1=number1.Replace("'","");
			imaginary1=imaginary1.Replace("'","");
			number2=number2.Replace("'","");
			imaginary2=imaginary2.Replace("'","");



			n1=number1.Length;
			n2=imaginary1.Length;
			n3=number2.Length;
			n4=imaginary2.Length;
			if (n1<n3)n1=n3;
			if (n2<n4)n2=n4;
			number1=sfills(number1,n1);
			imaginary1=sfillsrigth(imaginary1,n2);
			number2=sfills(number2,n1);
			imaginary2=sfillsrigth(imaginary2,n2);
			
			number1=sinvert(number1);
			imaginary1=left(imaginary1,n2);
			number2=sinvert(number2);
			imaginary2=left(imaginary2,n2);

			number1=left(number1,n1);
			imaginary1=sinvert(imaginary1);
			number2=left(number2,n1);
			imaginary2=sinvert(imaginary2);
			
			
			imaginary1out=mats(imaginary1,imaginary2);
			
			n1=imaginary1.Length;
			n2=imaginary1out.Length;
			img=false;
			if(n2>n1){
				if (n2>0)n2=n2-1;
				imaginary1out=left(imaginary1out,n2);
				img=true;
			}
			imaginary1out=sinvert(imaginary1out);
			imaginary1out=separetes(imaginary1out);
			number1out=mats(number1,number2);
			
			if (img){
				n1=number1out.Length-1;
				if (n1<0)n1=0;
				number1=sfills("1",n1);
				number1=sinvert(number1);
				number1out=mats(number1,number1out);
			}
			number1out=separetes(number1out);
			number1out=sinvert(number1out);
			number=number1out+"."+imaginary1out;
			if (errors) number="ERROR ILIGAL CHAR";
			return number;
		}
		private string separetes(string s1){
			string s2="";
			int counter=0;
			int i=0;
			for(i=0;i<s1.Length;i++){
				s2=s2+s1[i];
				counter++;
				if (counter>2){
					if (!(i+1>=s1.Length))s2=s2+",";
					counter=0;
				}
			}
			return s2;
		}
		private string mats(string s1, string s2){
			int n1=s1.Length;
			char c=' ';
			string s3="";
			int i=0;
			bool overflow=false;
			bool over=false;
			int i1=0;
			int i2=0;
			int i3=0;
			for(i=0;i<n1;i++){
				
				if (s1[i]>='0' && s1[i]<='9' && s2[i]>='0' && s2[i]<='9'){
					i1=Convert.ToInt16(s1[i]-'0');
					i2=Convert.ToInt16(s2[i]-'0');
					i3=i1+i2;
					if (overflow)i3++;
					over=false;
					if (i3>9){
						over=true;
						i3=i3-10;
					}
					c=Convert.ToChar(i3+Convert.ToInt16('0'));
					s3=s3+c;
					overflow=over;
				}else{
					errors=true;
					i=n1+1;
				}
				
			}
			if(overflow)s3=s3+"1";
			return s3;
		}
		public string left(string s1,int ii){
			int i=0;
			string s2="";
			for(i=0;i<ii;i++)s2=s2+s1[i];
			return s2;
		}
		public string sfills(string s1,int ii){
			int i=0;
			string s2=s1;
			for(i=0;i<ii;i++)s2="0"+s2;
			return s2;
		}
		public string sfillsrigth(string s1,int ii){
			int i=0;
			string s2=s1;
			for(i=0;i<ii;i++)s2=s2+'0';
			return s2;
		}

		public string sinvert(string s1){
			string s2="";
			int i=0;
			for(i=s1.Length-1;i>-1;i--){
				s2=s2+s1[i];
			}
			return s2;
		}		
	}
	
	class logics{
		static void Main(string[] args){

			MULS mulss =new MULS();
			string s1="0.122";//"654,321,000";
			string s2="0.0666";//"123,456,000";
			string s3=mulss.math(s1,s2,true);
				

		}

		
	}
}






