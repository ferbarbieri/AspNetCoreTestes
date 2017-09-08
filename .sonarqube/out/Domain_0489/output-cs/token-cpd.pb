†
5D:\Dev\AspNetCoreTestes\Domain\Enums\PerfilUsuario.cs
	namespace 	
Domain
 
. 
Enums 
{ 
public 

enum 
PerfilUsuario 
: 
byte  $
{ 
Usuarios 
= 
$num 
, 
Administradores 
= 
$num 
} 
} ∑
4D:\Dev\AspNetCoreTestes\Domain\Enums\TenantStatus.cs
	namespace 	
Domain
 
. 
Enums 
{ 
public

 

enum

 
TenantStatus

 
:

 
byte

 #
{ )
AguardandoConfirmacaoRegistro %
=& '
$num( )
,) *
	AtivoDemo 
= 
$num 
, 
Ativo 
= 
$num 
, 
	Bloqueado 
= 
$num 
} 
} ê
2D:\Dev\AspNetCoreTestes\Domain\Enums\TenantType.cs
	namespace 	
Domain
 
. 
Enums 
{ 
public

 

enum

 

TenantType

 
:

 
byte

 !
{ 
Normal 
= 
$num 
, 
Premium 
= 
$num 
} 
} Ú
ID:\Dev\AspNetCoreTestes\Domain\EventHandlers\ClienteCriadoEventHandler.cs
	namespace 	
Domain
 
. 
EventHandlers 
{ 
public 

class %
ClienteCriadoEventHandler *
:+ ,
IHandle- 4
<4 5
ClienteCriadoEvent5 G
>G H
{ 
public		 
void		 
Handle		 
(		 
ClienteCriadoEvent		 -
args		. 2
)		2 3
{

 	
Logger 
. 
Log 
( 
$" >
2Peguei o evento de Cliente Criado. O cliente √© o  J
{J K
argsK O
.O P
ClienteP W
.W X
NomeX \
}\ ]
.] ^
"^ _
)_ `
;` a
} 	
} 
} ≈

ID:\Dev\AspNetCoreTestes\Domain\EventHandlers\PedidoCreatedEventHandler.cs
	namespace 	
Domain
 
. 
EventHandlers 
{ 
public 

class %
PedidoCreatedEventHandler *
:+ ,
IHandle- 4
<4 5
PedidoCriadoEvent5 F
>F G
{ 
public 
void 
Handle 
( 
PedidoCriadoEvent ,
args- 1
)1 2
{		 	
Logger

 
.

 
Log

 
(

 
$"

 :
.Peguei o Pedido Created Event. Pedido Numero: 

 G
{

G H
args

I M
.

M N
Pedido

N T
.

T U
Id

U W
}

X Y*
, enviar email para o usuario 

Y w
{

w x
args

y }
.

} ~
Pedido	

~ Ñ
.


Ñ Ö
Cliente


Ö å
.


å ç
Nome


ç ë
}


í ì
"


ì î
)


î ï
;


ï ñ
DomainEvents 
. 
Raise 
( 
new "#
EmailPedidoEnviadoEvent# :
(: ;
args; ?
.? @
Pedido@ F
.F G
ClienteG N
)N O
)O P
;P Q
} 	
} 
} ≠
OD:\Dev\AspNetCoreTestes\Domain\EventHandlers\UsuarioAlterouEmailEventHandler.cs
	namespace 	
Domain
 
