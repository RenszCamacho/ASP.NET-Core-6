# FUNDAMENTOS DE WEB API Y HTTP

## ¿Que es una API?

<br />

-- Es un **_conjunto de interfaces definidas_** las cuales permiten a un conjunto de
aplicaciones externas consumir el _software_ de aplicaciones web. _("Un web API
expone un conjunto de funciones, los cuales podrán ser consumidos por apps desktop,
mobile, web, etc.")_

-- Un API permite que dos aplicaciones completamente distintas puedan comunicarse
entre sí.

-- Otra **_importancia de los APIs_**, a nivel general, es **_permitir realizar abstracciones_**.
_("No tienes por qué saber cómo funciona por dentro)_

<br />
<hr />
<br />

## REST (Representational State Transfer)

<br />

-- Es un **_estilo de construir servicios web_** los cuales se adhieren a **_un conjunto
de principios establecidos_**. _("Entonces para que una API implemente REST,
tiene que cumplir un conjunto de condiciones")_

-- Cuando consumimos un web api es porque queremos consumir sus recursos. _(“Cuando
queremos ver una lista de TODOS”)_

-- REST no es HTTP CRUD

-- No es obligatorio utilizar REST

-- Para que una **_web API sea RESTful_** tenemos que respetar las **_seis condiciones_** de REST.

<br />
<hr />
<br />

### Condiciones API RESTful

<br />

#### **_1. Arquitectura Cliente – Servidor._**

- La arquitectura cliente servidor nos habla de la separación entre un cliente y un proveedor o
  servidor.

- Esto permite la evolución independiente de nuestro web API sin afectar a cliente existentes.

<hr />

#### **_2. Interfaz Uniforme_**

- La idea de **_la interfaz uniforme_** es tener **_una forma estandarizada de transmisión
  de información._**

- Identificación del recurso (https://myapi.com/api/todos)

- Manipulación de recursos usando representaciones

- Mensajes autodescriptivos

- Hiper media como motor del estado de la aplicación aka HATEOAS, esto quiere decir que
  **_la información que nos da el web api debe incluir links para poder seguir explorando
  los recursos_** del web api

<hr />

#### **_3.Protocolos sin estado_**

- Cada una de las peticiones realizadas al web api tienen toda la información necesaria para que la petición sea resuelta de manera satisfactoria.

<hr />

#### **_4.Cache_**

- Las respuestas del web api deben de indicar cuando se deben guardar en cache. (“El cliente puede guardar el recurso de manera local, esto disminuye el tiempo de respuesta de nuestra aplicación, no todo se debe guardar en Cache, ya que pone en riesgos de poner a trabajar al cliente con data desactualizada”)

<hr />

#### **_5.Sistema de capas_**

- El servicio del servidor debe tener una arquitectura de capas, donde su evolución sea completamente transparente para el cliente.

<hr />

#### **_6.Código en demanda (opcional)_**

- El servicio web tiene la opción de enviar código fuente el cual se va a ejecutar en el cliente. Típicamente este código es JavaScript.

<br />
<hr />
<br />

## Métodos HTTP ("Hypertext Transfer Protocol")

<br />

-- HTTP en español quiere decir **_Protocolo de transferencias de hipertextos_**

-- Queremos poder hacer manipulaciones de recursos a través de una URL

-- Los métodos HTTP, son un mecanismo del protocolo HTTP los cuales nos permiten
expresar la acción la cual queremos ejercer sobre un recurso

<br />

## HTTP CRUD (Create, Read, Update, Delete)

<br />

-- En el modelo de madurez de Richardson, este es un modelo de API nivel 2.

<br />

#### **_1.HTTP GET_**

- Este se utiliza para pedir datos del servidor.

#### **_1.HTTP HEAD_**

- Hace lo mismo que el método GET, sin embargo, no nos trae el cuerpo de la
  respuesta, sino solamente la cabecera.

#### **_1.HTTP POST_**

- Sirve para indicar que queremos enviar información al servidor,
  típicamente a través del cuerpo de la petición HTTP.

#### **_1.HTTP PUT_**

- Este se utiliza para pedir datos del servidor. ("El metodo PUT puede hacer
  lo mismo que POST")

#### **_1.HTTP PATCH_**

- Sirve para expresar que queremos borra un recurso determinado. Sin embargo requiere
  su implementacion requiere mas trabajo, ya que es muy especifico.

#### **_1.HTTP DELETE_**

- Sirve para expresar que queremos borrar un recurso determinado.

<br />
<hr />
<br />

## Anatomía de una Petición HTTP

<br />

-- Una petición HTTP es un mensaje que una computadora envía a otra utilizando el protocolo HTTP. (“El cliente hace una petición al servidor mediante el protocolo HTTP”)

-- El servidor responde con una respuesta HTTP.

<br />
<hr />
<br />

## Partes de una Petición HTTP

<br />

#### **_1. Una línea de petición._**

- En la línea de petición colocamos el método HTTP a utilizar, la URI
  de la petición y el protocolo HTTP a utilizar.

- Estructura: METODO-HTTP URI PROTOCOLO-HTTP

- Ejemplo:

        GET /api/todos HTTP/1.1

- Ejemplo:

        POST /api/test.html HTTP/1.1

#### **_2. Un conjunto de campos cabecera_**

- La cabecera de la petición es donde se encuentran las cabeceras de la petición.

- Las cabeceras son metadatos que se envían en la petición para brindar información
  sobre la petición.

- Ejemplo:

        Host: en.wikipedia.org
        Cache-Control: no-cache

#### **_3. Un cuerpo, el cual es opcional_**

- El cuerpo de la petición es donde colocamos información adicional
  que vamos a enviar al servidor

- Ejemplo

        {
            "name": "John Doe",
            "age": 26,
        }

#### **_4. Línea de petición, Cabezera, Cuerpo_**

- Ejemplo:

        POST /api/todos HTTP/ 2.0
        Host: myapi.com
        Content-Type: application/json
        Cache-Control: no-cache

        {
            "name": "John Doe",
            "age": 26,
        }

<br />
<hr />
<br />

## Anatomía de una Respuesta HTTP

<br />

-- Cuando el cliente nos envía una petición HTTP, nuestro servidor d debe de
responder con una respuesta HTTP.

<br />

#### **_1. Una línea de estatus._**

-- En la línea de estatus se nos indica el estatus de la petición, es decir,
si fue exitosa, si hubo error, o si se requiere que tomemos algún tipo de acción

#### **_2. Cabecera._**

La cabecera es un conjunto de cabeceras, igual que la cabecera de la petición.

#### **_3. Cuerpo, el cual es opcional._**

El cuerpo es data que el servidor quiere transmitir.

#### **_4. Línea de petición, Cabezera, Cuerpo_**

- Ejemplo:

        HTTP/2.0 200 OK
        Date: Thu, 03 Jan 2022 22:15:03 GMT
        Server: gws
        Accept-Ranges: bytes
        Content-Length: 68894
        Content-Type: text/html; charset=UTF-8

        <!doctype html></html>

<br />
<hr />
<br />

## Códigos de estatus HTTP

<br />

-- Cuando se le hace una petición HTTP
a un servidor web, eventualmente, recibiremos una respuesta HTTP

-- El código de estatus es un numero que indica el resultado de la operación.

<br />
<hr />
<br />

## Categorias de estatus

<br />

| Codigo | Categoria          |
| ------ | ------------------ |
| 1xx    | Informacional      |
| 2xx    | Exitoso            |
| 3xx    | Redireccion        |
| 4xx    | Error del cliente  |
| 5xx    | Error del servidor |
