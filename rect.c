#include <stdio.h> 
#include <stdlib.h> 
void debug(char * s);
void rect(int x,int y,int w,int h,int c);
void screen(int n);
void back(int c);



int main(){
debug("start debug\n\n");
screen(0x13);
back(15);
rect(100,100,150,150,1);
rect(0,0,100,100,15);

screen(0x3);
exit(0);
return 0;
}

void rect(int x,int y,int w,int h,int c)
{
printf("rect\n",x);
printf("x=%i\n",x);
printf("y=%i\n",y);
printf("w=%i\n",w);
printf("h=%i\n",h);
printf("color=%i\n\n",c);
}


void debug(char * s)
{
printf(s);
}


void screen(int n)
{
printf("screen=%i\n\n",n);
}
 

void back(int c)
{
printf("back color=%i\n\n",c);
}
 









