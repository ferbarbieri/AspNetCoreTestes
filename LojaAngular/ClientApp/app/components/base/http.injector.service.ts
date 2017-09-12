import { Injectable, Inject } from '@angular/core';
import { InterceptorService } from 'ng2-interceptors';

@Injectable()
export class InjectorHttpService {
    constructor(
        @Inject(InterceptorService) public http: InterceptorService) {
    }
}