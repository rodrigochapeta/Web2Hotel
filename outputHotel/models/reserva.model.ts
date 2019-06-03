/* tslint:disable */
import {
  Habitacion,
  Usuario,
} from '.';

export interface Reserva {
  creation?: Usuario;
  creationDate?: string;
  creationId?: number;
  estado?: string;
  fechaFin?: string;
  fechaInicio?: string;
  habitacion?: Habitacion;
  habitacionId?: number;
  id?: number;
  usuario?: Usuario;
  usuarioId?: number;
}
