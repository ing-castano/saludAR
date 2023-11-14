using System;
using System.Collections.Generic;
using System.Text;

namespace SaludAr
{
    abstract class Servicios
    {
        TipoServicioEnum tipoServicio;
        string nombreServicio;
        float precioFinal;
        float valorIVA = 21;

        public Servicios(TipoServicioEnum tipoServicio, string nombreServicio)
        {
            TipoServicio = tipoServicio;
            NombreServicio = nombreServicio;
            PrecioFinal = precioFinal;
            
        }

        public string NombreServicio { get => nombreServicio; set => nombreServicio = value; }
        public float PrecioFinal { get => precioFinal; set => precioFinal = value; }
        public float ValorIVA { get => valorIVA; set => valorIVA = value; }
        internal TipoServicioEnum TipoServicio { get => tipoServicio; set => tipoServicio = value; }


        public abstract float calcularPrecio();
        

    }
}
