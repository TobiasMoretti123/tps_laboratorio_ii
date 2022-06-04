using System;
using Biblioteca;
using Excepciones;
namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Partida partida = new Partida("Dungeons and dragons");
            Mago mago = new Mago();
            Guerrero guerrero = new Guerrero();
            Arquero arquero = new Arquero();    
            try
            {
                mago = new Mago("Agustin","Megumin",24,11,15,13,15,9,19,Mago.EEscuelaDeMago.Ilusion);
                guerrero = new Guerrero("Fede","Gabiru",22,17,17,10,5,9,13);
                arquero = new Arquero("Sebastian", "Iados", 25, 13, 14, 12, 7, 5, 14, 20);
                partida += mago;
                partida += guerrero;
                partida += arquero; 
                Console.WriteLine(partida.ToString());
                Console.ReadKey();
                partida -= arquero;
                Console.WriteLine(partida.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
