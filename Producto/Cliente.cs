using System;
using System.Collections.Generic;
using System.Text;

namespace Entidad
{
    public class Cliente
    {

        private int id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string nombreCompleto;
        private bool existe;


        public string NombreCompleto
        {
            get =>  $"{nombre} {apellido}";   
        }
        public int Id { 
            get => id; 
            set => id = value; 
        }
        public string Nombre { 
            get => nombre; 
            set => nombre = value; 
        }
        public string Apellido { 
            get => apellido; 
            set => apellido = value; 
        }
        public string Telefono { 
            get => telefono; 
            set => telefono = value; 
        }
        public bool Existe { 
            get => existe;
            set => existe = value;
        }

        public Cliente()
        {
            id = 0;
            nombre= string.Empty;
            apellido= string.Empty;
            telefono= string.Empty;
            existe= false;
        }
    }
}
