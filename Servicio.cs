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
        float valorIVA;

        public Servicio()
        {
        }

        public Servicio(TipoServicioEnum tipoServico, string nombreServicio, float precioFinal, float valorIVA)
        {
            this.TipoServico = tipoServico;
            this.NombreServicio = nombreServicio;
            this.PrecioFinal = precioFinal;
            this.ValorIVA = valorIVA;
        }

        public string NombreServicio { get => nombreServicio; set => nombreServicio = value; }
        public float PrecioFinal { get => precioFinal; set => precioFinal = value; }
        public float ValorIVA { get => valorIVA; set => valorIVA = value; }
        internal TipoServicioEnum TipoServico { get => tipoServico; set => tipoServico = value; }


        public float calcularPrecio(float precioFinal, float valorIVA)
        {
            return precioFinal * valorIVA;
        }


    }
}
