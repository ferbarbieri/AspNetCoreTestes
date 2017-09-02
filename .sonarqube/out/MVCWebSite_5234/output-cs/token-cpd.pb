è
FD:\Dev\AspNetCoreTestes\AspNetCoreTestes\Controllers\HomeController.cs
	namespace

 	
AspNetCoreTestes


 
.

 
Controllers

 &
{ 
public 

class 
HomeController 
:  !

Controller" ,
{ 
private &
IUsuarioApplicationService *
_userService+ 7
;7 8
private %
IPedidoApplicationService )
_pedidoService* 8
;8 9
public 
HomeController 
( &
IUsuarioApplicationService 8
userService9 D
,D E%
IPedidoApplicationServiceF _
pedidoService` m
)m n
{ 	
_userService 
= 
userService &
;& '
_pedidoService 
= 
pedidoService *
;* +
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
Logger 
. 
Log 
( 
$str  
)  !
;! "
var 
user 
= 
_userService #
.# $
ObterUsuario$ 0
(0 1
$num1 2
)2 3
;3 4
var 
userAdd 
= 
new 
Usuario %
(& '
$str' 1
)1 2
;2 3
_userService   
.   
AdicionarUsuario   )
(  ) *
userAdd  * 1
)  1 2
;  2 3
return"" 
View"" 
("" 
)"" 
;"" 
}## 	
public%% 
IActionResult%% 
About%% "
(%%" #
)%%# $
{&& 	
Logger'' 
.'' 
Log'' 
('' 
$str'' 
)'' 
;''  
ViewData)) 
[)) 
$str)) 
])) 
=))  !
$str))" F
;))F G
return;; 
View;; 
(;; 
);; 
;;; 
}<< 	
public>> 
IActionResult>> 
Contact>> $
(>>$ %
)>>% &
{?? 	
Logger@@ 
.@@ 
Trace@@ 
(@@ 
$str@@ "
)@@" #
;@@# $
ViewDataAA 
[AA 
$strAA 
]AA 
=AA  !
$strAA" 6
;AA6 7
returnCC 
ViewCC 
(CC 
)CC 
;CC 
}DD 	
publicFF 
IActionResultFF 
ErrorFF "
(FF" #
)FF# $
{GG 	
LoggerHH 
.HH 
FatalHH 
(HH 
$strHH  
)HH  !
;HH! "
returnII 
ViewII 
(II 
)II 
;II 
}JJ 	
}KK 
}LL ¢
HD:\Dev\AspNetCoreTestes\AspNetCoreTestes\Middleware\RequestMiddleware.cs
	namespace

 	
AspNetCoreTestes


 
.

 

Middleware

 %
{ 
public 

sealed 
class 
RequestMiddleware )
{ 
private 
readonly 
IUserService %
userService& 1
;1 2
public 
RequestMiddleware  
(  !
IUserService! -
userService. 9
)9 :
{ 	
this 
. 
userService 
= 
userService *
;* +
} 	
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
{ 	
await 
next 
( 
) 
; 
} 	
} 
} €	
3D:\Dev\AspNetCoreTestes\AspNetCoreTestes\Program.cs
	namespace 	
AspNetCoreTestes
 
{		 
public

 

class

 
Program

 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
var 
host 
= 
new 
WebHostBuilder )
() *
)* +
. 

UseKestrel 
( 
) 
. 
UseContentRoot 
(  
	Directory  )
.) *
GetCurrentDirectory* =
(= >
)> ?
)? @
. 
UseIISIntegration "
(" #
)# $
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
. "
UseApplicationInsights '
(' (
)( )
. 
Build 
( 
) 
; 
host 
. 
Run 
( 
) 
; 
} 	
} 
} √O
3D:\Dev\AspNetCoreTestes\AspNetCoreTestes\Startup.cs
	namespace 	
AspNetCoreTestes
 
{ 
public 

class 
Startup 
{   
private!! 
	Container!! 
	container!! #
=!!$ %
ContainerFactory!!& 6
.!!6 7
	Container!!7 @
;!!@ A
public## 
Startup## 
(## 
IHostingEnvironment## *
env##+ .
)##. /
{$$ 	
var%% 
builder%% 
=%% 
new%%  
ConfigurationBuilder%% 2
(%%2 3
)%%3 4
.&& 
SetBasePath&& 
(&& 
env&&  
.&&  !
ContentRootPath&&! 0
)&&0 1
.'' 
AddJsonFile'' 
('' 
$str'' /
,''/ 0
optional''1 9
:''9 :
false''; @
,''@ A
reloadOnChange''B P
:''P Q
true''R V
)''V W
.(( 
AddJsonFile(( 
((( 
$"(( 
appsettings.(( +
{((+ ,
env((, /
.((/ 0
EnvironmentName((0 ?
}((? @
.json((@ E
"((E F
,((F G
optional((H P
:((P Q
true((R V
)((V W
.)) #
AddEnvironmentVariables)) (
())( )
)))) *
;))* +
Configuration** 
=** 
builder** #
.**# $
Build**$ )
(**) *
)*** +
;**+ ,
}++ 	
public-- 
IConfigurationRoot-- !
Configuration--" /
{--0 1
get--2 5
;--5 6
}--7 8
public00 
void00 
ConfigureServices00 %
(00% &
IServiceCollection00& 8
services009 A
)00A B
{11 	
services33 
.33 
AddMvc33 
(33 
)33 
;33 #
IntegrateSimpleInjector55 #
(55# $
services55$ ,
)55, -
;55- .
}66 	
private88 
void88 #
IntegrateSimpleInjector88 ,
(88, -
IServiceCollection88- ?
services88@ H
)88H I
{99 	
	container:: 
.:: 
Options:: 
.:: "
DefaultScopedLifestyle:: 4
=::5 6
new::7 : 
AsyncScopedLifestyle::; O
(::O P
)::P Q
;::Q R
services<< 
.<< 
AddSingleton<< !
<<<! " 
IHttpContextAccessor<<" 6
,<<6 7
HttpContextAccessor<<8 K
><<K L
(<<L M
)<<M N
;<<N O
services>> 
.>> 
AddSingleton>> !
<>>! " 
IControllerActivator>>" 6
>>>6 7
(>>7 8
new?? -
!SimpleInjectorControllerActivator?? 5
(??5 6
	container??6 ?
)??? @
)??@ A
;??A B
services@@ 
.@@ 
AddSingleton@@ !
<@@! "#
IViewComponentActivator@@" 9
>@@9 :
(@@: ;
newAA 0
$SimpleInjectorViewComponentActivatorAA 8
(AA8 9
	containerAA9 B
)AAB C
)AAC D
;AAD E
servicesCC 
.CC +
EnableSimpleInjectorCrossWiringCC 4
(CC4 5
	containerCC5 >
)CC> ?
;CC? @
servicesDD 
.DD 1
%UseSimpleInjectorAspNetRequestScopingDD :
(DD: ;
	containerDD; D
)DDD E
;DDE F
}EE 	
publicHH 
voidHH 
	ConfigureHH 
(HH 
IApplicationBuilderHH 1
appHH2 5
,HH5 6
IHostingEnvironmentHH7 J
envHHK N
,HHN O
ILoggerFactoryHHP ^
loggerFactoryHH_ l
)HHl m
{II 	
InitializeContainerKK 
(KK  
appKK  #
)KK# $
;KK$ %
	containerMM 
.MM 
RegisterMM 
<MM 
RequestMiddlewareMM 0
>MM0 1
(MM1 2
)MM2 3
;MM3 4
	containerOO 
.OO 
VerifyOO 
(OO 
)OO 
;OO 
appQQ 
.QQ 
UseQQ 
(QQ 
(QQ 
cQQ 
,QQ 
nextQQ 
)QQ 
=>QQ  
	containerQQ! *
.QQ* +
GetInstanceQQ+ 6
<QQ6 7
RequestMiddlewareQQ7 H
>QQH I
(QQI J
)QQJ K
.QQK L
InvokeQQL R
(QQR S
cQQS T
,QQT U
nextQQV Z
)QQZ [
)QQ[ \
;QQ\ ]
loggerFactoryUU 
.UU 

AddConsoleUU $
(UU$ %
ConfigurationUU% 2
.UU2 3

GetSectionUU3 =
(UU= >
$strUU> G
)UUG H
)UUH I
;UUI J
loggerFactoryVV 
.VV 
AddDebugVV "
(VV" #
)VV# $
;VV$ %
ifXX 
(XX 
envXX 
.XX 
IsDevelopmentXX !
(XX! "
)XX" #
)XX# $
{YY 
appZZ 
.ZZ %
UseDeveloperExceptionPageZZ -
(ZZ- .
)ZZ. /
;ZZ/ 0
app[[ 
.[[ 
UseBrowserLink[[ "
([[" #
)[[# $
;[[$ %
}\\ 
else]] 
{^^ 
app__ 
.__ 
UseExceptionHandler__ '
(__' (
$str__( 5
)__5 6
;__6 7
}`` 
appbb 
.bb 
UseStaticFilesbb 
(bb 
)bb  
;bb  !
appdd 
.dd 
UseMvcdd 
(dd 
routesdd 
=>dd  
{ee 
routesff 
.ff 
MapRouteff 
(ff  
namegg 
:gg 
$strgg #
,gg# $
templatehh 
:hh 
$strhh F
)hhF G
;hhG H
}ii 
)ii 
;ii 
}jj 	
privatell 
voidll 
InitializeContainerll (
(ll( )
IApplicationBuilderll) <
appll= @
)ll@ A
{mm 	
	containeroo 
.oo "
RegisterMvcControllersoo ,
(oo, -
appoo- 0
)oo0 1
;oo1 2
	containerpp 
.pp %
RegisterMvcViewComponentspp /
(pp/ 0
apppp0 3
)pp3 4
;pp4 5
	containerss 
.ss 
Registerss 
<ss 
IUserServicess +
,ss+ ,
UserServicess- 8
>ss8 9
(ss9 :
	Lifestyless: C
.ssC D
ScopedssD J
)ssJ K
;ssK L
	containervv 
.vv 
Registervv 
<vv &
IUsuarioApplicationServicevv 9
,vv9 :%
UsuarioApplicationServicevv; T
>vvT U
(vvU V
	LifestylevvV _
.vv_ `
Scopedvv` f
)vvf g
;vvg h
	containerww 
.ww 
Registerww 
<ww %
IPedidoApplicationServiceww 8
,ww8 9$
PedidoApplicationServiceww: R
>wwR S
(wwS T
	LifestylewwT ]
.ww] ^
Scopedww^ d
)wwd e
;wwe f
	containerzz 
.zz 
Registerzz 
<zz 
IUsuarioRepositoryzz 1
,zz1 2
UsuarioRepositoryzz3 D
>zzD E
(zzE F
	LifestylezzF O
.zzO P
ScopedzzP V
)zzV W
;zzW X
	container{{ 
.{{ 
Register{{ 
<{{ 
IPedidoRepository{{ 0
,{{0 1
PedidoRepository{{2 B
>{{B C
({{C D
	Lifestyle{{D M
.{{M N
Scoped{{N T
){{T U
;{{U V
	container|| 
.|| 
Register|| 
<|| 
IProdutoRepository|| 1
,||1 2
ProdutoRepository||3 D
>||D E
(||E F
	Lifestyle||F O
.||O P
Scoped||P V
)||V W
;||W X
Assembly
ÄÄ 
[
ÄÄ 
]
ÄÄ 

assemblies
ÄÄ !
=
ÄÄ" #
new
ÄÄ$ '
[
ÄÄ' (
]
ÄÄ( )
{
ÄÄ* +
typeof
ÅÅ 
(
ÅÅ 
SharedKernel
ÅÅ $
.
ÅÅ$ %
IHandle
ÅÅ% ,
<
ÅÅ, -
>
ÅÅ- .
)
ÅÅ. /
.
ÅÅ/ 0
GetTypeInfo
ÅÅ0 ;
(
ÅÅ; <
)
ÅÅ< =
.
ÅÅ= >
Assembly
ÅÅ> F
,
ÇÇ 
typeof
ÇÇ 
(
ÇÇ 
Domain
ÇÇ 
.
ÇÇ 
EventHandlers
ÇÇ ,
.
ÇÇ, -'
UsuarioCriadoEventHandler
ÇÇ- F
)
ÇÇF G
.
ÇÇG H
GetTypeInfo
ÇÇH S
(
ÇÇS T
)
ÇÇT U
.
ÇÇU V
Assembly
ÇÇV ^
,
ÉÉ 
typeof
ÉÉ 
(
ÉÉ 
Application
ÉÉ #
.
ÉÉ# $
EventHandlers
ÉÉ$ 1
.
ÉÉ1 2'
EmailPedidoEnviadoHandler
ÉÉ2 K
)
ÉÉK L
.
ÉÉL M
GetTypeInfo
ÉÉM X
(
ÉÉX Y
)
ÉÉY Z
.
ÉÉZ [
Assembly
ÉÉ[ c
,
ÑÑ 
typeof
ÑÑ 
(
ÑÑ 
Repositories
ÑÑ $
.
ÑÑ$ %
EventHandlers
ÑÑ% 2
.
ÑÑ2 3%
UserCreatedEventHandler
ÑÑ3 J
)
ÑÑJ K
.
ÑÑK L
GetTypeInfo
ÑÑL W
(
ÑÑW X
)
ÑÑX Y
.
ÑÑY Z
Assembly
ÑÑZ b
}
ÖÖ 
;
ÖÖ 
	container
áá 
.
áá  
RegisterCollection
áá (
(
áá( )
typeof
áá) /
(
áá/ 0
IHandle
áá0 7
<
áá7 8
>
áá8 9
)
áá9 :
,
áá: ;

assemblies
áá< F
)
ááF G
;
ááG H
	container
ää 
.
ää 
	CrossWire
ää 
<
ää  
ILoggerFactory
ää  .
>
ää. /
(
ää/ 0
app
ää0 3
)
ää3 4
;
ää4 5
}
ãã 	
}
åå 
}çç ˛
ED:\Dev\AspNetCoreTestes\AspNetCoreTestes\UserServices\IUserService.cs
	namespace 	
AspNetCoreTestes
 
. 
UserServices '
{ 
public 

	interface 
IUserService !
{ 
Usuario 
GetCurrentUser 
( 
)  
;  !
} 
}		 Ω
DD:\Dev\AspNetCoreTestes\AspNetCoreTestes\UserServices\UserService.cs
	namespace 	
AspNetCoreTestes
 
. 
UserServices '
{ 
public		 

class		 
UserService		 
:		 
IUserService		 +
{

 
public 
Usuario 
GetCurrentUser %
(% &
)& '
{ 	
return 
new 
Usuario 
( 
$str )
)) *
;* +
} 	
} 
} 