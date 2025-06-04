# SmartWallet – Gestor Inteligente de Finanzas Personales

![.NET](https://img.shields.io/badge/.NET-4.7.2-blue)
![License](https://img.shields.io/badge/License-MIT-green)
![Finanzas](https://img.shields.io/badge/Proyecto-Finanzas%20Personales-blueviolet)
![OS](https://img.shields.io/badge/Compatibilidad-Windows%2010%2F11-blue)

## Tabla de Contenidos

- [Descripción](#descripción)
- [Objetivos](#objetivos)
- [Características](#características)
- [Comenzando](#comenzando)
- [Uso](#uso)
- [Arquitectura](#arquitectura)
- [Configuración](#configuración)
- [Versiones](#versiones)
- [Desarrollo](#desarrollo)
- [Roadmap](#roadmap)
- [Contribución](#contribución)

---

## 🧾 Descripción

*SmartWallet* es una aplicación de escritorio diseñada para facilitar la gestión, control y seguimiento de tus finanzas personales. Con una interfaz intuitiva y funcionalidades enfocadas en la organización financiera, permite registrar ingresos, egresos, categorías de gasto y generar reportes detallados para una toma de decisiones más informada.

El sistema busca empoderar a los usuarios para administrar su dinero de forma clara, sencilla y efectiva.

---

## 🎯 Objetivos

- Facilitar el registro y visualización de movimientos financieros personales.
- Proporcionar herramientas para el control del presupuesto mensual.
- Generar reportes dinámicos de ingresos, egresos y balances.
- Mejorar la toma de decisiones financieras a través del seguimiento visual.
- Ofrecer una experiencia de usuario ágil y profesional.

---

## ✨ Características

### 💰 Gestión Financiera

- Registro de ingresos y egresos por fecha, monto y categoría.
- Clasificación personalizada de transacciones (alimentación, transporte, salud, etc.).
- Balance automático por día, mes o categoría.

### 🔐 Seguridad

- Inicio de sesión con credenciales personales.
- Validación de datos críticos.
- Protección de registros almacenados en base de datos local.

### 🖥 Interfaz Moderna

- Interfaz desarrollada en Windows Forms.
- Estilo visual optimizado para productividad.
- Estructura clara de navegación por módulos.

---

## 🚀 Comenzando

### Requisitos Previos

- .NET Framework 4.7.2 o superior  
- Visual Studio 2019 o superior  
- SQL Server (local o en red)  
- Cuenta de GitHub (opcional, para contribución al proyecto)

### Instalación

1. Clona el repositorio desde GitHub:

bash
https://github.com/andres2327-ai/SmartWalle.git


2. Abre la solución SmartWallet.sln en Visual Studio.

3. Restaura los paquetes NuGet si es necesario:

bash
dotnet restore


4. Compila y ejecuta el proyecto:

bash
dotnet build
dotnet run


---

## 🖥 Uso

SmartWallet cuenta con una interfaz de usuario amigable que permite a cualquier persona gestionar sus finanzas de forma rápida y estructurada.

### Funcionalidades Principales

#### 🧾 Registro de Movimientos

- Ingresos: sueldo, ahorros, reembolsos, otros ingresos.
- Egresos: compras, pagos de servicios, transporte, salud, etc.
- Cada movimiento se asocia a una categoría y una fecha específica.

---

## 🏗 Arquitectura

SmartWallet está estructurado en capas lógicas que permiten una mejor organización, mantenimiento y escalabilidad del proyecto.

### Estructura por Capas

#### 1. Presentation Layer

- Interfaz gráfica con Windows Forms
- Formularios para registrar y consultar movimientos
- Eventos e interacción con el usuario

#### 2. Business Logic Layer

- Validación y procesamiento de operaciones financieras
- Cálculo automático de balances
- Gestión de flujo entre formularios

#### 3. Data Access Layer

- Conexión con SQL Server
- Inserción, lectura, actualización y eliminación de datos
- Separación lógica del acceso a la información

### 📁 Estructura del Proyecto

```text
SmartWallet/
├── Presentacion/       # Formularios Windows Forms
├── LogicaNegocio/      # Reglas, validaciones, cálculos
├── Datos/              # Acceso a la base de datos
├── Entidades/          # Clases de modelo (Ingreso, Egreso, Usuario)
├── Reportes/           # Visualización y exportación de reportes
├── Tests/              # Pruebas unitarias e integración
```

---

## ⚙ Configuración

### 🔧 Base de Datos

csharp
string connectionString = "Server=localhost;Database=SmartWalletDB;User Id=admin;Password=123456;";


### 📄 App.config

xml
```text
<connectionStrings>
  <add name="SmartWalletDB"
       connectionString="Server=localhost;Database=SmartWalletDB;User Id=admin;Password=123456;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

> ⚠ Protege tu archivo App.config y evita subir credenciales al repositorio.

---

## 📦 Versiones

### Historial de Cambios

#### v1.1.0
- Reportes gráficos
- Mejoras visuales
- Validaciones reforzadas

#### v1.0.0
- Registro de movimientos
- Balance automático
- Conexión a SQL Server

### Compatibilidad

- ✅ Windows 10 / 11  
- ✅ .NET Framework 4.7.2  
- ✅ SQL Server  
- ✅ Pruebas MSTest / NUnit

---

## 👨‍💻 Desarrollo

### Guía de Estilo

```text
csharp
public class MovimientoService { }
private string _descripcion;

/// <summary>Calcula el balance</summary>
```

### Flujo de Trabajo

1. Clonar repositorio  
2. Crear rama nueva  
3. Desarrollar  
4. Push y Pull Request

---

## 📈 Roadmap

- [x] Registro de ingresos y egresos
- [x] Cálculo de balances
- [x] Reportes gráficos
- [ ] Exportar a PDF
- [ ] Recordatorios de pagos
- [ ] Versión móvil
- [ ] Integración bancaria
- [ ] Almacenamiento en la nube
