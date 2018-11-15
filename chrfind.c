#include <stdio.h> 
#include <stdlib.h> 

int chrfind(char *s1,char c);


int main(){
	char s2[32]="hello world\n$\0";
	char *s1;
	int i;
	s1=s2;
	i=chrfind(s2,'o');
	if (i>-1) s1=s2+i;
	puts(s1);
	
	exit(0);
return 0;
}

int chrfind(char *s1,char c)
{
	int a;
	int b;
	
	for(a=0;a<65000;a++){
		b=a;
		if (s1[a]==c || s1[a]==0) a=65001;
		
	}
		if (b>65000) b=-1;
		return b;
	}

