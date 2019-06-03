/* tslint:disable */
import {
  Reserva,
} from '.';

export interface Usuario {
  apelllido?: string;
  email?: string;
  estado?: string;
  id?: number;
  nombre?: string;
  password?: string;
  reservaCreation?: Reserva[];
  reservaUsuario?: Reserva[];
  role?: string;
  telefono?: string;
  username?: string;
}
