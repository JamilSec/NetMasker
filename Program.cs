using System;

namespace NetMasker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Obteniendo lista de adaptadores de red...");
            List<string> deviceIDs = Functions.GetDeviceIds();
            NetMasker spoofer = null;
            string selectedDeviceID = "";

            if (deviceIDs.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se encontraron dispositivos de red válidos.");
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===== Menú de Gestión de Direcciones MAC =====");
                Console.WriteLine("1. Listar y seleccionar adaptador de red");
                Console.WriteLine("2. Falsificar la dirección MAC automáticamente");
                Console.WriteLine("3. Establecer dirección MAC específica");
                Console.WriteLine("4. Restablecer la dirección MAC a la original");
                Console.WriteLine("5. Salir\n");
                Console.ResetColor();
                Console.Write("Seleccione una opción: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Adaptadores disponibles:");
                        for (int i = 0; i < deviceIDs.Count; i++)
                        {
                            string desc = Functions.GetDriverDescriptionById(deviceIDs[i]);
                            Console.WriteLine($"{i + 1}. ID: {deviceIDs[i]}, Descripción: {desc}");
                        }
                        Console.ResetColor();
                        Console.Write("\nSeleccione un adaptador por número: ");
                        int index = Convert.ToInt32(Console.ReadLine()) - 1;
                        selectedDeviceID = deviceIDs[index];
                        spoofer = new NetMasker(selectedDeviceID);
                        Console.WriteLine("Adaptador seleccionado: " + Functions.GetDriverDescriptionById(selectedDeviceID));
                        break;
                    case "2":
                        if (spoofer == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Seleccione un adaptador primero.");
                        }
                        else if (spoofer.ChangeMacAddress())
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Dirección MAC falsificada con éxito.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No se pudo falsificar la dirección MAC.");
                        }
                        break;
                    case "3":
                        if (spoofer == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Seleccione un adaptador primero.");
                        }
                        else
                        {
                            Console.Write("Ingrese la dirección MAC para configurar: ");
                            string mac = Console.ReadLine();
                            if (spoofer.ChangeMacAddress(mac))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Dirección MAC configurada en: " + mac);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No se pudo configurar la dirección MAC.");
                            }
                        }
                        break;
                    case "4":
                        if (spoofer == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Seleccione un adaptador primero.");
                        }
                        else if (spoofer.ResetMacAddress())
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Dirección MAC restablecida a la original.");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No se pudo restablecer la dirección MAC.");
                        }
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida, inténtelo de nuevo.");
                        break;
                }
                Console.ResetColor();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
