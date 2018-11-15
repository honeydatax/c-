#include <stdio.h> 
#include <stdlib.h> 

int len(char *s1);


int main(){
	char s2[64]="hello world\n$\0string 2$\0";
	char *s1;
	int i;
	s1=s2;
	i=len(s2);
	if (i>-1) s1=s2+i+1;
	puts(s1);
	
	exit(0);
return 0;
}

int len(char *s1)
{
	int a;
	int b;
	int c;
	
	for(a=0;a<65000;a++){
		b=a;
		if (s1[a]==0) a=65001;
		
	}
		if (b>65000) b=-1;
		return b;
	}

