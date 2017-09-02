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
DomainEvents&& 
.&& 
Raise&& 
(&& 
	userEvent&& (
)&&( )
;&&) *
}'' 	
public)) 
PaginatedResults)) 
<))  
Cliente))  '
>))' (
ListarTodos))) 4
())4 5
int))5 8
paginaAtual))9 D
,))D E
int))F I
itensPorPagina))J X
)))X Y
{** 	
return++ 
_repo++ 
.++ 
GetAll++ 
(++  
new++  #
PaginationInput++$ 3
(++3 4
paginaAtual++4 ?
,++? @
itensPorPagina++A O
)++O P
)++P Q
;++Q R
},, 	
public.. 
PaginatedResults.. 
<..  
Cliente..  '
>..' (
FiltrarPorNome..) 7
(..7 8
string..8 >
nome..? C
,..C D
int..E H
paginaAtual..I T
,..T U
int..V Y
itensPorPagina..Z h
)..h i
{// 	
return00 
_repo00 
.00 
GetAllBy00 !
(00! "
c11 
=>11 
c11 
.11 
Nome11 
.11 

StartsWith11 &
(11& '
nome11' +
)11+ ,
,11, -
new22 
PaginationInput22 #
(22# $
paginaAtual22$ /
,22/ 0
itensPorPagina221 ?
)22? @
)33 
;33 
}44 	
public66 
void66 
Excluir66 
(66 
int66 
id66  "
)66" #
{77 	
_repo88 
.88 
Delete88 
(88 
ObterCliente88 %
(88% &
id88& (
)88( )
)88) *
;88* +
}99 	
public;; 
void;; 
	Atualizar;; 
(;; 
int;; !
id;;" $
,;;$ %
string;;& ,
novoNome;;- 5
);;5 6
{<< 	
var== 
cliente== 
=== 
ObterCliente== &
(==& '
id==' )
)==) *
;==* +
cliente>> 
.>> 

UpdateInfo>> 
(>> 
novoNome>> '
)>>' (
;>>( )
_repo?? 
.?? 
Update?? 
(?? 
cliente??  
)??  !
;??! "
}@@ 	
privateBB 
ClienteBB 
ObterClienteBB $
(BB$ %
intBB% (
idBB) +
)BB+ ,
{CC 	
varDD 
clienteDD 
=DD 
_repoDD 
.DD  
GetByIdDD  '
(DD' (
idDD( *
)DD* +
;DD+ ,
ifEE 
(EE 
clienteEE 
==EE 
nullEE 
)EE  
throwFF 
newFF 
NotFoundExceptionFF +
(FF+ ,
$strFF, D
,FFD E
idFFF H
)FFH I
;FFI J
returnHH 
clienteHH 
;HH 
}II 	
}JJ 
}KK Ω
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