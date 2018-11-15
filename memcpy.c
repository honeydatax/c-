#include <stdio.h> 
#include <stdlib.h> 

void memcpy(char *s1,char *s2,int i);


int main(){
	char s2[32]="hello world\n$\0";
	char s1[32];
	memcpy(s1,s2,32);
	puts(s1);
	
	exit(0);
return 0;
}

void memcpy(char *s1,char *s2,int i)
{
	int a;
	
	for(a=0;a<i;a++){
		s1[a]=s2[a];
				}
	}

