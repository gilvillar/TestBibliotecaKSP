Trabajo Con Git para el examen con Infra
Esta es una linea mas para el ejercicio con git

Proyecto de prueba para la vacante de desarrollador

Este proyecto se realiza como parte del proceso de reclutamiento

La base de datos en Memoria cuenta con dos tablas: Books y Users. Ambas Tablas nacen con registros precargados. 3 registros para Books y 1 y registro para usuario.
El registro de la tabla de usuarios es el usuario: admin con contraseña: admingvr. Este usuario se agrego para fines de pruebas, sin embargo el sistema permite registrar un nuevo usuario.

La aplicación cuenta con una barra lateral con los botones que permiten cambiar de la vista administración de biblioteca a la vista de login.

La vista de administración de biblioteca presenta los siguientes controles:
1.- Un botón para agregar un nuevo libro.
2.- Un listado de los libros precargados en la base de datos, a su vez, cada libro presenta 4 botones. 
      Modificar un libro,
      Eliminar un libro,
      Prestar un libro ,
      Devolver un libro.
3.- Un usuario que no ha iniciado sesión solo puede ver el botón devolver un libro.
4.- Un usuario que ha iniciado sesión puede ver todos los botones

La vista de login permite a un usuario iniciar sesión en la app, solicitando un nombre de usuario y contraseña. Puede utilizar los datos del usuario que esta por default. 
  usuario: admin
  contraseña: admingvr
La vista tambien permite navegar a la vista registro, en donde puede crear un nuevo usuario.

NOTAS.
El backend esta desplegado en Azure y esta disponible en este link: https://apptestksp.azurewebsites.net/ 
La aplicacion web esta desplegada en Netlify y esta disponible en el link: https://testbiblioteca-gvr.netlify.app/

Para probar la aplicación en un ambiente local apuntando a una api tambien en local debe cambiar las url en los archivos: 
  TestBibliotecaAngular\src\app\auth\services\authServices.ts
  TestBibliotecaAngular\src\app\Books\services\books.service.ts
Actualmente, esta apuntando a la web api en azure.



