ä$
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
public 
Cliente 
Obter 
( 
int  
id! #
)# $
{ 	
return 
ObterCliente 
(  
id  "
)" #
;# $
} 	
public 
PaginatedResults 
<  
Cliente  '
>' (
ListarTodos) 4
(4 5
int5 8
paginaAtual9 D
,D E
intF I
totalPorPaginaJ X
)X Y
{ 	
return 
_repo 
. 
GetAll 
(  
new  #
PaginationInput$ 3
(3 4
paginaAtual4 ?
,? @
totalPorPaginaA O
)O P
)P Q
;Q R
} 	
public   
PaginatedResults   
<    
Cliente    '
>  ' (
FiltrarPorNome  ) 7
(  7 8
string  8 >
nome  ? C
,  C D
int  E H
paginaAtual  I T
,  T U
int  V Y
totalPorPagina  Z h
)  h i
{!! 	
return"" 
_repo"" 
."" 
GetAllBy"" !
(""! "
c## 
=>## 
c## 
.## 
Nome## 
.## 

StartsWith## &
(##& '
nome##' +
)##+ ,
,##, -
new$$ 
PaginationInput$$ #
($$# $
paginaAtual$$$ /
,$$/ 0
totalPorPagina$$1 ?
)$$? @
)%% 
;%% 
}&& 	
public,, 
void,, 
	Adicionar,, 
(,, 
ClienteInput,, *
cliente,,+ 2
),,2 3
{-- 	
var.. 
c.. 
=.. 
new.. 
Cliente.. 
(..  
cliente..  '
...' (
Nome..( ,
).., -
;..- .
_repo// 
.// 
Insert// 
(// 
c// 
)// 
;// 
var11 
	userEvent11 
=11 
new11 
ClienteCriadoEvent11  2
(112 3
c113 4
)114 5
;115 6
DomainEvents33 
.33 
Raise33 
(33 
	userEvent33 (
)33( )
;33) *
}44 	
public77 
void77 
Excluir77 
(77 
int77 
id77  "
)77" #
{88 	
_repo99 
.99 
Delete99 
(99 
ObterCliente99 %
(99% &
id99& (
)99( )
)99) *
;99* +
}:: 	
public<< 
void<< 
	Atualizar<< 
(<< 
int<< !
id<<" $
,<<$ %
ClienteInput<<& 2
cliente<<3 :
)<<: ;
{== 	
var>> 
c>> 
=>> 
ObterCliente>>  
(>>  !
id>>! #
)>># $
;>>$ %
c?? 
.?? 

UpdateInfo?? 
(?? 
cliente??  
.??  !
Nome??! %
)??% &
;??& '
_repo@@ 
.@@ 
Update@@ 
(@@ 
c@@ 
)@@ 
;@@ 
}AA 	
privateEE 
ClienteEE 
ObterClienteEE $
(EE$ %
intEE% (
idEE) +
)EE+ ,
{FF 	
varGG 
clienteGG 
=GG 
_repoGG 
.GG  
GetByIdGG  '
(GG' (
idGG( *
)GG* +
;GG+ ,
ifHH 
(HH 
clienteHH 
==HH 
nullHH 
)HH  
throwII 
newII 
NotFoundExceptionII +
(II+ ,
$strII, D
,IID E
idIIF H
)IIH I
;III J
returnKK 
clienteKK 
;KK 
}LL 	
}MM 
}NN Ω
ND:\Dev\AspNetCoreTestes\Application\EventHandlers\EmailPedidoEnviadoHandler.cs
	namespace 	
Application
 
. 
EventHandlers #
{ 
public 

class %
EmailPedidoEnviadoHandler *
:+ ,
IHandle- 4
<4 5#
EmailPedidoEnviadoEvent5 L
>L M
{ 
public 
void 
Handle 
( #
EmailPedidoEnviadoEvent 2
args3 7
)7 8
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
 U
IPeguei o Pedido Enviado dentro do Application!: J√° mandei o email para  

 a
{

a b
args

c g
.

g h
Cliente

h o
.

o p
Nome

p t
}

u v'
: Fazer alguma coisa aqui.	

v ê
"


ê ë
)


ë í
;


í ì
} 	
} 
} µ
9D:\Dev\AspNetCoreTestes\Application\Input\ClienteInput.cs
	namespace 	
Application
 
. 
Input 
{ 
public 

class 
ClienteInput 
{ 
public 
string 
Nome 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
} 
} Œ
9D:\Dev\AspNetCoreTestes\Application\Input\UsuarioInput.cs
	namespace 	
