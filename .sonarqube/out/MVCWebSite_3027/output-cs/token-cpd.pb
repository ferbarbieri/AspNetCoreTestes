‰
FD:\Dev\AspNetCoreTestes\AspNetCoreTestes\Controllers\HomeController.cs
	namespace 	
AspNetCoreTestes
 
. 
Controllers &
{ 
public 

class 
HomeController 
:  !

Controller" ,
{ 
private		 
readonly		 &
IUsuarioApplicationService		 3
_userService		4 @
;		@ A
private

 
readonly

 %
IPedidoApplicationService

 2
_pedidoService

3 A
;

A B
public 
HomeController 
( &
IUsuarioApplicationService 8
userService9 D
,D E%
IPedidoApplicationServiceF _
pedidoService` m
)m n
{ 	
_userService 
= 
userService &
;& '
_pedidoService 
= 
pedidoService *
;* +
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
Logger 
. 
Log 
( 
$str  
)  !
;! "
return 
View 
( 
) 
; 
} 	
public 
IActionResult 
About "
(" #
)# $
{ 	
Logger 
. 
Log 
( 
$str 
) 
;  
ViewData 
[ 
$str 
] 
=  !
$str" F
;F G
return   
View   
(   
)   
;   
}!! 	
public## 
IActionResult## 
Contact## $
(##$ %
)##% &
{$$ 	
Logger%% 
.%% 
Trace%% 
(%% 
$str%% "
)%%" #
;%%# $
ViewData&& 
[&& 
$str&& 
]&& 
=&&  !
$str&&" 6
;&&6 7
return(( 
View(( 
((( 
)(( 
;(( 
})) 	
public++ 
IActionResult++ 
Error++ "
(++" #
)++# $
{,, 	
Logger-- 
.-- 
Fatal-- 
(-- 
$str--  
)--  !
;--! "
return.. 
View.. 
(.. 
).. 
;.. 
}// 	
}00 
}11 ¢
HD:\Dev\AspNetCoreTestes\AspNetCoreTestes\Middleware\RequestMiddleware.cs
	namespace 	
AspNetCoreTestes
 
. 

Middleware %
{ 
public 

sealed 
class 
RequestMiddleware )
{		 
private

 
readonly

 
IUserService

 %
userService

& 1
;

1 2
public 
RequestMiddleware  
(  !
IUserService! -
userService. 9
)9 :
{ 	
this 
. 
userService 
= 
userService *
;* +
} 	
public 
async 
Task 
Invoke  
(  !
HttpContext! ,
context- 4
,4 5
Func6 :
<: ;
Task; ?
>? @
nextA E
)E F
{ 	
await 
next 
( 
) 
; 
} 	
} 
} €	
3D:\Dev\AspNetCoreTestes\AspNetCoreTestes\Program.cs
	namespace 	
AspNetCoreTestes
 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{		 	
var

 
host

 
=

 
new

 
WebHostBuilder

 )
(

) *
)

* +
. 

UseKestrel 
( 
) 
. 
UseContentRoot 
(  
	Directory  )
.) *
GetCurrentDirectory* =
(= >
)> ?
)? @
. 
UseIISIntegration "
(" #
)# $
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
. "
UseApplicationInsights '
(' (
)( )
. 
Build 
( 
) 
; 
host 
. 
Run 
( 
) 
; 
} 	
} 
} ∑N
3D:\Dev\AspNetCoreTestes\AspNetCoreTestes\Startup.cs
	namespace 	
AspNetCoreTestes
 
{ 
public 

class 
Startup 
{ 
private 
	Container 
	container #
=$ %
ContainerFactory& 6
.6 7
	Container7 @
;@ A
public 
Startup 
( 
IHostingEnvironment *
env+ .
). /
{ 	
var 
builder 
= 
new  
ConfigurationBuilder 2
(2 3
)3 4
.   
SetBasePath   
(   
env    
.    !
ContentRootPath  ! 0
)  0 1
.!! 
AddJsonFile!! 
(!! 
$str!! /
,!!/ 0
optional!!1 9
:!!9 :
false!!; @
,!!@ A
reloadOnChange!!B P
:!!P Q
true!!R V
)!!V W
."" 
AddJsonFile"" 
("" 
$""" 
appsettings."" +
{""+ ,
env"", /
.""/ 0
EnvironmentName""0 ?
}""? @
.json""@ E
"""E F
,""F G
optional""H P
:""P Q
true""R V
)""V W
.## #
AddEnvironmentVariables## (
(##( )
)##) *
;##* +
Configuration$$ 
=$$ 
builder$$ #
.$$# $
Build$$$ )
($$) *
)$$* +
;$$+ ,
}%% 	
public'' 
IConfigurationRoot'' !
Configuration''" /
{''0 1
get''2 5
;''5 6
}''7 8
public** 
void** 
ConfigureServices** %
(**% &
IServiceCollection**& 8
services**9 A
)**A B
{++ 	
services-- 
.-- 
AddMvc-- 
(-- 
)-- 
;-- #
IntegrateSimpleInjector// #
(//# $
services//$ ,
)//, -
;//- .
}00 	
private22 
void22 #
IntegrateSimpleInjector22 ,
(22, -
IServiceCollection22- ?
services22@ H
)22H I
{33 	
	container44 
.44 
Options44 
.44 "
DefaultScopedLifestyle44 4
=445 6
new447 : 
AsyncScopedLifestyle44; O
(44O P
)44P Q
;44Q R
services66 
.66 
AddSingleton66 !
<66! " 
IHttpContextAccessor66" 6
,666 7
HttpContextAccessor668 K
>66K L
(66L M
)66M N
;66N O
services88 
.88 
AddSingleton88 !
<88! " 
IControllerActivator88" 6
>886 7
(887 8
new99 -
!SimpleInjectorControllerActivator99 5
(995 6
	container996 ?
)99? @
)99@ A
;99A B
services:: 
.:: 
AddSingleton:: !
<::! "#
IViewComponentActivator::" 9
>::9 :
(::: ;
new;; 0
$SimpleInjectorViewComponentActivator;; 8
(;;8 9
	container;;9 B
);;B C
);;C D
;;;D E
services== 
.== +
EnableSimpleInjectorCrossWiring== 4
(==4 5
	container==5 >
)==> ?
;==? @
services>> 
.>> 1
%UseSimpleInjectorAspNetRequestScoping>> :
(>>: ;
	container>>; D
)>>D E
;>>E F
}?? 	
publicBB 
voidBB 
	ConfigureBB 
(BB 
IApplicationBuilderBB 1
appBB2 5
,BB5 6
IHostingEnvironmentBB7 J
envBBK N
,BBN O
ILoggerFactoryBBP ^
loggerFactoryBB_ l
)BBl m
{CC 	
InitializeContainerEE 
(EE  
appEE  #
)EE# $
;EE$ %
	containerGG 
.GG 
RegisterGG 
<GG 
RequestMiddlewareGG 0
>GG0 1
(GG1 2
)GG2 3
;GG3 4
	containerII 
.II 
VerifyII 
(II 
)II 
;II 
appKK 
.KK 
UseKK 
(KK 
(KK 
cKK 
,KK 
nextKK 
)KK 
=>KK  
	containerKK! *
.KK* +
GetInstanceKK+ 6
<KK6 7
RequestMiddlewareKK7 H
>KKH I
(KKI J
)KKJ K
.KKK L
InvokeKKL R
(KKR S
cKKS T
,KKT U
nextKKV Z
)KKZ [
)KK[ \
;KK\ ]
loggerFactoryOO 
.OO 

AddConsoleOO $
(OO$ %
ConfigurationOO% 2
.OO2 3

GetSectionOO3 =
(OO= >
$strOO> G
)OOG H
)OOH I
;OOI J
loggerFactoryPP 
.PP 
AddDebugPP "
(PP" #
)PP# $
;PP$ %
ifRR 
(RR 
envRR 
.RR 
IsDevelopmentRR !
(RR! "
)RR" #
)RR# $
{SS 
appTT 
.TT %
UseDeveloperExceptionPageTT -
(TT- .
)TT. /
;TT/ 0
appUU 
.UU 
UseBrowserLinkUU "
(UU" #
)UU# $
;UU$ %
}VV 
elseWW 
{XX 
appYY 
.YY 
UseExceptionHandlerYY '
(YY' (
$strYY( 5
)YY5 6
;YY6 7
}ZZ 
app\\ 
.\\ 
UseStaticFiles\\ 
(\\ 
)\\  
;\\  !
app^^ 
.^^ 
UseMvc^^ 
(^^ 
routes^^ 
=>^^  
{__ 
routes`` 
.`` 
MapRoute`` 
(``  
nameaa 
:aa 
$straa #
,aa# $
templatebb 
:bb 
$strbb F
)bbF G
;bbG H
}cc 
)cc 
;cc 
}dd 	
privateff 
voidff 
InitializeContainerff (
(ff( )
IApplicationBuilderff) <
appff= @
)ff@ A
{gg 	
	containerii 
.ii "
RegisterMvcControllersii ,
(ii, -
appii- 0
)ii0 1
;ii1 2
	containerjj 
.jj %
RegisterMvcViewComponentsjj /
(jj/ 0
appjj0 3
)jj3 4
;jj4 5
	containermm 
.mm 
Registermm 
<mm 
IUserServicemm +
,mm+ ,
UserServicemm- 8
>mm8 9
(mm9 :
	Lifestylemm: C
.mmC D
ScopedmmD J
)mmJ K
;mmK L
	containerpp 
.pp 
Registerpp 
<pp &
IUsuarioApplicationServicepp 9
,pp9 :%
UsuarioApplicationServicepp; T
>ppT U
(ppU V
	LifestyleppV _
.pp_ `
Scopedpp` f
)ppf g
;ppg h
	containerqq 
.qq 
Registerqq 
<qq %
IPedidoApplicationServiceqq 8
,qq8 9$
PedidoApplicationServiceqq: R
>qqR S
(qqS T
	LifestyleqqT ]
.qq] ^
Scopedqq^ d
)qqd e
;qqe f
	containertt 
.tt 
Registertt 
<tt 
IUsuarioRepositorytt 1
,tt1 2
UsuarioRepositorytt3 D
>ttD E
(ttE F
	LifestylettF O
.ttO P
ScopedttP V
)ttV W
;ttW X
	containeruu 
.uu 
Registeruu 
<uu 
IPedidoRepositoryuu 0
,uu0 1
PedidoRepositoryuu2 B
>uuB C
(uuC D
	LifestyleuuD M
.uuM N
ScopeduuN T
)uuT U
;uuU V
	containervv 
.vv 
Registervv 
<vv 
IProdutoRepositoryvv 1
,vv1 2
ProdutoRepositoryvv3 D
>vvD E
(vvE F
	LifestylevvF O
.vvO P
ScopedvvP V
)vvV W
;vvW X
Assemblyzz 
[zz 
]zz 

assemblieszz !
=zz" #
newzz$ '
[zz' (
]zz( )
{zz* +
typeof{{ 
({{ 
SharedKernel{{ $
.{{$ %
IHandle{{% ,
<{{, -
>{{- .
){{. /
.{{/ 0
GetTypeInfo{{0 ;
({{; <
){{< =
.{{= >
Assembly{{> F
,|| 
typeof|| 
(|| 
Domain|| 
.|| 
EventHandlers|| ,
.||, -%
UsuarioCriadoEventHandler||- F
)||F G
.||G H
GetTypeInfo||H S
(||S T
)||T U
.||U V
Assembly||V ^
,}} 
typeof}} 
(}} 
Application}} #
.}}# $
EventHandlers}}$ 1
.}}1 2%
EmailPedidoEnviadoHandler}}2 K
)}}K L
.}}L M
GetTypeInfo}}M X
(}}X Y
)}}Y Z
.}}Z [
Assembly}}[ c
,~~ 
typeof~~ 
(~~ 
Repositories~~ $
.~~$ %
EventHandlers~~% 2
.~~2 3#
UserCreatedEventHandler~~3 J
)~~J K
.~~K L
GetTypeInfo~~L W
(~~W X
)~~X Y
.~~Y Z
Assembly~~Z b
} 
; 
	container
ÅÅ 
.
ÅÅ  
RegisterCollection
ÅÅ (
(
ÅÅ( )
typeof
ÅÅ) /
(
ÅÅ/ 0
IHandle
ÅÅ0 7
<
ÅÅ7 8
>
ÅÅ8 9
)
ÅÅ9 :
,
ÅÅ: ;

assemblies
ÅÅ< F
)
ÅÅF G
;
ÅÅG H
	container
ÑÑ 
.
ÑÑ 
	CrossWire
ÑÑ 
<
ÑÑ  
ILoggerFactory
ÑÑ  .
>
ÑÑ. /
(
ÑÑ/ 0
app
ÑÑ0 3
)
ÑÑ3 4
;
ÑÑ4 5
}
ÖÖ 	
}
ÜÜ 
}áá ˛
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
}		 ˇ
DD:\Dev\AspNetCoreTestes\AspNetCoreTestes\UserServices\UserService.cs
	namespace 	
AspNetCoreTestes
 
. 
UserServices '
{ 
public 

class 
UserService 
: 
IUserService +
{ 
public 
Usuario 
GetCurrentUser %
(% &
)& '
{ 	
return		 
new		 
Usuario		 
(		 
$str		 )
,		) *
$str		+ <
,		< =
$str		> I
)		I J
;		J K
}

 	
} 
} 