. 
EventHandlers 
{ 
public 

class +
UsuarioAlterouEmailEventHandler 0
:1 2
IHandle3 :
<: ;$
UsuarioAlterouEmailEvent; S
>S T
{ 
public		 
void		 
Handle		 
(		 $
UsuarioAlterouEmailEvent		 3
args		4 8
)		8 9
{

 	
Logger 
. 
Log 
( 
$" 

O usuario  #
{# $
args$ (
.( )
Usuario) 0
.0 1
Nome1 5
}5 6-
! agora √© alterou seu email para 6 V
{V W
argsW [
.[ \
Usuario\ c
.c d
Emaild i
}i j-
 . Enviar email de confirma√ß√£o.	j à
"
à â
)
â ä
;
ä ã
} 	
} 
} Ú
ID:\Dev\AspNetCoreTestes\Domain\EventHandlers\UsuarioCriadoEventHandler.cs
	namespace 	
Domain
 
. 
EventHandlers 
{ 
public 

class %
UsuarioCriadoEventHandler *
:+ ,
IHandle- 4
<4 5
UsuarioCriadoEvent5 G
>G H
{ 
public		 
void		 
Handle		 
(		 
UsuarioCriadoEvent		 -
args		. 2
)		2 3
{

 	
Logger 
. 
Log 
( 
$" >
2Peguei o evento de Usuario Criado. O usuario √© o  J
{J K
argsK O
.O P
UsuarioP W
.W X
NomeX \
}\ ]
.] ^
"^ _
)_ `
;` a
} 	
} 
} œ
]D:\Dev\AspNetCoreTestes\Domain\EventHandlers\UsuarioPromovidoParaAdmnistradorEventHandlery.cs
	namespace 	
Domain
 
. 
EventHandlers 
{ 
public 

class 8
,UsuarioPromovidoParaAdmnistradorEventHandler =
:> ?
IHandle@ G
<G H2
&UsuarioPromovidoParaAdministradorEventH n
>n o
{ 
public		 
void		 
Handle		 
(		 2
&UsuarioPromovidoParaAdministradorEvent		 A
args		B F
)		F G
{

 	
Logger 
. 
Log 
( 
$" 

O usuario  #
{# $
args$ (
.( )
Usuario) 0
.0 1
Nome1 5
}5 6C
7 agora √© administrador. Aqui posso fazer alguma coisa.6 l
"l m
)m n
;n o
} 	
} 
} Ø
;D:\Dev\AspNetCoreTestes\Domain\Events\ClienteCriadoEvent.cs
	namespace 	
Domain
 
. 
Events 
{ 
public 

class 
ClienteCriadoEvent #
:$ %
IDomainEvent& 2
{ 
public 
Cliente 
Cliente 
{  
get! $
;$ %
set& )
;) *
}+ ,
public

 
ClienteCriadoEvent

 !
(

! "
Cliente

" )
cliente

* 1
)

1 2
{ 	
Cliente 
= 
cliente 
; 
} 	
} 
} û
@D:\Dev\AspNetCoreTestes\Domain\Events\EmailPedidoEnviadoEvent.cs
	namespace 	
Domain
 
. 
Events 
{ 
public 

class #
EmailPedidoEnviadoEvent (
:) *
IDomainEvent+ 7
{ 
public #
EmailPedidoEnviadoEvent &
(& '
Cliente' .
cliente/ 6
)6 7
{		 	
Cliente

 
=

 
cliente

 
;

 
} 	
public 
Cliente 
Cliente 
{  
get! $
;$ %
}& '
} 
} ª
:D:\Dev\AspNetCoreTestes\Domain\Events\PedidoCriadoEvent.cs
	namespace 	
Domain
 
. 
Events 
{ 
public 

class 
PedidoCriadoEvent "
:# $
IDomainEvent% 1
{ 
public		 
Pedido		 
Pedido		 
{		 
get		 "
;		" #
private		$ +
set		, /
;		/ 0
}		1 2
public 
PedidoCriadoEvent  
(  !
Pedido! '
pedido( .
). /
{ 	
Pedido 
= 
pedido 
; 
} 	
} 
} ¡
AD:\Dev\AspNetCoreTestes\Domain\Events\UsuarioAlterouEmailEvent.cs
	namespace 	
Domain
 
. 
Events 
{ 
public 

class $
UsuarioAlterouEmailEvent )
:* +
IDomainEvent, 8
{ 
public 
Usuario 
Usuario 
{  
get! $
;$ %
set& )
;) *
}+ ,
public

 $
UsuarioAlterouEmailEvent

 '
