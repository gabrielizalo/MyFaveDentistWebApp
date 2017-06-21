# README #

This is a personal exercise using ASP.NET MVC, Entity Framework, WebAPI and Angular.

### What is this repository for? ###

* La app "Mi Dentista Favorito" es una aplicación web para llevar el control de pacientes en la clínica.
* Está hecha en ASP.Net MVC con Entity Framework.
* La app se ajusta al dispositivo que la está mostrando (Teléfono, Tablet, PC) “Web Responsive”.
* La app muestra muestra la información y usando WebAPI envia la información a la base de datos, mediante servicios web Restful.
* Utiliza JWT para la autenticación.
* La aplicación permite a los administradores de la empresa poder agregar la información en la base de datos.
* La versión inicial sólo incluye dos tablas en SQL Server:
    * Paciente: Datos básicos del paciente (Nombre, Identificación, edad, datos de contacto, fecha última visita, fecha de próxima visita)
    * Tratamientos: Fecha de Inicio, Fecha de conclusión, costo, detalle,  documentos adjuntos de cada tratamiento. 
* Un paciente puede tener 1 o varios tratamientos.
* Se incluyen las opciones básicas “CRUD” crear/borrar/actualizar/obtener, utilizando Angular 2 para ambas tablas.
* Los registros de tratamientos se incluyen desde el detalle del paciente, no en una vista separada.
* Los servicios API incluyen autenticación básica, utilizando un usuario y contraseña almacenados en el archivo de configuración.
* Todos los métodos, clases y propiedades están debidamente documentados.
* La app consta de un solo proyecto que incluye los servicios (API) y las vistas.
* Adicionalmente se incluye un proyecto con las pruebas unitarias de los servios RestFull.
* Se incluye un archivo .sql con un insert de 100mil clientes creados con https://www.mockaroo.com/ - http://www.generatedata.com/.


### Who do I talk to? ###

* Gabriel Porras
* ghporras@gmail.com
