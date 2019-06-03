/* tslint:disable */

import { Observable } from 'rxjs';
import { HttpOptions } from './';
import * as models from './models';

export interface APIClientInterface {

  login(
    args: {
      loginDto?: models.LoginDto,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<any>;

  getContacto(
    requestHttpOptions?: HttpOptions
  ): Observable<models.Contacto[]>;

  postContacto(
    args: {
      contacto?: models.Contacto,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Contacto>;

  putContacto(
    args: {
      id: number,
      contacto?: models.Contacto,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<any>;

  getHabitacionesLibres(
    args: {
      fechaInicio?: string,
      fechaFin?: string,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Habitacion[]>;

  getHabitacion(
    requestHttpOptions?: HttpOptions
  ): Observable<models.Habitacion[]>;

  putHabitacion(
    args: {
      id: number,
      habitacion?: models.Habitacion,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<any>;

  postHabitacion(
    args: {
      habitacion?: models.Habitacion,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Habitacion>;

  deleteHabitacion(
    args: {
      id: number,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Habitacion>;

  getReserva(
    requestHttpOptions?: HttpOptions
  ): Observable<models.Reserva[]>;

  postReserva(
    args: {
      reserva?: models.ReservaDto,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Reserva>;

  putReserva(
    args: {
      id: number,
      reserva?: models.Reserva,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<any>;

  deleteReserva(
    args: {
      id: number,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Reserva>;

  getUsuario(
    requestHttpOptions?: HttpOptions
  ): Observable<models.Usuario[]>;

  postUsuario(
    args: {
      usuario?: models.Usuario,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Usuario>;

  putUsuario(
    args: {
      id: number,
      usuario?: models.Usuario,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<any>;

  deleteUsuario(
    args: {
      id: number,
    },
    requestHttpOptions?: HttpOptions
  ): Observable<models.Usuario>;

}
