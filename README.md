# Gestión de las colas de impresión en red  
 Liczi Citlali Flores Ramírez  

---

## Descripción del funcionamiento  
Este proyecto simula un sistema de impresión en red que usa los patrones de diseño **Singleton** y **Object Pool**.  
El **Singleton** asegura que solo exista una instancia del servidor de impresión, controlando toda la red de manera centralizada.  
El **Object Pool** gestiona tres trabajos de impresión reutilizables, lo que permite que los documentos se impriman de forma ordenada, rápida y sin saturar los recursos.  
El objetivo es mostrar cómo se puede optimizar el rendimiento y el control de acceso a una impresora compartida en red.  

---

##Requisitos para correr el programa  
- Tener instalado **Visual Studio** o cualquier entorno compatible con **C# (.NET Framework o .NET Core)**.  
- Contar con el **SDK de .NET** configurado.  
- Clonar o descargar el repositorio del proyecto.  

---

## Cómo ejecutar el programa  
1. Abre el proyecto en **Visual Studio**.  
2. Ejecuta el archivo **`Program.cs`**.  
3. El sistema mostrará el estado del servidor de impresión.  
4. Escribe el nombre de un documento para enviarlo a imprimir.  
5. Si presionas **Enter sin escribir nada**, el programa se cerrará automáticamente.  

---

## Estructura principal del proyecto  
- **Program.cs:** Contiene el método principal que ejecuta el sistema y controla la interacción con el usuario.  
- **ServidorImpresion.cs:** Implementa el patrón **Singleton**, asegurando una sola instancia del servidor.  
- **PoolTrabajos.cs:** Maneja el **Object Pool**, administrando los trabajos disponibles para imprimir.  
- **TrabajoImpresion.cs:** Representa los documentos que se imprimen y pueden reutilizarse.  

---

 *Proyecto desarrollado con fines académicos para demostrar la aplicación de patrones de diseño *

