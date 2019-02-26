main:
	jmp	_main
 
_puts:
	push	ebp
	mov	ebp, esp
	sub	esp, 16
	mov	eax, DWORD [ebp+8]
	mov	edx, eax
	mov	ah,9
	int	0x21
	nop
	leave
	ret
 
_exit:
	push	ebp
	mov	ebp, esp
	sub	esp, 16
	mov	eax, DWORD [ebp+8]
	mov	edx, eax
	mov	ax,0
	int	0x21
	nop
	leave
	ret
 
___main:
	;put your initial code here
	ret
;end head
 
	;.file	"rect.c"
	;.code16gcc
	;.intel_syntax noprefix
	;.global 	___main;	.scl	2;	.type	32;	.endef
	;;.section  .rdata,"dr"
LC0:
	db  "start debug",13,10,"",13,10,"\0"
	db "$\0"
	;.global 	_main
	;.global 	_main;	.scl	2;	.type	32;	.endef
_main:
	push	ebp
	mov	ebp, esp
	and	esp, -16
	sub	esp, 32
	call	___main
	mov	DWORD  [esp],  LC0
	call	__Z5debugPc
	mov	DWORD  [esp], 19
	call	__Z6screeni
	mov	DWORD  [esp], 15
	call	__Z4backi
	mov	DWORD  [esp+16], 1
	mov	DWORD  [esp+12], 150
	mov	DWORD  [esp+8], 150
	mov	DWORD  [esp+4], 100
	mov	DWORD  [esp], 100
	call	__Z4rectiiiii
	mov	DWORD  [esp+16], 15
	mov	DWORD  [esp+12], 100
	mov	DWORD  [esp+8], 100
	mov	DWORD  [esp+4], 0
	mov	DWORD  [esp], 0
	call	__Z4rectiiiii
	mov	DWORD  [esp], 3
	call	__Z6screeni
	mov	DWORD  [esp], 0
	call	_exit
	;;.section  .rdata,"dr"
LC1:
	db  "rect",13,10,"\0"
LC2:
	db  "x=%i",13,10,"\0"
LC3:
	db  "y=%i",13,10,"\0"
LC4:
	db  "w=%i",13,10,"\0"
LC5:
	db  "h=%i",13,10,"\0"
LC6:
	db  "color=%i",13,10,"",13,10,"\0"
	db "$\0"
	;.global 	__Z4rectiiiii
	;.global 	__Z4rectiiiii;	.scl	2;	.type	32;	.endef
__Z4rectiiiii:
	push	ebp
	mov	ebp, esp
	sub	esp, 24
	mov	eax, DWORD  [ebp+8]
	mov	DWORD  [esp+4], eax
	mov	DWORD  [esp],  LC1
	call	_printf
	mov	eax, DWORD  [ebp+8]
	mov	DWORD  [esp+4], eax
	mov	DWORD  [esp],  LC2
	call	_printf
	mov	eax, DWORD  [ebp+12]
	mov	DWORD  [esp+4], eax
	mov	DWORD  [esp],  LC3
	call	_printf
	mov	eax, DWORD  [ebp+16]
	mov	DWORD  [esp+4], eax
	mov	DWORD  [esp],  LC4
	call	_printf
	mov	eax, DWORD  [ebp+20]
	mov	DWORD  [esp+4], eax
	mov	DWORD  [esp],  LC5
	call	_printf
	mov	eax, DWORD  [ebp+24]
	mov	DWORD  [esp+4], eax
	mov	DWORD  [esp],  LC6
	call	_printf
	nop
	leave
	ret
	;.global 	__Z5debugPc
	;.global 	__Z5debugPc;	.scl	2;	.type	32;	.endef
__Z5debugPc:
	push	ebp
	mov	ebp, esp
	sub	esp, 24
	mov	eax, DWORD  [ebp+8]
	mov	DWORD  [esp], eax
	call	_printf
	nop
	leave
	ret
	;;.section  .rdata,"dr"
LC7:
	db  "screen=%i",13,10,"",13,10,"\0"
	db "$\0"
	;.global 	__Z6screeni
	;.global 	__Z6screeni;	.scl	2;	.type	32;	.endef
__Z6screeni:
	push	ebp
	mov	ebp, esp
	sub	esp, 24
	mov	eax, DWORD  [ebp+8]
	mov	DWORD  [esp+4], eax
	mov	DWORD  [esp],  LC7
	call	_printf
	nop
	leave
	ret
	;;.section  .rdata,"dr"
LC8:
	db  "back color=%i",13,10,"",13,10,"\0"
	db "$\0"
	;.global 	__Z4backi
	;.global 	__Z4backi;	.scl	2;	.type	32;	.endef
__Z4backi:
	push	ebp
	mov	ebp, esp
	sub	esp, 24
	mov	eax, DWORD  [ebp+8]
	mov	DWORD  [esp+4], eax
	mov	DWORD  [esp],  LC8
	call	_printf
	nop
	leave
	ret
	;;.ident	"GCC: (GNU) 6.3.0 20170406"
	;.global 	_exit;	.scl	2;	.type	32;	.endef
	;.global 	_printf;	.scl	2;	.type	32;	.endef
section .data
