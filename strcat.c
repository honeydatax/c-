#include <stdio.h> 
#include <stdlib.h> 

void strcat(char *s1,char *s2);


int main(){
	char s2[64]="hello world\n\0";
	char s3[64]="string 2$\0";
	char *s1;
	int i;
	s1=s2;
	strcat(s2,s3);
	puts(s1);
	
	exit(0);
return 0;
}

void strcat(char *s1,char *s2)
{
	int a;
	int b;
	int c;
	
	for(a=0;a<65000;a++){
		b=a;
		if (s1[a]==0) a=65001;
		
	}
		if (b<65000) {
		for(a=0;a<65000;a++){
			s1[a+b]=s2[a];
		if (s2[a]==0) a=65001;
		
		}

		}
	}

