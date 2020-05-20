using System;

namespace logic{
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
			n7++;
			
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

			n1++;
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
		private bool zero(string s1){
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
		private bool test(string s1,string s2,string s3,string s4){
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
	
	class logics{
		static void Main(string[] args){
			SUBS subs =new SUBS();
			string s1="987,654,321,000,987,654,321,000.0";
			string s2="111,111,111,111,111,111,111,111.9";
			Console.WriteLine("  {0}",s1);
			Console.WriteLine("  {0}",s2);
			Console.WriteLine(" -");
			Console.WriteLine("{0}",subs.subs(s1,s2));
			
				

		}

		
	}
}






