segment .text	   ;code segment
global _start    ;must be declared for linker 

org 0x100	

_start:	           
   mov ah,9
   mov dx,msg     
   int 0x21	   

   mov ah,0
   int 0x21

segment .data      ;data segment
msg	db 'Hello, world$',0xa ,10  ;our dear string
len	equ	$ - msg          ;length of our dear string
