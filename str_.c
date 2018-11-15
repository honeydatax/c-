#include <stdio.h> 
#include <stdlib.h> 

void str_(int i,char *s1);


int main(){
	char s2[32]="0000000000$                ";
	int i;
	for (i=0;i<15;i++){
		str_(i,s2);
	

	puts(s2);
	}
	exit(0);
return 0;
}

void str_(int i,char *s1)
{
	int a;
	int b=i;
	int c=1000000000;
	char d;
	int e;
	for(a=0;a<10;a++){
		e=b/c;
		d=(char) e;
		d=d+'0';
		if (a!=9 && d=='0') d=' ';
		s1[a]=d;
		e=e*c;
		b=b-e;
		c=c/10;
		
		}
	}

