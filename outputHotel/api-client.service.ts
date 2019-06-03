/* tslint:disable */

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Inject, Injectable, InjectionToken, Optional } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { DefaultHttpOptions, HttpOptions, APIClientInterface } from './';

import * as models from './models';

export const USE_DOMAIN = new InjectionToken<string>('APIClient_USE_DOMAIN');
export const USE_HTTP_OPTIONS = new InjectionToken<HttpOptions>('APIClient_USE_HTTP_OPTIONS');

type APIHttpOptions = HttpOptions & {
  headers: HttpHeaders;
  params: HttpParams;
};

/**
 * Created with https://github.com/flowup/api-client-generator
 */
@Injectable()
export class APIClient implements APIClientInterface {

  readonly options: APIHttpOptions;

  readonly domain: string = `//${window.location.hostname}${window.location.port ? ':'+window.location.port : ''}`;

  constructor(private readonly http: HttpClient,
              @Optional() @Inject(USE_DOMAIN) domain?: string,
              @Optional() @Inject(USE_HTTP_OPTIONS) options?: DefaultHttpOptions) {

    if (domain != null) {
      this.domain = domain;
    }

    this.options = {
      headers: new HttpHeaders(options && options.headers ? options.headers : {}),
      params: new HttpParams(options && options.params ? options.params : {}),
      ...(options && options.reportProgress ? { reportProgress: options.reportProgress } : {}),
      ...(options && options.withCredentials ? { withCredentials: options.withCredentials } : {})
    };
  }

  login(
    args: {
      loginDto?: models.LoginDto,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<any> {
    const path = `/api/Auth/Login`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<any>('POST', path, options, JSON.stringify(args.loginDto));
  }

  getContacto(
    requestHttpOptions?: HttpOptions
  ): Observable<models.Contacto[]> {
    const path = `/api/Contacto`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Contacto[]>('GET', path, options);
  }

  postContacto(
    args: {
      contacto?: models.Contacto,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Contacto> {
    const path = `/api/Contacto`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Contacto>('POST', path, options, JSON.stringify(args.contacto));
  }

  putContacto(
    args: {
      id: number,
      contacto?: models.Contacto,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<any> {
    const path = `/api/Contacto/${args.id}`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<any>('PUT', path, options, JSON.stringify(args.contacto));
  }

  getHabitacionesLibres(
    args: {
      fechaInicio?: string,
      fechaFin?: string,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Habitacion[]> {
    const path = `/api/Habitacion/GetHabitacionesLibres`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    if ('fechaInicio' in args) {
      options.params = options.params.set('fechaInicio', String(args.fechaInicio));
    }
    if ('fechaFin' in args) {
      options.params = options.params.set('fechaFin', String(args.fechaFin));
    }
    return this.sendRequest<models.Habitacion[]>('GET', path, options);
  }

  getHabitacion(
    requestHttpOptions?: HttpOptions
  ): Observable<models.Habitacion[]> {
    const path = `/api/Habitacion/GetHabitacion`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Habitacion[]>('GET', path, options);
  }

  putHabitacion(
    args: {
      id: number,
      habitacion?: models.Habitacion,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<any> {
    const path = `/api/Habitacion/PutHabitacion/${args.id}`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<any>('PUT', path, options, JSON.stringify(args.habitacion));
  }

  postHabitacion(
    args: {
      habitacion?: models.Habitacion,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Habitacion> {
    const path = `/api/Habitacion/PostHabitacion`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Habitacion>('POST', path, options, JSON.stringify(args.habitacion));
  }

  deleteHabitacion(
    args: {
      id: number,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Habitacion> {
    const path = `/api/Habitacion/DeleteHabitacion/${args.id}`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Habitacion>('DELETE', path, options);
  }

  getReserva(
    requestHttpOptions?: HttpOptions
  ): Observable<models.Reserva[]> {
    const path = `/api/Reserva`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Reserva[]>('GET', path, options);
  }

  postReserva(
    args: {
      reserva?: models.ReservaDto,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Reserva> {
    const path = `/api/Reserva`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Reserva>('POST', path, options, JSON.stringify(args.reserva));
  }

  putReserva(
    args: {
      id: number,
      reserva?: models.Reserva,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<any> {
    const path = `/api/Reserva/${args.id}`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<any>('PUT', path, options, JSON.stringify(args.reserva));
  }

  deleteReserva(
    args: {
      id: number,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Reserva> {
    const path = `/api/Reserva/${args.id}`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Reserva>('DELETE', path, options);
  }

  getUsuario(
    requestHttpOptions?: HttpOptions
  ): Observable<models.Usuario[]> {
    const path = `/api/Usuario`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Usuario[]>('GET', path, options);
  }

  postUsuario(
    args: {
      usuario?: models.Usuario,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Usuario> {
    const path = `/api/Usuario`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Usuario>('POST', path, options, JSON.stringify(args.usuario));
  }

  putUsuario(
    args: {
      id: number,
      usuario?: models.Usuario,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<any> {
    const path = `/api/Usuario/${args.id}`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<any>('PUT', path, options, JSON.stringify(args.usuario));
  }

  deleteUsuario(
    args: {
      id: number,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Usuario> {
    const path = `/api/Usuario/${args.id}`;
    const options: APIHttpOptions = {...this.options, ...requestHttpOptions};

    return this.sendRequest<models.Usuario>('DELETE', path, options);
  }

  private sendRequest<T>(method: string, path: string, options: HttpOptions, body?: any): Observable<T> {
    switch (method) {
      case 'DELETE':
        return this.http.delete<T>(`${this.domain}${path}`, options);
      case 'GET':
        return this.http.get<T>(`${this.domain}${path}`, options);
      case 'HEAD':
        return this.http.head<T>(`${this.domain}${path}`, options);
      case 'OPTIONS':
        return this.http.options<T>(`${this.domain}${path}`, options);
      case 'PATCH':
        return this.http.patch<T>(`${this.domain}${path}`, body, options);
      case 'POST':
        return this.http.post<T>(`${this.domain}${path}`, body, options);
      case 'PUT':
        return this.http.put<T>(`${this.domain}${path}`, body, options);
      default:
        console.error(`Unsupported request: ${method}`);
        return throwError(`Unsupported request: ${method}`);
    }
  }
}
