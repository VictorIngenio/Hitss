# Pasos para levantar la aplicación localmente

## Backend

- Descargar el código .net en equipo local
- En el archivo appsettings.json se debe cambiar la cadena de conexión para apuntar a una base de datos local, si es necesario se debe agregar nombre de usuario y contraseña
- Ejecutar proceso de migraciones para crear la base de datos
- Realizar pruebas

## Frontend

- Descargar el código de Angular en equipo local
- Se debe ejecutar dentro de la carpeta descargada el comado npm install para restaurar la carpeta node modules
- En el archivo clientes.service.ts se debe cambiar el valor que hay en la variable URL por el valor de la url de el aplicativo back cuando se está ejecutando
- Levantar el servidor de prueba de Angular con el comando ng serve -o