Application
 
. 
Input 
{ 
public 

class 
UsuarioInput 
{ 
public 
string 
Nome 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Senha 
{ 
get !
;! "
set# &
;& '
}( )
} 
} Ö
LD:\Dev\AspNetCoreTestes\Application\Interfaces\IClienteApplicationService.cs
	namespace 	
Application
 
. 

Interfaces  
{ 
public 

	interface &
IClienteApplicationService /
{ 
Cliente		 
Obter		 
(		 
int		 
id		 
)		 
;		 
void 
	Adicionar 
( 
ClienteInput #
cliente$ +
)+ ,
;, -
PaginatedResults 
< 
Cliente  
>  !
ListarTodos" -
(- .
int. 1
paginaAtual2 =
,= >
int? B
totalPorPaginaC Q
)Q R
;R S
PaginatedResults 
< 
Cliente  
>  !
FiltrarPorNome" 0
(0 1
string1 7
nome8 <
,< =
int> A
paginaAtualB M
,M N
intO R
totalPorPaginaS a
)a b
;b c
void 
Excluir 
( 
int 
id 
) 
; 
void 
	Atualizar 
( 
int 
id 
, 
ClienteInput +
cliente, 3
)3 4
;4 5
} 
} ﬁ
JD:\Dev\AspNetCoreTestes\Application\Interfaces\ILoginApplicationService.cs
	namespace 	
Application
 
. 

Interfaces  
{ 
public 

	interface $
ILoginApplicationService -
{		 
Usuario

 
Login

 
(

 
string

 
usuario

 $
,

$ %
string

& ,
senha

- 2
)

2 3
;

3 4
} 
} È
KD:\Dev\AspNetCoreTestes\Application\Interfaces\IPedidoApplicationService.cs
	namespace 	
Application
 
. 

Interfaces  
{ 
public 

	interface %
IPedidoApplicationService .
{ 
Pedido		 
ObterPedido		 
(		 
int		 
id		 !
)		! "
;		" #
void 
AdicionarPedido 
( 
Pedido #
pedido$ *
)* +
;+ ,
IList 
< 
Pedido 
> "
ObterPedidosPorCliente ,
(, -
int- 0
	IdCliente1 :
): ;
;; <
} 
} ä
LD:\Dev\AspNetCoreTestes\Application\Interfaces\IUsuarioApplicationService.cs
	namespace 	
Application
 
. 

Interfaces  
{ 
public 

	interface &
IUsuarioApplicationService /
{		 
UsuarioViewModel

 
Obter

 
(

 
int

 "
id

# %
)

% &
;

& '
void 
	Adicionar 
( 
UsuarioInput #
input$ )
)) *
;* +
void 
	Atualizar 
( 
int 
id 
, 
UsuarioInput +
input, 1
)1 2
;2 3
void 
Excluir 
( 
int 
id 
) 
; 
PaginatedResults 
< 
Usuario  
>  !
ListarTodos" -
(- .
int. 1
paginaAtual2 =
,= >
int? B
totalPorPaginaC Q
)Q R
;R S
PaginatedResults 
< 
Usuario  
>  !
FiltrarPorNome" 0
(0 1
string1 7
nome8 <
,< =
int> A
paginaAtualB M
,M N
intO R
totalPorPaginaS a
)a b
;b c
} 
} Ú
>D:\Dev\AspNetCoreTestes\Application\LoginApplicationService.cs
	namespace 	
Application
 
