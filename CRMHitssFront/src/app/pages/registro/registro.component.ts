import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClientesService } from '../../services/clientes.service';
import { Cliente } from '../../models/cliente.models';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [
    ReactiveFormsModule, CommonModule
  ],
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.css'
})
export class RegistroComponent {
  mensaje = "Campo obligatorio";
  formulario!: FormGroup;
  cliente: Cliente = new Cliente();

  constructor(private clientesService: ClientesService,
              private router: Router,
              private fb: FormBuilder) {
    this.crearFormulario();
  }

  get nombreObligatorio(): boolean{
    return this.formulario.get('Nombre')!.invalid && this.formulario.get('Nombre')!.touched;
  }

  get emailObligatorio(): boolean{
    return this.formulario.get('Email')!.invalid && this.formulario.get('Email')!.touched;
  }

  get telefonoObligatorio(): boolean{
    return this.formulario.get('Telefono')!.invalid && this.formulario.get('Telefono')!.touched;
  }

  get nombreFincaObligatorio(): boolean{
    return this.formulario.get('NombreFinca')!.invalid && this.formulario.get('NombreFinca')!.touched;
  }

  get hectareasObligatorio(): boolean{
    return this.formulario.get('Hectareas')!.invalid && this.formulario.get('Hectareas')!.touched;
  }

  crearFormulario(): void {
    this.formulario = this.fb.group({
      Nombre: ['', Validators.required],
      Email: ['', Validators.required],
      Telefono: ['', Validators.required],
      NombreFinca: ['', Validators.required],
      Hectareas: ['', Validators.required]
    });
  }

  guardar(): void {
    if (this.formulario.invalid) {
      Object.values(this.formulario.controls).forEach(control => {
        control.markAsTouched();
      });
      return;
    }

    this.cliente.id = 0;
    this.cliente.nombre = this.formulario.controls['Nombre'].value;
    this.cliente.email = this.formulario.controls['Email'].value;
    this.cliente.telefono = this.formulario.controls['Telefono'].value;
    this.cliente.nombreFinca = this.formulario.controls['NombreFinca'].value;
    this.cliente.hectareas = this.formulario.controls['Hectareas'].value;

    this.clientesService.crearCliente(this.cliente)
    .subscribe(resp => {
      if (resp.id > 0) {
        alert('Se guardó el cliente correctamente');
        this.router.navigateByUrl('inicio');
      } else {
        alert('El cliente no pudo ser guardado');
        this.router.navigateByUrl('inicio');
      }
    });
  }

  cancelar(): void {
    this.router.navigateByUrl('inicio');
  }
}
