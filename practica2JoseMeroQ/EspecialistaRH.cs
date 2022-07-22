using System;
using System.Collections.Generic;
using System.Text;

namespace practica2JoseMeroQ
{
    public class EspecialistaRH : IObserver<Aplicacion>
    {
        private IDisposable cancelacion;
        public string nombre { get; set; }

        public List<Aplicacion> aplicacions { get; set; }

        public EspecialistaRH (string nombre)
        {
            this.nombre = nombre;
            aplicacions = new ();
        }

        public virtual void Suscribir (AplicacionNotificacion proveedor)
        {
            cancelacion = proveedor.Subcribir(this);
        }

        public virtual void Unsubcripcion ()
        {
            cancelacion.Dispose();
            aplicacions.Clear();
        }

        public void OnCompleted()
        {
            Console.WriteLine($"Hola, {nombre}! no estamos aceptando ninguna aplicacion más");
        }

        public void OnError(Exception error)
        {

        }

        public void OnNext(Aplicacion value)
        {
            aplicacions.Add(value);
        }
        public void ListaAplicacion()
        {
            if(aplicacions.Any())
            {
                foreach(var app in aplicacions)
                {
                    Console.WriteLine($"Hola, { nombre}! {app.NombreAplicacion} acaba de solicitar el trabajo no. {app.IdJob}");
                }
            }else {
                Console.WriteLine($"Hola, {nombre}! Aun no hay aplicaciones");
                }
            }
        }
}
