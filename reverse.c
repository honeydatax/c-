#include <stdio.h> 
#include <stdlib.h> 

void strreverse(char *s1,char *s2);


int main(){
	char s2[32]="$hello world\n$\0";
	char s1[32]="...................\n$\0$\0$\0$\0";
	
	
	strreverse(s1,s2);
	puts(s1);
	
	exit(0);
return 0;
}

void strreverse(char *s1,char *s2)
{
	int a;
	int b;
	int c;
	
	if (s2[0]!=0){
	
		for(a=0;a<65000;a++){
			b=a;
			if ( s2[a]==0) a=65001;

		}
	}
	if (b<65000){
		
		c=b;

		for(a=0;a<b;a++){
			
			s1[a]=s2[c-1];
			c--;
		
		}
		s1[a]=0;
		
	}
	
		
}

