import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ClientesService } from '../../services/clientes.service';
import { Router } from '@angular/router';
import { Cliente } from '../../models/cliente.models';

@Component({
  selector: 'app-listado',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './listado.component.html',
  styleUrl: './listado.component.css'
})
export class ListadoComponent implements OnInit {
  clientes: Cliente[] = [];

  constructor(private clientesService: ClientesService,
              private router: Router) {
    
  }

  ngOnInit(): void {
    this.traerInformacion();
  }

  traerInformacion(): void {
    this.clientesService.traerClientes()
    .subscribe(resp => {
      this.clientes = resp;
    });
  }

  regresar(): void {
    this.router.navigateByUrl('inicio');
  }
}
