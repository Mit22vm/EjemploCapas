using System;

namespace Entidad
{
    //atributos
    public class Producto
    {
        private int id;
        private string descripcion;
        private int cantidad;
        private decimal precio;

        private bool existe;

        //Constructores
        //1 vacio
        public Producto()
        {
            id = 0;
            descripcion = string.Empty;
            cantidad = 0;
            precio = 0;
            existe = false;
        }
        //2 con parametros
        public Producto(int _id, string _descripcion, int _cantidad, decimal _precio)
        {
            id = _id;
            descripcion = _descripcion;
            cantidad = _cantidad;
            precio = _precio;
            existe = true;
        }



        //propiedades
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public bool Existe { get => existe; set => existe = value; }


        //sobreescribir el ToString
        public override string ToString()
        {
            //logica, datos 
            return $"Id: {id}, Descripcion: {descripcion}, Cantidad: {cantidad}, Precio: {precio}";
        }

    }



}
