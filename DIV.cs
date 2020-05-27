using System;

namespace logic{
	public class DIVS{
		private string number1n="";
		private string number2n="";
		public string number="";
		private string number1="";
		private string number2="";
		private string imaginary1="";
		private string imaginary2="";
		private string number1out="";
		private string number2out="";
		private string imaginary1out="";
		private string imaginary2out="";
		private bool errors=false;
		private bool bover=false;
		private SUBS sub=new SUBS();
		private MULS mul=new MULS();
		public DIVS(){
			
		}
		public string math(string s1,string s2,bool shows){
			int counter=0;
			string ssss="";
			char c=' ';
			int i=0;
			bool exits=false;
			bool exits2=false;
			int pos=0;
			int st=0;
			bool b=false;
			int point1s=0;
			int point2s=0;
			int point3s=0;
			int pos1=0;
			number="";
			string ss0="";
			string ss1=s1;
			string ss2=s2;
			
			if (shows)Console.WriteLine(" {0}",s1);
			if (shows)Console.WriteLine(" {0}",s2);
			if (shows)Console.WriteLine("----------------");

			ss1=ss1.Replace(",","");
			ss2=ss2.Replace(",","");
			ss1=ss1.Replace("'","");
			ss2=ss2.Replace("'","");
			st=ss1.IndexOf(".");
			
			
			if(st<0)st=ss1.Length;
			point1s=ss1.Length-st-1;
			if(point2s<0)point2s=0;
			st=ss2.IndexOf(".");
			if(st<0)st=ss2.Length;
			
			point2s=ss2.Length-st-1;
			if(point2s<0)point2s=0;
			
			ss1=ss1.Replace(".","");
			ss2=ss2.Replace(".","");

			if(ss1.Length<ss2.Length){
				number="0";
				exits=true;
			}else{
				number1=sub.left(ss1,ss2.Length);
				pos=ss2.Length;
			}
			ss2=Removezeros(ss2);
			while(!exits){

				exits2=false;
				if(pos>ss1.Length)exits2=true;
				while(!exits2){
					b=true;
					number1=Removezeros(number1);
					if(number1.Length==ss2.Length)b=sub.test(number1,"0",ss2,"0");
					if(number1.Length>ss2.Length)b=false;
					if(number1.Length<ss2.Length)b=true;
					if (b){
						number=number+"0";
						if (pos<ss1.Length)number1=number1+ss1[pos];
						pos++;
					}else{
						exits2=true;
					}
					
					if(pos>ss1.Length)exits2=true;
				}
				number1=Removezeros(number1);
				if (shows)Console.WriteLine("{0}",number1);
				
				if(pos<=ss1.Length){
					for(i=9;i>0;i--){
						c=Convert.ToChar(i+Convert.ToInt16('0'));
						number1out=mul.mulsn(mul.sinvert(ss2),c,false,0);
						number1out=Removezeros(number1out);
					number1=Removezeros(number1);
					if(number1.Length==number1out.Length)b=sub.test(number1,"0",number1out,"0");
					if(number1.Length>number1out.Length)b=false;
					if(number1.Length<number1out.Length)b=true;
						if (!b){
							number=number+c;
							i=-1;
							number1=sub.subs(number1+".0",number1out+".0");
							number1=number1.Replace(",","");
							number1=number1.Replace(".0","");
							number1=number1.Replace(".","");
							
						}
							
						
					}
					
				}
				number1=Removezeros(number1);
				if (shows)Console.WriteLine("{0}",number1);
					number1=Removezeros(number1);
					b=true;
					if(number1.Length==ss2.Length)b=sub.test(number1,"0",ss2,"0");
					if(number1.Length>ss2.Length)b=false;
					if(number1.Length<ss2.Length)b=true;
					if (b){
						if (pos<ss1.Length)number1=number1+ss1[pos];
						pos++;
					}
				
				if(pos>ss1.Length)exits=true;
			}
			if (shows)Console.WriteLine("----------------");
			if(number=="")number="0";
			number=Removezeros(number).Trim();
			
			point3s=point1s;
			point1s=number.Length-point1s-1;
			
			if (point1s<0){
				pos1=-point1s;
				for(i=0;i<pos1;i++)number="0"+number;
			}
			if (point2s>0){
				pos1=point2s;
				for(i=0;i<pos1;i++)number=number+"0";
			}

			
			point1s=number.Length-point3s-1;
			
			ss1="";
			ss0="";
			for (i=0;i<number.Length;i++){
				if(i<=point1s){
					ss0=ss0+number[i];
				}else{
					ss1=ss1+number[i];
				}
					
				
			}
			ss0=mul.sinvert(ss0);
			ss0=mul.separetes(ss0);
			ss0=mul.sinvert(ss0);
			ss1=mul.separetes(ss1);
			number=ss0+"."+ss1;
			
			if (shows)Console.WriteLine( " {0}",number);
			return number;
		}
		public string Removezeros(string s1){
			int i=0;
			bool b=false;
			string s="";
			for(i=0;i<s1.Length;i++){
				if(s1[i]!='0')b=true;
				if(i==s1.Length-1)b=true;
				if (b)s=s+s1[i];
			}
			return s;
		}
	}
	public class SUBS{
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
		private bool errors=false;
		private bool bover=false;
		public SUBS(){
			
		}
		public string subs(string s1, string s2){
			string [] ss1 =s1.Split('.');
			string [] ss2 =s2.Split('.');
			string sss="";
			string ssss="";
			bool img=false;
			bool neg=false;
			bool nneg=false;
			bool iimg=false;
			int n1=0;
			int n2=0;
			int n3=0;
			int n4=0;
			int n5=0;
			int n6=0;
			int n7=0;
			errors=false;
			bover=false;
			
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
			n7=n2;
			if (n2<n4){
				n7=n4;
				
			}
			
			imaginary1=sfillsrigth(imaginary1,n7);
			imaginary2=sfillsrigth(imaginary2,n7);
			imaginary1=left(imaginary1,n7);
			imaginary2=left(imaginary2,n7);
			
			neg=false;
			nneg=false;
			if (n1==n3){
				nneg=true;
				neg=test(number1,imaginary1,number2,imaginary2);
				
				if (neg){

				sss=number1;
				ssss=imaginary1;
				number1=number2;
				imaginary1=imaginary2;
				number2=sss;
				imaginary2=ssss;
				n5=n1;
				n6=n2;
				n1=n3;
				n2=n4;
				n3=n5;
				n4=n6;
				}
			}


			if (n1<n3){
				neg=true;
				sss=number1;
				ssss=imaginary1;
				number1=number2;
				imaginary1=imaginary2;
				number2=sss;
				imaginary2=ssss;
				n5=n1;
				n6=n2;
				n1=n3;
				n2=n4;
				n3=n5;
				n4=n6;
			}

			
			number1=sfills(number1,n1);
			number2=sfills(number2,n1);
			number1=sinvert(number1);
			number2=sinvert(number2);
			number1=left(number1,n1);

			imaginary1=sinvert(imaginary1);
			number2=left(number2,n1);

			imaginary2=sinvert(imaginary2);
									
			iimg=false;

			imaginary1out=mats(imaginary1,imaginary2);
			
			if(bover)iimg=true;

			n1=imaginary1.Length;

			n2=imaginary1out.Length;

			img=false;

			imaginary1out=sinvert(imaginary1out);
			imaginary1out=separetes(imaginary1out);
			
			number1out=mats(number1,number2);
			if (iimg){
				n1=number1out.Length-1;
				if (n1<0)n1=0;
				number1=sfills("1",n1);
				number1=sinvert(number1);
				iimg=zero(number1out);

				if(iimg){
					number1out=mats(number1,number1out);
				}else{
					number1out=mats(number1out,number1);
				}
			}
			number1out=separetes(number1out);
			number1out=sinvert(number1out);
			number=number1out+"."+imaginary1out;
			if(neg)number="-"+number;
			if (errors) number="ERROR ILIGAL CHAR";
			return number;
		}
		public bool zero(string s1){
			string s2="";
			string s3=s1;
			char c1=' ';
			char c2=' ';
			int i=0;
			int n=s1.Length;
			bool b=true;
			s2=sfills("",n);
			
			for(i=0;i<n;i++){
				
				c1=s2[i];
				c2=s3[i];
				
				if (c1!=c2){
					b=false;
					i=n+1;
				}
			}
			
			return b;
			
		}
		public bool test(string s1,string s2,string s3,string s4){
			int i=0;
			bool b=false;
			bool bb=false;
			for(i=0;i<s1.Length;i++){
				if (s1[i]<s3[i]){
					bb=true;
					b=true;
					i=s1.Length+1;
				}
				if (i<s1.Length){
					if(s1[i]>s3[i]){
						bb=true;
						b=false;
						i=s1.Length+1;
					}
				}
			}
			if(!b && !bb ){	
							
					for(i=0;i<s2.Length;i++){
						if (s2[i]<s4[i]){
							b=true;
							i=s2.Length+1;
						}
						if (i<s2.Length){
							if(s2[i]>s4[i]){
								b=false;
								i=s2.Length+1;
							}
						}
					}
			}
			return b;
		}
		public string separetes(string s1){
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
		public string mats(string s1, string s2){
			int n1=s1.Length;
			char c=' ';
			string s3="";
			int i=0;
			bool overflow=false;
			bool over=false;
			int i1=0;
			int i2=0;
			int i3=0;
			bover=false;
			for(i=0;i<n1;i++){
				
				if (s1[i]>='0' && s1[i]<='9' && s2[i]>='0' && s2[i]<='9'){
					i1=Convert.ToInt16(s1[i]-'0');
					i2=Convert.ToInt16(s2[i]-'0');
					if (overflow)i2++;
					i3=i1-i2;

					over=false;
					if (i3<0){
						over=true;
						i3=i3+10;
					}
					c=Convert.ToChar(i3+Convert.ToInt16('0'));
					s3=s3+c;
					overflow=over;
				}else{
					errors=true;
					i=n1+1;
				}
				if(overflow)bover=true;
			}
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
		public string separetes(string s1){
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

			DIVS div =new DIVS();
			string s1="0.0500,000,0";
			string s2="0.22";
			string s3=div.math(s1,s2,true);
				

		}

		
	}
}






