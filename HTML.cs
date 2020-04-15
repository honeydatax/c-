using System;

namespace logic{
	
	class logics{
		public class HTML{
			public HTML(string title){
				Console.WriteLine("<html>");
				Console.WriteLine("<head>");
				Console.WriteLine("<title>");
				Console.WriteLine("{0}",title);
				Console.WriteLine("</title>");
				Console.WriteLine("</head>");
				Console.WriteLine("<body>");
			}
			~HTML(){
				ends();
			}

			public void H1(){
				Console.WriteLine("<H1>");
			}
			public void h1(){
				Console.WriteLine("</H1>");
			}
			public void H2(){
				Console.WriteLine("<H2>");
			}
			public void h2(){
				Console.WriteLine("</H2>");
			}
			public void H3(){
				Console.WriteLine("<H3>");
			}
			public void h3(){
				Console.WriteLine("</H3>");
			}
			public void H4(){
				Console.WriteLine("<H4>");
			}
			public void h4(){
				Console.WriteLine("</H4>");
			}
			public void BR(){
				Console.WriteLine("<br>");
			}
			public void Bold(){
				Console.WriteLine("<bold>");
			}
			public void bold(){
				Console.WriteLine("</bold>");
			}
			
			public void H5(){
				Console.WriteLine("<H5>");
			}
			public void h5(){
				Console.WriteLine("</H5>");
			}

			public void text(string txt){
				Console.WriteLine("{0}",txt);
			}
			public void ends(){
				Console.WriteLine("</body>");
				Console.WriteLine("</html>");
			}
		}

		static void Main(string[] args){
			HTML html = new HTML("hello world");
			html.text("hello world");
			html.BR();
			html.H1();
			html.text("hello world");
			html.h1();
			html.BR();
			html.H2();
			html.text("hello world");
			html.h2();
			html.BR();
			html.H3();
			html.text("hello world");
			html.h3();
			html.BR();
			html.H4();
			html.text("hello world");
			html.h4();
			html.BR();
			html.H5();
			html.text("hello world");
			html.h5();
			html.BR();


		}

		
	}
}






