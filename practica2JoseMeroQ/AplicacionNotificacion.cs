using System;
using System.Collections.Generic;
using System.Text;

namespace practica2JoseMeroQ
{
    public class AplicacionNotificacion
    {
        private readonly List<IObserver<Aplicacion>> observers;

        public List<Aplicacion> aplicacions { get; set; }

        public AplicacionNotificacion()
        {
            observers = new();
            aplicacions = new();
        }

        public IDisposable Subcribir (IObserver<Aplicacion> observer)
        {
            if ( !observers.Contains(observer))
            {
                observers.Add(observer);
                foreach(var item in aplicacions)
                {
                    observer.OnNext(item);
                }
            }
            return new Unsubcripcion(observers, observer);
        }

        public void AddAplicaciones (Aplicacion app)
        {
            aplicacions.Add(app);
            foreach (var observer in observers)
            {
                observer.OnNext(app);
            }
        }

        public void CerrarAplicacion()
        {
            foreach ( var observer in observers)
            {
                observer.OnCompleted();
            }
            observers.Clear();
        }
    }
}
