	.file	"cross.c"
	.intel_syntax noprefix
	.def	__main;	.scl	2;	.type	32;	.endef
	.section .rdata,"dr"
.LC0:
	.ascii "hello world\0"
	.text
	.globl	main
	.def	main;	.scl	2;	.type	32;	.endef
	.seh_proc	__main
__main:
.LFB42:
	push	rbp
	.seh_pushreg	rbp
	mov	rbp, rsp
	.seh_setframe	rbp, 0
	sub	rsp, 32
	.seh_stackalloc	32
	.seh_endprologue
	;call	__main
	lea	rcx, .LC0[rip]
	call	puts
	mov	eax, 0
	add	rsp, 32
	pop	rbp
	ret
	.seh_endproc
	.ident	"GCC: (GNU) 6.3.0 20170406"
	.def	puts;	.scl	2;	.type	32;	.endef







