## TRELLO
https://trello.com/b/XM5W749V/entrega-p2

---
## Historias de usuarios

https://docs.google.com/spreadsheets/d/15p3wYOSRSRUC9iok9xvCvyx8-Ff6VaGeWw-tMUHlkt4/edit?gid=2143307420#gid=2143307420


---
## Tarjetas CRC

<img width="791" height="962" alt="image" src="https://github.com/user-attachments/assets/3834e249-00cd-4484-ba8b-04637c21c2ca" />


https://miro.com/welcomeonboard/NDZjYkdBODFETkdFQ0dSTkZMWnllNzlId21PZXBQTDNkbWIxQjZ3bkgwdEhmUnNGMFNsaTIwSHI3RkJabVhMenJtd2VxVS9oamw2WGlwSTVaWGRrVFhtQWY3b254NjJjWHR4UlJMYlpMR0VlcGNrRzVhTVQ1bUtvVG5tRG56cVd0R2lncW1vRmFBVnlLcVJzTmdFdlNRPT0hdjE=?share_link_id=192511849618

---
## Diagrama UML

<img width="887" height="842" alt="image" src="https://github.com/user-attachments/assets/78b579a6-af82-46a9-bb51-ff1658eb6528" />
https://drive.google.com/file/d/15GUD0jKnMR2Fe74zgRuUmBELfKcHVC2D/view?usp=sharing


---

## Para iniciar el proyecto debe hacerlo con: 
# !initadmin
En caso de querer iniciar como Admin
# !initseller
En caso de querer iniciar como Seller
 <br>

| Historia                                   | Comandos                                                     | Ejemplo                                                                                                                                                                          |
|--------------------------------------------|--------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Crear cliente                              | !newclient                                                   | !initadmin <br> !newseller juan <br> !newclient luis, suarez, luissuares@gmail.com, 099554466, 1                                                                                 |
| Modificar cliente                          | !editclient                                                  | !initadmin <br> !newseller juan <br> !newclient luis, suarez, luissuares@gmail.com, 099554466, 1 <br> !editclient 0, Name, luis                                                  |
| Eliminar cliente                           | !deleteclient                                                | !initadmin <br> !newseller juan <br> !newclient luis, suarez, luissuares@gmail.com, 099554466, 1 <br> !deleteclient 0                                                            |
| Buscar cliente                             | !searchclient                                                | !initadmin <br> !newseller juan <br> !newclient luis, suarez, luissuares@gmail.com, 099554466, 1 <br> !searchclient Name, luis                                                   |
| Ver lista de clientes                      | !getclients                                                  | !initadmin <br> !newseller juan <br> !newclient luis, suarez, luissuares@gmail.com, 099554466, 1 <br> !newclient diego, lugano, dlugano@gmail.com, 099020202, 1 <br> !getclients | 
| Registrar llamadas                         | !newcall                                                     |                                                                                                                                                                                  |
| Registrar reuniones                        | !newmeeting                                                  |
| Registrar mensajes                         | !newmessage                                                  |
| Registrar emails                           | !newemail                                                    |
| Registrar otros datos                      | !addclientdata                                               |
| Agregar una nota                           | !addnote                                                     |
| Registrar otros datos                      | !addclientdata                                               |
| Definir etiquetas                          | !addtag tagname                                              |
| Agregar etiqueta a cliente                 | !assigntag                                                   |
| Registrar venta                            | !closeopportunity                                            |
| Registrar cotizaciones enviadas            | !newopportunity                                              |
| Ver todas las interacciones con un cliente | !getinteractions                                             |
| Clientes hace tiempo no hay interacción    | !getinactiveclients                                          |
| Alternar cliente entre Inactivo y Activo | !switchclientinactivity clientid
| Clientes esperando respuesta               | !getwaitingclients                                           |
| Crear, suspender o eliminar usuarios       | !newuser <br> !suspenduser <br> !activeuser <br> !deleteuser |
| Asignar otro vendedor a cliente            | !assignseller                                                |
| Saber total de ventas en periodo           | !getsales                                                    |
| Ver panel                                  | !getpanel                                                    |
| Mostrar comandos                           | !help                                                        |
| Mostrar Usuario                            | !who                                                         |
| Historia                                   | Comandos                                                     | Ejemplos                                                                                                                                           |
|--------------------------------------------|--------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|
| Crear cliente                              | !newclient nombre                                            |                                                                                                                                                    |
| Modificar cliente                          | !editclient                                                  |                                                                                                                                                    |
| Eliminar cliente                           | !deleteclient                                                |                                                                                                                                                    |
| Buscar cliente                             | !searchclient                                                |                                                                                                                                                    |
| Ver lista de clientes                      | !getclients                                                  |                                                                                                                                                    |
| Registrar llamadas                         | !newcall                                                     |                                                                                                                                                    |
| Registrar reuniones                        | !newmeeting                                                  |                                                                                                                                                    |
| Registrar mensajes                         | !newmessage                                                  |                                                                                                                                                    |
| Registrar emails                           | !newemail                                                    |                                                                                                                                                    |
| Registrar otros datos                      | !addnewdata ClientId, TypeOfData, Data                       | !newseller Mario<br/>!newclient Marcelo, Pereira, ejemplo@gmail.com, 099123654, 0 <br/>!getclients<br/>!addnewdata 0, gender, male<br/>!getclients |
| Definir etiquetas                          | !addtag TagName                                              | !newtag Compra televisores                                                                                                                         |
| Agregar etiqueta a cliente                 | !assigntag ClientId, TagName                                 | !newseller Mario<br/>!newclient Marcelo, Pereira, ejemplo@gmail.com, 099123654, 0<br/>!newtag Compra televisores !assigntag 0, Compra televisores  |
| Registrar venta                            | !closeopportunity product price client                       |                                                                                                                                                    |
| Registrar cotizaciones enviadas            | !newopportunity Product Price OppState ClientId              | !newseller Mario<br/>!newclient Marcelo, Pereira, ejemplo@gmail.com, 099123654, 0<br/>!newopportunity Chocolate, 149.99, Closed, 0                 |
| Ver todas las interacciones con un cliente | !getinteractions client filter(optional)                     | !newseller Mario<br/>!newclient Marcelo, Pereira, ejemplo@gmail.com, 099123654, 0<br/>!getinteractions 0,                                          |
| Clientes hace tiempo no hay interacción    | !getinactiveclients                                          |                                                                                                                                                    |
| Clientes esperando respuesta               | !getwaitingclients                                           |                                                                                                                                                    |
| Crear, suspender o eliminar usuarios       | !newuser <br> !suspenduser <br> !activeuser <br> !deleteuser |                                                                                                                                                    |
| Asignar otro vendedor a cliente            | !assignseller                                                |                                                                                                                                                    |
| Saber total de ventas en periodo           | !getsales                                                    |                                                                                                                                                    |
| Ver panel                                  | !getpanel                                                    |                                                                                                                                                    |
| Mostrar comandos                           | !help                                                        |                                                                                                                                                    |
| Mostrar Usuario                            | !who                                                         |                                                                                                                                                    |
>>>>>>> Branch-Matteo



