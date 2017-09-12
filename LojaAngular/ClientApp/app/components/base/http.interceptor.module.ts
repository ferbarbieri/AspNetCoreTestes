import { NgModule, Injectable, Inject } from '@angular/core';
import { InterceptedResponse, InterceptorService, Interceptor, InterceptedRequest } from 'ng2-interceptors';
import { XHRBackend, RequestOptions } from '@angular/http';

//import { AuthService } from '../auth/auth.service';


export function interceptorFactory(xhrBackend: XHRBackend, requestOptions: RequestOptions, serverURLInterceptor: ServerURLInterceptor) {
    let service = new InterceptorService(xhrBackend, requestOptions);
    service.addInterceptor(serverURLInterceptor);
    return service;
}

export class ServerURLInterceptor implements Interceptor {

    constructor(
        //@Inject(AuthService) private authService: AuthService
    ) { }

    public interceptBefore(request: InterceptedRequest): InterceptedRequest {
        //debugger;
        request.options.headers.append("Accept-Language", navigator.language);
        console.log("Inside Interceptor Before");
        //request.options.headers.append("Authorization", "bearer " + this.authService.token);
        return request;
    }

    public interceptAfter(response: InterceptedResponse): InterceptedResponse {
        //debugger;
        if (response.response.status == 0) alert('Erro na API: Status 0');
        console.log("Inside Interceptor After");
        return response;
    }
}

@NgModule({
    providers: [
        ServerURLInterceptor,
        {
            provide: InterceptorService,
            useFactory: interceptorFactory,
            deps: [XHRBackend, RequestOptions, ServerURLInterceptor]
        }
    ]
})
export class HttpInterceptorModule { }

