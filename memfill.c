#include <stdio.h> 
#include <stdlib.h> 

void memfill(char *s1,char c,int i);


int main(){
	char s2[64]="hello world\n                       $\0";
	char *s1;
	int i;
	s1=s2;
	memfill(s2,'.',20);
	puts(s1);
	
	exit(0);
return 0;
}

void memfill(char *s1,char c,int i)
{
	int a;
	int b;
	
	for(a=0;a<i;a++){
		b=a;
		s1[a]=c;
		
	}
		
	
	}