{ 
public 

class #
LoginApplicationService (
:) *$
ILoginApplicationService+ C
{ 
private 
IConfigurationRoot "
_config# *
;* +
private 
readonly 
ITenantRepository *
_tenantRepository+ <
;< =
public #
LoginApplicationService &
(& '
IConfigurationRoot 
config %
,% &
ITenantRepository 
tenantRepository .
). /
{ 	
_config 
= 
config 
; 
_tenantRepository 
= 
tenantRepository  0
;0 1
} 	
public&& 
Usuario&& 
Login&& 
(&& 
string&& #
email&&$ )
,&&) *
string&&+ 1
password&&2 :
)&&: ;
{'' 	
var)) 
dominio)) 
=)) 
email)) 
.))  
Split))  %
())% &
$char))& )
)))) *
[))* +
$num))+ ,
])), -
;))- .
var++ 
tenant++ 
=++ 
_tenantRepository++ *
.++* +
ObterPeloDominio+++ ;
(++; <
dominio++< C
)++C D
;++D E
if,, 
(,, 
tenant,, 
==,, 
null,, 
||-- 
tenant-- 
.-- 
Status--  
==--! #
TenantStatus--$ 0
.--0 1
	Bloqueado--1 :
||.. 
tenant.. 
... 
Status..  
==..! #
TenantStatus..$ 0
...0 1)
AguardandoConfirmacaoRegistro..1 N
)..N O
{// 
return00 
null00 
;00 
}11 
var88 
cnn88 
=88 
_config88 
.88 
GetConnectionString88 1
(881 2
$str882 :
)88: ;
;88; <
cnn99 
=99 
cnn99 
.99 
Replace99 
(99 
$str99 (
,99( )
dominio99* 1
)991 2
;992 3
var;; 
builder;; 
=;; 
new;; #
DbContextOptionsBuilder;; 5
<;;5 6
AdminContext;;6 B
>;;B C
(;;C D
);;D E
;;;E F
builder<< 
.<< 
UseSqlServer<<  
(<<  !
cnn<<! $
)<<$ %
;<<% &
var== 
ctx== 
=== 
new== 
AdminContext== &
(==& '
builder==' .
.==. /
Options==/ 6
)==6 7
;==7 8
var?? 
repo?? 
=?? 
new?? 
UsuarioRepository?? ,
(??, -
ctx??- 0
)??0 1
;??1 2
varCC 
userCC 
=CC 
repoCC 
.CC 

GetByEmailCC &
(CC& '
emailCC' ,
)CC, -
;CC- .
ifFF 
(FF 
userFF 
!=FF 
nullFF 
&&FF 
PasswordHasherFF  .
.FF. /
VerifyFF/ 5
(FF5 6
passwordFF6 >
,FF> ?
userFF@ D
.FFD E
SenhaFFE J
)FFJ K
)FFK L
{GG 
returnHH 
userHH 
;HH 
}II 
returnKK 
nullKK 
;KK 
}LL 	
}NN 
}OO „
ID:\Dev\AspNetCoreTestes\Application\Mappings\ApplicationMappingProfile.cs
	namespace 	
Application
 