(

' (
Usuario

( /
usuario

0 7
)

7 8
{ 	
Usuario 
= 
usuario 
; 
} 	
} 
} Ø
;D:\Dev\AspNetCoreTestes\Domain\Events\UsuarioCriadoEvent.cs
	namespace 	
Domain
 
. 
Events 
{ 
public 

class 
UsuarioCriadoEvent #
:$ %
IDomainEvent& 2
{ 
public 
Usuario 
Usuario 
{  
get! $
;$ %
set& )
;) *
}+ ,
public

 
UsuarioCriadoEvent

 !
(

! "
Usuario

" )
usuario

* 1
)

1 2
{ 	
Usuario 
= 
usuario 
; 
} 	
} 
} Î
OD:\Dev\AspNetCoreTestes\Domain\Events\UsuarioPromovidoParaAdministradorEvent.cs
	namespace 	
Domain
 
. 
Events 
{ 
public 

class 2
&UsuarioPromovidoParaAdministradorEvent 7
:8 9
IDomainEvent: F
{ 
public 
Usuario 
Usuario 
{  
get! $
;$ %
set& )
;) *
}+ ,
public

 2
&UsuarioPromovidoParaAdministradorEvent

 5
(

5 6
Usuario

6 =
usuario

> E
)

E F
{ 	
Usuario 
= 
usuario 
; 
} 	
} 
} É
0D:\Dev\AspNetCoreTestes\Domain\Models\Cliente.cs
	namespace 	
Domain
 
. 
Models 
{ 
public 

class 
Cliente 
: 
Entity !
{ 
public 
string 
Nome 
{ 
get  
;  !
private" )
set* -
;- .
}/ 0
private

 
Cliente

 
(

 
)

 
{ 	
} 	
public 
Cliente 
( 
string 
nome "
)" #
{ 	
new 
Guard 
( 
) 
. 
NotNullOrEmpty 
(  
$str  &
,& '
nome( ,
), -
. 
Validate 
( 
) 
; 
Nome 
= 
nome 
; 
} 	
public 
void 

UpdateInfo 
( 
string %
novoNome& .
). /
{ 	
new 
Guard 
( 
) 
. 
NotNullOrEmpty 
(  
$str  &
,& '
novoNome( 0
)0 1
. 
Validate 
( 
) 
; 
Nome 
= 
novoNome 
; 
} 	
} 
}   § 
/D:\Dev\AspNetCoreTestes\Domain\Models\Entity.cs
	namespace 	
Domain
 
. 
Models 
{ 
public 

abstract 
class 
Entity  
:! "

IEquatable# -
<- .
Entity. 4
>4 5
{ 
public

 
int

 
Id

 
{

 
get

 
;

 
	protected

 &
set

' *
;

* +
}

, -
public 
bool 
Equals 
( 
Entity !
obj" %
)% &
{ 	
var 
	compareTo 
= 
obj 
as  "
Entity# )
;) *
if 
( 
ReferenceEquals 
(  
this  $
,$ %
	compareTo& /
)/ 0
)0 1
return2 8
true9 =
;= >
if 
( 
ReferenceEquals 
(  
null  $
,$ %
	compareTo& /
)/ 0
)0 1
return2 8
false9 >
;> ?
return 
Id 
. 
Equals 
( 
	compareTo &
.& '
Id' )
)) *
;* +
} 	
public 
override 
bool 
Equals #
(# $
object$ *
obj+ .
). /
{ 	
if 
( 
! 
( 
obj 
is 
Entity 
)  
)  !
return 
false 
; 
return 
Equals 
( 
obj 
as  
Entity! '
)' (
;( )
} 	
public 
static 
bool 
operator #
==$ &
(& '
Entity' -
a. /
,/ 0
Entity1 7
b8 9
)9 :
{ 	
if   
(   
ReferenceEquals   
(    
a    !
,  ! "
null  # '
)  ' (
&&  ) +
ReferenceEquals  , ;
(  ; <
b  < =
,  = >
null  ? C
)  C D
)  D E
return!! 
true!! 
;!! 
if## 
(## 
ReferenceEquals## 
(##  
a##  !
,##! "
null### '
)##' (
||##) +
ReferenceEquals##, ;
(##; <
b##< =
,##= >
null##? C
)##C D
)##D E
return$$ 
false$$ 
;$$ 
return&& 
a&& 
.&& 
Equals&& 
(&& 
b&& 
)&& 
;&& 
}'' 	
public)) 
static)) 
bool)) 
operator)) #
!=))$ &
())& '
Entity))' -
a)). /
,))/ 0
Entity))1 7
b))8 9
)))9 :
{** 	
return++ 
!++ 
(++ 
a++ 
==++ 
b++ 
)++ 
;++ 
},, 	
public.. 
override.. 
int.. 
GetHashCode.. '
(..' (
)..( )
{// 	
return00 
(00 
GetType00 
(00 
)00 
.00 
GetHashCode00 )
(00) *
)00* +
*00, -
$num00. 1
)001 2
+003 4
Id005 7
.007 8
GetHashCode008 C
(00C D
)00D E
;00E F
}11 	
public33 
override33 
string33 
ToString33 '
(33' (
)33( )
{44 	
return55 
GetType55 
(55 
)55 
.55 
Name55 !
+55" #
$str55$ +
+55, -
Id55. 0
+551 2
$str553 6
;556 7
}66 	
}77 
}88 Î
4D:\Dev\AspNetCoreTestes\Domain\Models\ItensPedido.cs
	namespace 	
