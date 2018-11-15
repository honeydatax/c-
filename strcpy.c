#include <stdio.h> 
#include <stdlib.h> 

void strcpy(char *s1,char *s2);


int main(){
	char s2[32]="hello world\n$\0";
	char s1[32];
	strcpy(s1,s2);
	puts(s1);
	
	exit(0);
return 0;
}

void strcpy(char *s1,char *s2)
{
	int a;
	
	for(a=0;a<65000;a++){
		s1[a]=s2[a];
		if (s1[a]==0) a=65001;
		}
	}

