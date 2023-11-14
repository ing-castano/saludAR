namespace SaludAr
{
    internal class ServicioVenta: Servicios
    {
        public string medicamento;
        public float precioLista;
        public float porcentajeGanancia;
        public int cantidadVendida;


        public ServicioVenta(TipoServicioEnum tipoServicio, string medicamento, float precioLista, float porcentajeGanancia, int cantidadVendida) : base (tipoServicio, medicamento)
        {
            this.medicamento = medicamento;
            this.precioLista = precioLista;
            this.porcentajeGanancia = porcentajeGanancia;
            this.cantidadVendida = cantidadVendida;
        }

        public string Medicamento { get => medicamento; set => medicamento = value; }
        public float PrecioLista { get => precioLista; set => precioLista = value; }
        public float PorcentajeGanancia { get => porcentajeGanancia; set => PorcentajeGanancia = value; }
        public int CantidadVendida {  get => cantidadVendida; set => cantidadVendida = value;}
        
        public override float  calcularPrecio()
        {
            float ganancia = (porcentajeGanancia / 100) * precioLista;
            float subTotal = ganancia + precioLista;
            float precioIva = (base.ValorIVA / 100) * subTotal;
            float totalUnitario = subTotal + precioIva;
            float precioFinal = totalUnitario * cantidadVendida;
           
            return precioFinal;
        }

        public override string ToString()
        {
            return "Tipo: " + TipoServicio + "\n" + "Nombre del Medicamento: " + Medicamento + "\n" + "Precio de Lista: " + PrecioLista + "\n" + "% Ganancia: " + PorcentajeGanancia + "\n" + "Cantidad Vendida: " + CantidadVendida;
        }
    }
}
