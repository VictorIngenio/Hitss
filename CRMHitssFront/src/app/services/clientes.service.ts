import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente.models';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  private URL = 'https://localhost:7139/api/Cliente';

  constructor(private http: HttpClient) { }

  crearCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(`${ this.URL }`, cliente);
  }

  traerClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(`${ this.URL }`);
  }
}