. 
Mappings 
{ 
public 

class %
ApplicationMappingProfile *
:+ ,
Profile- 4
{ 
public		 %
ApplicationMappingProfile		 (
(		( )
)		) *
{

 	
	CreateMap 
< 
Usuario 
, 
UsuarioViewModel /
>/ 0
(0 1
)1 2
;2 3
} 	
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
public 
Pedido 
ObterPedido !
(! "
int" %
id& (
)( )
{ 	
return 
_repo 
. 
GetById  
(  !
id! #
)# $
;$ %
} 	
public 
IList 
< 
Pedido 
> "
ObterPedidosPorCliente 3
(3 4
int4 7
	IdCliente8 A
)A B
{ 	
return 
_repo 
. "
ObterPedidosPorCliente /
(/ 0
	IdCliente0 9
)9 :
;: ;
} 	
public"" 
void"" 
AdicionarPedido"" #
(""# $
Pedido""$ *
pedido""+ 1
)""1 2
{## 	
_repo$$ 
.$$ 
Insert$$ 
($$ 
pedido$$ 
)$$  
;$$  !
var&& 
PedidoEvent&& 
=&& 
new&& !
PedidoCriadoEvent&&" 3
(&&3 4
pedido&&4 :
)&&: ;
;&&; <
DomainEvents'' 
.'' 
Raise'' 
('' 
PedidoEvent'' *
)''* +
;''+ ,
}(( 	
},, 
}-- É.
@D:\Dev\AspNetCoreTestes\Application\UsuarioApplicationService.cs
	namespace 	
Application
 
{ 
public 

class %
UsuarioApplicationService *
:+ ,&
IUsuarioApplicationService- G
{ 
private 
IUsuarioRepository "
_repo# (
{) *
get+ .
;. /
}0 1
private 
IMapper 
_mapper 
;  
private 
IConfigurationRoot "
_config# *
;* +
public %
UsuarioApplicationService (
(( )
IUsuarioRepository 
repo #
,# $
IMapper 
mapper 
, 
IConfigurationRoot 
config %
)% &
{ 	
_repo 
= 
repo 
; 
_mapper 
= 
mapper 
; 
_config 
= 
config 
; 
} 	
public"" 
PaginatedResults"" 
<""  
Usuario""  '
>""' (
ListarTodos"") 4
(""4 5
int""5 8
paginaAtual""9 D
,""D E
int""F I
totalPorPagina""J X
)""X Y
{## 	
return$$ 
_repo$$ 
.$$ 
GetAll$$ 
($$  
new$$  #
PaginationInput$$$ 3
($$3 4
paginaAtual$$4 ?
,$$? @
totalPorPagina$$A O
)$$O P
)$$P Q
;$$Q R
}%% 	
public'' 
PaginatedResults'' 
<''  
Usuario''  '
>''' (
FiltrarPorNome'') 7
(''7 8
string''8 >
nome''? C
,''C D
int''E H
paginaAtual''I T
,''T U
int''V Y
totalPorPagina''Z h
)''h i
{(( 	
return)) 
_repo)) 
.)) 
GetAllBy)) !
())! "
c** 
=>** 
c** 
.** 
Nome** 
.** 

StartsWith** $
(**$ %
nome**% )
)**) *
,*** +
new++ 
PaginationInput++ #
(++# $
paginaAtual++$ /
,++/ 0
totalPorPagina++1 ?
)++? @
)++@ A
;++A B
},, 	
public// 
UsuarioViewModel// 
Obter//  %
(//% &
int//& )
id//* ,
)//, -
{00 	
return11 
_mapper11 
.11 
Map11 
<11 
UsuarioViewModel11 /
>11/ 0
(110 1
ObterUsuario111 =
(11= >
id11> @
)11@ A
)11A B
;11B C
}22 	
public88 
void88 
	Adicionar88 
(88 
UsuarioInput88 *
input88+ 0
)880 1
{99 	
if:: 
(:: 
_repo:: 
.:: 

GetByEmail:: 
(::  
input::  %
.::% &
Email::& +
)::+ ,
!=::- /
null::0 4
)::4 5
{;; 
throw<< 
new<< %
FieldsValidationException<< 3
(<<3 4
$str<<4 R
)<<R S
;<<S T
}== 
var?? 
usuario?? 
=?? 
new?? 
Usuario?? %
(??% &
input??& +
.??+ ,
Nome??, 0
,??0 1
input??2 7
.??7 8
Email??8 =
,??= >
input??? D
.??D E
Senha??E J
)??J K
;??K L
_repo@@ 
.@@ 
Insert@@ 
(@@ 
usuario@@  
)@@  !
;@@! "
varBB 
	userEventBB 
=BB 
newBB 
UsuarioCriadoEventBB  2
(BB2 3
usuarioBB3 :
)BB: ;
;BB; <
DomainEventsDD 
.DD 
RaiseDD 
(DD 
	userEventDD (
)DD( )
;DD) *
}EE 	
publicGG 
voidGG 
ExcluirGG 
(GG 
intGG 
idGG  "
)GG" #
{HH 	
_repoII 
.II 
DeleteII 
(II 
ObterUsuarioII %
(II% &
idII& (
)II( )
)II) *
;II* +
}JJ 	
publicLL 
voidLL 
	AtualizarLL 
(LL 
intLL !
idLL" $
,LL$ %
UsuarioInputLL& 2
inputLL3 8
)LL8 9
{MM 	
varNN 
usuarioNN 
=NN 
ObterUsuarioNN &
(NN& '
idNN' )
)NN) *
;NN* +
usuarioOO 
.OO 

UpdateInfoOO 
(OO 
inputOO $
.OO$ %
NomeOO% )
,OO) *
inputOO+ 0
.OO0 1
EmailOO1 6
,OO6 7
inputOO8 =
.OO= >
SenhaOO> C
)OOC D
;OOD E
_repoPP 
.PP 
UpdatePP 
(PP 
usuarioPP  
)PP  !
;PP! "
}QQ 	
privateUU 
UsuarioUU 
ObterUsuarioUU $
(UU$ %
intUU% (
idUU) +
)UU+ ,
{VV 	
varWW 
usuarioWW 
=WW 
_repoWW 
.WW  
GetByIdWW  '
(WW' (
idWW( *
)WW* +
;WW+ ,
ifXX 
(XX 
usuarioXX 
==XX 
nullXX 
)XX  
throwYY 
newYY 
NotFoundExceptionYY +
(YY+ ,
$strYY, D
,YYD E
idYYF H
)YYH I
;YYI J
return[[ 
usuario[[ 
;[[ 
}\\ 	
}]] 
}^^ Ù
BD:\Dev\AspNetCoreTestes\Application\ViewModels\UsuarioViewModel.cs
	namespace 	
Application
 
. 

ViewModels  
{ 
public 

class 
UsuarioViewModel !
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
Nome 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Perfil 
{ 
get "
;" #
set$ '
;' (
}) *
}		 
}

 