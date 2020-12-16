Buen día.

Requisitos previos para testear el código:

*El código fue realizado con Visual studio 2019, las librerías las pueden visualizar en el csproj.
*Se debe cambiar la cadena de conexión por la propia en el archivo appsettings.json en "dTechConnection".
*Se debe cambiar la ubicación del guardado de archivos en el archivo appsettings.json StoragePath:Key.
*El código fue realizado Code first Lo cual indica que la base de datos se genera sola al correr el programa, o en caso que no 	aplique, se debe hacer la migración con el Package manage console dando los comandos add-migration y update-database.

Luego de hacer estas configuraciones previas el proyecto debe funcionar completamente.

Continuamos con la explicación del proyecto, el cual se conforma de la siguiente manera:

-El proyecto está programado siguiendo la programación por capas.

-Se usa la inyección de dependencias, para separar componentes.

-Se generaron 4 librerías las cuales se usaron en:
-***Ioc: Controlador de inyecciones.
-***Infraestructura: Consultas a base de datos.
-***Dominio: servicios, Lógica.
-***Común: se usa para poner aquellos elementos que todos usan.
-***Controlador: End points de acceso.

-El primer punto se encuentra en 
https://localhost:44358/api/v1/Number/FindGap
se debe hacer un POST y enviar por body {"ID":<numero>} el numero sin <>. En esta clase se debe estar previamente logueado, y como admin de lo contrario no funcionara.

Logueo: se realizó el logueo por correo, el logueo por Facebook, no se pudo realizar por ocupaciones imprevistas estos días, pero se instaló el Nuggets. Solo hay 2 tipos de usuario (admin, customer). Solo se bloqueó por log bearer token el primer punto para facilitar el testeo del resto del ejercicio.

El resto de controladores hacen parte del resto del ejercicio donde básicamente se muestra el CRUD de la base de datos planteada.

NOTA: debido a la fortaleza en el Back, y las falencias en las vistas, el proyecto debe ser probado por postman o software semejante ya que es básicamente el back de un servidor con REST.



 