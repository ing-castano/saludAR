using System;

namespace SaludAr
{
    internal class ServicioLaboratorio : Servicios
    {
        const int VALOR_DIA = 10000;
        int diasProcesamiento;
        ComplejidadEnum complejidad;

        public ServicioLaboratorio(string nombreServicio, int diasProcesamiento, ComplejidadEnum complejidad)
            : base(TipoServicioEnum.LABORATORIO, nombreServicio)
        {
            this.diasProcesamiento = diasProcesamiento;
            this.complejidad = complejidad;
        }

        public int DiasProcesamiento { get => diasProcesamiento; set => diasProcesamiento = value; }
        internal ComplejidadEnum Complejidad { get => complejidad; set => complejidad = value; }

        public override float calcularPrecio()
        {
            float precioSinIva = VALOR_DIA * diasProcesamiento;
            float iva = (base.ValorIVA / 2);
            float precioFinal = precioSinIva + (precioSinIva * iva / 100);

            if (complejidad > ComplejidadEnum.TRES)
            {
                precioFinal *= 1.25f;
            }

            return precioFinal;
        }

        public override string ToString()
        {
            return "Tipo: " + TipoServicio + "\n" + "Nombre del Servicio: " + NombreServicio +
                   "\n" + "Dias de procesamiento: " + DiasProcesamiento + "\n" + "Complejidad: " + Complejidad;
        }
    }

    internal enum ComplejidadEnum
    {
        UNO, DOS, TRES, CUATRO, CINCO
    }
}
