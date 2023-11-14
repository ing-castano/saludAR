namespace SaludAr
{
    internal class ServicioVenta: Servicio
    {
        public float precioLista;
        public float porcentajeGanancia;
        public int cantidadVendida;


        public ServicioVenta(float precioLista, float porcentajeGanancia, int cantidadVendida)
        {
            this.precioLista = precioLista;
            this.porcentajeGanancia = porcentajeGanancia;
            this.cantidadVendida = cantidadVendida;
        }

        public float PrecioLista { get => precioLista; set => precioLista = value; }
        public float PorcentajeGanancia { get => porcentajeGanancia; set => PorcentajeGanancia = value; }
        public int CantidadVendida {  get => cantidadVendida; set => cantidadVendida = value;}
        
        public override float  calcularPrecio()
        { 

            float subTotal = porcentajeGanancia + precioLista;
            float precioIva = (base.ValorIVA / 100) * subTotal ;
            float totalUnitario = subTotal + precioIva;
            float precioFinal = totalUnitario * cantidadVendida;
           
            return precioFinal;
        }

    }
}
