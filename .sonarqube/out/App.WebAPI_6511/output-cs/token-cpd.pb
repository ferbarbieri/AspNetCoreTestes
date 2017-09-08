á
CD:\Dev\AspNetCoreTestes\App.WebAPI\Controllers\ClienteController.cs
	namespace 	
App
 
. 
WebAPI 
. 
Controllers  
{ 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
ClienteController "
:# $

Controller% /
{ 
private &
IClienteApplicationService *
_appService+ 6
{7 8
get9 <
;< =
}> ?
public 
ClienteController  
(  !&
IClienteApplicationService! ;

appService< F
)F G
{ 	
_appService 
= 

appService $
;$ %
} 	
[ 	
HttpGet	 
] 
public 
IActionResult 
Get  
(  !
int! $
pagina% +
,+ ,
int- 0
	porPagina1 :
): ;
{ 	
return 
Ok 
( 
_appService !
.! "
ListarTodos" -
(- .
pagina. 4
,4 5
	porPagina6 ?
)? @
)@ A
;A B
} 	
[   	
HttpGet  	 
(   
$str   
)   
]   
public!! 
IActionResult!! 
Get!!  
(!!  !
int!!! $
id!!% '
)!!' (
{"" 	
return## 
Ok## 
(## 
_appService## !
.##! "
Obter##" '
(##' (
id##( *
)##* +
)##+ ,
;##, -
}$$ 	
['' 	
HttpPost''	 
]'' 
public(( 
IActionResult(( 
Post(( !
(((! "
[((" #
FromBody((# +
]((+ ,
string((, 2
nome((3 7
)((7 8
{)) 	
_appService** 
.** 
	Adicionar** !
(**! "
nome**" &
)**& '
;**' (
return++ 
Ok++ 
(++ 
)++ 
;++ 
},, 	
[// 	
HttpPut//	 
(// 
$str// 
)// 
]// 
public00 
IActionResult00 
Put00  
(00  !
int00! $
id00% '
,00' (
[00) *
FromBody00* 2
]002 3
string003 9
novoNome00: B
)00B C
{11 	
_appService22 
.22 
	Atualizar22 !
(22! "
id22" $
,22$ %
novoNome22& .
)22. /
;22/ 0
return33 
Ok33 
(33 
)33 
;33 
}44 	
[77 	

HttpDelete77	 
(77 
$str77 
)77 
]77 
public88 
IActionResult88 
Delete88 #
(88# $
int88$ '
id88( *
)88* +
{99 	
_appService:: 
.:: 
Excluir:: 
(::  
id::  "
)::" #
;::# $
return;; 
Ok;; 
(;; 
);; 
;;; 
}<< 	
}== 
}>> ∏
ED:\Dev\AspNetCoreTestes\App.WebAPI\Middleware\ApiRequestMiddleware.cs
	namespace		 	
App		
 
.		 
WebAPI		 
.		 

Middleware		 
{

 
public 

sealed 
class  
ApiRequestMiddleware ,
{ 
public 
async 
Task 
Invoke  
(  !
HttpContext! ,
context- 4
,4 5
Func6 :
<: ;
Task; ?
>? @
nextA E
)E F
{ 	
await 
next 
( 
) 
; 
} 	
} 
} €
GD:\Dev\AspNetCoreTestes\App.WebAPI\Middleware\ErrorHandlerMiddleware.cs
	namespace

 	
App


 
.

 
WebAPI

 
.

 

Middleware

 
{ 
public 

class "
ErrorHandlerMiddleware '
{ 
public 
async 
Task 
Invoke  
(  !
HttpContext! ,
context- 4
,4 5
Func6 :
<: ;
Task; ?
>? @
nextA E
)E F
{ 	
try 
{ 
await 
next 
( 
) 
; 
} 
catch 
( 
	Exception 
ex 
)  
{ 
await  
HandleExceptionAsync *
(* +
context+ 2
,2 3
ex4 6
)6 7
;7 8
} 
} 	
private!! 
static!! 
Task!!  
HandleExceptionAsync!! 0
(!!0 1
HttpContext!!1 <
context!!= D
,!!D E
	Exception!!F O
	exception!!P Y
)!!Y Z
{"" 	
HttpStatusCode## 
code## 
;##  
switch%% 
(%% 
	exception%% 
)%% 
{&& 
case'' 
NotFoundException'' &
nfEx''' +
:''+ ,
code(( 
=(( 
HttpStatusCode(( )
.(() *
NotFound((* 2
;((2 3
break)) 
;)) 
case** %
FieldsValidationException** .
fvEx**/ 3
:**3 4
code++ 
=++ 
HttpStatusCode++ )
.++) *

BadRequest++* 4
;++4 5
break,, 
;,, 
default-- 
:-- 
code.. 
=.. 
HttpStatusCode.. )
...) *
InternalServerError..* =
;..= >
break// 
;// 
}00 
var22 
result22 
=22 
JsonConvert22 $
.22$ %
SerializeObject22% 4
(224 5
new225 8
{229 :
error22; @
=22A B
	exception22C L
.22L M
Message22M T
}22U V
)22V W
;22W X
context33 
.33 
Response33 
.33 
ContentType33 (
=33) *
$str33+ =
;33= >
context44 
.44 
Response44 
.44 

StatusCode44 '
=44( )
(44* +
int44+ .
)44. /
code44/ 3
;443 4
return55 
context55 
.55 
Response55 #
.55# $

WriteAsync55$ .
(55. /
result55/ 5
)555 6
;556 7
}66 	
}77 
}88 ÷
-D:\Dev\AspNetCoreTestes\App.WebAPI\Program.cs
	namespace 	
App
 
. 
WebAPI 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
BuildWebHost 
( 
args 
) 
. 
Run "
(" #
)# $
;$ %
} 	
public 
static 
IWebHost 
BuildWebHost +
(+ ,
string, 2
[2 3
]3 4
args5 9
)9 :
=>; =
WebHost 
.  
CreateDefaultBuilder (
(( )
args) -
)- .
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
. 
Build 
( 
) 
; 
} 
} ´V
-D:\Dev\AspNetCoreTestes\App.WebAPI\Startup.cs
	namespace   	
App  
 
.   
WebAPI   
{!! 
public"" 

class"" 
Startup"" 
{## 
private%% 
readonly%% 
	Container%% "
	container%%# ,
=%%- .
ContainerFactory%%/ ?
.%%? @
	Container%%@ I
;%%I J
public'' 
Startup'' 
('' 
IConfiguration'' %
configuration''& 3
)''3 4
{(( 	
Configuration)) 
=)) 
configuration)) )
;))) *
}** 	
public,, 
IConfiguration,, 
Configuration,, +
{,,, -
get,,. 1
;,,1 2
},,3 4
public// 
void// 
ConfigureServices// %
(//% &
IServiceCollection//& 8
services//9 A
)//A B
{00 	
services11 
.11 
AddMvc11 
(11 
)11 
;11 #
IntegrateSimpleInjector33 #
(33# $
services33$ ,
)33, -
;33- .
}44 	
private66 
void66 #
IntegrateSimpleInjector66 ,
(66, -
IServiceCollection66- ?
services66@ H
)66H I
{77 	
	container88 
.88 
Options88 
.88 "
DefaultScopedLifestyle88 4
=885 6
new887 : 
AsyncScopedLifestyle88; O
(88O P
)88P Q
;88Q R
services:: 
.:: 
AddSingleton:: !
<::! " 
IHttpContextAccessor::" 6
,::6 7
HttpContextAccessor::8 K
>::K L
(::L M
)::M N
;::N O
services<< 
.<< 
AddSingleton<< !
<<<! " 
IControllerActivator<<" 6
><<6 7
(<<7 8
new== -
!SimpleInjectorControllerActivator== 5
(==5 6
	container==6 ?
)==? @
)==@ A
;==A B
services>> 
.>> 
AddSingleton>> !
<>>! "#
IViewComponentActivator>>" 9
>>>9 :
(>>: ;
new?? 0
$SimpleInjectorViewComponentActivator?? 8
(??8 9
	container??9 B
)??B C
)??C D
;??D E
servicesAA 
.AA +
EnableSimpleInjectorCrossWiringAA 4
(AA4 5
	containerAA5 >
)AA> ?
;AA? @
servicesBB 
.BB 1
%UseSimpleInjectorAspNetRequestScopingBB :
(BB: ;
	containerBB; D
)BBD E
;BBE F
}CC 	
publicFF 
voidFF 
	ConfigureFF 
(FF 
IApplicationBuilderFF 1
appFF2 5
,FF5 6
IHostingEnvironmentFF7 J
envFFK N
)FFN O
{GG 	
InitializeContainerJJ 
(JJ  
appJJ  #
)JJ# $
;JJ$ %
	containerMM 
.MM 
RegisterMM 
<MM  
ApiRequestMiddlewareMM 3
>MM3 4
(MM4 5
)MM5 6
;MM6 7
	containerNN 
.NN 
RegisterNN 
<NN "
ErrorHandlerMiddlewareNN 5
>NN5 6
(NN6 7
)NN7 8
;NN8 9
	containerPP 
.PP 
VerifyPP 
(PP 
)PP 
;PP 
appSS 
.SS 
UseSS 
(SS 
(SS 
cSS 
,SS 
nextSS 
)SS 
=>SS  
	containerSS! *
.SS* +
GetInstanceSS+ 6
<SS6 7 
ApiRequestMiddlewareSS7 K
>SSK L
(SSL M
)SSM N
.SSN O
InvokeSSO U
(SSU V
cSSV W
,SSW X
nextSSY ]
)SS] ^
)SS^ _
;SS_ `
appTT 
.TT 
UseTT 
(TT 
(TT 
cTT 
,TT 
nextTT 
)TT 
=>TT  
	containerTT! *
.TT* +
GetInstanceTT+ 6
<TT6 7"
ErrorHandlerMiddlewareTT7 M
>TTM N
(TTN O
)TTO P
.TTP Q
InvokeTTQ W
(TTW X
cTTX Y
,TTY Z
nextTT[ _
)TT_ `
)TT` a
;TTa b
appYY 
.YY 
UseMvcYY 
(YY 
)YY 
;YY 
}uu 	
privateww 
voidww 
InitializeContainerww (
(ww( )
IApplicationBuilderww) <
appww= @
)ww@ A
{xx 	
	containerzz 
.zz "
RegisterMvcControllerszz ,
(zz, -
appzz- 0
)zz0 1
;zz1 2
	container{{ 
.{{ %
RegisterMvcViewComponents{{ /
({{/ 0
app{{0 3
){{3 4
;{{4 5
	container
ÅÅ 
.
ÅÅ 
Register
ÅÅ 
<
ÅÅ (
IUsuarioApplicationService
ÅÅ 9
,
ÅÅ9 :'
UsuarioApplicationService
ÅÅ; T
>
ÅÅT U
(
ÅÅU V
	Lifestyle
ÅÅV _
.
ÅÅ_ `
Scoped
ÅÅ` f
)
ÅÅf g
;
ÅÅg h
	container
ÇÇ 
.
ÇÇ 
Register
ÇÇ 
<
ÇÇ '
IPedidoApplicationService
ÇÇ 8
,
ÇÇ8 9&
PedidoApplicationService
ÇÇ: R
>
ÇÇR S
(
ÇÇS T
	Lifestyle
ÇÇT ]
.
ÇÇ] ^
Scoped
ÇÇ^ d
)
ÇÇd e
;
ÇÇe f
	container
ÉÉ 
.
ÉÉ 
Register
ÉÉ 
<
ÉÉ (
IClienteApplicationService
ÉÉ 9
,
ÉÉ9 :'
ClienteApplicationService
ÉÉ; T
>
ÉÉT U
(
ÉÉU V
	Lifestyle
ÉÉV _
.
ÉÉ_ `
Scoped
ÉÉ` f
)
ÉÉf g
;
ÉÉg h
	container
ÜÜ 
.
ÜÜ 
Register
ÜÜ 
<
ÜÜ  
IUsuarioRepository
ÜÜ 1
,
ÜÜ1 2
UsuarioRepository
ÜÜ3 D
>
ÜÜD E
(
ÜÜE F
	Lifestyle
ÜÜF O
.
ÜÜO P
Scoped
ÜÜP V
)
ÜÜV W
;
ÜÜW X
	container
áá 
.
áá 
Register
áá 
<
áá 
IPedidoRepository
áá 0
,
áá0 1
PedidoRepository
áá2 B
>
ááB C
(
ááC D
	Lifestyle
ááD M
.
ááM N
Scoped
ááN T
)
ááT U
;
ááU V
	container
àà 
.
àà 
Register
àà 
<
àà  
IProdutoRepository
àà 1
,
àà1 2
ProdutoRepository
àà3 D
>
ààD E
(
ààE F
	Lifestyle
ààF O
.
ààO P
Scoped
ààP V
)
ààV W
;
ààW X
	container
ââ 
.
ââ 
Register
ââ 
<
ââ  
IClienteRepository
ââ 1
,
ââ1 2
ClienteRepository
ââ3 D
>
ââD E
(
ââE F
	Lifestyle
ââF O
.
ââO P
Scoped
ââP V
)
ââV W
;
ââW X
	container
çç 
.
çç 
Register
çç 
<
çç 
AdminContext
çç +
>
çç+ ,
(
çç, -
(
çç- .
)
çç. /
=>
çç0 2
{
éé 
var
èè 
options
èè 
=
èè 
new
èè !%
DbContextOptionsBuilder
èè" 9
<
èè9 :
AdminContext
èè: F
>
èèF G
(
èèG H
)
èèH I
;
èèI J
options
êê 
.
êê 
UseSqlServer
êê $
(
êê$ %
Configuration
êê% 2
.
êê2 3!
GetConnectionString
êê3 F
(
êêF G
$str
êêG P
)
êêP Q
)
êêQ R
;
êêR S
return
ëë 
new
ëë 
AdminContext
ëë '
(
ëë' (
options
ëë( /
.
ëë/ 0
Options
ëë0 7
)
ëë7 8
;
ëë8 9
}
íí 
,
íí 
	Lifestyle
íí 
.
íí 
Scoped
íí 
)
íí  
;
íí  !
	container
îî 
.
îî 
Register
îî 
<
îî 
LojaContext
îî *
>
îî* +
(
îî+ ,
(
îî, -
)
îî- .
=>
îî/ 1
{
ïï 
var
ññ 
options
ññ 
=
ññ 
new
ññ !%
DbContextOptionsBuilder
ññ" 9
<
ññ9 :
LojaContext
ññ: E
>
ññE F
(
ññF G
)
ññG H
;
ññH I
options
óó 
.
óó 
UseSqlServer
óó $
(
óó$ %
Configuration
óó% 2
.
óó2 3!
GetConnectionString
óó3 F
(
óóF G
$str
óóG P
)
óóP Q
)
óóQ R
;
óóR S
return
òò 
new
òò 
LojaContext
òò &
(
òò& '
options
òò' .
.
òò. /
Options
òò/ 6
)
òò6 7
;
òò7 8
}
ôô 
,
ôô 
	Lifestyle
ôô 
.
ôô 
Scoped
ôô 
)
ôô  
;
ôô  !
Assembly
ùù 
[
ùù 
]
ùù 

assemblies
ùù !
=
ùù" #
new
ùù$ '
[
ùù' (
]
ùù( )
{
ùù* +
typeof
ûû 
(
ûû 
SharedKernel
ûû $
.
ûû$ %
IHandle
ûû% ,
<
ûû, -
>
ûû- .
)
ûû. /
.
ûû/ 0
GetTypeInfo
ûû0 ;
(
ûû; <
)
ûû< =
.
ûû= >
Assembly
ûû> F
,
üü 
typeof
üü 
(
üü 
Domain
üü 
.
üü 
EventHandlers
üü ,
.
üü, -'
UsuarioCriadoEventHandler
üü- F
)
üüF G
.
üüG H
GetTypeInfo
üüH S
(
üüS T
)
üüT U
.
üüU V
Assembly
üüV ^
,
†† 
typeof
†† 
(
†† 
Application
†† #
.
††# $
EventHandlers
††$ 1
.
††1 2'
EmailPedidoEnviadoHandler
††2 K
)
††K L
.
††L M
GetTypeInfo
††M X
(
††X Y
)
††Y Z
.
††Z [
Assembly
††[ c
,
°° 
typeof
°° 
(
°° 
Repositories
°° $
.
°°$ %
EventHandlers
°°% 2
.
°°2 3%
UserCreatedEventHandler
°°3 J
)
°°J K
.
°°K L
GetTypeInfo
°°L W
(
°°W X
)
°°X Y
.
°°Y Z
Assembly
°°Z b
}
¢¢ 
;
¢¢ 
	container
§§ 
.
§§  
RegisterCollection
§§ (
(
§§( )
typeof
§§) /
(
§§/ 0
IHandle
§§0 7
<
§§7 8
>
§§8 9
)
§§9 :
,
§§: ;

assemblies
§§< F
)
§§F G
;
§§G H
	container
ßß 
.
ßß 
	CrossWire
ßß 
<
ßß  
ILoggerFactory
ßß  .
>
ßß. /
(
ßß/ 0
app
ßß0 3
)
ßß3 4
;
ßß4 5
}
®® 	
}
©© 
}™™ 