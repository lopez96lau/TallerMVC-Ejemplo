using Ejercicio_1.Modelo;

/*
 * Cosas para revisar/ajustar:
 * ---------------------------
 *  - En vez de utilizar Strings para las fechas, usar DateTime y ordenar cronologicamente para que los movimientos se realicen
 *    de manera acorde a la fecha en los que son realizados (p. ej: las transferencias solo pueden ser para fechas futuras).
 *  - Representar los numeros de telefono como uint en vez de int.
 *  - Hacer uso de structs. Implementar properties.
 *  - Sobrecargar metodos para distintos tipos de datos en ciertos campos (p. ej: que los montos puedan ser ingresados como int).
 *  - Revisar atributos que no se inicializan en constructores, ya que luego quedan como "null".
 *  - Ver como crear clases "constantes".
 *  - Diferenciar de Persona Fisica y Juridica.
 *  - Domicilio como clase.
 *  - Revisar los sealed.
 *  - Ver ANNOTATIONS.
 */

namespace Ejercicio_1
{
    public class Programa
    {
        private static void Main(string[] args)
        {
            Banco b = new Banco();
            Cliente a, j, p;

            a = b.NewCliente("Ana", "Fisica", "San Martin 3231", 342456158, "ana@mvc.asp", 4000.0, "STARTER");
            j = b.NewCliente("Jose", "Fisica", "Rivadavia 3046", 342567878, "jose@mvc.asp", 5000.0, "ADVANCE");
            p = b.NewCliente("Maxikiosco Pedrito", "Juridica", "Bv. Galvez 2045", 342451132, "pedrito@mvc.asp", 10000.0, "BUSINESS");

            a.AddTelefono(342505483);
            a.AddEmail("ana@google.com");
            j.AddTelefono(342511456);
            j.AddEmail("jose_m@yahoo.com");
            p.AddTelefono(342486881);
            p.AddEmail("info@maxikioscopedrito.com");
            p.AddEmail("faq@maxikioscopedrito.com");

            a.NewExtraccion("23/03/2018", 1000.0);
            a.NewDeposito("11/04/2018", 3000.0);
            a.NewExtraccion("20/04/2018", 2500.0);
            a.NewExtraccion("20/04/2018", 1000.0);

            j.NewDeposito("13/01/2018", 5000.0);
            j.NewDeposito("25/02/2018", 1500.0);
            j.NewExtraccion("01/03/2018", 1350.0);
            j.NewExtraccion("10/03/2018", 1150.0);

            p.NewDeposito("03/03/2018", 500.0);
            p.NewExtraccion("05/03/2018", 1500.0);
            p.NewTransferencia("12/03/2018", 1550.0, j);
            p.NewTransferencia("17/03/2018", 4000.0, a);
            p.NewTransferencia("17/03/2018", 2500.0, a);
            p.NewTransferencia("18/03/2018", 1500.0, a);
            p.NewDeposito("20/03/2018", 15000.0);
            p.NewDeposito("23/03/2018", 2500.0);

            b.EstadoCuenta(j);

            System.Console.Read();
        }
    }
}