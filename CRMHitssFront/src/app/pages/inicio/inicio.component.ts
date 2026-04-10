import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-inicio',
  standalone: true,
  imports: [],
  templateUrl: './inicio.component.html',
  styleUrl: './inicio.component.css'
})
export class InicioComponent {

  constructor(private router: Router) {
    
  }

  registrarCliente(): void {
    this.router.navigateByUrl('registro');
  }

  listarClientes(): void {
    this.router.navigateByUrl('listado');
  }
}
