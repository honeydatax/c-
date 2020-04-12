using System;

namespace logic{
	
	class logics{
		class timeElepsed{
			public string dt="";
			public string dt2="";
			public int count=0;
			public bool elepseds=false;
			public int sleepes=0;
			public bool change=false;
			
			public void Resets(){
				dt="";
				dt2="";
				count=0;
				elepseds=false;
				change=false;
				sleepes=0;
			}
			
			public void check( ){
				if (dt=="")dt=DateTime.Now.ToString();
				if (dt2=="")dt2=DateTime.Now.ToString();
				change=false;
				dt=DateTime.Now.ToString();
					if(dt!=dt2){
						dt2=dt;
						count++;
						change=true;
					}
				elepseds=(count<sleepes);
			}

			
		}
	

		static void Main(string[] args){
			timeElepsed t1=new timeElepsed();
			t1.Resets();
			t1.sleepes=10;
			do{
				if (t1.change) Console.WriteLine("{0}:",t1.dt);
				t1.check();
			}while(t1.elepseds);
			
		}

		
	}
}






