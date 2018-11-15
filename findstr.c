#include <stdio.h> 
#include <stdlib.h> 

int findstr(char *s1,char *s2);


int main(){
	char s2[32]="hello world\n$\0";
	char s3[32]="world\0";
	char *s1;
	int i;
	s1=s2;
	i=findstr(s2,s3);
	if (i>-1) s1=s2+i;
	puts(s1);
	
	exit(0);
return 0;
}

int findstr(char *s1,char *s2)
{
	int a;
	int b;
	int cc;
	char c;
	int d;
	int e;
	int f;
	int g;
	e=-1;
	cc=0;
	c=s2[0];
	f=0;
	g=0;
	for (d=0;d<65000;d++)	
	{
		g=d;
		
		for(a=g;a<65000;a++){
			b=a;

			if (s1[a]==c) 
			{
				a=65001;
				goto exits1findstr;
			}


			if (s1[a]==0)
			{
				d=65001;
				f=65001;
				b=65001;
				goto exitsfindstr;
			}



			if (a>64999)
			{
				d=65001;
				f=65001;
				b=65001;
				goto exitsfindstr;
			}
				
		}
		
		
		exits1findstr:
		
		if (b<65000 && d<65000)
		{
			for (f=b;f<65000;f++)	
			{

				if (s2[f-b]==0)
				{
					f=65001;
					
					goto exitsfindstr;
				}

				if (s1[f]!=s2[f-b])
				{
					f=65001;
					goto exits2findstr;
				}
			
				if (s1[f]==0)
				{
					f=65001;
					goto exits2findstr;
				} 

							
			}
		}
			exits2findstr:
			if (b>65000) 
			{
				b=65001;
				d=65001;
				a=65001;
				f=65001;
			}
		}

			exitsfindstr:
			if (b>64999) 
			{
				b=-1;
				d=65001;
				a=65001;
				f=65001;
			}
			
			
			return b;
		}