Domain
 
. 
Models 
{ 
public 

class 
ItensPedido 
{ 
public 
int 
PedidoId 
{ 
get !
;! "
private# *
set+ .
;. /
}0 1
public 
int 
	ProdutoId 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public		 
int		 

Quantidade		 
{		 
get		  #
;		# $
private		% ,
set		- 0
;		0 1
}		2 3
public

 
Produto

 
Produto

 
{

  
get

! $
;

$ %
private

& -
set

. 1
;

1 2
}

3 4
public 
decimal 

PrecoTotal !
=>" $

Quantidade% /
*0 1
Produto2 9
.9 :
Preco: ?
;? @
private 
ItensPedido 
( 
) 
{ 	
} 	
public 
ItensPedido 
( 
Pedido !
pedido" (
,( )
Produto* 1
produto2 9
,9 :
int; >

quantidade? I
)I J
{ 	
new 
Guard 
( 
) 
. 
NotNull 
( 
$str !
,! "
pedido# )
)) *
. 
NotNull 
( 
$str "
," #
produto$ +
)+ ,
. 
GreaterThan 
( 
$str )
,) *

quantidade+ 5
,5 6
$num7 8
)8 9
. 
Validate 
( 
) 
; 
	ProdutoId 
= 
produto 
.  
Id  "
;" #
Produto 
= 
produto 
; 
PedidoId 
= 
pedido 
. 
Id  
;  !

Quantidade 
= 

quantidade #
;# $
} 	
}   
}$$ £
/D:\Dev\AspNetCoreTestes\Domain\Models\Pedido.cs
	namespace 	
Domain
 
. 
Models 
{ 
public 

class 
Pedido 
: 
Entity  
{ 
public		 
Cliente		 
Cliente		 
{		  
get		! $
;		$ %
private		& -
set		. 1
;		1 2
}		3 4
public

 
IList

 
<

 
ItensPedido

  
>

  !
Itens

" '
{

( )
get

* -
;

- .
private

/ 6
set

7 :
;

: ;
}

< =
public 
decimal 
TotalPedido "
=># %
Itens& +
.+ ,
Sum, /
(/ 0
i0 1
=>2 4
i5 6
.6 7

PrecoTotal7 A
)A B
;B C
private 
Pedido 
( 
) 
{ 	
} 	
public 
Pedido 
( 
Cliente 
cliente %
,% &
IList' ,
<, -
ItensPedido- 8
>8 9
itens: ?
)? @
{ 	
new 
Guard 
( 
) 
. 
NotNull 
( 
$str "
," #
cliente$ +
)+ ,
. 
HasMoreThanOne 
(  
$str  '
,' (
itens) .
). /
. 
Validate 
( 
) 
; 
Cliente 
= 
cliente 
; 
Itens 
= 
itens 
; 
} 	
} 
}  
0D:\Dev\AspNetCoreTestes\Domain\Models\Produto.cs
	namespace 	
