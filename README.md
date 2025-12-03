## TRELLO
https://trello.com/b/XM5W749V/entrega-p2

---
## Historias de usuarios

https://docs.google.com/spreadsheets/d/15p3wYOSRSRUC9iok9xvCvyx8-Ff6VaGeWw-tMUHlkt4/edit?gid=2143307420#gid=2143307420



---
## Diagrama UML

<img width="2470" height="3697" alt="CRM_prog2 drawio (1)" src="https://github.com/user-attachments/assets/1bbc58c2-38b2-4e7b-921f-4769c3174c07" />


https://drive.google.com/file/d/15GUD0jKnMR2Fe74zgRuUmBELfKcHVC2D/view?usp=sharing


---
## Tarjetas CRC

https://miro.com/welcomeonboard/NDZjYkdBODFETkdFQ0dSTkZMWnllNzlId21PZXBQTDNkbWIxQjZ3bkgwdEhmUnNGMFNsaTIwSHI3RkJabVhMenJtd2VxVS9oamw2WGlwSTVaWGRrVFhtQWY3b254NjJjWHR4UlJMYlpMR0VlcGNrRzVhTVQ1bUtvVG5tRG56cVd0R2lncW1vRmFBVnlLcVJzTmdFdlNRPT0hdjE=?share_link_id=192511849618

---

## Para iniciar el proyecto debe hacerlo con: 
# !initadmin
En caso de querer iniciar como Admin
# !initseller
En caso de querer iniciar como Seller
 <br>

