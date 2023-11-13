


using System;

namespace SaludAr
{
   internal class ServicioInternacion :Servicio
    {
    const int VALOR_DIA = 20000;
    string especialidad;
    int diasInternado;
    

    public ServicioInternacion()
    { 
    }

    public ServicioInternacion(string especialidad , int diasInternado)
    {
        this.especialidad = especialidad;
        this.diasInternado = diasInternado;
    }

    public string Especialidad { get => especialidad; set => especialidad = value; }
    public int DiasInternado { get => diasInternado; set => diasInternado = value; }
   
    

    public override float calcularPrecio()
        {
        float precioSinIva = VALOR_DIA * diasInternado;
        float iva = (base.ValorIVA / 2);
        float precioFinal = precioSinIva + (precioSinIva * iva / 100);
        return precioFinal;     
        }

    }
}