Domain
 
. 
Models 
{ 
public 

class 
Produto 
: 
Entity !
{ 
public 
string 
Nome 
{ 
get  
;  !
private" )
set* -
;- .
}/ 0
public 
decimal 
Preco 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
private

 
Produto

 
(

 
)

 
{ 	
} 	
public 
Produto 
( 
string 
nome "
," #
decimal$ +
preco, 1
)1 2
{ 	
new 
Guard 
( 
) 
. 
NotNullOrEmpty 
(  
$str  &
,& '
nome( ,
), -
. 
GreaterThan 
( 
$str $
,$ %
preco& +
,+ ,
$num- .
). /
. 
Validate 
( 
) 
; 
Nome 
= 
nome 
; 
Preco 
= 
preco 
; 
} 	
} 
} ˚$
/D:\Dev\AspNetCoreTestes\Domain\Models\Tenant.cs
	namespace 	
Domain
 
. 
Models 
{ 
public		 

class		 
Tenant		 
:		 
Entity		  
{

 
public 
string 
Nome 
{ 
get  
;  !
private" )
set* -
;- .
}/ 0
public 
string 
Dominio 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public 
TenantStatus 
Status "
{# $
get% (
;( )
private* 1
set2 5
;5 6
}7 8
public 

TenantType 
Tipo 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public 
string 
NomeAdministrador '
{( )
get* -
;- .
private/ 6
set7 :
;: ;
}< =
public 
string 
EmailAdministrador (
{) *
get+ .
;. /
private0 7
set8 ;
;; <
}= >
private 
Tenant 
( 
) 
{ 	
} 	
public 
Tenant 
( 
string 
nome !
,! "
string# )
dominio* 1
,1 2
string3 9
nomeAdministrador: K
,K L
stringM S
emailAdministradorT f
)f g
{ 	
new 
Guard 
( 
) 
. 
NotNullOrEmpty 
(  
$str  &
,& '
nome( ,
), -
. 
NotNullOrEmpty 
(  
$str  )
,) *
dominio+ 2
)2 3
. 
NotNullOrEmpty 
(  
$str  7
,7 8
nomeAdministrador9 J
)J K
. 

ValidEmail 
( 
$str 4
,4 5
emailAdministrador6 H
)H I
. 
Validate 
( 
) 
; 
Nome 
= 
nome 
; 
Dominio   
=   
dominio   
;   
Status!! 
=!! 
TenantStatus!! !
.!!! ")
AguardandoConfirmacaoRegistro!!" ?
;!!? @
Tipo"" 
="" 

TenantType"" 
."" 
Normal"" $
;""$ %
NomeAdministrador## 
=## 
nomeAdministrador##  1
;##1 2
EmailAdministrador$$ 
=$$  
emailAdministrador$$! 3
;$$3 4
}%% 	
public'' 
void''  
AlterarAdministrador'' (
(''( )
string'') /
nome''0 4
,''4 5
string''6 <
email''= B
)''B C
{(( 	
new)) 
Guard)) 
()) 
))) 
.** 
NotNullOrEmpty** 
(**  
$str**  &
,**& '
nome**( ,
)**, -
.++ 

ValidEmail++ 
(++ 
$str++ #
,++# $
email++% *
)++* +
.,, 
Validate,, 
(,, 
),, 
;,, 
NomeAdministrador.. 
=.. 
nome..  $
;..$ %
EmailAdministrador// 
=//  
email//! &
;//& '
}00 	
public22 
void22 
AlterarPlano22  
(22  !

TenantType22! +
tipo22, 0
)220 1
{33 	
Tipo44 
=44 
tipo44 
;44 
}55 	
public77 
void77 
Bloquear77 
(77 
)77 
{88 	
Status99 
=99 
TenantStatus99 !
.99! "
	Bloqueado99" +
;99+ ,
}:: 	
public<< 
void<< 
Desbloquear<< 
(<<  
)<<  !
{== 	
Status>> 
=>> 
TenantStatus>> !
.>>! "
Ativo>>" '
;>>' (
}?? 	
publicAA 
voidAA 
EmailConfirmadoAA #
(AA# $
)AA$ %
{BB 	
StatusCC 
=CC 
TenantStatusCC !
.CC! "
AtivoCC" '
;CC' (
}DD 	
}EE 
}FF •#
0D:\Dev\AspNetCoreTestes\Domain\Models\Usuario.cs
	namespace 	
