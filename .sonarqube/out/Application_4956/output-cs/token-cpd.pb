‹#
@D:\Dev\AspNetCoreTestes\Application\ClienteApplicationService.cs
	namespace

 	
Application


 
{ 
public 

class %
ClienteApplicationService *
:+ ,&
IClienteApplicationService- G
{ 
private 
IClienteRepository "
_repo# (
{) *
get+ .
;. /
}0 1
public %
ClienteApplicationService (
(( )
IClienteRepository) ;
repo< @
)@ A
{ 	
_repo 
= 
repo 
; 
} 	
public 
Cliente 
Obter 
( 
int  
id! #
)# $
{ 	
return 
ObterCliente 
(  
id  "
)" #
;# $
} 	
public 
void 
	Adicionar 
( 
string $
nome% )
)) *
{ 	
var 
cliente 
= 
new 
Cliente %
(% &
nome& *
)* +
;+ ,
_repo 
. 
Insert 
( 
cliente  
)  !
;! "
var 
	userEvent 
= 
new 
ClienteCriadoEvent  2
(2 3
cliente3 :
): ;
;; <
DomainEvents   
.   
Raise   
(   
	userEvent   (
)  ( )
;  ) *
}!! 	
public## 
PaginatedResults## 
<##  
Cliente##  '
>##' (
ListarTodos##) 4
(##4 5
int##5 8
paginaAtual##9 D
,##D E
int##F I
totalPorPagina##J X
)##X Y
{$$ 	
return%% 
_repo%% 
.%% 
GetAll%% 
(%%  
new%%  #
PaginationInput%%$ 3
(%%3 4
paginaAtual%%4 ?
,%%? @
totalPorPagina%%A O
)%%O P
)%%P Q
;%%Q R
}&& 	
public(( 
PaginatedResults(( 
<((  
Cliente((  '
>((' (
FiltrarPorNome(() 7
(((7 8
string((8 >
nome((? C
,((C D
int((E H
paginaAtual((I T
,((T U
int((V Y
itensPorPagina((Z h
)((h i
{)) 	
return** 
_repo** 
.** 
GetAllBy** !
(**! "
c++ 
=>++ 
c++ 
.++ 
Nome++ 
.++ 

StartsWith++ &
(++& '
nome++' +
)+++ ,
,++, -
new,, 
PaginationInput,, #
(,,# $
paginaAtual,,$ /
,,,/ 0
itensPorPagina,,1 ?
),,? @
)-- 
;-- 
}.. 	
public00 
void00 
Excluir00 
(00 
int00 
id00  "
)00" #
{11 	
_repo22 
.22 
Delete22 
(22 
ObterCliente22 %
(22% &
id22& (
)22( )
)22) *
;22* +
}33 	
public55 
void55 
	Atualizar55 
(55 
int55 !
id55" $
,55$ %
string55& ,
novoNome55- 5
)555 6
{66 	
var77 
cliente77 
=77 
ObterCliente77 &
(77& '
id77' )
)77) *
;77* +
cliente88 
.88 

UpdateInfo88 
(88 
novoNome88 '
)88' (
;88( )
_repo99 
.99 
Update99 
(99 
cliente99  
)99  !
;99! "
}:: 	
private<< 
Cliente<< 
ObterCliente<< $
(<<$ %
int<<% (
id<<) +
)<<+ ,
{== 	
var>> 
cliente>> 
=>> 
_repo>> 
.>>  
GetById>>  '
(>>' (
id>>( *
)>>* +
;>>+ ,
if?? 
(?? 
cliente?? 
==?? 
null?? 
)??  
throw@@ 
new@@ 
NotFoundException@@ +
(@@+ ,
$str@@, D
,@@D E
id@@F H
)@@H I
;@@I J
returnBB 
clienteBB 
;BB 
}CC 	
}DD 
}EE Ω
ND:\Dev\AspNetCoreTestes\Application\EventHandlers\EmailPedidoEnviadoHandler.cs
	namespace 	
Application
 
. 
EventHandlers #
{		 
public

 

class

 %
EmailPedidoEnviadoHandler

 *
:

+ ,
IHandle

- 4
<

4 5#
EmailPedidoEnviadoEvent

5 L
>

L M
{ 
public 
void 
Handle 
( #
EmailPedidoEnviadoEvent 2
args3 7
)7 8
{ 	
Logger 
. 
Log 
( 
$" U
IPeguei o Pedido Enviado dentro do Application!: J√° mandei o email para   a
{a b
argsc g
.g h
Clienteh o
.o p
Nomep t
}u v'
: Fazer alguma coisa aqui.	v ê
"
ê ë
)
ë í
;
í ì
} 	
} 
} ≈

AD:\Dev\AspNetCoreTestes\Application\IClienteApplicationService.cs
	namespace 	
Application
 
{ 
public		 

	interface		 &
IClienteApplicationService		 /
{

 
Cliente 
Obter 
( 
int 
id 
) 
; 
void 
	Adicionar 
( 
string 
nome "
)" #
;# $
PaginatedResults 
< 
Cliente  
>  !
ListarTodos" -
(- .
int. 1
paginaAtual2 =
,= >
int? B
totalPorPaginaC Q
)Q R
;R S
PaginatedResults 
< 
Cliente  
>  !
FiltrarPorNome" 0
(0 1
string1 7
nome8 <
,< =
int> A
paginaAtualB M
,M N
intO R
itensPorPaginaS a
)a b
;b c
void 
Excluir 
( 
int 
id 
) 
; 
void 
	Atualizar 
( 
int 
id 
, 
string %
novoNome& .
). /
;/ 0
} 
} ∑
@D:\Dev\AspNetCoreTestes\Application\IPedidoApplicationService.cs
	namespace 	
Application
 
{ 
public		 

	interface		 %
IPedidoApplicationService		 .
{

 
Pedido 
ObterPedido 
( 
int 
id !
)! "
;" #
void 
AdicionarPedido 
( 
Pedido #
pedido$ *
)* +
;+ ,
IList 
< 
Pedido 
> "
ObterPedidosPorCliente ,
(, -
int- 0
	IdCliente1 :
): ;
;; <
} 
} ˝
AD:\Dev\AspNetCoreTestes\Application\IUsuarioApplicationService.cs
	namespace 	
Application
 
{ 
public 

	interface &
IUsuarioApplicationService /
{ 
Usuario

 
ObterUsuario

 
(

 
int

  
id

! #
)

# $
;

$ %
void 
AdicionarUsuario 
( 
Usuario %
user& *
)* +
;+ ,
} 
} à
?D:\Dev\AspNetCoreTestes\Application\PedidoApplicationService.cs
	namespace 	
Application
 
{		 
public

 

class

 $
PedidoApplicationService

 )
:

* +%
IPedidoApplicationService

, E
{ 
private 
IPedidoRepository !
_repo" '
{( )
get* -
;- .
}/ 0
public $
PedidoApplicationService '
(' (
IPedidoRepository( 9
repo: >
)> ?
{ 	
_repo 
= 
repo 
; 
} 	
public 
Pedido 
ObterPedido !
(! "
int" %
id& (
)( )
{ 	
return 
_repo 
. 
GetById  
(  !
id! #
)# $
;$ %
} 	
public 
void 
AdicionarPedido #
(# $
Pedido$ *
pedido+ 1
)1 2
{ 	
_repo 
. 
Insert 
( 
pedido 
)  
;  !
var 
PedidoEvent 
= 
new !
PedidoCriadoEvent" 3
(3 4
pedido4 :
): ;
;; <
DomainEvents 
. 
Raise 
( 
PedidoEvent *
)* +
;+ ,
} 	
public 
IList 
< 
Pedido 
> "
ObterPedidosPorCliente 3
(3 4
int4 7
	IdCliente8 A
)A B
{   	
return!! 
_repo!! 
.!! "
ObterPedidosPorCliente!! /
(!!/ 0
	IdCliente!!0 9
)!!9 :
;!!: ;
}"" 	
}## 
}$$ Ù
@D:\Dev\AspNetCoreTestes\Application\UsuarioApplicationService.cs
	namespace 	
Application
 
{ 
public		 

class		 %
UsuarioApplicationService		 *
:		+ ,&
IUsuarioApplicationService		- G
{

 
private 
IUsuarioRepository "
_repo# (
{) *
get+ .
;. /
}0 1
public %
UsuarioApplicationService (
(( )
IUsuarioRepository) ;
repo< @
)@ A
{ 	
_repo 
= 
repo 
; 
} 	
public 
Usuario 
ObterUsuario #
(# $
int$ '
id( *
)* +
{ 	
return 
_repo 
. 
GetById  
(  !
id! #
)# $
;$ %
} 	
public 
void 
AdicionarUsuario $
($ %
Usuario% ,
usuario- 4
)4 5
{ 	
_repo 
. 
Insert 
( 
usuario  
)  !
;! "
var 
	userEvent 
= 
new 
UsuarioCriadoEvent  2
(2 3
usuario3 :
): ;
;; <
DomainEvents 
. 
Register !
<! "
UsuarioCriadoEvent" 4
>4 5
(5 6
(6 7
args7 ;
); <
=>= ?
{ 
Logger 
. 
Log 
( 
$str %
+& '
args( ,
., -
Usuario- 4
.4 5
Nome5 9
)9 :
;: ;
}   
)   
;   
DomainEvents"" 
."" 
Raise"" 
("" 
	userEvent"" (
)""( )
;"") *
}## 	
}$$ 
}%% 