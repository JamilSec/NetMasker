# NetMasker

NetMasker es una herramienta de administración de redes desarrollada en C# que permite a los usuarios modificar y gestionar las direcciones MAC de los adaptadores de red en sistemas Windows. Esta herramienta está diseñada para facilitar operaciones de spoofing de direcciones MAC de manera sencilla y eficiente.

## ¿Qué es el Spoofing de Direcciones MAC?

El spoofing de direcciones MAC implica cambiar la dirección MAC (Media Access Control) de un dispositivo de red. Esta dirección es un identificador único asignado a interfaces de red para comunicaciones en la capa de enlace de datos. El spoofing puede ser utilizado para varias finalidades, desde la prueba de seguridad y la protección de la privacidad hasta la evasión de restricciones o límites impuestos por filtros de hardware.


## Aplicaciones Potenciales

NetMasker se puede utilizar en una variedad de escenarios para mejorar la privacidad, seguridad o para fines de prueba. Algunas aplicaciones potenciales incluyen:

- **Evadir Bloqueos en Juegos**: Cambiar la dirección MAC puede ayudar a evadir bloqueos basados en la dirección MAC en juegos en línea. Esto puede ser útil si una dirección MAC ha sido injustamente bloqueada o para acceder a servidores desde diferentes cuentas.

- **Privacidad en Redes Públicas**: En redes públicas, cambiar tu dirección MAC puede ofrecer una capa adicional de privacidad, evitando que tu dispositivo sea rastreado o identificado por su dirección MAC original.

- **Pruebas de Seguridad de Red**: Los profesionales de seguridad pueden utilizar NetMasker para validar las políticas de seguridad de la red que podrían estar filtrando o actuando en base a direcciones MAC específicas.

- **Desarrollo de Software y Testing**: Desarrolladores y testers pueden usar NetMasker para verificar cómo sus aplicaciones responden a cambios en la configuración de red, como parte de pruebas de integración de sistemas.

## Características

- **Listar Adaptadores de Red**: Identifica y muestra todos los adaptadores de red disponibles en el sistema.
- **Cambio de Dirección MAC**: Permite a los usuarios establecer una dirección MAC específica o generar una nueva dirección MAC válida de forma automática.
- **Restauración de Dirección MAC**: Facilita el restablecimiento de la dirección MAC a su estado original.

## Prerrequisitos

Antes de comenzar, asegúrate de tener instalado:

- Windows 10 o superior
- .NET Framework 4.7.2 o superior

## Instalación

Clona el repositorio a tu máquina local usando:

```bash
git clone https://github.com/JamilSec/NetMasker.git
```

### Advertencia Legal

Es importante destacar que el cambio de dirección MAC para evadir bloqueos o restricciones, especialmente en plataformas de juegos en línea, puede violar términos de servicio o leyes locales. El uso de NetMasker para tales propósitos es bajo la propia responsabilidad del usuario. Siempre asegúrate de entender y respetar todas las leyes y políticas aplicables antes de usar esta herramienta en tal contexto.


### Puntos Clave:
- **Definición de Spoofing**: Añadí una breve introducción sobre qué es el spoofing de direcciones MAC para proporcionar claridad a los usuarios que no estén familiarizados con el término.
- **Relevancia y Usos**: Detallé cómo el spoofing se relaciona con las características y aplicaciones de NetMasker.

Esta adición ayuda a contextualizar mejor el propósito de la herramienta y educar a los usuarios sobre cómo y por qué podrían querer utilizarla.