Domain
 
. 
Models 
{ 
public		 

class		 
Usuario		 
:		 
Entity		 !
{

 
public 
string 
Nome 
{ 
get  
;  !
private" )
set* -
;- .
}/ 0
public 
string 
Email 
{ 
get !
;! "
private# *
set+ .
;. /
}0 1
public 
string 
Senha 
{ 
get !
;! "
private# *
set+ .
;. /
}0 1
public 
PerfilUsuario 
Perfil #
{$ %
get& )
;) *
private+ 2
set3 6
;6 7
}8 9
private 
Usuario 
( 
) 
{ 	
} 	
public 
void %
PromoverParaAdministrador -
(- .
). /
{ 	
Perfil 
= 
PerfilUsuario "
." #
Administradores# 2
;2 3
DomainEvents 
. 
Raise 
( 
new "2
&UsuarioPromovidoParaAdministradorEvent# I
(I J
thisJ N
)N O
)O P
;P Q
} 	
public   
Usuario   
(   
string   
nome   "
,  " #
string  $ *
email  + 0
,  0 1
string  2 8
senha  9 >
)  > ?
{!! 	
new## 
Guard## 
(## 
)## 
.$$ 
ValidPassword$$ "
($$" #
$str$$# *
,$$* +
senha$$, 1
)$$1 2
.%% 
Validate%% 
(%% 
)%% 
;%%  

UpdateInfo'' 
('' 
nome'' 
,'' 
email'' "
,''" #
senha''$ )
)'') *
;''* +
Perfil** 
=** 
PerfilUsuario** "
.**" #
Usuarios**# +
;**+ ,
}++ 	
public-- 
void-- 

UpdateInfo-- 
(-- 
string-- %
nome--& *
,--* +
string--, 2
email--3 8
,--8 9
string--: @
senha--A F
=--G H
null--I M
)--M N
{.. 	
new// 
Guard// 
(// 
)// 
.00 
NotNullOrEmpty00 
(00  
$str00  &
,00& '
nome00( ,
)00, -
.11 

ValidEmail11 
(11 
$str11 #
,11# $
email11% *
)11* +
.22 
Validate22 
(22 
)22 
;22 
if44 
(44 
senha44 
!=44 
null44 
)44 
new55 
Guard55 
(55 
)55 
.66 
ValidPassword66 "
(66" #
$str66# *
,66* +
senha66, 1
)661 2
.77 
Validate77 
(77 
)77 
;77  
bool99 
usuarioAlterouEmail99 $
=99% &
false99' ,
;99, -
if;; 
(;; 
!;; 
string;; 
.;; 
IsNullOrEmpty;; %
(;;% &
Email;;& +
);;+ ,
&&;;- /
Email;;0 5
!=;;6 8
email;;9 >
);;> ?
usuarioAlterouEmail<< #
=<<$ %
true<<& *
;<<* +
Nome>> 
=>> 
nome>> 
;>> 
Email?? 
=?? 
email?? 
;?? 
ifAA 
(AA 
senhaAA 
!=AA 
nullAA 
)AA 
SenhaBB 
=BB 
PasswordHasherBB &
.BB& '
HashBB' +
(BB+ ,
senhaBB, 1
)BB1 2
;BB2 3
ifEE 
(EE 
usuarioAlterouEmailEE #
)EE# $
DomainEventsFF 
.FF 
RaiseFF "
(FF" #
newFF# &$
UsuarioAlterouEmailEventFF' ?
(FF? @
thisFF@ D
)FFD E
)FFE F
;FFF G
}GG 	
}HH 
}II É
ID:\Dev\AspNetCoreTestes\Domain\RepositoryInterfaces\IClienteRepository.cs
	namespace 	
