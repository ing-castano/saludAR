using System;
using System.Collections.Generic;
using System.Text;

namespace SaludAr
{
    internal class Servicio
    {
        TipoServicioEnum tipoServico;
        string nombreServicio;
        float precioFinal;
        float valorIVA = 21;

        public Servicio()
        {
        }

        public Servicio(TipoServicioEnum tipoServico, string nombreServicio, float precioFinal)
        {
            this.TipoServico = tipoServico;
            this.NombreServicio = nombreServicio;
            this.PrecioFinal = precioFinal;
            
        }

        public string NombreServicio { get => nombreServicio; set => nombreServicio = value; }
        public float PrecioFinal { get => precioFinal; set => precioFinal = value; }
        public float ValorIVA { get => valorIVA; set => valorIVA = value; }
        internal TipoServicioEnum TipoServico { get => tipoServico; set => tipoServico = value; }


        public virtual float calcularPrecio()
        {
            return precioFinal * valorIVA;
        }


    }
}
