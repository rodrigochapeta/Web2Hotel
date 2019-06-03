/* tslint:disable */
import {
  Reserva,
} from '.';

export interface Habitacion {
  capacidad?: number;
  id?: number;
  numero?: number;
  reserva?: Reserva[];
}