Domain
 
.  
RepositoryInterfaces %
{ 
public 

	interface 
IClienteRepository '
:( )
IRepository* 5
<5 6
Cliente6 =
>= >
{ 
} 
} æ
HD:\Dev\AspNetCoreTestes\Domain\RepositoryInterfaces\IPedidoRepository.cs
	namespace 	
Domain
 
.  
RepositoryInterfaces %
{ 
public 

	interface 
IPedidoRepository &
:' (
IRepository) 4
<4 5
Pedido5 ;
>; <
{ 
IList 
< 
Pedido 
> "
ObterPedidosPorCliente ,
(, -
int- 0
	idCliente1 :
): ;
;; <
}		 
}

 É
ID:\Dev\AspNetCoreTestes\Domain\RepositoryInterfaces\IProdutoRepository.cs
	namespace 	
Domain
 
.  
RepositoryInterfaces %
{ 
public 

	interface 
IProdutoRepository '
:( )
IRepository* 5
<5 6
Produto6 =
>= >
{ 
} 
} ú
BD:\Dev\AspNetCoreTestes\Domain\RepositoryInterfaces\IRepository.cs
	namespace 	
Domain
 
.  
RepositoryInterfaces %
{ 
public		 

	interface		 
IRepository		  
<		  !
TEntity		! (
>		( )
where		* /
TEntity		0 7
:		8 9
Entity		: @
{

 
TEntity 
GetById 
( 
int 
id 
) 
;  
IList 
< 
TEntity 
> 
GetAllBy 
(  

Expression  *
<* +
Func+ /
</ 0
TEntity0 7
,7 8
bool9 =
>= >
>> ?
	predicate@ I
)I J
;J K
PaginatedResults 
< 
TEntity  
>  !
GetAllBy" *
(* +

Expression+ 5
<5 6
Func6 :
<: ;
TEntity; B
,B C
boolD H
>H I
>I J
	predicateK T
,T U
PaginationInputV e
paginationInputf u
)u v
;v w
PaginatedResults 
< 
TEntity  
>  !
GetAll" (
(( )
PaginationInput) 8
paginationInput9 H
)H I
;I J
void 
Update 
( 
TEntity 
entity "
)" #
;# $
void 
Insert 
( 
TEntity 
entity "
)" #
;# $
void 
Delete 
( 
TEntity 
entity "
)" #
;# $
} 
} à
HD:\Dev\AspNetCoreTestes\Domain\RepositoryInterfaces\ITenantRepository.cs
	namespace 	
Domain
 
.  
RepositoryInterfaces %
{ 
public 

	interface 
ITenantRepository &
:' (
IRepository) 4
<4 5
Tenant5 ;
>; <
{		 
Tenant

 
ObterPeloDominio

 
(

  
string

  &
dominio

' .
)

. /
;

/ 0
} 
} Ñ
ID:\Dev\AspNetCoreTestes\Domain\RepositoryInterfaces\IUsuarioRepository.cs
	namespace 	
Domain
 
.  
RepositoryInterfaces %
{ 
public 

	interface 
IUsuarioRepository '
:( )
IRepository* 5
<5 6
Usuario6 =
>= >
{ 
Usuario 

GetByEmail 
( 
string !
email" '
)' (
;( )
} 
}		 Ê
4D:\Dev\AspNetCoreTestes\Domain\ValueObjects\Email.cs
	namespace 	
Domain
 
. 
ValueObjects 
{ 
class 	
Email
 
{ 
} 
} 