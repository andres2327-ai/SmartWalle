using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;


namespace Prueba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Usuario usuario = new Usuario
            //{
            //    Telefono = "1234567890",
            //    Nombre = "Juan Perez",
            //    FechaRegistro = DateTime.Now,
            //    Username = "juanperez",
            //    Password = "password123",
            //    Presupuesto = 1000.00m
            //};

            Usuario usuario2 = new Usuario
            {
                Telefono = "1234567890",
                Nombre = "pepi",
                FechaRegistro = DateTime.Now,
                Username = "pepipro",
                Password = "123",
                Presupuesto = 1000.00m
            };
            UsuarioService usuarioService = new UsuarioService();

            //usuarioService.Registrar(usuario);
            usuarioService.Registrar(usuario2);
            //Transacciones transaccion = new Transacciones
            //{
            //    Monto = 100.00m,
            //    Fecha = DateTime.Now,
            //    Tipo = "ingreso",
            //    Categoria = "ocio",
            //    Descripcion = "Compra de prueba"
                
            //};

            TransaccionService transaccionesRepository = new TransaccionService();
            Transacciones transaccion2 = new Transacciones
            {
                Monto = 200.00m,
                Fecha = DateTime.Now,
                Tipo = "transferencia",
                Categoria = "alimentación",
                Descripcion = "Compra de prueba"

            };

            transaccionesRepository.RegistrarTransaccion(transaccion2, usuario2.Username);

            //transaccionesRepository.RegistrarTransaccion(transaccion, usuario.Username);

            Console.WriteLine();

        }
    }
}