| Historia                                   | Comandos                                                                      | Ejemplo                                                                                                                                                                                                                                         |
|--------------------------------------------|-------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Crear cliente                              | !newclient                                                                    | !initadmin <br> !newseller juan <br> !newclient luis, suarez, luissuares@gmail.com, 099554466, 1                                                                                                                                                |
| Modificar cliente                          | !editclient                                                                   | !initadmin <br> !newseller juan <br> !newclient luis, suarez, luissuares@gmail.com, 099554466, 1 <br> !editclient 0, Name, luis                                                                                                                 |
| Eliminar cliente                           | !deleteclient                                                                 | !initadmin <br> !newseller juan <br> !newclient luis, suarez, luissuares@gmail.com, 099554466, 1 <br> !deleteclient 0                                                                                                                           |
| Buscar cliente                             | !searchclient                                                                 | !initadmin <br> !newseller juan <br> !newclient luis, suarez, luissuares@gmail.com, 099554466, 1 <br> !searchclient Name, luis                                                                                                                  |
| Ver lista de clientes                      | !getclients                                                                   | !initadmin <br> !newseller juan <br> !newclient luis, suarez, luissuares@gmail.com, 099554466, 1 <br> !newclient diego, lugano, dlugano@gmail.com, 099020202, 1 <br> !getclients                                                                |
| Registrar llamadas                         | !newcall                                                                      | !init <br/> !newseller Pipe <br/> !newclient Juan, Perez, juan@gmail.com, 090009999, 1 <br/> !newcall 0, hola, Sent, Nueva llamada                                                                                                              |                                                                                                            
| Registrar reuniones                        | !newmeeting                                                                   | !init <br/> !newseller Pipe <br/> !newclient Juan, Perez, juan@gmail.com, 090009999, 1 <br/> !newmeeting 0, hola, Maldonado, Programmed, 02/12/2025, Nueva Reunión                                                                              |                                                                                                                                               
| Registrar mensajes                         | !newmessage                                                                   |        !init <br/> !newseller Pipe <br/> !newclient Juan, Perez, juan@gmail.com, 090009999, 1 <br/> !newmessage 0, hola, Sent, whatsapp, mensaje por whatsapp                                                                                   |                                                                                                                                           
| Registrar emails                           | !newemail                                                                     | !init <br/> !newseller Pipe <br/> !newclient Juan, Perez, juan@gmail.com, 090009999, 1 <br/> !newemail 0, hola, Sent, Te mando un email                                                                                                         |                                                                                                                                       
| Añadir nota                                | !addnote                                                                      | !init <br/> !newseller Pipe <br/> !newclient Juan, Perez, juan@gmail.com, 090009999, 1 <br/> !newmessage 0, hola, Sent, whatsapp, mensaje por whatsapp <br/> !addnote 0, 1, Agrego esta nota                                                    |
| Registrar otros datos                      | !addnewdata ClientId, TypeOfData, Data                                        | !newseller Mario<br/>!newclient Marcelo, Pereira, ejemplo@gmail.com, 099123654, 0 <br/>!getclients<br/>!addnewdata 0, gender, male<br/>!getclients                                                                                              |
| Definir etiquetas                          | !addtag TagName                                                               | !newtag Compra televisores                                                                                                                                                                                                                      |
| Agregar etiqueta a cliente                 | !assigntag ClientId, TagName                                                  | !newseller Mario<br/>!newclient Marcelo, Pereira, ejemplo@gmail.com, 099123654, 0<br/>!newtag Compra televisores !assigntag 0, Compra televisores                                                                                               |
| Registrar venta                            | !closeopportunity product price client                                        |                                                                                                                                                                                                                                                 |
| Registrar cotizaciones enviadas            | !newopportunity Product Price OppState ClientId                               | !newseller Mario<br/>!newclient Marcelo, Pereira, ejemplo@gmail.com, 099123654, 0<br/>!newopportunity Chocolate, 149.99, Closed, 0                                                                                                              |
| Ver todas las interacciones con un cliente | !getinteractions client filter(optional)                                      | !newseller Mario<br/>!newclient Marcelo, Pereira, ejemplo@gmail.com, 099123654, 0<br/>!getinteractions 0,                                                                                                                                       |
| Clientes hace tiempo no hay interacción    | !getinactiveclients                                                           | !init <br/> !newseller Pipe <br/> !newclient Juan, Perez, juan@gmail.com, 090009999, 1 <br/> !switchclientinactivity 0 <br/> !getinactiveclients                                                                                                |
| Clientes esperando respuesta               | !getwaitingclients                                                            | !init <br/> !newseller Pipe <br/> !newclient Juan, Perez, juan@gmail.com, 090009999, 1 <br/> !newmessage 0, hola, Sent, whatsapp, mensaje por whatsapp <br/> !getwaitingclients                                                                 |
| Crear, suspender o eliminar usuarios       | !newuser userName <br> !suspenduser Id <br> !activeuser Id <br> !deleteuser Id | !init <br/> !newseller Pipe <br/> !suspenduser 1 <br/> !activeuser 1 <br/> !deleteuser 1                                                                                                                                                       |
| Asignar otro vendedor a cliente            | !assignseller seller1Id, seller2Id, clientId                                  | !init <br/> !newseller Pipe <br/> !newclient Juan, Perez, juan@gmail.com, 090009999, 1 <br/> !newseller Pope <br/> !assignseller 1,2,0                                                                                                          |
| Saber total de ventas en periodo           | !getsales                                                                     |                                                                                                                                                                                                                                                 |
| Alternar si los clientes estan activos o inactivos | !switchclientinactivity                                                        |      !init <br/> !newseller Pipe <br/> !newclient Juan, Perez, juan@gmail.com, 090009999, 1 <br/> !switchclientinactivity 0                                                                                                            |
| Ver panel                                  | !getpanel                                                                     | !init <br/> !newseller Pipe <br/> !newclient Juan, Perez, juan@gmail.com, 090009999, 1 <br/> !newmessage 0, hola, Sent, whatsapp, llamada por whatsapp <br/> !newmeeting 0, discusion, maldonado, Programmed, 10/12/2026, notas <br/> !getpanel |
| Mostrar comandos                           | !help                                                                         |                                                                                                                                                                                                                                                 |
| Mostrar Usuario                            | !who                                                                          |                                                                                                                                                                                                                                                 |




